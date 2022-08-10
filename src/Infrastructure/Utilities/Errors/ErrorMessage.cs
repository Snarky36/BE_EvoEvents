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
        public static readonly string NameFormatError = "Name should have between 2 and 100 alphanumeric characters";
        public static readonly string DescriptionFormatError = "Description should have maximum 2000 alphanumeric characters";
        public static readonly string EventTypeNullError = "Event type can't be null";
        public static readonly string EventTypeIdOutOfBoundsError = "Event type Id is invalid";
        public static readonly string MaxNoAttendeesSizeError = "Max number of attendees should be between 1 and 100.000";
        public static readonly string MaxNoAttendeesFormatError = "Max number of attendees should be an integer";
        public static readonly string InvalidIdValueError = "Id should be greater than 0";
        public static readonly string InvalidPageNumberError = "Page number should exist and be greater than 0";
        public static readonly string InvalidPageSizeError = "Page size should exist and be greater than 0";
        public static readonly string IdNotFoundError = "Event with that id does not exist";
        public static readonly string AddressLocationLenghtError = "Address location should have between 10 and 50 characters";
        public static readonly string AddressCityNullError = "Address city can't be null";
        public static readonly string AddressCountryNullError = "Address country can't be null";
        public static readonly string UserNotFoundError = "User with that email does not exist";
        public static readonly string PasswordAndNewPasswordError = "The new and old password should be sent togheter";
        public static readonly string UserAlreadyRegisteredError = "User is already registered to that event";
        public static readonly string SameEmailError = "Accompanying person email can't be equal to user email";
    }
}