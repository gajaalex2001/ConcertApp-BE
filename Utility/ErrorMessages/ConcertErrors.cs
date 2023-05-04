namespace Utility.ErrorMessages
{
    public class ConcertErrors
    {
        public static readonly string Name = "Name should have between 2 and 100 alphanumeric characters, including ' ' '-' '.' ','";
        public static readonly string Description = "Description should maximum 2000 alphanumeric characters, including ' ' '-' '.' ','";
        public static readonly string Genre = "Genre is invalid";
        public static readonly string Capacity = "Capacity should be a number between 1 and 100000";
        public static readonly string Location = "Location should have between 2 and 100 alphanumeric characters, including ' ' '-' '.' ','";
        public static readonly string UserStatus = "UserStatus is invalid";
        public static readonly string StartDate = "StartDate is invalid";
        public static readonly string CurrentDate = "CurrentDate is invalid";
        public static readonly string EndDate = "EndDate is invalid";
        public static readonly string EndDateAheadOfStartDate = "EndDate should be after StartDate";
        public static readonly string ConcertId = "ConcertId is invalid";
        public static readonly string NotFound = "Concert not found";
        public static readonly string UserAlreadyParticipating = "User is already participating in this concert";
        public static readonly string UserIsOrganizing = "User is the organizer of this concert";
        public static readonly string UserNotParticipating = "User is not participating in this concert";
        public static readonly string ConcertInThePast = "Concert has already passed";
        public static readonly string PageRequestEmpty = "PageRequest should not be empty.";
        public static readonly string PageIndexEmpty = "PageIndex should not be empty.";
        public static readonly string PageIndexBelowOne = "PageIndex should be a number greater than 0.";
        public static readonly string ItemsPerPageEmpty = "ItemsPerPage should not be empty.";
        public static readonly string ItemsPerPageBelowOne = "PageIndex should be a number greater than 0.";
        public static readonly string EmailAndUserStatus = "Email and UserStatus should both be null or not null.";
        public static readonly string CapacityReached = "The concert participant capacity has been reached.";
    }
}
