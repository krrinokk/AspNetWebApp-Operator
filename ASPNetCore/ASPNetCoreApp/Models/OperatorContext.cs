using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreApp.Models
{
    public partial class OperatorContext : DbContext
    {
        #region Constructor
        public OperatorContext(DbContextOptions<OperatorContext>
        options)
        : base(options)
        { }
        #endregion
        public virtual DbSet<Тариф> Тариф { get; set; }
        public virtual DbSet<Dogovor> Dogovor { get; set; }
        public virtual DbSet<Клиент> Клиент { get; set; }
        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {
            modelBuilder.Entity<Тариф>(entity =>
            {
                entity.Property(e => e.Код_тарифа).IsRequired();
            });
            //modelBuilder.Entity<Dogovor>(entity =>
            //{
            //    entity.HasOne(d => d.Тариф)
            //    .WithMany(p => p.Dogovor)
            //    .HasForeignKey(d => d.Код_тарифа_FK);
            //});

            modelBuilder.Entity<Клиент>(entity =>
            {
                entity.Property(e => e.Номер_клиента).IsRequired();
            });
            //modelBuilder.Entity<Dogovor>(entity =>
            //{
            //    entity.HasOne(d => d.Клиент)
            //    .WithMany(p => p.Dogovor)
            //    .HasForeignKey(d => d.Номер_клиента_FK);
            //});


        }
    }
}
