using Hello_Web_Api.Models;
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

            Crocodile msd = new Crocodile();
            var commoname = "MSDJKSH";
            var scientificName = "IdontKnow";
            msd.updateDetails(commoname, scientificName);
            return Ok(msd);
        }

        [HttpGet]
        [Route("Cheetah")]
        public async Task<IActionResult> Cheetahs()
        {

            Cheetah cheetah = new Cheetah();
            var name = "Cheetah";
            var age = 100;
            cheetah.updateDetails(name, age);
            return Ok(cheetah);
        }

        [HttpGet]
        [Route("Elephant")]
        public async Task<IActionResult> Elephants()
        {

            Elephant elephant = new Elephant();
            var Commonname = "Elephant";
            var weight = 1000;
            elephant.updateDetails(Commonname, weight);
            return Ok(elephant);
        }


        [HttpGet]
        [Route("Lion")]
        public async Task<IActionResult> Lions()
        {

            Lion lion = new Lion();
            var Commonname = "Liion";
            var strength = 300;
            lion.updateDetails(Commonname, strength);
            return Ok(lion);
        }

        [HttpGet]
        [Route("Monkey")]
        public async Task<IActionResult> Monkeys()
        {

            Monkey monkey = new Monkey();
            var Commonname = "Monkey";
            var tailLength = 89;
            monkey.updateDetails(Commonname, tailLength);
            return Ok(monkey);
        }

        [HttpGet]
        [Route("Tiger")]
        public async Task<IActionResult> Tigers()
        {

            Tiger tiger = new Tiger();
            var Commonname = "Tiger";
            var power = "IdontKnow";
            tiger.updateDetails(Commonname, power);
            return Ok(tiger);
        }


        [HttpPost]
        [Route("AddCore")]
        public async Task<IActionResult> CreateCroc([FromBody] Crocodile crocodile)
        {
            var temCroc =crocodile;
           return Ok("Core recieved");
        }

        [HttpPost]
        [Route("AddCore2")]
        public async Task<IActionResult> CreateCroc2([FromBody] Crocodile crocodile)
        {
            var temCroc = crocodile;
            return Ok(temCroc);
        }

        [HttpPost]
        [Route("AddNums")]
        public async Task<IActionResult> AddNums([FromBody] Numbers numbers)
        {
            var number1 = numbers.firstNumber;
            var number2 = numbers.secondNumber;
            displays d = new displays();
            d.additions(number1,number2);
            d.subtractions(number1,number2);
            d.divisions(number1,number2);
            d.multiplications(number1,number2);

            return Ok(d);
        }
    }

    public class displays
    {
        public int addition { get; set; }
        public int subtraction { get; set; }
        public int multiplication { get; set; }
        public int division { get; set; }

        public void additions(int a,int b)
        {
            addition = a + b;
        }
        public void subtractions(int a, int b)
        {
            subtraction = a -b;
        }
        public void multiplications(int a, int b)
        {
            multiplication = a *b;
        }
        public void divisions(int a, int b)
        {
            division = a / b;
        }
    }
    public class Numbers
    {
        public int firstNumber { get; set; }
        public int secondNumber { get; set; }

        

    }
    //class Crocodile
    //{
    //    public double? Weight { get; set; }
    //    public string? CommonName { get; set; }
    //    public string? ScientificName { get; set; }
    //    public double? Length { get; set; }
    //    public bool? isExtinct { get; set; }
    //    public string? ExtinctionStatus { get; set; }
    //    public int? Lifespan { get; set; }
    //    public Crocodile createRandomCrocs()
    //    {
    //        Crocodile crocodile = new Crocodile();
    //        crocodile.CommonName = "MSD";
    //        crocodile.ScientificName = "ashdjahsd";
    //        crocodile.ScientificName = "alskdhasluiydfoue";
    //        crocodile.Lifespan = 100;
    //        crocodile.Length = 100;
    //        return crocodile;
    //    }
    //}
    //class CrocsOps
    //{
    //    public Crocodile ReadCrocodile(int i)
    //    {
    //        Crocodile crocodile = new Crocodile();
    //        Console.WriteLine($"Enter the weight of the crocodile {i + 1} :");
    //        try { crocodile.Weight = Convert.ToInt32(Console.ReadLine()); } catch { }
    //        Console.WriteLine($"Enter the common name of the crocodile {i + 1} : ");
    //        crocodile.CommonName = Console.ReadLine();
    //        Console.WriteLine($"Enter the scientific name of the crocodile {i + 1} : ");
    //        crocodile.ScientificName = Console.ReadLine();
    //        Console.WriteLine($"Enter the length of the crocodile {i + 1} in meters: ");
    //        crocodile.ExtinctionStatus = Console.ReadLine();
    //        Console.WriteLine($"Enter the lifespan of the crocodile {i + 1} in years: ");
    //        try { crocodile.Lifespan = Convert.ToInt32(Console.ReadLine()); } catch { }
    //        Console.WriteLine();
    //        return crocodile;
    //    }
    //    public Crocodile createRandomCrocs()
    //    {
    //        Crocodile crocodile = new Crocodile();
    //        crocodile.CommonName = "MSD";
    //        crocodile.ScientificName = "ashdjahsd";
    //        crocodile.ScientificName = "alskdhasluiydfoue";
    //        crocodile.Lifespan = 100;
    //        crocodile.Length = 100;
    //        return crocodile;
    //    }
    //    public bool checkCrocodileDetails(Crocodile crocodile)
    //    {
    //        if (crocodile.Weight == null || crocodile.CommonName == null || crocodile.ScientificName == null || crocodile.Length == null || crocodile.Lifespan == null)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    public List<Crocodile> readCrocodiles()
    //    {
    //        List<Crocodile> crocodiles = new List<Crocodile>();
    //        Console.WriteLine("Enter the number of crocodiles: ");
    //        int numberOfCrocodiles = Convert.ToInt32(Console.ReadLine());
    //        for (int i = 0; i < numberOfCrocodiles; i++)
    //        {
    //            Crocodile crocodile = ReadCrocodile(i);
    //            crocodiles.Add(crocodile);
    //        }
    //        Console.WriteLine();
    //        return crocodiles;
    //    }
    //    public void DisplayCrocodileList(List<Crocodile> crocodiles)
    //    {
    //        Console.WriteLine("Crocodile List: ");
    //        Console.WriteLine();
    //        foreach (Crocodile crocodile in crocodiles)
    //        {
    //            Console.WriteLine($"Weight: {crocodile.Weight}");
    //            Console.WriteLine($"Common Name: {crocodile.CommonName}");
    //            Console.WriteLine($"Scientific Name: {crocodile.ScientificName}");
    //            Console.WriteLine($"Length: {crocodile.Length} m");
    //            Console.WriteLine($"Lifespan: {crocodile.Lifespan} years");
    //            Console.WriteLine();
    //        }
    //    }
    //}

}
