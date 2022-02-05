
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fort.Dto.Response
{
    [Table("UserCountry")]
    public class UserCountryResponse
    {
        [Key]
        public int UserCountryId { get; set; }
        [ForeignKey("UserAccountId")]
        public int UserAccountId { get; set; }
        public string country { get; set; }
        public string City { get; set; }
    }
}
