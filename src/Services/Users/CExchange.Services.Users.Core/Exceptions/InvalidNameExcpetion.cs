namespace CExchange.Services.Users.Core.Exceptions
{
    internal class InvalidNameExcpetion : CustomException
    {
        public string Name { get; set; }
        public InvalidNameExcpetion(string name) : base($"Name: `{name}` is invalid")
        {
            Name = name;
        }
    }

    internal class InvalidPasswordExcpetion : CustomException
    {
        public InvalidPasswordExcpetion() : base("Password is invalid")
        {
        }
    }

}
