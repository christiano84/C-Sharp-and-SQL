using System;
using System.Globalization;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        // ------ FUNCTIONS ----------

        static void PrintArray(int[] intArray, string mess)
        {
            foreach(int k in intArray)
            {
                Console.WriteLine("{0} : {1}", mess, k);
            }
        }
        static double DoDivision(double x, double y)
        {
            if (y == 0)
            {
                throw new System.DivideByZeroException();
            }

            return x / y;
        }

        // ------ END OF FUNCTIONS ------
        static void Main(string[] args)
        {
            int[] favNums = new int[3];
            favNums[0] = 23;
            Console.WriteLine("favNum 0 : {0}", favNums[0]);
            string[] customers = { "Bob", "Sally", "Sue" };
            var employees = new[] { "Mike", "Paul", "Rick" };
            object[] randomArray = { "Paul", 45, 1.234 };
            Console.WriteLine("Array Size : {0}", randomArray.Length);

            int[] randNums = { 1, 4, 9, 2 };
            PrintArray(randNums, "ForEach");
            Console.WriteLine("--------------------");

            Array.Sort(randNums);
            Array.Reverse(randNums);


            Console.WriteLine("1 at index : {0}", Array.IndexOf(randNums, 1));
            randNums.SetValue(0, 1);
            int[] srcArray = { 1, 2, 3 };
            int[] destArray = new int[2];
            int startInd = 0;
            int length = 2;
            Array.Copy(srcArray, startInd, destArray, 0, length);
            PrintArray(destArray, "Copy");
            
            Array anotherArray = Array.CreateInstance(typeof(int), 10);

            srcArray.CopyTo(anotherArray, 5);

            foreach (int m in anotherArray)
            {
                Console.WriteLine("CopyTo : {0} ", m);
            }

            int[] numArray = { 1, 11, 22 };
            //Console.WriteLine("> 10 : {0}", Array.Find(numArray, GT10));

            int age = 17;
            if ((age >= 5) && (age <= 7))
            {
                Console.WriteLine("Go to elementary school");
            }
            if ((age > 7) && (age < 13))
            {
                Console.WriteLine("Go to middle school");
            }
            if ((age > 13) && (age < 19))
            {
                Console.WriteLine("Go to high school");
            }
            else
            {
                Console.WriteLine("Go to college");
            }

            if ((age < 14) || (age > 67))
            {
                Console.WriteLine("You shouldnt work");
            }

            Console.WriteLine("! true = " + (!true));

            bool canDrive = (age >= 16 ? true : false);

            switch (age)
            {
                case 1:
                case 2:
                    Console.WriteLine("Go to Day Care");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("Go to Preschool");
                    break;
                case 5:
                    Console.WriteLine("Go to Kindergarten");
                    break;
                default:
                    Console.WriteLine("Go to another school");
                    goto OtherSchool;
            }
        OtherSchool:
            Console.WriteLine("Elementary, Middle, High School");

            string name2 = "Derek";
            string name3 = "Derek";

            if (name2.Equals(name3, StringComparison.Ordinal))
            {
                Console.WriteLine("Names are equal");
            }

            // WHILE LOOP
            int i = 1;
            while (i <= 10)
            {
                if (i % 2 == 0)
                {
                    i++;
                    continue;
                }

                if (i == 9) break;
                Console.WriteLine(i);
                i++;
            }

            // DO WHILE LOOP

            //Random rnd = new Random();
            //int secretNumber = rnd.Next(1, 11);
            //int numberGuessed = 0;
            //Console.WriteLine("Random Num : ", secretNumber);

            //do
            //{
            //    Console.WriteLine("Enter a number between 1 and 10");
            //    numberGuessed = Convert.ToInt32(Console.ReadLine());
            //} while (secretNumber != numberGuessed);

            //Console.WriteLine($"You guessed it it was {secretNumber}");

            double num1 = 5;
            double num2 = 0;

            try
            {
                Console.WriteLine("5 / 0 = {0}", DoDivision(num1, num2));
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("You can't divide by zero");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Cleaning Up");
            }

            StringBuilder sb = new StringBuilder("Random Text");
            StringBuilder sb2 = new StringBuilder("More stuff that is very important", 256);
            Console.WriteLine("Capacity : {0}", sb2.Capacity);
            Console.WriteLine("Length : {0}", sb2.Length);
            sb2.AppendLine("\nMore important text");
            CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
            string bestCust = "Bob Smith";
            sb2.AppendFormat(enUS, "Best Customer : {0}", bestCust);
            Console.WriteLine(sb2.ToString());
            sb2.Replace("text", "characters");
            Console.WriteLine(sb2.ToString());
            sb2.Clear();
            sb2.Append("Random Text");
            Console.WriteLine(sb.Equals(sb2));
            sb2.Insert(11, " that's great");
            Console.WriteLine(sb2.ToString());
            sb2.Remove(11, 7);
            Console.WriteLine(sb2.ToString());
        }   
    }
}
    
