using System.ComponentModel.DataAnnotations;

namespace CROMA.API.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int PhoneNumber { get; set; }

        public string Comment { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
