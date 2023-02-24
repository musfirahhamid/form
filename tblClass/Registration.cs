using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace form.tblClass
    {
    public class Registration:Common
        {
        public string UserName { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string UserEmail { get; set; }

        public string UserContact { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string UserPassword { get; set; }
        }
    }
