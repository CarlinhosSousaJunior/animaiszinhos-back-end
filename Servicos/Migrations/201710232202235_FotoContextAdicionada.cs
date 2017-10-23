namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoContextAdicionada : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bytes = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fotoes");
        }
    }
}
