using System;
using System.Collections.Generic;
using System.Text;

namespace GymMembershipManagementSystem.Models
{
    
    public enum Status
    {
        Active,
        Expired,
        Cancelled
    }

    public class Membership
    {
        public int MembershipId { get; set; }
        public string? MemberId { get; set; }
        public int PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status status { get; set; }
        public decimal AmountPaid { get; set; }

        public Membership()
        {

        }


        public Membership(int membershipId , string memberId , int planId, DateTime startDate , DateTime endDate,decimal amountPaid)
        {
            MembershipId = membershipId;
            MemberId = memberId;
            PlanId = planId;
            StartDate = DateTime.Today;
            EndDate = endDate;
            AmountPaid = amountPaid;
        }




    }
}
