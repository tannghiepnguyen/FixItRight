namespace FixItRight_Domain
{
	public class CustomError
	{
		public bool Success { get; set; } = false;
		public IList<string> Errors { get; set; } = new List<string>();
	}
}
