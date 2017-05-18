using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("DefaultDB") { }

				public virtual DbSet<Jedinica_mere> Jedinica_mere { get; set; }
		public virtual DbSet<Stopa_PDV_a> Stopa_PDV_a { get; set; }
		public virtual DbSet<Analitika_magacinske_kartice> Analitika_magacinske_kartice { get; set; }
		public virtual DbSet<Poslovni_partner> Poslovni_partner { get; set; }
		public virtual DbSet<Mesto> Mesto { get; set; }
		public virtual DbSet<Grupa_roba> Grupa_roba { get; set; }
		public virtual DbSet<PDV> PDV { get; set; }
		public virtual DbSet<Poslovna_godina> Poslovna_godina { get; set; }
		public virtual DbSet<Roba> Roba { get; set; }
		public virtual DbSet<Prijemni_dokument> Prijemni_dokument { get; set; }
		public virtual DbSet<Faktura> Faktura { get; set; }
		public virtual DbSet<Preduzece> Preduzece { get; set; }
		public virtual DbSet<Robna_kartica> Robna_kartica { get; set; }
		public virtual DbSet<Magacin> Magacin { get; set; }
		public virtual DbSet<Stavka_dokumenta> Stavka_dokumenta { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } 
    }
}