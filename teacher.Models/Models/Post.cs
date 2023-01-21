using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace teacher.Models.Models
{
    public class Post
    {
        [Column("PostId")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Eesnimi on vajalik")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Perekonnanimi on vajalik")]
        public string? LastName { get; set; }
        public string? PicturePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Speciality { get; set; }
        public string? Description { get; set; }
        public string? Languages { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public string? Location { get; set; }
        public string? HighestDegree { get; set; }
        public List<Subject>? TeachSubjects { get; set; }
        public TeachingTakesPlace? TeachingTakesPlace { get; set; }

    }

    public class Subject
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public bool Elementary { get; set; }
        public bool Basic { get; set; }
        public bool High { get; set; }
        public bool University { get; set; }
    }

    public class TeachingTakesPlace
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        public bool StudentsPlace { get; set; }
        public bool TeachersPlace { get; set; }
        public bool Online { get; set; }
        public bool OtherLocation { get; set; }

    }


}
