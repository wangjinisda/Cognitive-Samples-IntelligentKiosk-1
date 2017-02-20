using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentKioskSample.AddOpg.Models
{
    public class ImageModel
    {
        public string Id { get; set; }

        public string CampaignId { get; set; }

        public string CameraId { get; set; }

        public string VideoId { get; set; }

        public string ImageBase64String { get; set; }

        public DateTime SentTime { get; set; }

    }
}
