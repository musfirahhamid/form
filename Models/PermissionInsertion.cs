namespace form.Models
    {
    public class PermissionInsertion
        {
        public string Title { get; set; }
        public string URL { get; set; }
        }
    public class PermissionUpdation: PermissionInsertion
        {
        public int Id { get; set; }
        }
    public class PermissionDeletion
        {
        public int Id { get; set; }
        }
    }
