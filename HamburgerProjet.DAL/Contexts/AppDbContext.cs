using HamburgerProject.DATA.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProjet.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<EkstraMalzeme> EkstraMalzemes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisMalzeme> SiparisMalzemes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            builder.Entity<EkstraMalzeme>().HasMany(x => x.SiparisMalzemes).WithOne(x => x.EkstraMalzeme).HasForeignKey(x => x.EkstraMalzemeId);
            builder.Entity<Siparis>().HasMany(x => x.SiparisMalzemes).WithOne(x => x.Siparis).HasForeignKey(x => x.SiparisId);
            builder.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id = "5702b9a5-8f37-4374-b1a0-895c69fe7858",
                    Name = "Manager",
                    NormalizedName = "Manager"
                },
                new AppRole()
                {
                    Id = "ffdc4513-353c-47d6-8657-b9d0b065a539",
                    Name = "Member",
                    NormalizedName = "MEMBER"
                }
                );
            

            base.OnModelCreating(builder);
        }
    }
}
