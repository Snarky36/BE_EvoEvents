namespace Infrastructure.Utilities.Errors.ErrorMessages
{
    public static class EventErrorMessage
    {
        public static readonly string NameFormat = "Name should have between 2 and 100 alphanumeric characters";

        public static readonly string DescriptionFormat = "Description should have maximum 2000 alphanumeric characters";

        public static readonly string EventTypeNull = "Event type can't be null";

        public static readonly string MaxNoAttendeesFormat = "Max number of attendees should be an integer between 1 and 100.000";

        public static readonly string EventNotFound = "Event with that id does not exist";
    }
}