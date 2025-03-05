using MovieTransfer.Repositories.Abstract;

namespace MovieTransfer.Repositories.Concrete
{
	public class ArrayOperations : IOperationOnArray
	{
		public async Task<string[]> GetArray()
		{
			var array = await File.ReadAllLinesAsync("Notes.txt");
			return array;

		}


		public string GetWordFromArray(string[] array)
		{
			Random random = new Random();
			var index = random.Next(array.Length);
			return array[index];
		}
		
	}
}
