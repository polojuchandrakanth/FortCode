
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fort.Dto.Request
{
    [Table("UserCountry")]
    public class UserCountryRequest
    {
        [Key]
        public int UserCountryId { get; set; }
        [ForeignKey("UserAccountId")]
        public int UserAccountId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
    }
}
