using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(  //kullanıcı rollerini oluşturuyoruz.
                    new IdentityRole() { Name = "user", NormalizedName = "USER" },
                    new IdentityRole() { Name = "editor", NormalizedName="EDITOR"}, //ürünleri organize edecek kullanıcı
                     new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" }
                );
        }
    }
}
