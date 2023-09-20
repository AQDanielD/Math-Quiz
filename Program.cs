using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Data.Common;

namespace Math_Quiz
{
    internal class Program
    {
        public class Student
        {
            public string FirstName;
            public string LastName;
            public int Score;
            public DateTime Date;

        }

        static public void Quiz(string fname,string lname, string room,int length)
        {
            FileStream fs = new FileStream("Scores.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            Student student = new Student();

            int total = 0;
            for (int i = 1; i <= length; i++)
            {
                string[] operators = { "+", "-", "*" };
                Random rand = new Random();
                int roperator = rand.Next(operators.Length);
                int num1 = rand.Next(1,10);
                int num2 = rand.Next(1,10);
                Console.Write($"Q{i}. {num1} {operators[roperator]} {num2} -> ");
                int answer = 0; 
                switch(roperator)
                {
                    case 0:
                        answer = num1 + num2;
                        break;
                    case 1:
                        answer = num1 - num2;
                        break;
                    case 2:
                        answer = num1 * num2;
                        break;
                }
                int input = 0;
                int timeout = 4;
                bool accepted = true;
                int attempts = 0;
                bool TO = false;
                do
                {
                    attempts++;
                    try
                    {
                        accepted = true;
                        input = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        accepted = false;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("Value needs to be of intiger value -> ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (attempts == timeout)
                        {
                            TO = true;
                        }
                    }
                }while (accepted == false && TO == false);

                if (TO == true)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("failed to enter correct input");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    if (answer == input)
                    {
                        total++;
                    }
                }
            }

            student.Date = DateTime.Now.Date;
            student.FirstName = fname; 
            student.LastName = lname; 
            student.Score = total;
            Console.WriteLine($"{student.FirstName},{student.LastName},{student.Score}/{length},{student.Date}");
            sw.WriteLine($"{student.FirstName},{student.LastName},{student.Score},{student.Date}");
            sw.Close();
            fs.Close();
            Console.ReadKey();
        }
        static void Main(string[] args)
        {

            Console.Write("First name -> ");

            string fname = Console.ReadLine();

            Console.Write("Second name -> ");
            
            string lname = Console.ReadLine();

            Console.Write("Class -> ");
            
            string room = Console.ReadLine();

            Console.Write("Questions -> ");

            int questions = 0;
            int timeout = 4;
            bool accepted = true;
            int attempts = 0;
            bool TO = false;
            do
            {
                attempts++;
                try
                {
                    accepted = true;
                    questions = int.Parse(Console.ReadLine());
                }
                catch
                {
                    accepted = false;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("Value needs to be of intiger value -> ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (attempts == timeout)
                    {
                        TO = true;
                    }
                }
            } while (accepted == false && TO == false);

            if (TO==true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("failed to enter correct input");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Quiz(fname, lname, room, questions);
            }
            Console.ReadKey();

        }
    }
}
