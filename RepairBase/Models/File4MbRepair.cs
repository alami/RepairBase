using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairBase.Models
{
    public enum FILEType
    {
        BIOS,
        Schematic,
        BoardView,
        AddAttachment
    }
    public class File4MbRepair
    {
        [Key]
        public int Id { get; set; }

        public int MbRepairId { get; set; }
        [ForeignKey("MbRepairId")]
        public virtual MbRepair MbRepair { get; set; }
        public FILEType Type {  get; set; } 
        public string Location { get; set; }
    }
}
