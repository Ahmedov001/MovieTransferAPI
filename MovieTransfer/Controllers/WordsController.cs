using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTransfer.Data;
using MovieTransfer.Entities;
using MovieTransfer.Repositories.Abstract;
using MovieTransfer.Repositories.Concrete;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieTransfer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WordsController : ControllerBase
	{

		private readonly IOperationOnArray _operationOnArray;
		private readonly IApiService _apiService;
		private readonly MovieDbContext _context;

		public WordsController(IOperationOnArray operationOnArray, IApiService apiService, MovieDbContext context)
		{
			_operationOnArray = operationOnArray;
			_apiService = apiService;
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<Movie>> Get()
		{
			var words = await _operationOnArray.GetArray();
			var word = _operationOnArray.GetWordFromArray(words);
			var url = $"https://www.omdbapi.com/?t={word}&apikey=9bb3ef42";

			var movie = await _apiService.GetDataAsync(url);
			var convertMovie = JsonSerializer.Deserialize<Movie>(movie, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			if (convertMovie == null) return NotFound();

			var movieType = new Movie
			{
				Title = convertMovie.Title,
				Plot = convertMovie.Plot,
				Year = convertMovie.Year
			};

			await _context.AddAsync(movieType);
			await _context.SaveChangesAsync();

			return Ok(movieType);

		}




	}
}
