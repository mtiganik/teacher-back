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
                getData()
                ) ;
        }

        public Post getData()
        {
            return new Post
            {
                Id = 1,
                FirstName = "Mihkel",
                LastName = "Tiganik",
                PicturePath = "https://scontent-hel3-1.xx.fbcdn.net/v/t39.30808-6/246660293_10216443541721640_696967518917121996_n.jpg?_nc_cat=106&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=dLGcrq3NYUUAX8ZejJ6&_nc_ht=scontent-hel3-1.xx&oh=00_AfBVRoRLRJF0b3vz2J4XKZ52_WHH7DQLmv-ShjxvRIpxwg&oe=63D174B9",
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
                TeachingTakesPlace = new TeachingTakesPlace
                {
                    Id = 1,
                    PostId = 1,
                    StudentsPlace = true,
                    TeachersPlace = true,
                    Online = true,
                    OtherLocation = false
                },
                TeachSubjects = new List<Subject>
                    {
                        new Subject
                        {
                            Id = 1,
                            PostId= 1,
                            Name = "Matemaatika",
                            Elementary = false,
                            Basic = true,
                            High = true,
                            University = true
                        },
                        new Subject
                        {
                            Id = 2,
                            PostId = 1,
                            Name = "Füüsika",
                            Elementary = true,
                            Basic = true,
                            High = true,
                            University = true
                        },
                        new Subject
                        {
                            Id = 3,
                            PostId = 1,
                            Name = "Programmeerimine",
                            Elementary = true,
                            Basic = true,
                            High = true,
                            University = true
                        }
                    }


            };
                
        }
    }
}
