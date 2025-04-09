namespace FixItRight_Domain.RequestFeatures
{
	public class RepairServiceParameters : RequestParameters
	{
		public bool Active { get; set; } = true;
		public string SearchName { get; set; } = string.Empty;
		public Guid CategoryId { get; set; } = Guid.Empty;
	}
}
