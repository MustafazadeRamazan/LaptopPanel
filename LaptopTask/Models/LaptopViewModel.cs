namespace LaptopTask.Models
{
    public class LaptopViewModel
    {
        private static int id = 0;

        public int Id { get; set; } = id++;
        public string Model { get; set; }
        public string Vendor { get; set; }


        public override string ToString() => string.Format("{0}: {1} - {2}", Id, Vendor, Model);
    }
}
