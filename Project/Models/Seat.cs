using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Seat
    {
        [Key]
        public int Seat_Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public int Seat_Num { get; set; }

        [ForeignKey("HallID")]
        public Hall? Hall { get; set; }
    }
}
