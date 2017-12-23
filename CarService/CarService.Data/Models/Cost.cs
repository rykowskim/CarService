namespace CarService.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cost")]
    public partial class Cost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool IsActive { get; set; }

        public int Order_Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual Order Order { get; set; }
    }
}
