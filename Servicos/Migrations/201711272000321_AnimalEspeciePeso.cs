namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalEspeciePeso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Especie", c => c.String());
            AddColumn("dbo.Animals", "Peso", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "Peso");
            DropColumn("dbo.Animals", "Especie");
        }
    }
}
