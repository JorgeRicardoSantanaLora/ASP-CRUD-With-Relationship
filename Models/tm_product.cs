using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Xml.Linq;
using TEST.Models;

namespace TEST.Models
{
    [Table("tm_product")]
    public class TmProduct
    {
        public int id { get; set; }
        [Display(Name = "Título")]
        public string? title { get; set; }

        [InverseProperty("TmProduct")]
        public ICollection<TmProductVersion>? TmProductVersion { get; set; }
    }
}