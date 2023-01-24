using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using TEST.Models;

namespace TEST.Models
{
    [Table("acc_account")]
    public class AccAccount
    {
        public int id { get; set; }
        [Display(Name = "Título")]
        public string? title { get; set; }
        [Display(Name = "WK Account Number 'SAP'")]
        public int wk_number { get; set; }
        [Display(Name = "País")]
        public int country_id { get; set; }
        [Display(Name = "Estado de Cuenta")]
        public Boolean account_status { get; set; }

        [ForeignKey("country_id")]
        public AccCountry? Country { get; set; }

        [InverseProperty("Account")]
        public ICollection<AccContact>? Contact { get; set; }
    }
}