using System;



    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> test = new Matrix<int>("testMatrix.txt");
            Console.WriteLine(test);
        }
    }

