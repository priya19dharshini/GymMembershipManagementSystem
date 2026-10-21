using GymMembershipManagementSystem.Services;

MemberService ms = new MemberService();
PlanService ps = new PlanService();

string? ch = "";

while (ch != "0")
{
    Console.WriteLine("1.Register a Member:");
    Console.WriteLine("2.Display:");
    Console.WriteLine("3.Search by Member ID:");
    Console.WriteLine("4.Search by Name:");
    Console.WriteLine("5.Search Phone Number:");
    Console.WriteLine("6.Update contact details");
    Console.WriteLine("7.Delete the Member");
    Console.WriteLine("8.Add Plan");
    Console.WriteLine("9.Display the Plan");
    Console.WriteLine("10.Search by PlanID:");
    Console.WriteLine("11.Search by PlanName:");
    Console.WriteLine("12.Update Plan details");
    Console.WriteLine("13.Delete the Plan");
    Console.WriteLine("14.Exit");

    Console.WriteLine("Enter the switch");
    ch = Console.ReadLine();
    Console.WriteLine();

    switch (ch)
    {
        case "1":
            ms.Registration();
            break;

        case "2":
            ms.Display();
            break;

        case "3":
            ms.SearchId();
            break;

        case "4":
            ms.SearchName();
            break;

        case "5":
            ms.SearchPhoneNumber();
            break;

        case "6":
            ms.Update();
            break;

        case "7":
            ms.DeleteMember();
            break;

        case "8":
            ps.PlanDetails();
            break;

        case "9":
            ps.DisplayPlan();
            break;

        case "10":
            ps.SearchId();
            break;

        case "11":
            ps.SearchName();
            break;

        case "12":
            ps.UpdatePlan();
            break;

        case "13":
            ps.DeletePlan();
            break;

        case "14":
            Console.WriteLine("Exit...");
            break;

        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}