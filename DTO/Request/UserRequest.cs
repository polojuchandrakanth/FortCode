using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fort.Dto.Request
{
    [Table("UserAccounts")]
    public class UserRequest
    {
        [Key]
        public int UserAccountId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
