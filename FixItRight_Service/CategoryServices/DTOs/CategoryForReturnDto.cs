namespace FixItRight_Service.CategoryServices.DTOs
{
	public record CategoryForReturnDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; }
	}
}
