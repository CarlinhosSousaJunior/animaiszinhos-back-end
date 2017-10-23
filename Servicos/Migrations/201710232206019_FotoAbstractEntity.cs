namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoAbstractEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fotoes", "Ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fotoes", "Ativo");
        }
    }
}
