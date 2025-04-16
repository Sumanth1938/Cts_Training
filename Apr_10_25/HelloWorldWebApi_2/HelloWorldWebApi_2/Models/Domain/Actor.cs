namespace HelloWorldWebApi_2.Models.Domain
{
    public class Actor
    {
        // Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Experience { get; set; }
        public List<string> Awards { get; set; }
        public List<string> Movies { get; set; }
    }
}
