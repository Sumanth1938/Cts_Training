using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hello_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrocController : ControllerBase
    {
        [HttpGet]
        [Route("SUmantH")]
        public async Task<IActionResult> helloWorld()
        {
            string blogId = "HEllo world";
            return Ok(blogId);

        }

        [HttpGet]
        [Route("randomCroc")]
        public async Task<IActionResult> randomCroc()
        {
            
            CrocsOps crocsOps = new CrocsOps();
            Crocodile emptyobj = crocsOps.createRandomCrocs();
            return Ok(emptyobj);

        }
    }
    class Crocodile
    {
        public double? Weight { get; set; }
        public string? CommonName { get; set; }
        public string? ScientificName { get; set; }
        public double? Length { get; set; }
        public bool? isExtinct { get; set; }
        public string? ExtinctionStatus { get; set; }
        public int? Lifespan { get; set; }
    }
    class CrocsOps
    {
        public Crocodile ReadCrocodile(int i)
        {
            Crocodile crocodile = new Crocodile();
            Console.WriteLine($"Enter the weight of the crocodile {i + 1} :");
            try { crocodile.Weight = Convert.ToInt32(Console.ReadLine()); } catch { }
            Console.WriteLine($"Enter the common name of the crocodile {i + 1} : ");
            crocodile.CommonName = Console.ReadLine();
            Console.WriteLine($"Enter the scientific name of the crocodile {i + 1} : ");
            crocodile.ScientificName = Console.ReadLine();
            Console.WriteLine($"Enter the length of the crocodile {i + 1} in meters: ");
            crocodile.ExtinctionStatus = Console.ReadLine();
            Console.WriteLine($"Enter the lifespan of the crocodile {i + 1} in years: ");
            try { crocodile.Lifespan = Convert.ToInt32(Console.ReadLine()); } catch { }
            Console.WriteLine();
            return crocodile;
        }
        public Crocodile createRandomCrocs()
        {
            Crocodile crocodile = new Crocodile();
            crocodile.CommonName = "MSD";
            crocodile.ScientificName = "ashdjahsd";
            crocodile.ScientificName = "alskdhasluiydfoue";
            crocodile.Lifespan = 100;
            crocodile.Length = 100;
            return crocodile;
        }
        public bool checkCrocodileDetails(Crocodile crocodile)
        {
            if (crocodile.Weight == null || crocodile.CommonName == null || crocodile.ScientificName == null || crocodile.Length == null || crocodile.Lifespan == null)
            {
                return false;
            }
            return true;
        }
        public List<Crocodile> readCrocodiles()
        {
            List<Crocodile> crocodiles = new List<Crocodile>();
            Console.WriteLine("Enter the number of crocodiles: ");
            int numberOfCrocodiles = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCrocodiles; i++)
            {
                Crocodile crocodile = ReadCrocodile(i);
                crocodiles.Add(crocodile);
            }
            Console.WriteLine();
            return crocodiles;
        }
        public void DisplayCrocodileList(List<Crocodile> crocodiles)
        {
            Console.WriteLine("Crocodile List: ");
            Console.WriteLine();
            foreach (Crocodile crocodile in crocodiles)
            {
                Console.WriteLine($"Weight: {crocodile.Weight}");
                Console.WriteLine($"Common Name: {crocodile.CommonName}");
                Console.WriteLine($"Scientific Name: {crocodile.ScientificName}");
                Console.WriteLine($"Length: {crocodile.Length} m");
                Console.WriteLine($"Lifespan: {crocodile.Lifespan} years");
                Console.WriteLine();
            }
        }
    }

}
