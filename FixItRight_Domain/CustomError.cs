using Microsoft.AspNetCore.Identity;

namespace FixItRight_Domain
{
	public class CustomError
	{
		public bool Success { get; set; } = false;
		public string Message { get; set; }
		public IList<IdentityError> Errors { get; set; } = new List<IdentityError>();
	}
}
