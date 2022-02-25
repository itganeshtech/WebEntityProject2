using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEntityProject2.Models.EF
{
    public partial class StudentFees
    {
        [Key]
        public int StudentFeeId { get; set; }
        public int? StudentId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AmountPaid { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(Students.StudentFees))]
        public virtual Students Student { get; set; }
    }
}
