// See https://aka.ms/new-console-template for more information
#region Console Write
//Console.WriteLine("My name is sumanth");
//Console.WriteLine("My name is sumanth");
//Console.WriteLine("My name is sumanth");
//Console.WriteLine("My name is sumanth");
//Console.WriteLine("My name is sumanth");

//var bats = "I am IronMan";
//Console.WriteLine(bats);

#endregion
#region ipl
//var team1 = "LSG";
//var team2 = "Punjab";
//var score = 8;
//var ans = team2 + " defeated " + team1 + " by " + score + " Wickets";
//Console.WriteLine(ans);
#endregion

#region Maths
//var num1 = 10;
//var num2 = 5;

//var add = num1 + num2;
//var sub = num1 - num2;
//var mul = num1 * num2;
//var div = num1 / num2;

//Console.WriteLine(add);
//Console.WriteLine(sub);
//Console.WriteLine(mul);
//Console.WriteLine(div);
#endregion


#region Student Marks
//List<string> names = new List<string>()  {"Rama","Seetha","Lakshman"};
//List<int> Marks = new List<int>();
//List<int> Average = new List<int>();
//for (int i = 0; i < 3; i++)
//{
//    Console.WriteLine("Enter the marks of student " + $"{names[i]}");
//    int sum = 0;
//    for (int j = 0; j < 3; j++)
//    {
//        Console.WriteLine("Enter the marks in subject " + $"{j+1}");
//        string inputString = Console.ReadLine();
//        int number1 = int.Parse(inputString);
//        sum+= number1;
//    }
//    Marks.Add(sum);
//    Console.WriteLine("The total sum of student "+ $"{names[i]}" + " is "+ $"{sum}");
//    Average.Add(sum/3);
//}
//int maxTotal=0, highAvg=0,l=0,k=0,classAvg=0;
//for (int i = 0;i <Marks.Count; i++)
//{
//    if (maxTotal < Marks[i])
//    {
//        maxTotal = Marks[i];
//        l= i;
//    }
//    if (highAvg < Average[i])
//    {
//        highAvg = Average[i];
//        k = i;
//    }
//    classAvg += Average[i];

//}

//Console.WriteLine("The student with highest total is: "+ $"{names[l]}");
//Console.WriteLine("The student with highest average is : " + $"{names[k]}");
//Console.WriteLine("The class Average marks are : " + $"{classAvg / 3}");

#endregion

#region Calculator

//Console.WriteLine("Enter the first number:");
//double num1 = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Enter the second number:");
//double num2 = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Addition: " + Add(num1, num2));
//Console.WriteLine("Subtraction: " + Subtract(num1, num2));
//Console.WriteLine("Multiplication: " + Multiply(num1, num2));
//Console.WriteLine("Division: " + Divide(num1, num2));



//static double Add(double a, double b)
//{
//    return a + b;
//}

//static double Subtract(double a, double b)
//{
//    return a - b;
//}

//static double Multiply(double a, double b)
//{
//    return a * b;
//}
//static double Divide(double a, double b) // Added static
//{
//    if (b != 0)
//    {
//        return a / b;
//    }
//    else
//    {
//        Console.WriteLine("Error: Division by zero.");
//        return double.NaN;
//    }
//}
#endregion

#region Retail shop



public class RetailStore
{
    static string[] productNames = { "Laptop", "Smartphone", "Headphones", "Keyboard", "Mouse" };
    static double[] productPrices = { 1200.00, 800.00, 100.00, 80.00, 30.00 };
    static int[] productStocks = { 10, 20, 30, 25, 50 };

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nWelcome to the Retail Store!");
            Console.WriteLine("Are you a Customer (C) or Shop Owner (O)? (Enter Q to quit)");
            string role = Console.ReadLine().ToUpper();

