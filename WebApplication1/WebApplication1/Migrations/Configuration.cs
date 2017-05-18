namespace WebApplication1.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.AppDBContext context)
        {
            context.Mesto.AddOrUpdate(
                new Mesto { Naziv = "Subotica", Postanski_broj = "24000" }
                );

            context.SaveChanges();

            context.Preduzece.AddOrUpdate(
                new Preduzece { Naziv = "Mnogo dobro preduzece", PIB = "1231231231231", Maticni_broj = "1231231231231", Mesto_ID = 1, Adresa = "Frankopanska 1" }
                );

            context.SaveChanges();
        }
    }
}
