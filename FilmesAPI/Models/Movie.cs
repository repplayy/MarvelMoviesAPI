using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]  
        public int Id { get; set; }
        [Required(ErrorMessage = "The field title is mandatory") ]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Director is mandatory")]
        public string Director { get; set; }

        [StringLength(30, ErrorMessage = "The gender can't be above 30 characters")]
        public string Gender { get; set; }

        public DateTime Date { get; set; }

        [Range(1,200,ErrorMessage = "The time of the movie can't be above 200 minutes ")]
        public int time { get; set; }

       



    }
}
