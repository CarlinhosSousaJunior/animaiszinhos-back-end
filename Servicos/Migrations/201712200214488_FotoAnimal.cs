namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fotoes", "Animal_Id", c => c.Int());
            CreateIndex("dbo.Fotoes", "Animal_Id");
            AddForeignKey("dbo.Fotoes", "Animal_Id", "dbo.Animals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fotoes", "Animal_Id", "dbo.Animals");
            DropIndex("dbo.Fotoes", new[] { "Animal_Id" });
            DropColumn("dbo.Fotoes", "Animal_Id");
        }
    }
}
