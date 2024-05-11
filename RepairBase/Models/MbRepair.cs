using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairBase.Models
{
    public class MbRepair
    {
        [Key]
        public int Id { get; set; }

        public int MbId { get; set; }
        [ForeignKey("MbId")]
        public virtual Mb Mb { get; set; }

        public string? Model { get; set; }
        public string? Revision { get; set; }
        public string? Resistance { get; set; }
        public string? Standby { get; set; }
        public string? WorkingVoltage { get; set; }
        public string? AddInformation { get; set; }
 /*
         BIOS { get; set; }  // multiple files
         Schematic { get; set; }
         BoardView { get; set; }
         AddAttch { get; set; }
 */
    }
}
