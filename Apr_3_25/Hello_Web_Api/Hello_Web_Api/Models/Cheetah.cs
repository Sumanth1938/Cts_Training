namespace Hello_Web_Api.Models
{
    public class Cheetah
    {
        public string? Name { get; set; }
        public int? age { get; set; }
        public void updateDetails(string a, int n)
        {
            Name = a;
            age = n;
        }
    }
}
