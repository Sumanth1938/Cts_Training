namespace Hello_Web_Api.Models
{
    public class Monkey
    {
        public string? CommonName { get; set; }
        public int? tailLength { get; set; }
        public void updateDetails(string a, int n)
        {
            CommonName = a;
            tailLength = n;
        }
    }
}
