namespace AspApp_VenteVetements.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        AdresseLivraison = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VetementCommandes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        commandeId = c.Int(nullable: false),
                        vetementId = c.Int(nullable: false),
                        quantite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Vetements", t => t.vetementId, cascadeDelete: true)
                .ForeignKey("dbo.Commandes", t => t.commandeId, cascadeDelete: true)
                .Index(t => t.commandeId)
                .Index(t => t.vetementId);
            
            CreateTable(
                "dbo.Vetements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        marque = c.String(),
                        prix = c.Single(nullable: false),
                        couleur = c.String(),
                        taille = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Statuts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        adresseMail = c.String(),
                        motDePasse = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetementCommandes", "commandeId", "dbo.Commandes");
            DropForeignKey("dbo.VetementCommandes", "vetementId", "dbo.Vetements");
            DropIndex("dbo.VetementCommandes", new[] { "vetementId" });
            DropIndex("dbo.VetementCommandes", new[] { "commandeId" });
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Statuts");
            DropTable("dbo.Vetements");
            DropTable("dbo.VetementCommandes");
            DropTable("dbo.Commandes");
        }
    }
}
