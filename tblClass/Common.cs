using System.ComponentModel.DataAnnotations;

namespace form.tblClass
    {
    public class Common
        {
        [Key]
        public int UserId { get; set; }
        public bool Status { get; set; }
        }
    }
