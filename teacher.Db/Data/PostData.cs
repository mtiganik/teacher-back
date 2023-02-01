using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Models.Models;

namespace teacher.Db.Data
{
    public class PostData : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
            new Post
            {
                Id = 1,
                FirstName = "Mihkel",
                LastName = "Tiganik",
                PicturePath = "https://i.postimg.cc/sX0HJTRT/246660293-10216443541721640-696967518917121996-n.jpg",
                DateOfBirth = new DateTime(1989, 10, 1),
                Phone = "55655828",
                Email = "mtiganik@gmail.com",
                Speciality = "Insener, Õpetaja",
                Description = "Õpetan matemaatikat, Füüsikat, programmeerimist keskkooli, ülikooli tasemel",
                Languages = "Eesti, Inglise, Vene",
                PriceMin = 30,
                PriceMax = 50,
                Location = "Tallinn, Harjumaa",
                HighestDegree = "Ülikool",
            },
            new Post{
                Id = 2,
                FirstName = "Anngrett",
                LastName = "Suurkask",
                PicturePath = "https://i.postimg.cc/DZs4Cz9R/285751931-5916052801752817-7142409434228113031-n.jpg",
                DateOfBirth= new DateTime(1995,4,21),
                Phone ="55549251",
                Email = "anngret2008@hotmail.com",
                Speciality = "Muusik, kunstnik",
                Description = "Olen vabakutseline laulja/muusik. Meeldib suhelda ja teisi õpetada",
                Languages = "Eesti, Inglise",
                PriceMin = 15,
                PriceMax = 30,
                Location = "Tallinn, Harjumaa"
                }

                ) ;
        }

    }
}
