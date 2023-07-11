namespace User.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewUsers");
        }
    }
}
