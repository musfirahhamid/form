﻿namespace form.Models
    {
    public class AssignmentInsertion
        {
        public int AssignmentId { get; set; }
        public int idPermission { get; set; }
        public int idUser { get; set; }
        }
    public class AssignmentUpdation: AssignmentInsertion
        {
        public int AssignmentId { get; set; }
        }
    }
