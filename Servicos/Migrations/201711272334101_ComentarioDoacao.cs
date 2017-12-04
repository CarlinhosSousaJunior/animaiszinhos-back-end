namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComentarioDoacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mensagem = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Doacao_Id = c.Int(),
                        Remetente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doacaos", t => t.Doacao_Id)
                .ForeignKey("dbo.Pessoas", t => t.Remetente_Id)
                .Index(t => t.Doacao_Id)
                .Index(t => t.Remetente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "Remetente_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Comentarios", "Doacao_Id", "dbo.Doacaos");
            DropIndex("dbo.Comentarios", new[] { "Remetente_Id" });
            DropIndex("dbo.Comentarios", new[] { "Doacao_Id" });
            DropTable("dbo.Comentarios");
        }
    }
}
