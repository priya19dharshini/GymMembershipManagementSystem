using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GymMembershipManagementSystem.Models;

namespace GymMembershipManagementSystem.Services
{
    public class MemberService
    {
        List<Member> list = new List<Member>();

        private JsonFile<Member> fileService;

        int Age;
        long PhoneNumber;

        public MemberService()
        {
            fileService = new JsonFile<Member>("members.json");
            list = fileService.Load();
        }


        public void Registration()
        {
            Console.WriteLine("Enter the Member Id:");
            string? MemberId = Console.ReadLine();

            Console.WriteLine("Enter the Full Name:");
            string? FullName = Console.ReadLine();

            Console.WriteLine("Enter the Age:");
            int.TryParse(Console.ReadLine(), out Age);

            Console.WriteLine("Enter the Phone Number:");
            long.TryParse(Console.ReadLine(), out PhoneNumber);

            Member member = new Member
            {
                MemberId = MemberId,
                FullName = FullName,
                Age = Age,
                PhoneNumber = PhoneNumber
            };


            list.Add(member);
            fileService.Save(list);

            Console.WriteLine("Registered Successfully");

        }

        public void Display()
        {
            foreach(Member x in list)
            {
                Console.WriteLine($"Member Id: {x.MemberId}");
                Console.WriteLine($"Full Name: {x.FullName}");
                Console.WriteLine($"Age: {x.Age}");
                Console.WriteLine($"Phone Number: {x.PhoneNumber}");
                Console.WriteLine($"Date : {x.JoinDate}");
            }

        }

        public void DisplaySearch(Member member)
        {

            Console.WriteLine($"Member Id: {member.MemberId}");
            Console.WriteLine($"Full Name: {member.FullName}");
            Console.WriteLine($"Age: {member.Age}");
            Console.WriteLine($"Phone Number: {member.PhoneNumber}");
            Console.WriteLine($"Date : {member.JoinDate}");
        }

        public void SearchId()
        {
            Console.WriteLine("Enter Member ID to search:");
            string? id = Console.ReadLine();

            Member? member = list.FirstOrDefault( m => m.MemberId == id);

            if (member != null)
            {
                DisplaySearch(member);
            }
            else
            {
                Console.WriteLine("Member not found.");
            }

        }

        public void SearchName()
        {
            Console.WriteLine("Enter FullName to search:");
            string? FullName = Console.ReadLine();

            Member? member = list.FirstOrDefault(m => m.FullName == FullName);

            if (member != null)
            {
                DisplaySearch(member);
            }
            else
            {
                Console.WriteLine("Member not found.");
            }

        }

        public void SearchPhoneNumber()
        {
            Console.WriteLine("Enter PhoneNumber to search:");
            int PhoneNumber;
            int.TryParse(Console.ReadLine(), out PhoneNumber);


            Member? member = list.FirstOrDefault(m => m.PhoneNumber == PhoneNumber);

            if (member != null)
            {
                DisplaySearch(member);
            }
            else
            {
                Console.WriteLine("Member not found.");
            }

        }

        public void Update()
        {
            Console.WriteLine("Enter Member ID to update:");
            string? id = Console.ReadLine();

            Member? member = list.FirstOrDefault( m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.WriteLine("Enter the Full Name:");
            string? FullName = Console.ReadLine();
            member.FullName = FullName;

            int age;
            Console.WriteLine("Enter the Age:");
            int.TryParse(Console.ReadLine(), out age);
            member.Age = age;

            Console.WriteLine("Enter new Phone Number:");
            int phone;
            int.TryParse(Console.ReadLine(), out phone);
            member.PhoneNumber = phone;

            Console.WriteLine("Member updated successfully.");

            DisplaySearch(member);


        }

        public void DeleteMember()
        {
            Console.WriteLine("Enter Member ID to update:");
            string? id = Console.ReadLine();

            Member? member = list.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            list.Remove(member);
            Console.WriteLine("Member deleted successfully.");


        }



    }
}
