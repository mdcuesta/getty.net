namespace Api.Getty.Models
{
    public class SizesDownloadableImage
    {
        public int ResolutionDpi { get; set; }

        public string SizeKey { get; set; }
        
        public int PixelWidth { get; set; }
        
        public int PixelHeight { get; set; }

        public string SizeName { get; set; }

        public string MimeType { get; set; }

        public int FileSizeInBytes { get; set; }

        public double InchesHeight { get; set; }

        public double InchesWidth { get; set; }
    }
}
