using System.ComponentModel.DataAnnotations;

namespace form.tblClass
    {
    public class UserRole
        {
        [Key]
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public bool status { get; set; }
        }
    }
