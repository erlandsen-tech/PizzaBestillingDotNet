using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using PizzaBestilling.Models;

namespace PizzaBestilling.Repo
{
    public partial class PizzaDBContext : DbContext
    {
        public PizzaDBContext()
            : base("name=PizzaBase")
        {
            Database.CreateIfNotExists();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Kunde> Kunder { get; set; }
        public virtual DbSet<Pizza> Pizzaer{ get; set; }
    }
}
