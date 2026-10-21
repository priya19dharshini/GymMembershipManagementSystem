using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace GymMembershipManagementSystem.Models
{
    public class Member
    {

        public string? MemberId { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }

        public Member()
        {

        }

        public Member (string? memberId, string? fullName, int age, int phoneNumber, DateTime joinDate)
        {
            MemberId = memberId;
            FullName = fullName;
            Age = age;
            PhoneNumber = phoneNumber;
            JoinDate = DateTime.Now;
        }
    }
}
