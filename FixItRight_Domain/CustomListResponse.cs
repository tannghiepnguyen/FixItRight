using FixItRight_Domain.RequestFeatures;

namespace FixItRight_Domain
{
	public class CustomListResponse<T> where T : class
	{
		public IEnumerable<T> Data { get; set; }
		public MetaData MetaData { get; set; }
	}
}
