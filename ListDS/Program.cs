namespace ListDS
{
    class Program 
    {
        public static void Main(string[] args)
        {
            CustomList<int> numbersList=new CustomList<int>();
            numbersList.Add(10);
            numbersList.Add(20);
            numbersList.Add(30);
            numbersList.Add(40);
            numbersList.Add(50);
            CustomList<int> numbers=new CustomList<int>();
            int num=numbers[2];
            numbers.Add(60);
            numbers.Add(70);
            numbers.Add(80);
            numbersList.AddRange(numbers);
            numbersList.Add(90);
            numbersList.Insert(9,100);
            numbersList.RemoveAt(9);
            numbersList.Add(100);
            numbersList.InsertRange(2,numbers);
            numbersList.Sort();
            foreach(int data in numbersList)
            {
                System.Console.WriteLine(data);
            }
        }
    }
}