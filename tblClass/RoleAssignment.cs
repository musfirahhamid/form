using System.ComponentModel.DataAnnotations;

namespace form.tblClass
    {
    public class RoleAssignment
        {
        [Key]
        public int AssignmentId { get; set; }
        public int idPermission { get; set; }
        public int idUser { get; set; }
        public bool status { get; set; }
        }
    }
