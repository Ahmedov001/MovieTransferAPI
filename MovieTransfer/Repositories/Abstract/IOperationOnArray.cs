namespace MovieTransfer.Repositories.Abstract
{
	public interface IOperationOnArray 
	{
		Task<string[]> GetArray();
		public string GetWordFromArray(string[] array);
		//Task<string> GetFilmName();
	}
}
