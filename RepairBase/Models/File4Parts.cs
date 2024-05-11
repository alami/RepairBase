using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairBase.Models
{
    public class File4Parts
    {
        [Key]
        public int Id { get; set; }

        public int PartsId { get; set; }
        [ForeignKey("PartsId")]
        public virtual Parts Parts { get; set; }
        public Boolean IsURL {  get; set; }
        public string Location { get; set; }
    }
}
