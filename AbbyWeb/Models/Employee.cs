using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbbyWeb.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50), Display(Name ="First name")]
        public string FirstName { get; set; }
        [Required, StringLength(50), Display(Name ="Last name")]
        public string LastName { get; set; }
        [Required, StringLength(255)]
        public string Address { get; set; }
        [Required, StringLength(50)]
        public string Telephone { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan TimeRecorded { get; set; }
        [Column(TypeName ="decimal(18, 2)"), Required, Display(Name ="Wage"), DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Column(TypeName ="date"), Required, Display(Name ="Date Of Birth"), DataType(DataType.Date)]
        public DateTime? Dob { get; set; }

        [ForeignKey("Gender"), Display(Name ="Gender")]
        public int GenderId { get; set; }
        [ForeignKey("Occupation"), Display(Name ="Occupation")]
        public int OccupationId { get; set; }
        [NotMapped, Display(Name ="Fullname")]
        public string FullName
        {
            get
            {
                return string.Concat(LastName + ", " + FirstName);
            }
        }


        //Navigation Properties

        public virtual Gender Gender { get; set; }

        public virtual Occupation Occupation { get; set; }

    }
}
