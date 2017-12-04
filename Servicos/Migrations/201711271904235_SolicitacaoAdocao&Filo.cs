namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolicitacaoAdocaoFilo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Filo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "Filo", c => c.String());
        }
    }
}
