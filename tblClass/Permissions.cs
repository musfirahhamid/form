using System.ComponentModel.DataAnnotations;

namespace form.tblClass
    {
    public class Permissions
        {
         
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public bool status { get; set; }
    }
    }
