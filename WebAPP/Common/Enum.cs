using System.Runtime.Serialization;


namespace WebAPP.Common
{
    public class TrangThai
    {
        public const int HoatDong = 1;
        public const int KhongHoatDong = 2;
    }

    public class ImageCategory
    {
        public const int Slide = 5;
        public const int Tour = 6;
    }

    public class ReferenceId
    {
        public const int TourStyle = 2;
        public const int ImageCategory = 3;
        public const int Nationality = 1003;
    }

    public class SecurityRoles
    {
        public const string Admin = "Admin";
        public const string Member = "Member";
        public const string Agency1 = "Agency1";
        public const string Agency2 = "Agency2";
    }
}