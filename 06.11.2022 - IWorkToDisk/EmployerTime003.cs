using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;

namespace Indexers_lab
{
    enum DayOfWeek
    {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }
    class EmployerTime : ICounter, IWhenCreated, IWorkToDisk
    {
        private int[] WorkTime;
        private int summOfHours;
        private DateTime CreatedTime;
        private string name;
        public string Name { get; set; }
        public DateTime Created
        {
            get 
            {
                Console.WriteLine($"Объект {this.ToString()} был создан {CreatedTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}");    
                return CreatedTime; 
            }    
        }
        public int count
        {
            get
            {
                foreach (var item in WorkTime)
                {
                    summOfHours += item;
                }
                return summOfHours;
            }
        }



        public static void TimeStamp(IWhenCreated obj)
        {
            Console.WriteLine(obj.Created.ToString());
        }
        public void BriefPrint()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{item} - {WorkTime[(int)item]}");
            }
        }
        public EmployerTime(string _name)
        {
            WorkTime = new int[7];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            Name = _name;
        }
        public EmployerTime()
        {
            WorkTime = new int[7];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            this.name = "John Dow #" + CreatedTime.ToString();
        }

        public static ICounter rename(ICounter obj, string newname)
        {
            obj.Name = newname;
            return obj;
        }

        public int this[int index]
        {
            set { WorkTime[index] = value; }
            get { return WorkTime[index]; }
        }
        public void Print()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"В день {item} отработано {WorkTime[(int)item]}");
            }

        }

        // Homework

        private string nameOfFile = "";

        string IWorkToDisk.filename
        {
            get => nameOfFile = System.IO.Path.GetFileNameWithoutExtension(@"C:\Study\MyProjects\01. C sharp\02. HomeWork\06.11.2022 - IWorkToDisk\06.11.2022 - IWorkToDisk\06.11.2022 - IWorkToDisk\bin\Debug\myFile.txt");
            set => nameOfFile = value;
        }

        bool IWorkToDisk.SaveToDisk(IWorkToDisk obj, string _name, int _WorkTimeIndex, int _summOfHours, DateTime _CreatedTime)
        {
            string myText = $"Имя файла: {obj.filename.ToString()}" + $" Имя сотрудника:{_name}" + $" Рабочее время {_WorkTimeIndex}" +
                $" Сумма часов: {_summOfHours}" + $" Дата создания файла: {_CreatedTime}" ;

            File.WriteAllText("myFile.txt", myText);

            Console.WriteLine("Записано");

            return true;
        }

        bool IWorkToDisk.ReadFromDisk()
        {
            var EmployyeeTable = new EmployerTime("myFile.txt");
            var _employyeeTable = new List<string>();
            _employyeeTable = EmployyeeTable.ReadString();

            foreach (var item in _employyeeTable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Считано");

            return true;
        }

        public List<string> ReadString()
        {
            var sr = new StreamReader(this.Name);
            var _arr = new List<string>();
            string _tmp;
            while ((_tmp = sr.ReadLine()) != null)
            {
                _arr.Add(_tmp);
            }
            sr.Close();
            return _arr;
        }
    }
}