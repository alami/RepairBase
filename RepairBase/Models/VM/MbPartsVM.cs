namespace RepairBase.Models.VM
{
    public class MbPartsVM
    {
        public Mb mb { get; set; } = new Mb();
        public string[] strVideoSrcLocated { get; set; } = [];
        public string[] strPartsPNs { get; set; } = [];
    }
}
