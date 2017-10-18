namespace CarService.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserXRole")]
    public partial class UserXRole
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ModifyDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsActive { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_Id { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Role_Id { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
