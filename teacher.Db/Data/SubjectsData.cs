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
    public class SubjectsData : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(
                        new Subject
                        {
                            Id = 1,
                            PostId = 1,
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

                );
        }
    }
}
