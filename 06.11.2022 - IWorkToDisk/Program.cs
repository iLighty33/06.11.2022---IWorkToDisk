using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Indexers_lab
{

    interface ICounter
    {
        int count { get; }
        string Name { get; set; }
        void BriefPrint();
    }
    interface IWhenCreated
    {
        DateTime Created { get; }
    }
    interface IWorkToDisk
    {
        string filename { get; set; }
        bool SaveToDisk(IWorkToDisk obj, string _name, int _WorkTimeIndex, int _summOfHours, DateTime _CreatedTime);
        bool ReadFromDisk();
    }
    class Program
    {
        static void Main(string[] args)
        {

            var BobTime = new EmployerTime();
            var JohnTime = new EmployerTime();
            //ICounter Bill = JohnTime;
            //Console.WriteLine(JohnTime.Name);
            //EmployerTime.rename(Bill, "Billy123");
            //Console.WriteLine(Bill.Name);
            //BobTime.Print();
            BobTime[2] = 7;

            BobTime.Print();
            BobTime.BriefPrint();
            Console.WriteLine($"\nОтработано {BobTime.count} часов");
            Console.WriteLine(BobTime.Created);

            JohnTime[0] = 7;
            Console.WriteLine(JohnTime.Created);
            IWhenCreated obj = new EmployerTime();
            EmployerTime.TimeStamp(obj);
            //Console.WriteLine(obj.Created.ToString());
            Console.ReadKey();

            // Homework

            IWorkToDisk obj2 = new EmployerTime();
            obj2.SaveToDisk(obj2, BobTime.Name, BobTime[2], BobTime.count, BobTime.Created);

            obj2.ReadFromDisk();

            Console.ReadKey();
        }
    }
}