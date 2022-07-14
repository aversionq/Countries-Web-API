using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CountriesApp.API.CountriesApp.DAL.Entities
{
    public partial class Country
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("capital")]
        [StringLength(50)]
        public string Capital { get; set; }
        [Column("area")]
        public double Area { get; set; }
        [Column("population")]
        public int Population { get; set; }
    }
}
