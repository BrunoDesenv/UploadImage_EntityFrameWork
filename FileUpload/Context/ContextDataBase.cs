using FileUpload.EntityConfig;
using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Context
{
    public class ContextDataBase : DbContext
    {

        public ContextDataBase() : base("name=connection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextDataBase>());
            var ensureDLLIsCopied =
                 System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        }
        public DbSet<UploadedImage> UploadedImage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                 .Where(x => x.Name == x.ReflectedType.Name + "id")
                .Configure(x => x.IsKey());

            modelBuilder.Properties<string>()
               .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
               .Configure(x => x.HasMaxLength(3000));

            modelBuilder.Configurations.Add(new UploadedImageConfiguration());
        }
    }
}
