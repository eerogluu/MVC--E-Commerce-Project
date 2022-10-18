using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        [Key]

        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }


        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        // alttaki prop'u virtual yaparsak üstte ki attribute'ü kaldırırız ve onun foreign key olduğunu anlar.
        public  Movie Movie { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]

        public Order Order { get; set; }
    }
}
