using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using TEST.Models;

namespace TEST.Models
{
    [Table("acc_country")]
    public class AccCountry
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? abbrev { get; set; }

        [InverseProperty("Country")]
        public ICollection<AccAccount>? Accounts { get; set; }
    }
}