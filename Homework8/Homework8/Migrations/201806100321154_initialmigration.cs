namespace Homework8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        City = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artwork",
                c => new
                    {
                        ArtworkID = c.Int(nullable: false),
                        ArtistID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ArtworkID)
                .ForeignKey("dbo.Artist", t => t.ArtistID)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Classification",
                c => new
                    {
                        ClassificationID = c.Int(nullable: false),
                        ArtworkID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassificationID)
                .ForeignKey("dbo.Genre", t => t.GenreID)
                .ForeignKey("dbo.Artwork", t => t.ArtworkID)
                .Index(t => t.ArtworkID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false),
                        GenreName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GenreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artwork", "ArtistID", "dbo.Artist");
            DropForeignKey("dbo.Classification", "ArtworkID", "dbo.Artwork");
            DropForeignKey("dbo.Classification", "GenreID", "dbo.Genre");
            DropIndex("dbo.Classification", new[] { "GenreID" });
            DropIndex("dbo.Classification", new[] { "ArtworkID" });
            DropIndex("dbo.Artwork", new[] { "ArtistID" });
            DropTable("dbo.Genre");
            DropTable("dbo.Classification");
            DropTable("dbo.Artwork");
            DropTable("dbo.Artist");
        }
    }
}
