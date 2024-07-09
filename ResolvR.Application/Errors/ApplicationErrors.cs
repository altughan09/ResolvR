using ResolvR.Domain.Shared;

namespace ResolvR.Application.Errors;

public static class ApplicationErrors
{
    public static class Generic
    {
        public static readonly Error DatabaseError = new(
            "Generic.DatabaseError",
            "An error occurred while saving changes to the database.");
    }
}