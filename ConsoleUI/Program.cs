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


            var students = studentRep.AllStudents();
            ConsolePlus.WriteList(students, "\n");
                    
        }
    }
}
