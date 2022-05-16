namespace MiniGuestBook
{
    internal class GuestBookProtocols
    {
        public static List<string> GetPartyInfo(List<string> allPartyNames)
        {
            string? partyName = "";
            
            {
                do
                {
                    Console.Write("Please enter your parties name: ");
                    partyName = Console.ReadLine();
                    allPartyNames.Add(partyName);
                }   while (string.IsNullOrEmpty(partyName));

                return allPartyNames;
            } 
        }

        public static double GetPartySize(double totalGuests)
        {
            double partySize;
            bool isValid = false;
            do
            {
                Console.Write("Enter the total number of people in your party: ");
                isValid = double.TryParse(Console.ReadLine(), out partySize);
                if (isValid)
                {
                    totalGuests = totalGuests + partySize;
                }
                Console.WriteLine();
            } while (!isValid);

            return totalGuests;
        } 

        public static void GuestBookGreeting()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Welcome to the Console GuestBook.");
            Console.WriteLine("Choose from the below options: ");
            Console.WriteLine("-------------------------------");
        }

        public static void GustBookFlow()
        {
            List<string> allPartyNames = new();
            double totalGuests = 0;
            bool isValid;
            int choice = 0;
            do
            {
                do
                {
                    Console.WriteLine("1) Enter party name");
                    Console.WriteLine("2) Close guest book and show totals");
                    Console.Write("What is your choice: ");
                    isValid = int.TryParse(Console.ReadLine(), out choice);

                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You must choose 1 or 2. Choice: ");
                        Console.WriteLine();
                    }

                    switch (choice)

                    {

                        case 1:
                            allPartyNames = GetPartyInfo(allPartyNames);
                            totalGuests = GetPartySize(totalGuests);
                            break;

                        case 2:
                            Console.WriteLine("\n");
                            Console.WriteLine("The guest list includes: ");

                            foreach (string name in allPartyNames)
                            {
                                Console.WriteLine(name);
                            }
                            Console.WriteLine($"With a grand total of {totalGuests} present.");
                            break;
                    }

                } while (!isValid);

            } while (choice != 2);
        }

                    
    } 
}
