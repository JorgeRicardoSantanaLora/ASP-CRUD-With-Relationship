using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using TEST.Models;

namespace TEST.Models
{
    [Table("acc_contacts")]
    public class AccContact
    {
        public int id { get; set; }
        [Display(Name = "Name")]
        public string? name { get; set; }
        [Display(Name = "Titulo")]
        public string? title { get; set; }
        [Display(Name = "Departmento")]
        public string? department { get; set; }
        [Display(Name = "Correo Electronico")]
        public string? email { get; set; }
        [Display(Name = "Telefono")]
        public string? phone { get; set; }
        [Display(Name = "Extension")]
        public string? ext { get; set; }

        [Display(Name = "Champion")]
        public Boolean champion { get; set; }
        [Display(Name = "Estado de Contacto")]
        public Boolean status { get; set; }
        [Display(Name = "Cuenta")]
        public int account_id { get; set; }

        [ForeignKey("account_id")]
        public AccAccount? Account { get; set; }
    }
}