            if (role == "C")
            {
                CustomerMenu();
            }
            else if (role == "O")
            {
                ShopOwnerMenu();
            }
            else if (role == "Q")
            {
                Console.WriteLine("Exiting the store. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid role. Please enter C or O.");
            }
        }
    }

    static void CustomerMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCustomer Menu:");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Buy Products");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewProducts();
                        break;
                    case 2:
                        BuyProducts();
                        break;
                    case 3:
                        return; // Back to main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    static void ShopOwnerMenu()
    {
        while (true)
        {
            Console.WriteLine("\nShop Owner Menu:");
            Console.WriteLine("1. View Product Stocks");
            Console.WriteLine("2. Update Product Stocks");
            Console.WriteLine("3. Add New Product");
            Console.WriteLine("4. Update Product Price");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewProductStocks();
                        break;
                    case 2:
                        UpdateProductStocks();
                        break;
                    case 3:
                        AddNewProduct();
                        break;
                    case 4:
                        UpdateProductPrice();
                        break;
                    case 5:
                        return; // Back to main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    static void ViewProducts()
    {
        Console.WriteLine("\nAvailable Products:");
        for (int i = 0; i < productNames.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {productNames[i]} - ${productPrices[i]} (Stock: {productStocks[i]})");
        }
    }

    static void BuyProducts()
    {
        ViewProducts();
        Console.Write("Enter the product number you want to buy (or 0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= productNames.Length)
        {
            int productIndex = productNumber - 1;
            Console.Write($"Enter the quantity of {productNames[productIndex]} you want to buy: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0 && quantity <= productStocks[productIndex])
            {
                double totalPrice = productPrices[productIndex] * quantity;
                Console.WriteLine($"Total price: ${totalPrice}");
                productStocks[productIndex] -= quantity;
                Console.WriteLine("Purchase successful!");
            }
            else
            {
                Console.WriteLine("Invalid quantity or insufficient stock.");
            }
        }
        else if (productNumber != 0)
        {
            Console.WriteLine("Invalid product number.");
        }
    }

    static void ViewProductStocks()
    {
        Console.WriteLine("\nProduct Stocks:");
        for (int i = 0; i < productNames.Length; i++)
        {
            Console.WriteLine($"{productNames[i]}: {productStocks[i]}");
        }
    }

    static void UpdateProductStocks()
    {
        ViewProductStocks();
        Console.Write("Enter the product number to update stock: ");
        if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= productNames.Length)
        {
            int productIndex = productNumber - 1;
            Console.Write($"Enter the new stock for {productNames[productIndex]}: ");
            if (int.TryParse(Console.ReadLine(), out int newStock))
            {
                productStocks[productIndex] = newStock;
                Console.WriteLine("Stock updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid stock value.");
            }
        }
        else
        {
            Console.WriteLine("Invalid product number.");
        }
    }

    static void AddNewProduct()
    {
        Console.Write("Enter the product name: ");
        string newProductName = Console.ReadLine();
        Console.Write("Enter the product price: ");
        if (double.TryParse(Console.ReadLine(), out double newProductPrice))
        {
            Console.Write("Enter the initial stock: ");
            if (int.TryParse(Console.ReadLine(), out int newProductStock))
            {
                Array.Resize(ref productNames, productNames.Length + 1);
                Array.Resize(ref productPrices, productPrices.Length + 1);
                Array.Resize(ref productStocks, productStocks.Length + 1);

                productNames[productNames.Length - 1] = newProductName;
                productPrices[productPrices.Length - 1] = newProductPrice;
                productStocks[productStocks.Length - 1] = newProductStock;

                Console.WriteLine("Product added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid stock value");
            }
        }
        else
        {
            Console.WriteLine("Invalid price value");
        }
    }

    static void UpdateProductPrice()
    {
        ViewProducts();
        Console.Write("Enter the product number to update price: ");
        if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= productNames.Length)
        {
            int productIndex = productNumber - 1;
            Console.Write($"Enter the new price for {productNames[productIndex]}: ");
            if (double.TryParse(Console.ReadLine(), out double newPrice))
            {
                productPrices[productIndex] = newPrice;
                Console.WriteLine("Price updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid price value.");
            }
        }
        else
        {
            Console.WriteLine("Invalid product number.");
        }
    }
}
#endregion