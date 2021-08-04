using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASS_EF.core.Models
{
    [Keyless]
    public partial class VwPeopleDanhba
    {
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(42)]
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public bool Sex { get; set; }
        [StringLength(15)]
        public string Phone1 { get; set; }
        [StringLength(15)]
        public string Phone2 { get; set; }
        [StringLength(40)]
        public string Mail { get; set; }
        [StringLength(150)]
        public string GhiChu { get; set; }
    }
}
