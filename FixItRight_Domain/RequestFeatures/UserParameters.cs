using FixItRight_Domain.Constants;

namespace FixItRight_Domain.RequestFeatures
{
	public class UserParameters : RequestParameters
	{
		public Role? Role { get; set; }
		public bool Active { get; set; } = true;
		public bool IsVerified { get; set; } = false;
		public string SearchName { get; set; } = string.Empty;

	}
}
