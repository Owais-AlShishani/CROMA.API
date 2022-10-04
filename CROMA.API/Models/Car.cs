using System.ComponentModel.DataAnnotations;

namespace CROMA.API.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CarType { get; set; }
    }
}
