namespace RepairBase.Models.VM
{
    public class MbPartsVM
    {
        public Mb Mb { get; set; } = new Mb();
        public string[] StrVideoSrcLocated { get; set; } = [];
        public int[] PartsIds { get; set; } = [];
    }
}
