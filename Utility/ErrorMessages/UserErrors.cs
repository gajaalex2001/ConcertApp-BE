namespace Utility.ErrorMessages
{
    public static class UserErrors
    {
        public static readonly string EmailAlreadyExists = "Email should be unique.";
        public static readonly string EmailLength = "Email should have between 10 and 100 characters.";
        public static readonly string EmailFormat = "Email should have a valid format.";
        public static readonly string PasswordLength = "Password should have between 3 and 30 characters";
        public static readonly string PasswordFormat = "White spaces are not allowed in the password";
        public static readonly string FirstName = "First Name should have between 2 and 100 alphanumeric characters, including '-' and ' '";
        public static readonly string LastName = "Last Name should have between 2 and 100 alphanumeric characters, including '-' and ' '";
        public static readonly string PhoneNumber = "Phone Number should have a valid format.";
        public static readonly string WrongCredentials = "Wrong credentials";
        public static readonly string NotFound = "User not found";
    }
}
