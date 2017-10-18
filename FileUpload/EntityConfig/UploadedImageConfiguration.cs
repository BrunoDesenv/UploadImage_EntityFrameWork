using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.EntityConfig
{
    public class UploadedImageConfiguration : EntityTypeConfiguration<UploadedImage>
    {
        public UploadedImageConfiguration()
        {
            HasKey(x => x.UploadedImageID);

            Property(x => x.File)
               .IsRequired();

            Property(x => x.ContentType)
              .IsRequired();

            Property(x => x.FileName)
              .IsRequired();
        }
    }
}
