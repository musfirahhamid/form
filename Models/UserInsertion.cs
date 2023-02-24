namespace form.Models
    {
    public class UserInsertion
        {
        public string UserTitle { get; set; }
        }
    public class UserUpdation : UserInsertion
        {
        public int UserId { get; set; }
        }
    public class UserDeletion
        {
        public int UserId { get; set; }
        }
    }
