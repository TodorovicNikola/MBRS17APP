namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analitika_magacinske_kartice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Redni_broj = c.Int(nullable: false),
                        Vrsta_prometa = c.Int(nullable: false),
                        Smer_prometa = c.Int(nullable: false),
                        Kolicina = c.Double(nullable: false),
                        Cena = c.Double(nullable: false),
                        Vrednost = c.Double(nullable: false),
                        Robna_kartica_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Robna_kartica", t => t.Robna_kartica_ID)
                .Index(t => t.Robna_kartica_ID);
            
            CreateTable(
                "dbo.Robna_kartica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prosecna_cena = c.Double(nullable: false),
                        Poc__stanje_kol_ = c.Double(nullable: false),
                        Poc__stanje_vr_ = c.Double(nullable: false),
                        Promet_ulaza_kol_ = c.Double(nullable: false),
                        Promet_ulaza_vr_ = c.Double(nullable: false),
                        Promet_izlaza_kol_ = c.Double(nullable: false),
                        Promet_izlaza_vr_ = c.Double(nullable: false),
                        Ukupna_kolicina = c.Double(nullable: false),
                        Ukupna_vrednost = c.Double(nullable: false),
                        Roba_ID = c.Int(nullable: false),
                        Magacin_ID = c.Int(nullable: false),
                        Poslovna_godina_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roba", t => t.Roba_ID)
                .ForeignKey("dbo.Poslovna_godina", t => t.Poslovna_godina_ID)
                .ForeignKey("dbo.Magacin", t => t.Magacin_ID)
                .Index(t => t.Roba_ID)
                .Index(t => t.Magacin_ID)
                .Index(t => t.Poslovna_godina_ID);
            
            CreateTable(
                "dbo.Magacin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(maxLength: 128, unicode: false),
                        Adresa = c.String(maxLength: 128, unicode: false),
                        Preduzece_ID = c.Int(nullable: false),
                        Mesto_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mesto", t => t.Mesto_ID)
                .ForeignKey("dbo.Preduzece", t => t.Preduzece_ID)
                .Index(t => t.Adresa)
                .Index(t => t.Preduzece_ID)
                .Index(t => t.Mesto_ID);
            
            CreateTable(
                "dbo.Prijemni_dokument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Redni_broj = c.Int(nullable: false),
                        Datum_formiranja = c.DateTime(nullable: false),
                        Datum_knjizenja = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Ukupna_vrednost = c.Double(nullable: false),
                        Transportni_troskovi = c.Double(nullable: false),
                        Zavisni_troskovi = c.Double(nullable: false),
                        Pripada_magacinu_ID = c.Int(nullable: false),
                        Magacin_u_dokumentu_ID = c.Int(nullable: false),
                        Poslovni_partner_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Poslovni_partner", t => t.Poslovni_partner_ID)
                .ForeignKey("dbo.Magacin", t => t.Magacin_u_dokumentu_ID)
                .ForeignKey("dbo.Magacin", t => t.Pripada_magacinu_ID)
                .Index(t => t.Pripada_magacinu_ID)
                .Index(t => t.Magacin_u_dokumentu_ID)
                .Index(t => t.Poslovni_partner_ID);
            
            CreateTable(
                "dbo.Poslovni_partner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tip = c.Int(nullable: false),
                        Naziv = c.String(maxLength: 128, unicode: false),
                        PIB = c.String(nullable: false, maxLength: 128, unicode: false),
                        Maticni_broj = c.String(nullable: false, maxLength: 128, unicode: false),
                        Adresa = c.String(maxLength: 128, unicode: false),
                        Iz_mesta_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mesto", t => t.Iz_mesta_ID)
                .Index(t => t.PIB, unique: true)
                .Index(t => t.Maticni_broj, unique: true)
                .Index(t => t.Iz_mesta_ID);
            
            CreateTable(
                "dbo.Faktura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Broj_fakture = c.Int(nullable: false),
                        Datum_fakture = c.DateTime(nullable: false),
                        Datum_valute = c.DateTime(nullable: false),
                        Ukupan_rabat = c.Double(nullable: false),
                        Ukupan_iznos_bez_PDV_a = c.Double(nullable: false),
                        Ukupan_PDV = c.Double(nullable: false),
                        Ukupno_za_placanje = c.Double(nullable: false),
                        Poslovna_godina_ID = c.Int(nullable: false),
                        Poslovni_partner_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Poslovna_godina", t => t.Poslovna_godina_ID)
                .ForeignKey("dbo.Poslovni_partner", t => t.Poslovni_partner_ID)
                .Index(t => t.Broj_fakture, unique: true)
                .Index(t => t.Poslovna_godina_ID)
                .Index(t => t.Poslovni_partner_ID);
            
            CreateTable(
                "dbo.Poslovna_godina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Godina = c.Int(nullable: false),
                        Zakljucena = c.Boolean(nullable: false),
                        Preduzece_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Preduzece", t => t.Preduzece_ID)
                .Index(t => t.Preduzece_ID);
            
            CreateTable(
                "dbo.Preduzece",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(maxLength: 128, unicode: false),
                        Maticni_broj = c.String(nullable: false, maxLength: 128, unicode: false),
                        PIB = c.String(nullable: false, maxLength: 128, unicode: false),
                        Adresa = c.String(maxLength: 128, unicode: false),
                        Mesto_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mesto", t => t.Mesto_ID)
                .Index(t => t.Maticni_broj, unique: true)
                .Index(t => t.PIB, unique: true)
                .Index(t => t.Mesto_ID);
            
            CreateTable(
                "dbo.Grupa_roba",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(maxLength: 128, unicode: false),
                        Preduzece_ID = c.Int(nullable: false),
                        PDV_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PDV", t => t.PDV_ID)
                .ForeignKey("dbo.Preduzece", t => t.Preduzece_ID)
                .Index(t => t.Preduzece_ID)
                .Index(t => t.PDV_ID);
            
            CreateTable(
                "dbo.PDV",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv_PDV_a = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stopa_PDV_a",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stopa = c.Double(nullable: false),
                        Datum_vazenja = c.DateTime(nullable: false),
                        PDV_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PDV", t => t.PDV_ID)
                .Index(t => t.PDV_ID);
            
            CreateTable(
                "dbo.Roba",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(maxLength: 128, unicode: false),
                        Grupa_roba_ID = c.Int(nullable: false),
                        Preduzece_ID = c.Int(nullable: false),
                        Jedinica_mere_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jedinica_mere", t => t.Jedinica_mere_ID)
                .ForeignKey("dbo.Grupa_roba", t => t.Grupa_roba_ID)
                .ForeignKey("dbo.Preduzece", t => t.Preduzece_ID)
                .Index(t => t.Grupa_roba_ID)
                .Index(t => t.Preduzece_ID)
                .Index(t => t.Jedinica_mere_ID);
            
            CreateTable(
                "dbo.Jedinica_mere",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 128, unicode: false),
                        Oznaka = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Naziv);
            
            CreateTable(
                "dbo.Stavka_dokumenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Redni_broj = c.Int(nullable: false),
                        Kolicina = c.Double(nullable: false),
                        Nabavna_cena_po_jedinici = c.Double(nullable: false),
                        Nabavna_vrednost = c.Double(nullable: false),
                        Procenat_marze = c.Double(nullable: false),
                        Transportni_trosak = c.Double(nullable: false),
                        Zavisni_trosak = c.Double(nullable: false),
                        Kalkulisana_cena = c.Double(nullable: false),
                        Ukupna_vrednost = c.Double(nullable: false),
                        Prijemni_dokument_ID = c.Int(nullable: false),
                        Roba_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prijemni_dokument", t => t.Prijemni_dokument_ID)
                .ForeignKey("dbo.Roba", t => t.Roba_ID)
                .Index(t => t.Prijemni_dokument_ID)
                .Index(t => t.Roba_ID);
            
            CreateTable(
                "dbo.Mesto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(maxLength: 128, unicode: false),
                        Postanski_broj = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analitika_magacinske_kartice", "Robna_kartica_ID", "dbo.Robna_kartica");
            DropForeignKey("dbo.Robna_kartica", "Magacin_ID", "dbo.Magacin");
            DropForeignKey("dbo.Prijemni_dokument", "Pripada_magacinu_ID", "dbo.Magacin");
            DropForeignKey("dbo.Magacin", "Preduzece_ID", "dbo.Preduzece");
            DropForeignKey("dbo.Magacin", "Mesto_ID", "dbo.Mesto");
            DropForeignKey("dbo.Prijemni_dokument", "Magacin_u_dokumentu_ID", "dbo.Magacin");
            DropForeignKey("dbo.Faktura", "Poslovni_partner_ID", "dbo.Poslovni_partner");
            DropForeignKey("dbo.Faktura", "Poslovna_godina_ID", "dbo.Poslovna_godina");
            DropForeignKey("dbo.Robna_kartica", "Poslovna_godina_ID", "dbo.Poslovna_godina");
            DropForeignKey("dbo.Poslovna_godina", "Preduzece_ID", "dbo.Preduzece");
            DropForeignKey("dbo.Roba", "Preduzece_ID", "dbo.Preduzece");
            DropForeignKey("dbo.Preduzece", "Mesto_ID", "dbo.Mesto");
            DropForeignKey("dbo.Poslovni_partner", "Iz_mesta_ID", "dbo.Mesto");
            DropForeignKey("dbo.Roba", "Grupa_roba_ID", "dbo.Grupa_roba");
            DropForeignKey("dbo.Stavka_dokumenta", "Roba_ID", "dbo.Roba");
            DropForeignKey("dbo.Stavka_dokumenta", "Prijemni_dokument_ID", "dbo.Prijemni_dokument");
            DropForeignKey("dbo.Robna_kartica", "Roba_ID", "dbo.Roba");
            DropForeignKey("dbo.Roba", "Jedinica_mere_ID", "dbo.Jedinica_mere");
            DropForeignKey("dbo.Grupa_roba", "Preduzece_ID", "dbo.Preduzece");
            DropForeignKey("dbo.Grupa_roba", "PDV_ID", "dbo.PDV");
            DropForeignKey("dbo.Stopa_PDV_a", "PDV_ID", "dbo.PDV");
            DropForeignKey("dbo.Prijemni_dokument", "Poslovni_partner_ID", "dbo.Poslovni_partner");
            DropIndex("dbo.Stavka_dokumenta", new[] { "Roba_ID" });
            DropIndex("dbo.Stavka_dokumenta", new[] { "Prijemni_dokument_ID" });
            DropIndex("dbo.Jedinica_mere", new[] { "Naziv" });
            DropIndex("dbo.Roba", new[] { "Jedinica_mere_ID" });
            DropIndex("dbo.Roba", new[] { "Preduzece_ID" });
            DropIndex("dbo.Roba", new[] { "Grupa_roba_ID" });
            DropIndex("dbo.Stopa_PDV_a", new[] { "PDV_ID" });
            DropIndex("dbo.Grupa_roba", new[] { "PDV_ID" });
            DropIndex("dbo.Grupa_roba", new[] { "Preduzece_ID" });
            DropIndex("dbo.Preduzece", new[] { "Mesto_ID" });
            DropIndex("dbo.Preduzece", new[] { "PIB" });
            DropIndex("dbo.Preduzece", new[] { "Maticni_broj" });
            DropIndex("dbo.Poslovna_godina", new[] { "Preduzece_ID" });
            DropIndex("dbo.Faktura", new[] { "Poslovni_partner_ID" });
            DropIndex("dbo.Faktura", new[] { "Poslovna_godina_ID" });
            DropIndex("dbo.Faktura", new[] { "Broj_fakture" });
            DropIndex("dbo.Poslovni_partner", new[] { "Iz_mesta_ID" });
            DropIndex("dbo.Poslovni_partner", new[] { "Maticni_broj" });
            DropIndex("dbo.Poslovni_partner", new[] { "PIB" });
            DropIndex("dbo.Prijemni_dokument", new[] { "Poslovni_partner_ID" });
            DropIndex("dbo.Prijemni_dokument", new[] { "Magacin_u_dokumentu_ID" });
            DropIndex("dbo.Prijemni_dokument", new[] { "Pripada_magacinu_ID" });
            DropIndex("dbo.Magacin", new[] { "Mesto_ID" });
            DropIndex("dbo.Magacin", new[] { "Preduzece_ID" });
            DropIndex("dbo.Magacin", new[] { "Adresa" });
            DropIndex("dbo.Robna_kartica", new[] { "Poslovna_godina_ID" });
            DropIndex("dbo.Robna_kartica", new[] { "Magacin_ID" });
            DropIndex("dbo.Robna_kartica", new[] { "Roba_ID" });
            DropIndex("dbo.Analitika_magacinske_kartice", new[] { "Robna_kartica_ID" });
            DropTable("dbo.Mesto");
            DropTable("dbo.Stavka_dokumenta");
            DropTable("dbo.Jedinica_mere");
            DropTable("dbo.Roba");
            DropTable("dbo.Stopa_PDV_a");
            DropTable("dbo.PDV");
            DropTable("dbo.Grupa_roba");
            DropTable("dbo.Preduzece");
            DropTable("dbo.Poslovna_godina");
            DropTable("dbo.Faktura");
            DropTable("dbo.Poslovni_partner");
            DropTable("dbo.Prijemni_dokument");
            DropTable("dbo.Magacin");
            DropTable("dbo.Robna_kartica");
            DropTable("dbo.Analitika_magacinske_kartice");
        }
    }
}
