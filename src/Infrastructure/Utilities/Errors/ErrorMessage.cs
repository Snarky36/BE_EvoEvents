namespace Infrastructure.Utilities.Errors
{
    public static class ErrorMessage
    {
        public static readonly string EmailLengthError = "Email should have between 7 and 74 characters";
        public static readonly string FirstNameLengthError = "First name should have between 2 and 100 characters";
        public static readonly string LastNameLengthError = "Last name should have between 2 and 100 characters";
        public static readonly string PasswordLengthError = "Password should have between 2 and 100 characters";
        public static readonly string CompanyLengthError = "Company should have between 2 and 100 characters";
        public static readonly string EmailFormatError = "Email should have a valid format {alphanumeric and/or underline}@{alpha}.com";
        public static readonly string CompanyFormatError = "Company should have between 2 and 100 alphanumeric characters";
        public static readonly string FirstNameFormatError = "First Name should have between 2 and 100 alpha characters, including '-' and ' '";
        public static readonly string LastNameFormatError = "Last Name should have between 2 and 100 alpha characters, including '-' and ' '";
        public static readonly string PasswordWhiteSpaceError = "Password should not have white spaces";
        public static readonly string WrongCredentialsError = "Wrong credentials";
        public static readonly string UniqueEmailError = "Email should be unique";
    }
}
