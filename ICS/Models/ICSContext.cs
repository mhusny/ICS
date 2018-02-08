using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ICS.Models.Mapping;

namespace ICS.Models
{
    public partial class ICSContext : DbContext
    {
        static ICSContext()
        {
            Database.SetInitializer<ICSContext>(null);
        }

        public ICSContext()
            : base("Name=ICSContext")
        {
        }

        public DbSet<ARTICLE> ARTICLES { get; set; }
        public DbSet<FACTORY> FACTORIES { get; set; }
        public DbSet<GRN_DETAIL> GRN_DETAILS { get; set; }
        public DbSet<GRN_HEADER> GRN_HEADERS { get; set; }
        public DbSet<ORDER_DETAIL> ORDER_DETAILS { get; set; }
        public DbSet<ORDER_HEADER> ORDER_HEADERS { get; set; }
        public DbSet<SEASON> SEASONS { get; set; }
        public DbSet<SUPPLIER> SUPPLIERS { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ARTICLEMap());
            modelBuilder.Configurations.Add(new FACTORYMap());
            modelBuilder.Configurations.Add(new GRN_DETAILMap());
            modelBuilder.Configurations.Add(new GRN_HEADERMap());
            modelBuilder.Configurations.Add(new ORDER_DETAILMap());
            modelBuilder.Configurations.Add(new ORDER_HEADERMap());
            modelBuilder.Configurations.Add(new SEASONMap());
            modelBuilder.Configurations.Add(new SUPPLIERMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new USERMap());
        }
    }
}
