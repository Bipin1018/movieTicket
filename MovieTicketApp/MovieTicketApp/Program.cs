using System.ComponentModel.Design;

namespace MovieTicketApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            //validaing name
            while (true)
            {
                bool isNameCorrect = string.IsNullOrWhiteSpace(name);
                if (!isNameCorrect == false)
                {
                    Console.WriteLine("your name format is not correct, please input your name again");

                }
                else
                {
                    break;

                }


            }

            //validating age
            Console.WriteLine("enter your age");
            while (true)
            {
                string agestring = Console.ReadLine();
                bool isconversionsuccessful = int.TryParse(agestring, out int age);
                if (isconversionsuccessful == false || age <= 0)
                {
                    Console.WriteLine("your age input is not in correct format, please use numbers");

                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Choose the ticket type:");
            Console.WriteLine("1: Child ticket (under 12 years old)");
            Console.WriteLine("2: Adult ticket (12-64 years old)");
            Console.WriteLine("3: Senior ticket (65 years and older)");

            double childTicketPrice = 4.99;
            double adultTicketPrice = 9.99;
            double seniorTicketPrice = 6.99;

            // Prompt user to select ticket type
            // Console.Write("Select ticket type (1 = Child, 2 = Adult, 3 = Senior): ");
            int ticketType = Convert.ToInt32(Console.ReadLine());

            // Validate user input using a while loop
            while (ticketType < 1 || ticketType > 3)
            {
                Console.Write("Invalid input. Please try again: ");
                ticketType = Convert.ToInt32(Console.ReadLine());
            }

            // Use a switch case statement to determine ticket price
            double ticketPrice = 0.00;
            string ticketTypeString = "";
            switch (ticketType)
            {
                case 1:
                    ticketTypeString = "Child";
                    ticketPrice = childTicketPrice;
                    break;
                case 2:
                    ticketTypeString = "Adult";
                    ticketPrice = adultTicketPrice;
                    break;
                case 3:
                    ticketTypeString = "Senior";
                    ticketPrice = seniorTicketPrice;
                    break;

            }

            // Ask user if they have a discount code
            Console.Write("Do you have a discount code? (yes/no): ");
            string hasDiscountCode = Console.ReadLine().ToLower();

            // Validate user input using a while loop
            while (hasDiscountCode != "yes" && hasDiscountCode != "no")
            {
                Console.Write("Invalid input. Please enter 'yes' or 'no': ");
                hasDiscountCode = Console.ReadLine().ToLower();
            }

            double finalDiscountePrice = 0.00; // Initialize final price to 0

            // If user has a discount code, ask for the code
            if (hasDiscountCode == "yes")
            {
                string discountCode = "";
                bool isValidDiscountCode = false;
                while (!isValidDiscountCode)
                {
                    Console.Write("Enter discount code: ");
                    discountCode = Console.ReadLine();

                    // Validate discount code using an if-else statement
                    if (discountCode.ToUpper() == "ALE20")
                    {
                        isValidDiscountCode = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid discount code. Please try again.");
                    }
                }

                // Apply discount if valid
                if (isValidDiscountCode)
                {
                    finalDiscountePrice = ticketPrice * 0.80; // 20% off
                    Console.WriteLine("Discount code accepted! You receive a 20% discount");
                }
                else
                {
                    finalDiscountePrice = ticketPrice; // No discount applied
                }
            }
            else
            {
                finalDiscountePrice = ticketPrice; // No discount applied
            }

            // Display Final Message
            Console.WriteLine($"Hello {name}. You chose {ticketTypeString} ticket. Original price: {ticketPrice:F2} euro. Discounted price: {finalDiscountePrice:F2} euro");
        }
    }

    }
