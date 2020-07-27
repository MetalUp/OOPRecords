using MetalUp;
using OOPRecords;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentRep = new StudentRepository();
            var init = new Initializer();
            init.Seed(studentRep);

            while (true)
            {
                int id = ConsolePlus.ReadInteger("Enter Student Id: ", 1, studentRep.AllStudents().Count);
                Student s = studentRep.FindStudentById(id);
                Console.WriteLine(s);
            }
                    
        }
    }
}
