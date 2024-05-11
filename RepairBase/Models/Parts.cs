using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace RepairBase.Models
{
    public enum PartsType
    {
        IOBoard,
        Laptop,
        LCDScreen,
        LCDScreenAssy,
        Palmrest,
        Battery,
        Heatsink,
        HeatsinkFanAssy,
        Speaker,
        Tablet
    }
    public class Parts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PN { get; set; }// !2-PN->UPPERCASE!
        public string? CompatiblePN { get; set; }
        public string? AddPNComments { get; set; }
        [Required]
        public PartsType Type { get; set; }
        [Required]
        public string LaptopModel { get; set; }
        public string? Image { get; set; } //URL|Local file

        public string? Location { get; set; }
        public string? Comments { get; set; }

        public int MbId { get; set; }
        [ForeignKey("MbId")]
        public virtual Mb Mb { get; set; }
    }
}
