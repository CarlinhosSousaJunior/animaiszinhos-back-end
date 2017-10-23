namespace Servicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Adicionals", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Atracaos", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Atracaos", "Cidade_Id", "dbo.Cidades");
            DropForeignKey("dbo.Atracaos", "Pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Adicionals", "Consumo_Id", "dbo.Consumoes");
            DropForeignKey("dbo.Consumoes", "Comanda_Id", "dbo.Comandas");
            DropForeignKey("dbo.Consumoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Comandas", "Mesa_Id", "dbo.Mesas");
            DropForeignKey("dbo.ComandaTransferencias", "Destino_Id", "dbo.Comandas");
            DropForeignKey("dbo.ComandaTransferencias", "Origem_Id", "dbo.Comandas");
            DropIndex("dbo.Adicionals", new[] { "Produto_Id" });
            DropIndex("dbo.Adicionals", new[] { "Consumo_Id" });
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            DropIndex("dbo.Atracaos", new[] { "Categoria_Id" });
            DropIndex("dbo.Atracaos", new[] { "Cidade_Id" });
            DropIndex("dbo.Atracaos", new[] { "Pessoa_Id" });
            DropIndex("dbo.Comandas", new[] { "Mesa_Id" });
            DropIndex("dbo.Consumoes", new[] { "Comanda_Id" });
            DropIndex("dbo.Consumoes", new[] { "Produto_Id" });
            DropIndex("dbo.ComandaTransferencias", new[] { "Destino_Id" });
            DropIndex("dbo.ComandaTransferencias", new[] { "Origem_Id" });
            DropColumn("dbo.Categorias", "DataCadastro");
            DropColumn("dbo.Categorias", "DataModificacao");
            DropColumn("dbo.Categorias", "DataExclusao");
            DropTable("dbo.Adicionals");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Atracaos");
            DropTable("dbo.Comandas");
            DropTable("dbo.Consumoes");
            DropTable("dbo.Mesas");
            DropTable("dbo.ComandaTransferencias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ComandaTransferencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Destino_Id = c.Int(),
                        Origem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mesas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Observacao = c.String(),
                        Ocupado = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consumoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Comanda_Id = c.Int(),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comandas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Observacao = c.String(),
                        Valor = c.Single(nullable: false),
                        Encerrado = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Mesa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Atracaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PrecoCouvert = c.Single(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Categoria_Id = c.Int(),
                        Cidade_Id = c.Int(),
                        Pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(),
                        Preco = c.Single(nullable: false),
                        Manufaturado = c.Boolean(nullable: false),
                        TempoEstimado = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Adicionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Produto_Id = c.Int(),
                        Consumo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categorias", "DataExclusao", c => c.DateTime());
            AddColumn("dbo.Categorias", "DataModificacao", c => c.DateTime());
            AddColumn("dbo.Categorias", "DataCadastro", c => c.DateTime(nullable: false));
            CreateIndex("dbo.ComandaTransferencias", "Origem_Id");
            CreateIndex("dbo.ComandaTransferencias", "Destino_Id");
            CreateIndex("dbo.Consumoes", "Produto_Id");
            CreateIndex("dbo.Consumoes", "Comanda_Id");
            CreateIndex("dbo.Comandas", "Mesa_Id");
            CreateIndex("dbo.Atracaos", "Pessoa_Id");
            CreateIndex("dbo.Atracaos", "Cidade_Id");
            CreateIndex("dbo.Atracaos", "Categoria_Id");
            CreateIndex("dbo.Produtoes", "Categoria_Id");
            CreateIndex("dbo.Adicionals", "Consumo_Id");
            CreateIndex("dbo.Adicionals", "Produto_Id");
            AddForeignKey("dbo.ComandaTransferencias", "Origem_Id", "dbo.Comandas", "Id");
            AddForeignKey("dbo.ComandaTransferencias", "Destino_Id", "dbo.Comandas", "Id");
            AddForeignKey("dbo.Comandas", "Mesa_Id", "dbo.Mesas", "Id");
            AddForeignKey("dbo.Consumoes", "Produto_Id", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.Consumoes", "Comanda_Id", "dbo.Comandas", "Id");
            AddForeignKey("dbo.Adicionals", "Consumo_Id", "dbo.Consumoes", "Id");
            AddForeignKey("dbo.Atracaos", "Pessoa_Id", "dbo.Pessoas", "Id");
            AddForeignKey("dbo.Atracaos", "Cidade_Id", "dbo.Cidades", "Id");
            AddForeignKey("dbo.Atracaos", "Categoria_Id", "dbo.Categorias", "Id");
            AddForeignKey("dbo.Adicionals", "Produto_Id", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias", "Id");
        }
    }
}
