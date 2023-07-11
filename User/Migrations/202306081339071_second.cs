namespace User.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewUsers", "Image", c => c.Binary());
            DropColumn("dbo.NewUsers", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewUsers", "File", c => c.Binary());
            DropColumn("dbo.NewUsers", "Image");
        }
    }
}
