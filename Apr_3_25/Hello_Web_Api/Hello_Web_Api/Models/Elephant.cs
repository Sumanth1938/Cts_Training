namespace Hello_Web_Api.Models
{
    public class Elephant
    {
        public string? CommonName { get; set; }
        public int weight { get; set; }
        public void updateDetails(string a, int n)
        {
            CommonName = a;
            weight = n;
        }
    }
}
