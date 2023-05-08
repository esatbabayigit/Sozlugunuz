using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(50)]
        public string AdminUserName { get; set; }
        [StringLength(50)]
        public string AdminPassword { get; set; }
        [StringLength(1)]
        public string AdminRole{ get; set; }

        public bool AdminStatus { get; set; }
    }
}