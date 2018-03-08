namespace CST356_Week_5_Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pets", new[] { "User_Id" });
            DropColumn("dbo.Pets", "UserId");
            RenameColumn(table: "dbo.Pets", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Pets", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Pets", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pets", new[] { "UserId" });
            AlterColumn("dbo.Pets", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Pets", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Pets", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "User_Id");
        }
    }
}
