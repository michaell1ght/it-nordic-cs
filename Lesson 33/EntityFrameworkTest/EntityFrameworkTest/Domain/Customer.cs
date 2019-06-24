using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkTest.Domain
{
    [Table("Customers", Schema = "dbo")]
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }
    }
}