namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoSemNome : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fotoes", "Animal_Id", "dbo.Animals");
            DropIndex("dbo.Fotoes", new[] { "Animal_Id" });
            DropTable("dbo.Fotoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bytes = c.Binary(),
                        Animal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Fotoes", "Animal_Id");
            AddForeignKey("dbo.Fotoes", "Animal_Id", "dbo.Animals", "Id");
        }
    }
}
