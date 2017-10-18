namespace FileUpload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadedImage",
                c => new
                    {
                        UploadedImageID = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 3000, unicode: false),
                        ContentType = c.String(nullable: false, maxLength: 3000, unicode: false),
                        File = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.UploadedImageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadedImage");
        }
    }
}
