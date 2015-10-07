

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1__Using_Methods_
{
    class Program
    {
        const int STUDENTS = 5;
        static StudentInformation[] studentInfo = new StudentInformation[STUDENTS];
        static TestInformation[] testInfo = new TestInformation[1];

        static int getInteger()
        {
            int num = 0;
            do
            {
                string sNum = Console.ReadLine();
                if (Int32.TryParse(sNum, out num) == true)
                {
                    break;
                }
                else
                {
                    Console.Write("\nPlease enter a valid number: ");
                }
            } while (true);
            return num;
        }

        static string getString()
        {
            string word = "";
            do
            {
                word = Console.ReadLine();
                if (word.Length != 0)
                {
                    break;
                }
                else
                {
                    Console.Write("\nPlease enter a word: ");
                }
            } while (true);

            return word;
        }

        static decimal calculatePercentage(int num1, int num2)
        {
            decimal convertedNum1 = (decimal)num1;
            decimal convertedNum2 = (decimal)num2;

            decimal percentage = (convertedNum1 / convertedNum2) * 100;
            return percentage;
        }

        struct StudentInformation
        {
            public int studentID;
            public string studentName;
            public int studentScore;
            public bool studentPassed;
            public decimal studentPercentage;

            public StudentInformation(int studentID, int studentScore, string studentName, bool studentPassed, decimal studentPercentage)
            {
                this.studentID = studentID;
                this.studentName = studentName;
                this.studentScore = studentScore;
                this.studentPassed = studentPassed;
                this.studentPercentage = studentPercentage;
            }
        }

        struct TestInformation
        {
            public string testName;
            public int testPass;
            public int testTotal;

            public TestInformation(int testPass, int testTotal, string testName)
            {
                this.testName = testName;
                this.testTotal = testTotal;
                this.testPass = testPass;
            }
        }

        static void getStudentInfo()
        {
            for (int i = 0; i < STUDENTS; i++)
            {
                Console.Write("Enter student " + (i + 1) + "'s ID: ");
                studentInfo[i].studentID = getInteger();

                Console.Write("Enter sudent " + (i + 1) + "'s Name: ");
                studentInfo[i].studentName = getString();

                Console.Write("Enter student " + (i + 1) + "'s Score: ");
                studentInfo[i].studentScore = getInteger();
                Console.WriteLine("\n \n");
            }
        }

        static void retrieveStudentInfo()
        {
            Console.Write("\n\nWould you like to retrieve a students info? (Y/N) ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.Write("Please enter the student ID of the student you wish to retrieve: ");
                int requestedID = getInteger();
                bool foundStudent = false;

                for (int i = 0; i < STUDENTS; i++)
                {
                    if (studentInfo[i].studentID == requestedID)
                    {
                        Console.WriteLine("\n\nStudent ID: " + studentInfo[i].studentID + "\nStudent Name: "
                            + studentInfo[i].studentName + " \nStudent Score: " + studentInfo[i].studentScore);
                        foundStudent = true;
                    }
                }
                if (foundStudent == false)
                {
                    Console.WriteLine("Student not found.\n");
                }
            }
        }

        static void getTestInformation()
        {
            Console.Write("\n\nWould you like to enter information about the test? (Y/N) ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.Write("\n\nEnter the test name: ");
                testInfo[0].testName = getString();

                Console.Write("Enter the total marks for test: ");
                testInfo[0].testTotal = getInteger();

                Console.Write("Enter the pass mark for the test: ");
                testInfo[0].testPass = getInteger();

                percentageMarks();
                hasPassed();
                recordResults();
            }
        }

        static void percentageMarks()
        {
            Console.Write("Would you like to output the percentage mark for each student? (Y/N) ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                for (int i = 0; i < STUDENTS; i++)
                {
                    decimal percentage = calculatePercentage(studentInfo[i].studentScore, testInfo[0].testTotal);
                    Console.WriteLine("Student " + (i + 1) + ": " + percentage + "%");
                    studentInfo[i].studentPercentage = percentage;
                }
            }
        }

        static void hasPassed()
        {
            Console.Write("\n\nWould you like to find out who has failed and who has passed? (Y/N) ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("\n");
                for (int i = 0; i < STUDENTS; i++)
                {
                    if (studentInfo[i].studentScore - testInfo[0].testPass >= 0)
                    {
                        Console.WriteLine("Student " + (i + 1) + " has passed.");
                        studentInfo[i].studentPassed = true;
                    }
                    else
                    {
                        Console.WriteLine("Student " + (i + 1) + " has failed.");
                        studentInfo[i].studentPassed = false;
                    }
                }
            }
        }

        static void writeToFile(string text)
        {
            Console.Write("\n\nWould you like to record the test results to a file? (Y/N) ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\sclay\\Documents\\A Level\\Computing\\Assessment Task October 2015\\Test Results\\" + testInfo[0].testName + ".txt");
                file.WriteLine(text);
                file.Close();
                Console.WriteLine("Successfully wrote information to file!");
            }
        }

        static void recordResults()
        {
            string text = "Test: " + testInfo[0].testName + "\r\nTotal Marks: " + testInfo[0].testTotal + "\r\nPass Mark: " + testInfo[0].testPass;
            for (int i = 0; i < STUDENTS; i++)
            {
                text += "\r\n\r\nName: " + studentInfo[i].studentName + "   ID: " + studentInfo[i].studentID + "   Mark: " + studentInfo[i].studentScore
                    + "    Percentage: " + studentInfo[i].studentPercentage + "% " + "    Pass: " + studentInfo[i].studentPassed + "\r\n\r\n";
            }

            writeToFile(text);
        }

        static void Main(string[] args)
        {
            getStudentInfo();
            retrieveStudentInfo();
            getTestInformation();
            Console.ReadLine();
        }
    }
}
