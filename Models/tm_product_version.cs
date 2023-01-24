using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Xml.Linq;
using TEST.Models;

namespace TEST.Models
{
    [Table("tm_product_version")]
    public class TmProductVersion
    {
        public int id { get; set; }
        [Display(Name = "Título")]
        public string? title { get; set; }
        public string? build_number { get; set; }
        public DateTime? build_date { get; set; }
        public DateTime? EOL { get; set; }
        public int product_id { get; set; }

        [ForeignKey("product_id")]
        public TmProduct? TmProduct { get; set; }
    }
}