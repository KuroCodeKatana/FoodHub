namespace FoodHub.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CART_ITEM> CART_ITEM { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CITY> CITies { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACKs { get; set; }
        public virtual DbSet<ITEM> ITEMs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<STATE> STATEs { get; set; }
        public virtual DbSet<USER_DETAILS> USER_DETAILS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CART>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CART>()
                .HasMany(e => e.CART_ITEM)
                .WithRequired(e => e.CART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CART>()
                .HasMany(e => e.ORDERs)
                .WithRequired(e => e.CART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CART_ITEM>()
                .Property(e => e.QNTY)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.CATE_NM)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.CATE_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.ITEMs)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CITY>()
                .Property(e => e.CITY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_NM)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.IMG)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.PRICE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.FEEDBACKs)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.AMOUNT)
                .HasPrecision(6, 0);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.REMARKS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.FEEDBACKs)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATE>()
                .Property(e => e.STATE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STATE>()
                .HasMany(e => e.CITies)
                .WithRequired(e => e.STATE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.USER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.CONTACT_NO)
                .HasPrecision(10, 0);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.PIN)
                .HasPrecision(6, 0);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.STATE)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.USER_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.TOKEN)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<USER_DETAILS>()
                .HasMany(e => e.CARTs)
                .WithRequired(e => e.USER_DETAILS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_DETAILS>()
                .HasMany(e => e.ORDERs)
                .WithRequired(e => e.USER_DETAILS)
                .WillCascadeOnDelete(false);
        }
    }
}
