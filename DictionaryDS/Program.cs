using System.Collections.Generic;

namespace DictionaryDS
{
    class Program 
    {
        public static void Main(string[] args)
        {
            //Default Dictionary with type
            Dictionary<string,string> number=new Dictionary<string, string>();
            //Add Key Value to the Dictionary Array
            number.Add("number1","432342342");
            // Cannot have duplicate key will cause Execption
            
            // foreach(var dict in number)
            // {
            //     System.Console.WriteLine(dict.Key + dict.Value );
            // }

            CustomDictionary<int,string> names=new CustomDictionary<int, string>();
            names.Add(1,"prem");
            names.Add(2,"prem");
            names.Add(3,"prem");
            names[1]="Student";

            foreach(KeyValue<int,string> data in names)
            {
                System.Console.WriteLine(data.Key+" "+data.Value);
            }
            System.Console.WriteLine(names.ContainsKey(1));
            System.Console.WriteLine(names.ContainsValue("prem"));
            names.Remove(3);
            foreach(KeyValue<int,string> data in names)
            {
                System.Console.WriteLine(data.Key+" "+data.Value);
            }
        }
    }
}