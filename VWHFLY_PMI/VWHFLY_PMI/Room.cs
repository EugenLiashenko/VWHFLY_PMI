using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWHFLY_PMI
{
    class Room
    {
        public int RoomNumber { get; set; }
        public int NumberOfStudents { get; set; }
        public Room(int roomnumber)
        {
            this.NumberOfStudents = 0;
            this.RoomNumber = roomnumber;
        }
        public void AddNewStudent()
        {
            if (NumberOfStudents < 6)
            {
                NumberOfStudents++;
                Console.WriteLine("You added new student! \nPress any key to continue!");
                Console.ReadKey();
            }
            else 
            { 
                Console.WriteLine("No more students in this room (max 6)! \nPress any key to continue!");
                Console.ReadKey();
            }
        }
        public void RemoveStudent()
        {
            if (NumberOfStudents > 0)
            {
                NumberOfStudents--;
                Console.WriteLine("You removed one student! \nPress any key to continue!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You cannot remove any student, because there are no students in this room! \nPress any key to continue!");
                Console.ReadKey();
            }
        } 
        public void GetRoomNumber()
        {
            Console.WriteLine($"The number of your room is: {RoomNumber}");
        }
        public void GetNumberOfStudents()
        {
            Console.WriteLine($"The number of students in the room: {NumberOfStudents}");
        }
        public void All()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please select menu point: \nA) Add new student; \nR) Remove student; \nG) Get room number; \nN) Get number of students \nE) Exit.");
                Console.Write("Your choise: ");
                ConsoleKeyInfo key = Console.ReadKey();
                char value = key.KeyChar;
                if (value == 'A' || value == 'a')
                {
                    Console.WriteLine();
                    AddNewStudent();
                }
                else if (value == 'R' || value == 'r')
                {
                    Console.WriteLine();
                    RemoveStudent();
                }
                else if (value == 'G' || value == 'g')
                {
                    Console.WriteLine();
                    GetRoomNumber();
                }
                else if (value == 'N' || value == 'n')
                {
                    Console.WriteLine();
                    GetNumberOfStudents();
                }
                else if (value == 'E' || value == 'e')
                {
                    break;
                }
            }
        }
    }
}
