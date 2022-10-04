namespace CROMA.API.Models
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Comment { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
