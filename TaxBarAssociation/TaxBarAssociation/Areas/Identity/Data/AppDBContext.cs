using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxBarAssociation.Models;
using TaxBarAssociation.Areas.Identity.Data;

namespace TaxBarAssociation.Areas.Identity.Data
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguraion());
        }
        public class ApplicationUserEntityConfiguraion : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.Property(x => x.Name).HasMaxLength(50);
                builder.Property(x => x.LastName).HasMaxLength(50);
                builder.Property(x => x.CorrespondenceAddress).HasMaxLength(255);
                builder.Property(x => x.OffNo).HasMaxLength(50);
                builder.Property(x => x.ResAddress).HasMaxLength(255);
                builder.Property(x => x.Email).HasMaxLength(255);
                builder.Property(x => x.BarCouncil).HasMaxLength(50);
                builder.Property(x => x.MemberNo).HasMaxLength(50);
                builder.Property(x => x.DateOfBirth).HasMaxLength(50);
                builder.Property(x => x.ProfilePicture).HasMaxLength(50);
            }
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Galleries> Galleries { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogGallery> BlogGalleries { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Sliders> Sliders { get; set; }
        public virtual DbSet<CoreCommite> CoreCommite { get; set; }
        public virtual DbSet<ReferenceDocument> ReferenceDocuments { get; set; }
    }
}
