namespace CExchange.Services.Users.Core.Exceptions
{
    internal class InvalidLastNameExcpetion : CustomException
    {
        public string LastName { get; set; }
        public InvalidLastNameExcpetion(string lastName) : base($"Name: `{lastName}` is invalid")
        {
            LastName = lastName;
        }
    }

}
