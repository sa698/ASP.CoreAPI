using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace StcWebApi.Models.Cutomer
{
    public class Customer
    {
      public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [StringLength(50)]  
        public string PhoneNumber { get; set; }
        = string.Empty;
        [Required]
        [StringLength(50)]  
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public  int CreditLimit { get; set; }
        public Boolean Active { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;  
        public DateTime Updated { get; set; } = DateTime.Now; 
    }
}
