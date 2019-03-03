using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql;

namespace wg_backend.Models
{
    public class WgContext : DbContext
    {
        //Добавляется для того что бы перечесляемый тип появился в бд
        static WgContext() => NpgsqlConnection.GlobalTypeMapper.MapEnum<cat_color>();
        public WgContext(DbContextOptions<WgContext> options) : base(options)
        {

        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Cats_stat> Cats_stats { get; set; }
        public DbSet<Cat_colors_info> Cat_colors_infs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cat_colors_info>().HasKey(b => b.Color);
            //Добавляется для того что бы перечесляемый тип появился в бд
            modelBuilder.ForNpgsqlHasEnum<cat_color>();



        }




    }
}