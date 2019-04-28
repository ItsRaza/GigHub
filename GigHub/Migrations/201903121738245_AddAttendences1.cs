namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendences1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendences", "GigId", "dbo.Gigs");
            AddForeignKey("dbo.Attendences", "GigId", "dbo.Gigs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "GigId", "dbo.Gigs");
            AddForeignKey("dbo.Attendences", "GigId", "dbo.Gigs", "Id", cascadeDelete: true);
        }
    }
}
