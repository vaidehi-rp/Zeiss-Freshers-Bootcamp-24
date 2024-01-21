using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//nterfrom user ProductId(should be>0), ProductName (length must be>3chars), ManufactureDate (must be<today),
//Warranty, Price(should be>0), Stock, Gst (must be only 5,12,18 or 28); Discount (range is 1-30)

namespace prog1_assignment
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Product prod1; 
            int choice;

            prod1 = new Product();

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Product");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice (1-3): ");
                choice=Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                         

                        Console.WriteLine("Enter ProductId: ");
                        prod1.ProductId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter ProductName: ");
                        prod1.ProductName = Console.ReadLine();

                        Console.WriteLine("Enter ManufactureDate (in yyyy-MM-dd format): ");
                        prod1.ManufactureDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Warranty: ");
                        prod1.Warranty = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Price: ");
                        prod1.Price = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter Stock: ");
                        prod1.Stock = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Gst (should be 5, 12, 18, or 28): ");
                        prod1.Gst = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Discount (range is 1-30): ");
                        prod1.Discount = Convert.ToInt32(Console.ReadLine());

                        break;

                    case 2:
                        if (prod1 != null)
                        {
                            Console.WriteLine(prod1.Display());
                        }
                        else
                        {
                            Console.WriteLine("No product added. Please add a product first.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Exiting the program.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            } while (choice != 3);
        }
    }
}
