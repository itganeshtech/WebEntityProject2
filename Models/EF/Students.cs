using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEntityProject2.Models.EF
{
    public partial class Students
    {
        public Students()
        {
            StudentFees = new HashSet<StudentFees>();
        }

        [Key]
        public int StudentId { get; set; }
        [StringLength(250)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Mobile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public string Notes { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudentFees> StudentFees { get; set; }
    }
}
