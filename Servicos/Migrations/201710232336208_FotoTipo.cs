namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoTipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fotoes", "Tipo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fotoes", "Tipo");
        }
    }
}
