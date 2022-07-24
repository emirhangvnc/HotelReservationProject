
namespace Business.Constants
{
    public static class Messages
    {
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar" + string.Join(",", ValidImageFileTypes);
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string HotelImageMustBeExists = "Otel Resmi Ekleyiniz";
        public static string RoomImageMustBeExists = "Oda Resmi Ekleyiniz";
    }
}