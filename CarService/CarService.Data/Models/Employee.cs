namespace CarService.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Pesel { get; set; }

        public string Phone { get; set; }

        public int? Position_Id { get; set; }

        public decimal Salary { get; set; }

        public int? Address_Id { get; set; }

        public int User_Id { get; set; }

        public bool IsVerified { get; set; }

        public virtual Address Address { get; set; }

        public virtual Position Position { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
