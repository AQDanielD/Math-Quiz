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


        public void test(int length)
        {
            FileStream Scores = new FileStream("C:\\Users\\AQ232596\\source\\repos\\Math Quiz\\Scores.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(Scores);


            for (int i = 0; i == length; i++)
            {
                string[] operators = { "+", "-", "*" };
                Random rand = new Random();
                int roperator = rand.Next(operators.Length);
                int num1 = rand.Next(0,10);
                int num2 = rand.Next(0,10);
                Console.WriteLine($"{num1} {roperator} {num2}");
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


            }
        }
        static void Main(string[] args)
        {
/*
#Challenge 39
import random
import sympy
def Game_10Q():
  flag = False
  score = 0
  qNum = 0
  while flag == False:
    qNum += 1
    operators = ["+", "*", "-"]
    num1 = random.randint(1, 101)
    num2 = random.randint(1, 101)
    operator = random.randint(0, 2)
    question = f"{num1} {operators[operator]} {num2}"
    print(question)
    ans = sympy.sympify(question)
    userAnswer = int(input("Your answer: "))
    if userAnswer == ans:
      score += 1
    else:
      score += 0
    if qNum == 10:
      print(f"Your sore out of 10 was {score}")
      flag = True

  user_score = {
                f"{name}":f"{score}"
  }
            file = open("Text.txt", "w")
  file.writelines(f"{user_score}")
  file.close()








name = input("Enter your name: ")
print(f"Welcome {name}, to the quiz here is the first question")
Game_10Q()
*/



            

        }
    }
}
