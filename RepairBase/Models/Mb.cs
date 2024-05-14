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
        public string Parts4test { get; set; }  // y/n/other
        public string How2start { get; set; }
        public string RAMtype { get; set; }    //DDR2-5, builtin
        public int RAMspeed { get; set; }       //Mhz
        public string RAMslot { get; set; }
        public Boolean BuiltinSSD { get; set; }//y/n
        public Boolean Post { get; set; }      //y/n
        public string Video { get; set; }      //n/wtLCD/extScr
        public string VideoInfo { get; set; }  //Post/OS/Blank
        public string VideoSrcLocated { get; set; }  //HDMI/rightType-C/..
        public OStype  OS { get; set; }        
        public string AdapterBrand { get; set; }
        public string AdapterWattage { get; set; }
        public string AdapterPN { get; set; }
        public string PowerAdapterType { get; set; } //ACjack/direct2board
        public string RepairInfo { get; set; }       //comment
        public DateTime DateAdded { get; set; }
        public DateTime UserAdded { get; set; }
        //  public int PartsID                  //----Mb2Parts---
    }
}
