using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASS_EF.core.Models
{
    [Table("DanhBa")]
    public partial class DanhBa
    {
        [Key]
        [Column("ID_DB_Pp")]
        public Guid IdDbPp { get; set; }
        [Column("Sdt_1")]
        [StringLength(15)]
        public string Sdt1 { get; set; }
        [Column("Sdt_2")]
        [StringLength(15)]
        public string Sdt2 { get; set; }
        [StringLength(40)]
        public string Mail { get; set; }
        [StringLength(150)]
        public string GhiChu { get; set; }

        [ForeignKey(nameof(IdDbPp))]
        [InverseProperty(nameof(Person.DanhBa))]
        public virtual Person IdDbPpNavigation { get; set; }
    }
}
