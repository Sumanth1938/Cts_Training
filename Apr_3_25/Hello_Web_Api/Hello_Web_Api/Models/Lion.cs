namespace Hello_Web_Api.Models
{
    public class Lion
    {
        public string? CommonName { get; set; }
        public int? strength { get; set; }
        public void updateDetails(string a, int n)
        {
            CommonName = a;
            strength = n;
        }
    }
}
