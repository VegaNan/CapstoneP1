using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Data
{
    public class SqlServerDBContext : DbContext
    {
        private readonly SqlServerSettings sqlServerSettings;

        public SqlServerDBContext(IOptions<SqlServerSettings> configuration)
        {
            sqlServerSettings = configuration.Value;
        }


        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Models.Image> images { get; set; }


        public DbConnection connection()
        {
            var connectionString = new SqlConnectionStringBuilder()
            {

                DataSource = sqlServerSettings.Server,     // e.g. '127.0.0.1' 
                UserID = sqlServerSettings.UserId,        // e.g. 'my-db-user'
                Password = sqlServerSettings.Password,       // e.g. 'my-db-password'
                InitialCatalog = sqlServerSettings.Database, // e.g. 'my-database'
                Encrypt = false,
            };
            connectionString.Pooling = true;      
            connectionString.MaxPoolSize = 5;
            connectionString.MinPoolSize = 0;
            connectionString.ConnectTimeout = 15;
            DbConnection connection =
                new SqlConnection(connectionString.ConnectionString);
            return connection;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId)
                    .UseIdentityColumn();

                entity.Property(e => e.ItemName);
                entity.Property(e => e.ItemDescription);
                entity.Property(e => e.Price);
                entity.Property(e => e.Rating);

                entity.Property(e => e.Types);
                entity.Property(e => e.Reviews);
                entity.Property(e => e.UnavailableDates);
                entity.Property(e => e.Images);


            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection());
            }
        }

    }
}
