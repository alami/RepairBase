using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
namespace RepairBase.Models
{
    public enum OStype
    {
        Windows,
        Linux,
        Mac,
        Unix,
    }
    public enum VideoSrcType
    {
        HDMI,
        rightType_C,
        leftType_C,
        IO_board,
        VGA,
        DisplayPort,
        DVI
    }
    public class Mb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }  //HP,Del,Asus,Lenovo,Sams,MSI
        [Required]
        public string PN { get; set; }     // !3-PN->UPPERCASE!
        public string? CompatiblePN { get; set; }// multiple rec
        [Required]
        public string Parts4test { get; set; }  // y/n/other
        [Required]
        public string How2start { get; set; }
        [Required]
        public string RAMtype { get; set; }    //DDR2-5, builtin
        [Required]
        public int RAMspeed { get; set; }       //Mhz
        [Required]
        public string RAMslot { get; set; }
        [Required]
        public Boolean BuiltinSSD { get; set; }//y/n
        [Required]
        public Boolean Post { get; set; }      //y/n
        [Required]
        public string Video { get; set; }      //n/wtLCD/extScr
        [Required]
        public string VideoInfo { get; set; }  //Post/OS/Blank
        [Required]
        public string VideoSrcLocated { get; set; }  //HDMI/rightType-C/..
        [Required]
        public OStype  OS { get; set; }
        [Required]
        public string AdapterBrand { get; set; }
        [Required]
        public string AdapterWattage { get; set; }
        [Required]
        public string AdapterPN { get; set; }
        [Required]
        public string PowerAdapterType { get; set; } //ACjack/direct2board
        [Required]
        public string RepairInfo { get; set; }       //comment
        [Required]
        public DateTime DateAdded { get; set; }
        public DateTime UserAdded { get; set; }
        //  public int PartsID                  //----Mb2Parts---
    }
}
