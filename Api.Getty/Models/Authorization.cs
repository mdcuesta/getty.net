﻿namespace Api.Getty.Models
{
    public class Authorization
    {
        public bool DownloadIsFree { get; set; }

        public string DownloadToken { get; set; }

        public string ProductOfferingInstanceId { get; set; }

        public string ProductOfferingType { get; set; }

        public string SizeKey { get; set; }

        public int DownloadsRemaining { get; set; }
    }
}
