using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Models
{
    public class UploadedImage
    {
        public int UploadedImageID { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
    }
}
