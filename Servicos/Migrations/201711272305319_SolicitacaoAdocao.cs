namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolicitacaoAdocao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SolicitacaoAdocaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivo = c.String(),
                        Status = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Doacao_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doacaos", t => t.Doacao_Id)
                .ForeignKey("dbo.Pessoas", t => t.Usuario_Id)
                .Index(t => t.Doacao_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SolicitacaoAdocaos", "Usuario_Id", "dbo.Pessoas");
            DropForeignKey("dbo.SolicitacaoAdocaos", "Doacao_Id", "dbo.Doacaos");
            DropIndex("dbo.SolicitacaoAdocaos", new[] { "Usuario_Id" });
            DropIndex("dbo.SolicitacaoAdocaos", new[] { "Doacao_Id" });
            DropTable("dbo.SolicitacaoAdocaos");
        }
    }
}
