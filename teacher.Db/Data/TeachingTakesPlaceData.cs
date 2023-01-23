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
    public class TeachingTakesPlaceData : IEntityTypeConfiguration<TeachingTakesPlace>
    {
        public void Configure(EntityTypeBuilder<TeachingTakesPlace> builder)
        {
            builder.HasData(
                new TeachingTakesPlace
                {
                    Id = 1,
                    PostId = 1,
                    StudentsPlace = true,
                    TeachersPlace = true,
                    Online = true,
                    OtherLocation = false
                }
            );
        }
    }
}
