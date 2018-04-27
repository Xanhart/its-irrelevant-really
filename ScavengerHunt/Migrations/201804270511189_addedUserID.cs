namespace ScavengerHunt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "userID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "userID");
        }
    }
}
