namespace WebLearn1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NumberOfDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpecialOffer = c.Boolean(nullable: false),
                        Trip_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trips", t => t.Trip_ID)
                .Index(t => t.Trip_ID);
            
            CreateTable(
                "dbo.TripPhotoes",
                c => new
                    {
                        Trip_ID = c.Int(nullable: false),
                        Photo_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trip_ID, t.Photo_ID })
                .ForeignKey("dbo.Trips", t => t.Trip_ID, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.Photo_ID, cascadeDelete: true)
                .Index(t => t.Trip_ID)
                .Index(t => t.Photo_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "Trip_ID", "dbo.Trips");
            DropForeignKey("dbo.TripPhotoes", "Photo_ID", "dbo.Photos");
            DropForeignKey("dbo.TripPhotoes", "Trip_ID", "dbo.Trips");
            DropIndex("dbo.TripPhotoes", new[] { "Photo_ID" });
            DropIndex("dbo.TripPhotoes", new[] { "Trip_ID" });
            DropIndex("dbo.Tours", new[] { "Trip_ID" });
            DropTable("dbo.TripPhotoes");
            DropTable("dbo.Tours");
            DropTable("dbo.Trips");
            DropTable("dbo.Photos");
        }
    }
}
