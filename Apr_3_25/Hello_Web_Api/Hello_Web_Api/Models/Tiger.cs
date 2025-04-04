namespace Hello_Web_Api.Models
{
    public class Tiger
    {
        public string? CommonName { get; set; }
        public string? ScientificName { get; set; }
        public void updateDetails(string a, string n)
        {
            CommonName = a;
            ScientificName = n;
        }
    }
}
