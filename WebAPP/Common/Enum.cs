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
        Admin,
        [EnumMember]
        Member,
    }
    public enum Languages
    {
        [EnumMember]
        VietNam = 1,
        [EnumMember]
        EngLish = 2,
    }
    public enum Pages
    {
        [EnumMember]
        Login = 1,
        [EnumMember]
        HomeCms = 2,
        [EnumMember]
        Layout = 3,
        [EnumMember]
        NewUser = 4,
        [EnumMember]
        ListUser = 5,
    }
}