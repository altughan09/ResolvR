using ResolvR.Domain.Shared;

namespace ResolvR.Domain.Errors;

public static class DomainErrors
{
    public static class Brand
    {
        public static readonly Error NameNullOrEmpty = new(
            "Brand.NameNullOrEmpty",
            "Name can't be null or empty.");
        public static readonly Error InvalidLogoUrl = new(
            "Brand.InvalidLogoUrl",
            "Logo Url must be a valid URL.");
        public static readonly Error InvalidWebsiteUrl = new(
            "Brand.InvalidWebsiteUrl",
            "Website Url must be a valid URL.");
        public static readonly Error NoResultFoundForGivenId = new(
            "Brand.NoResultFoundForGivenId",
            "No brand found for the given id.");
    }

    public static class Complaint
    {
        public static readonly Error TitleNullOrEmpty = new(
            "Complaint.NameNullOrEmpty",
            "Title can't be null or empty.");
        
        public static readonly Error DescriptionNullOrEmpty = new(
            "Complaint.NameNullOrEmpty",
            "Description can't be null or empty.");
    }
}