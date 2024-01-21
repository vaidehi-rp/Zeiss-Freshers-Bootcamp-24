using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] prods= new Product[10];
            int choice;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Product");
                Console.WriteLine("3. Find Product by ID");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice (1-4): ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter no. of products you want to add? ");
                        int numProducts = Convert.ToInt32(Console.ReadLine());

                        prods = new Product[numProducts];

                        for (int i = 0; i < prods.Length; i++)
                        {
                            Product p = new Product();

                            Console.Write("Enter ProductId for product {0}: ", i + 1);
                            p.ProductId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter ProductName for product {0}: ", i + 1);
                            p.ProductName = Console.ReadLine();

                            Console.Write("Enter ManufactureDate for product {0} (in yyyy-MM-dd format): ", i + 1);
                            p.ManufactureDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Warranty for product {0}: ", i + 1);
                            p.Warranty = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Price for product {0}: ", i + 1);
                            p.Price = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Enter Stock for product {0}: ", i + 1);
                            p.Stock = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Gst for product {0} (should be 5, 12, 18, or 28): ", i + 1);
                            p.Gst = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Discount for product {0} (range is 1-30): ", i + 1);
                            p.Discount = Convert.ToInt32(Console.ReadLine());

                            prods[i] = p;
                        }

                        break;

                    case 2:
                        if (prods != null)
                        {
                            foreach (Product item in prods)
                            {
                                Console.WriteLine(item.Display());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No products added");
                        }
                        break;

                    case 3:
                        Console.Write("Enter the ProductId to search: ");
                        int SearchId = Convert.ToInt32(Console.ReadLine());

                        bool found = false;
                        foreach (Product item in prods)
                        {
                            if (item.ProductId == SearchId)
                            {
                                Console.WriteLine(item.Display());
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Product not found with the ProductId {0}.", SearchId);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting the program.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            } while (choice != 4);
        }
    }
}
