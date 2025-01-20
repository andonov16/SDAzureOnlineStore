using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Server.Model
{
    public class Customer:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }

        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
