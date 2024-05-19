using System.ComponentModel.DataAnnotations;

namespace RepairBase.Models.Dto
{
    public class PartsDto
    {
        public string PN { get; set; }// !2-PN->UPPERCASE!
        public string? CompatiblePN { get; set; }
        public string? AddPNComments { get; set; }
        [Required]
        public PartsType Type { get; set; }
        [Required]
        public string LaptopModel { get; set; }
        public Boolean? IsURL { get; set; }
        public string? ImageData { get; set; } //URL|Local file
        public string? ImageOriginalName { get; set; } //URL|Local file

        public string? Location { get; set; }
        public string? Comments { get; set; }
    }
}
