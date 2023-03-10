namespace TravelBooking.Common
{
    public static class GlobalConstants
    {
        public const string AntiforgeryHeaderName = "X-CSRF-TOKEN";

        public const string SystemName = "TravelBooking";

        public const string Title = "Title";

        public const string AdministratorRoleName = "Administrator";

        public const string AdministrationArea = "Administration";

        public const string FirstName = "Име";

        public const string LastName = "Фамилия";

        public const string PhoneNumber = "Телефон";

        public const string CustomerNote = "Бележка към заявката";

        public const string OriginCountry = "От";

        public const string OriginAddress = "От адрес";

        public const string OriginCity = "От град";

        public const string DestinationCountry = "До";

        public const string DestinationAddress = "До адрес";

        public const string DestinationCity = "До град";

        public const string Breed = "Порода";

        public const string Weight = "Килограми";

        public const string Height = "Височина";

        public const string Width = "Широчина";

        public const string VehicleType = "Вид на мотора";

        public const string ReturnUrlKey = "ReturnUrl";

        public const string HomeReturnUrl = "/home";

        // Errors
        public const string RequiredField = "Полето е задължително";

        public const string ModelStateErrorKey = "ModelStateErrors";

        public const string InvalidUsernameOrPasswordErrorMessage = "Грешно потребителско име или парола.";

        public const string InvalidEmailErrorMessage = "Невалиден имейл.";
    }
}
