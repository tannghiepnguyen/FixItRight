namespace FixItRight_Domain.RequestFeatures
{
	public class RepairServiceParameters : RequestParameters
	{
		public bool Active { get; set; } = true;
		public string SearchName { get; set; } = string.Empty;
		public Guid CategoryId { get; set; } = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f");
	}
}
