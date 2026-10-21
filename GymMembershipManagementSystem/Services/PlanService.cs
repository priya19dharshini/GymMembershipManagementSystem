using GymMembershipManagementSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymMembershipManagementSystem.Services
{
    public class PlanService
    {
        List<MembershipPlan> mp = new List<MembershipPlan>();
        int next = 100;

        private JsonFile<MembershipPlan> fileService;

        public PlanService()
        {
            fileService = new JsonFile<MembershipPlan>("plans.json");
            mp = fileService.Load();
        }
        public void PlanDetails()
        {
            Console.WriteLine($"Plan ID :{++next}");
            Console.WriteLine("Enter the Plan Name:");
            string? PlanName = Console.ReadLine();

            Console.WriteLine("Enter the Duration:");
            int days;
            int.TryParse(Console.ReadLine(), out days);
            while (days <= 0)
            {
                Console.WriteLine("Negative input is not allowed");
                Console.WriteLine("Enter the Duration:");
                
                int.TryParse(Console.ReadLine(), out days);

            }

            Console.WriteLine("Enter the Fee:");
            decimal fees;
            decimal.TryParse(Console.ReadLine(), out fees);
            while (fees <= 0)
            {
                Console.WriteLine("Negative input is not allowed");
                Console.WriteLine("Enter the Duration:");

                decimal.TryParse(Console.ReadLine(), out fees);

            }

            MembershipPlan memberShipPlan = new MembershipPlan
            {
                PlanId = next,
                PlanName = PlanName,
                DurationInDays = days,
                Fee = fees

            };

            mp.Add(memberShipPlan);
            fileService.Save(mp);

            Console.WriteLine("Plan Added Succesfully");

        }

        public void DisplayPlan()
        {
            foreach(MembershipPlan x in mp)
            {
                Console.WriteLine($"Plan Id: {x.PlanId}");
                Console.WriteLine($"Plan Name: {x.PlanName}");
                Console.WriteLine($"Days: {x.DurationInDays}");
                Console.WriteLine($"Fees: {x.Fee}");
              
            }
        }

        public void DisplaySearch(MembershipPlan membershipPlan)
        {
            Console.WriteLine($"Plan Id: {membershipPlan.PlanId}");
            Console.WriteLine($"Plan Name: {membershipPlan.PlanName}");
            Console.WriteLine($"Days: {membershipPlan.DurationInDays}");
            Console.WriteLine($"Fees: {membershipPlan.Fee}");
        }

        public void SearchId()
        {
            Console.WriteLine("Enter Plan ID to search:");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            MembershipPlan membershipPlan = mp.FirstOrDefault(m => m.PlanId == id);

            if (membershipPlan != null)
            {
                DisplaySearch(membershipPlan);
            }
            else
            {
                Console.WriteLine("Plan Id not found.");
            }

        }

        public void SearchName()
        {
            Console.WriteLine("Enter PlanName to search:");
            string? PlanName = Console.ReadLine();

            MembershipPlan membershipPlan = mp.FirstOrDefault(m => m.PlanName == PlanName);

            if (membershipPlan != null)
            {
                DisplaySearch(membershipPlan);
            }
            else
            {
                Console.WriteLine("Plan Name not found.");
            }

        }

        public void UpdatePlan()
        {
            Console.WriteLine("Enter Plan ID to update:");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            MembershipPlan membershipPlan = mp.FirstOrDefault(m => m.PlanId == id);

            if (membershipPlan == null)
            {
                Console.WriteLine("Plan Id not found.");
                return;
            }

            Console.WriteLine("Enter the Plan Name:");
            string? PlanName = Console.ReadLine();
            membershipPlan.PlanName = PlanName;

            int duration;
            Console.WriteLine("Enter the Duration in days:");
            int.TryParse(Console.ReadLine(), out duration);
            membershipPlan.DurationInDays = duration;

            Console.WriteLine("Enter fees:");
            decimal fees;
            decimal.TryParse(Console.ReadLine(), out fees);
            membershipPlan.Fee = fees;

            Console.WriteLine("{Plan updated successfully.");

            DisplaySearch(membershipPlan);
        }

        public void DeletePlan()
        {
            Console.WriteLine("Enter Plan ID :");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            MembershipPlan membershipPlan = mp.FirstOrDefault(m => m.PlanId == id);

            if (membershipPlan == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            mp.Remove(membershipPlan);
            Console.WriteLine("Plan deleted successfully.");


        }



    }
}
