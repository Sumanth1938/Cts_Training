// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<string> list = new List<string>();
list.Add("Sumanth");
list.Add("Abhiram");
list.Add("Mukesh");
list.Add("Paul");
list.Add("Vishal");

int countOfNames = 0;

int countNumberOfNames(List<string>list)
{
    for (int i = 0; i < 100; i++)
    {
        try
        {
            if (list[i].ElementAt(i) != null)
            {
                countOfNames++;
            }
        }
        catch (Exception e)
        {
            //Console.WriteLine(e.Message);
        }
    }
    return countOfNames;
}


Console.WriteLine(countNumberOfNames(list));


//foreach (string name in list)
//{
//    countOfNames++;
//}


//for(int i = 0; i < list.Count; i++)
//{
//    Console.WriteLine(list[i]);
//}
//Console.WriteLine();
//foreach(string s in list)
//{
//    Console.WriteLine(s);
//}
