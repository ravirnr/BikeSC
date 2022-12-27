
using System.ComponentModel.DataAnnotations;

namespace BikeSC.Data;

    public class StudentModel
    {
    public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }     

    }

