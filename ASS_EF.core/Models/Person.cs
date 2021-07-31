using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASS_EF.core.Models
{
    public partial class Person
    {
        [Key]
        [Column("ID_Pp")]
        public Guid IdPp { get; set; }
        [Required]
        [Column("Ho_Pp")]
        [StringLength(10)]
        public string HoPp { get; set; }
        [Required]
        [Column("TenDem_Pp")]
        [StringLength(10)]
        public string TenDemPp { get; set; }
        [Required]
        [Column("Ten_Pp")]
        [StringLength(10)]
        public string TenPp { get; set; }
        [Column("NamSinh_Pp")]
        public int NamSinhPp { get; set; }
        [Column("GioiTinh_Pp")]
        public bool GioiTinhPp { get; set; }

        [InverseProperty("IdDbPpNavigation")]
        public virtual DanhBa DanhBa { get; set; }
    }
}
