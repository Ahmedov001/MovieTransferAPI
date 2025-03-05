using MovieTransfer.Entities;

namespace MovieTransfer.Repositories.Abstract
{
	public interface IApiService
	{
		Task<Stream> GetDataAsync(string url);
		
	}
}
