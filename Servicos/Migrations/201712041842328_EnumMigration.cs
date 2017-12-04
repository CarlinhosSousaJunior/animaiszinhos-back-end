namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doacaos", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doacaos", "Status", c => c.String());
        }
    }
}
