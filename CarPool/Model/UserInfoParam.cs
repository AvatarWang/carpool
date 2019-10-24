namespace Model
{
    public class UserInfoParam : BaseParam
    {
        public long UId { get; set; }
        public string UIHomeAddress { get; set; }
        public string UIWorkAddress { get; set; }
        public string UIHomeLat { get; set; }
        public string UIHomeLon { get; set; }
        public string UIWorkLat { get; set; }
        public string UIWorkLon { get; set; }
        public int UIRole { get; set; }
    }
}
