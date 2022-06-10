using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace VWHFLY_PMI
{
    class Dormitory
    {
        public List<Room> Rooms { get; set; }
        public void CreateNewRoom()
        {
            Console.WriteLine("Enter number of your new room: ");
            int roomnumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 5; i++)
            {
                if (roomnumber > 999 || roomnumber < 100 && i != 5)
                {
                    Console.WriteLine($"Room number cannot be less than a 100 and more than 999! \nTry again, you have {5 - i} more tries!");
                    Console.Write("Your new room number is: ");
                    roomnumber = int.Parse(Console.ReadLine());
                }
                else if (i == 5)
                {
                    Console.WriteLine("Too much wrong tries! Try again later! \nPress any key to continue!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else break;
            }
            var room = new Room(roomnumber);
            Rooms.Add(room);
            Console.WriteLine("The room was created! \nPress any key to continue!");
            Console.ReadKey();
            room.All();
        }
        public void SaveRooms(List<Room> Rooms, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Room>));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fStream, Rooms);
            fStream.Close();
        }
        public void LoadRooms(string Path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Room>));
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            var OldRooms = xmlSerializer.Deserialize(fStream) as List<Room>;
            fStream.Close();
            Rooms.AddRange(OldRooms);
        }
        public void GetFreeCapacity()
        {
            int result = 0;
            for (int i = 0; i < Rooms.Count; i++)
            {
                result += (6 - Rooms[i].NumberOfStudents);
            }
            if (result == 0) Console.WriteLine("Suddenly it's any place for new students(");
            else Console.WriteLine($"There are {result} free places!");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
        }
        public void GetRooms()
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                Console.WriteLine($"Roomnumber: {Rooms[i].RoomNumber} Number of students: {Rooms[i].NumberOfStudents};");
            }
        }
        public void Exit() 
        {
            Console.WriteLine("Have a nice day! \nTab any key to finish the work!");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public void All()
        {
            Rooms = new List<Room>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please select menu point: \nC) Create new room; \nS) Save rooms; \nL) Load rooms; \nF) Get free capacity; \nG) Get rooms; \nE) Exit.");
                Console.Write("Your choise: ");
                ConsoleKeyInfo key = Console.ReadKey();
                char value = key.KeyChar;
                if (value == 'C' || value == 'c')
                {
                    Console.Clear();
                    CreateNewRoom();
                }
                else if (value == 'S' || value == 's')
                {
                    Console.Clear();
                    SaveRooms(Rooms,@"dormitory.xml");
                }
                else if (value == 'L' || value == 'l')
                {
                    Console.Clear();
                    LoadRooms(@"dormitory.xml");
                }
                else if (value == 'F' || value == 'f')
                {
                    Console.Clear();
                    GetFreeCapacity();
                }
                else if (value == 'G' || value == 'g')
                {
                    Console.Clear();
                    GetRooms();
                }
                else if (value == 'E' || value == 'e')
                {
                    Exit();
                }
            }
        }
    }
}
