namespace FixItRight_Domain.Exceptions
{
	public sealed class RequestTokenBadRequest : BadRequestException
	{
		public RequestTokenBadRequest() : base("Invalid client request. The tokenDto has some invalid values.")
		{
		}

		public RequestTokenBadRequest(string? message) : base(message)
		{
		}
	}
}
