using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPSP_DAL
{
    public class Project : BasicEntity
    {
        [Required]
        [MaxLength(SmallColumnLength)]
        public string Name { get; set; }

        [Required]
        public Department Department { get; set; }

        public string Client { get; set; }

        [Required]
        [MaxLength(MediumColumnLength)]
        public string Manager { get; set; }

        public string Employees { get; set; }

        public string Introduction { get; set; }
        [Required]
        public string Content { get; set; }

        public string Conclusion { get; set; }

        [Required]
        [MaxLength(SmallColumnLength)]
        public string Budget { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }

        [InverseProperty("Projects")]
        public virtual ICollection<User> Users { get; set; }

        //public virtual ICollection<AssignedUser> AssignedUsers { get; set; }

    }

    public enum Department
    {
        Consulting = 10,
        Taxes = 20,
        Law = 30,
        Accounting = 40
    }


}
