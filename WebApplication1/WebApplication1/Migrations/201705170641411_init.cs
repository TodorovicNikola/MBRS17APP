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
                .ForeignKey("dbo.Magacins", t => t.Magacin_ID)
                .ForeignKey("dbo.Poslovna_godina", t => t.Poslovna_godina_ID)
                .ForeignKey("dbo.Robas", t => t.Roba_ID)
                .Index(t => t.Roba_ID)
                .Index(t => t.Magacin_ID)
                .Index(t => t.Poslovna_godina_ID);
            
            CreateTable(
                "dbo.Magacins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(maxLength: 128, unicode: false),
                        Preduzece_ID = c.Int(nullable: false),
                        Mesto_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mestoes", t => t.Mesto_ID)
                .ForeignKey("dbo.Preduzeces", t => t.Preduzece_ID)
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
                        Stavka_dokumenta_ID = c.Int(nullable: false),
                        MagacinUDokumentu_ID = c.Int(nullable: false),
                        MagacinKomPripada_ID = c.Int(nullable: false),
                        Poslovni_partner_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Poslovni_partner", t => t.Poslovni_partner_ID)
                .ForeignKey("dbo.Stavka_dokumenta", t => t.Stavka_dokumenta_ID)
                .ForeignKey("dbo.Magacins", t => t.MagacinUDokumentu_ID)
                .ForeignKey("dbo.Magacins", t => t.MagacinKomPripada_ID)
                .Index(t => t.Stavka_dokumenta_ID)
                .Index(t => t.MagacinUDokumentu_ID)
                .Index(t => t.MagacinKomPripada_ID)
                .Index(t => t.Poslovni_partner_ID);
            
            CreateTable(
                "dbo.Poslovni_partner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tip = c.Int(nullable: false),
                        Naziv = c.String(),
                        PIB = c.String(nullable: false, maxLength: 128, unicode: false),
                        Maticni_broj = c.String(nullable: false, maxLength: 128, unicode: false),
                        Adresa = c.String(),
                        Mesto_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mestoes", t => t.Mesto_ID)
                .Index(t => t.PIB, unique: true)
                .Index(t => t.Maticni_broj, unique: true)
                .Index(t => t.Mesto_ID);
            
            CreateTable(
                "dbo.Fakturas",
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
                .ForeignKey("dbo.Preduzeces", t => t.Preduzece_ID)
                .Index(t => t.Preduzece_ID);
            
            CreateTable(
                "dbo.Preduzeces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Maticni_broj = c.String(nullable: false, maxLength: 128, unicode: false),
                        PIB = c.String(nullable: false, maxLength: 128, unicode: false),
                        Adresa = c.String(),
                        Mesto_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mestoes", t => t.Mesto_ID)
                .Index(t => t.Maticni_broj, unique: true)
                .Index(t => t.PIB, unique: true)
                .Index(t => t.Mesto_ID);
            
            CreateTable(
                "dbo.Grupa_roba",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Preduzece_ID = c.Int(nullable: false),
                        PDV_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PDVs", t => t.PDV_ID)
                .ForeignKey("dbo.Preduzeces", t => t.Preduzece_ID)
                .Index(t => t.Preduzece_ID)
                .Index(t => t.PDV_ID);
            
            CreateTable(
                "dbo.PDVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv_PDV_a = c.String(),
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
                .ForeignKey("dbo.PDVs", t => t.PDV_ID)
                .Index(t => t.PDV_ID);
            
            CreateTable(
                "dbo.Robas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Grupa_roba_ID = c.Int(nullable: false),
                        Preduzece_ID = c.Int(nullable: false),
                        Jedinica_mere_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupa_roba", t => t.Grupa_roba_ID)
                .ForeignKey("dbo.Jedinica_mere", t => t.Jedinica_mere_ID)
                .ForeignKey("dbo.Preduzeces", t => t.Preduzece_ID)
                .Index(t => t.Grupa_roba_ID)
                .Index(t => t.Preduzece_ID)
                .Index(t => t.Jedinica_mere_ID);
            
            CreateTable(
                "dbo.Jedinica_mere",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 128, unicode: false),
                        Oznaka = c.String(),
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
                        Roba_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Robas", t => t.Roba_ID)
                .Index(t => t.Roba_ID);
            
            CreateTable(
                "dbo.Mestoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Postanski_broj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analitika_magacinske_kartice", "Robna_kartica_ID", "dbo.Robna_kartica");
            DropForeignKey("dbo.Robna_kartica", "Roba_ID", "dbo.Robas");
            DropForeignKey("dbo.Robna_kartica", "Poslovna_godina_ID", "dbo.Poslovna_godina");
            DropForeignKey("dbo.Robna_kartica", "Magacin_ID", "dbo.Magacins");
            DropForeignKey("dbo.Prijemni_dokument", "MagacinKomPripada_ID", "dbo.Magacins");
            DropForeignKey("dbo.Magacins", "Preduzece_ID", "dbo.Preduzeces");
            DropForeignKey("dbo.Magacins", "Mesto_ID", "dbo.Mestoes");
            DropForeignKey("dbo.Prijemni_dokument", "MagacinUDokumentu_ID", "dbo.Magacins");
            DropForeignKey("dbo.Prijemni_dokument", "Stavka_dokumenta_ID", "dbo.Stavka_dokumenta");
            DropForeignKey("dbo.Prijemni_dokument", "Poslovni_partner_ID", "dbo.Poslovni_partner");
            DropForeignKey("dbo.Poslovni_partner", "Mesto_ID", "dbo.Mestoes");
            DropForeignKey("dbo.Fakturas", "Poslovni_partner_ID", "dbo.Poslovni_partner");
            DropForeignKey("dbo.Fakturas", "Poslovna_godina_ID", "dbo.Poslovna_godina");
            DropForeignKey("dbo.Poslovna_godina", "Preduzece_ID", "dbo.Preduzeces");
            DropForeignKey("dbo.Preduzeces", "Mesto_ID", "dbo.Mestoes");
            DropForeignKey("dbo.Stavka_dokumenta", "Roba_ID", "dbo.Robas");
            DropForeignKey("dbo.Robas", "Preduzece_ID", "dbo.Preduzeces");
            DropForeignKey("dbo.Robas", "Jedinica_mere_ID", "dbo.Jedinica_mere");
            DropForeignKey("dbo.Robas", "Grupa_roba_ID", "dbo.Grupa_roba");
            DropForeignKey("dbo.Grupa_roba", "Preduzece_ID", "dbo.Preduzeces");
            DropForeignKey("dbo.Grupa_roba", "PDV_ID", "dbo.PDVs");
            DropForeignKey("dbo.Stopa_PDV_a", "PDV_ID", "dbo.PDVs");
            DropIndex("dbo.Stavka_dokumenta", new[] { "Roba_ID" });
            DropIndex("dbo.Jedinica_mere", new[] { "Naziv" });
            DropIndex("dbo.Robas", new[] { "Jedinica_mere_ID" });
            DropIndex("dbo.Robas", new[] { "Preduzece_ID" });
            DropIndex("dbo.Robas", new[] { "Grupa_roba_ID" });
            DropIndex("dbo.Stopa_PDV_a", new[] { "PDV_ID" });
            DropIndex("dbo.Grupa_roba", new[] { "PDV_ID" });
            DropIndex("dbo.Grupa_roba", new[] { "Preduzece_ID" });
            DropIndex("dbo.Preduzeces", new[] { "Mesto_ID" });
            DropIndex("dbo.Preduzeces", new[] { "PIB" });
            DropIndex("dbo.Preduzeces", new[] { "Maticni_broj" });
            DropIndex("dbo.Poslovna_godina", new[] { "Preduzece_ID" });
            DropIndex("dbo.Fakturas", new[] { "Poslovni_partner_ID" });
            DropIndex("dbo.Fakturas", new[] { "Poslovna_godina_ID" });
            DropIndex("dbo.Fakturas", new[] { "Broj_fakture" });
            DropIndex("dbo.Poslovni_partner", new[] { "Mesto_ID" });
            DropIndex("dbo.Poslovni_partner", new[] { "Maticni_broj" });
            DropIndex("dbo.Poslovni_partner", new[] { "PIB" });
            DropIndex("dbo.Prijemni_dokument", new[] { "Poslovni_partner_ID" });
            DropIndex("dbo.Prijemni_dokument", new[] { "MagacinKomPripada_ID" });
            DropIndex("dbo.Prijemni_dokument", new[] { "MagacinUDokumentu_ID" });
            DropIndex("dbo.Prijemni_dokument", new[] { "Stavka_dokumenta_ID" });
            DropIndex("dbo.Magacins", new[] { "Mesto_ID" });
            DropIndex("dbo.Magacins", new[] { "Preduzece_ID" });
            DropIndex("dbo.Magacins", new[] { "Adresa" });
            DropIndex("dbo.Robna_kartica", new[] { "Poslovna_godina_ID" });
            DropIndex("dbo.Robna_kartica", new[] { "Magacin_ID" });
            DropIndex("dbo.Robna_kartica", new[] { "Roba_ID" });
            DropIndex("dbo.Analitika_magacinske_kartice", new[] { "Robna_kartica_ID" });
            DropTable("dbo.Mestoes");
            DropTable("dbo.Stavka_dokumenta");
            DropTable("dbo.Jedinica_mere");
            DropTable("dbo.Robas");
            DropTable("dbo.Stopa_PDV_a");
            DropTable("dbo.PDVs");
            DropTable("dbo.Grupa_roba");
            DropTable("dbo.Preduzeces");
            DropTable("dbo.Poslovna_godina");
            DropTable("dbo.Fakturas");
            DropTable("dbo.Poslovni_partner");
            DropTable("dbo.Prijemni_dokument");
            DropTable("dbo.Magacins");
            DropTable("dbo.Robna_kartica");
            DropTable("dbo.Analitika_magacinske_kartice");
        }
    }
}
