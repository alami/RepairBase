using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairBase.Models
{
    public class Mb2Parts
    {
        [Key]
        public int Id { get; set; }
        public Boolean IsBase { get; set; } //or Compatible Parts
        public int MbId { get; set; }
        [ForeignKey("MbId")]
        public virtual Mb Mb { get; set; }
        public int PartsId { get; set; }
        [ForeignKey("PartsId")]
        public virtual Parts Parts { get; set; }
    }
}
