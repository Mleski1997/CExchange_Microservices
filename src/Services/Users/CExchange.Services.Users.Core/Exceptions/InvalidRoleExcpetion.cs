namespace CExchange.Services.Users.Core.Exceptions
{
    internal class InvalidRoleExcpetion : CustomException
    {
        public string Role { get; set; }
        public InvalidRoleExcpetion(string role) : base($"Name: `{role}` is invalid")
        {
            Role = role;
        }
    }

}
