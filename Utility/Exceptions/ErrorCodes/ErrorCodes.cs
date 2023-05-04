namespace Utility.Exceptions.ErrorCodes
{
    public enum ErrorCodes
    {
        User_EmailAlreadyExists = 100,
        User_AccountNotFound = 101,
        Concert_NotFound = 200,
        Concert_AlreadyParticipating = 201,
        Concert_UserIsOrganizing = 202,
        Concert_UserNotParticipating = 203,
        Concert_PassedConcert = 204,
        Concert_CapacityReached = 205,
    }
}
