using System.Runtime.Serialization;


namespace WebAPP.Common
{
    public class TrangThai
    {
        public const int HoatDong = 1;
        public const int KhongHoatDong = 2;
    }

    public enum SecurityRoles
    {
        [EnumMember]
        Admin = 1,
        [EnumMember]
        Agency = 2,
    }
}