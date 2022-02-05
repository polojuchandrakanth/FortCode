
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Fort.Dto.Response
{
    [Table("UserAccounts")]
    public class UserResponse
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserAccountId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        [IgnoreDataMember]
        public string PasswordHash { get; set; }
    }
}
