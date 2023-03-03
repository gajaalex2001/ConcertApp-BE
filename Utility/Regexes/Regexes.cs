namespace Utility.Regexes
{
    public static class Regexes
    {
        public static readonly string Email = @"^\w+@\w+\.[Cc][Oo][Mm]$";
        public static readonly string NoWhiteSpace = @"^[^\s]+$";
        public static readonly string AlphaNumeric = @"^[a-zA-Z0-9]+$";
        public static readonly string AlphaNumericSpace = @"^[a-zA-Z\d\s]*$";
        public static readonly string AlphaNumericSpaceDash = @"^[a-zA-Z\d\-\s]*$";
        public static readonly string AlphaNumericSpaceDashDotComma = @"^[a-zA-Z\d\-\s\.\,]*$";
        public static readonly string PhoneNumber = @"^(\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\s|\.|\-)?([0-9]{3}(\s|\.|\-|)){2}$";
    }
}
