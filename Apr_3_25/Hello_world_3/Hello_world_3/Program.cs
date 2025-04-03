// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Crocodile croc1 = new Crocodile();
//croc1.weight = 4500;
//croc1.CommonName = "Mugger Croccodile";
//croc1.ScientificName = "Crocodylus palustris";
//croc1.Length = 11;
//croc1.isExtinct = false;
//croc1.ExtinctionStatus = "Vulnerable";
//croc1.Lifespan = 30;

//Console.WriteLine(croc1);
//croc1.collectTheDataFromCrocs();



//croc1.displayFeaturesOfCrocodile();

//class Crocodile
//{
//    public int weight { get; set; }
//    public string? CommonName { get; set; }
//    public string? ScientificName { get; set; }
//    public double? Length { get; set; }
//    public bool isExtinct { get; set; }
//    public string? ExtinctionStatus { get; set; }
//    public int Lifespan { get; set; }

//    public void displayFeaturesOfCrocodile()
//    {
//        Console.WriteLine($"Croc Weight: {weight} kg");
//        Console.WriteLine($"Croc CommonName: {CommonName}");
//        Console.WriteLine($"Croc Length :    {Length}");
//    }
//    public void collectTheDataFromCrocs()
//    {
//        Console.WriteLine("Enter the crocodile Name: ");
//        weight = int.Parse(Console.ReadLine());
//        Console.WriteLine("Enter the Crocodile CommonName: ");
//        CommonName = Console.ReadLine();
//        Console.WriteLine("Enter the crocodile Length: ");
//        Length = double.Parse(Console.ReadLine());
//    }
//}

CrocsOps CrocsOps = new CrocsOps();
List<Crocodile> crocodiles = CrocsOps.readCrocodiles();
if (CrocsOps.checkCrocodileDetails(crocodiles[0]))
{
    Console.WriteLine("Crocodile details are valid.\n");
}
else
{
    Console.WriteLine("Crocodile details are invalid.\n");
}
CrocsOps.DisplayCrocodileList(crocodiles);

class Crocodile
{
    public double? Weight { get; set; }
    public string? CommonName { get; set; }
    public string? ScientificName { get; set; }
    public double? Length { get; set; }
    public bool? isExtinct { get; set; }
    public string? ExtinctionStatus { get; set; }
    public int? Lifespan { get; set; }
    public void DisplayCrocInformation()
    {
        Console.WriteLine($"Crocodile Information: ");
        Console.WriteLine($"Weight: {Weight}");
        Console.WriteLine($"Common Name: {CommonName}");
        Console.WriteLine($"Scientific Name: {ScientificName}");
        Console.WriteLine($"Length: {Length} m");
        Console.WriteLine($"Is Extinct: {isExtinct}");
        Console.WriteLine($"Extinction Status: {ExtinctionStatus}");
        Console.WriteLine($"Lifespan: {Lifespan} years");
    }
}


class CrocsOps
{
    public Crocodile ReadCrocodile(int i)
    {
        Crocodile crocodile = new Crocodile();
        Console.WriteLine($"Enter the weight of the crocodile {i+1} :");
        try { crocodile.Weight = Convert.ToInt32(Console.ReadLine()); } catch { }
        Console.WriteLine($"Enter the common name of the crocodile {i+1} : ");
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
    public bool checkCrocodileDetails(Crocodile crocodile)
    {
        if (crocodile.Weight == null || crocodile.CommonName == null || crocodile.ScientificName == null || crocodile.Length == null  || crocodile.Lifespan == null)
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
