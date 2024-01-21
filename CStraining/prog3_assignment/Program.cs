using prog3_assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prog3_assignment
{
    internal class Program
    {
        static Dictionary<int, Product> Products = new Dictionary<int, Product>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n-----Menu-----");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display All Products");
                Console.WriteLine("3. Find Product by ID");
                Console.WriteLine("4. Remove Product by ID");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;

                    case 2:
                        DisplayAllProducts();
                        break;

                    case 3:
                        FindProductById();
                        break;

                    case 4:
                        RemoveProductById();
                        break;

                    case 5:
                        Console.WriteLine("Exiting the program.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            } while (choice != 5);
        }

        static void AddProduct()
        {
            do
            {
                Product product = new Product();

                Console.Write("Enter ProductId: ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (Products.ContainsKey(id))
                {
                    Console.WriteLine($"Product with ID {id} already exists. Add another product? (y/n)");
                    if (Console.ReadLine().ToLower() != "y")
                        break;
                }
                else
                {
                    try
                    {
                        product.ProductId = id;
                        Console.Write("Enter ProductName (length must be > 3 chars): ");
                        product.ProductName = Console.ReadLine();

                        Console.Write("Enter ManufactureDate (in yyyy-MM-dd format, must be before today): ");
                        product.ManufactureDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Warranty: ");
                        product.Warranty = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Price: ");
                        product.Price = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Stock: ");
                        product.Stock = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Gst (should be 5, 12, 18, or 28 only): ");
                        product.Gst = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Discount (range is 1-30): ");
                        product.Discount = Convert.ToInt32(Console.ReadLine());

                        Products.Add(id, product);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        continue;
                    }

                    Console.Write("Do you want to add another product? (y/n): ");
                }

            } while (Console.ReadLine().ToLower() == "y");
        }

        static void DisplayAllProducts()
        {
            if (Products.Count > 0)
            {
                foreach (Product item in Products.Values)
                {
                    Console.WriteLine(item.Display());
                }
            }
            else
            {
                Console.WriteLine("No products added");
            }
        }

        static void FindProductById()
        {
            Console.Write("Enter the ProductId to find: ");
            int SearchId = Convert.ToInt32(Console.ReadLine());

            if (Products.TryGetValue(SearchId, out Product ProductFound)) //fix here
            {
                Console.WriteLine("Product Found.");
                Console.WriteLine(ProductFound.Display());
            }
            else
            {
                Console.WriteLine($"\nProduct with ProductId {SearchId} does not exist.");
            }
        }

        static void RemoveProductById()
        {
            Console.Write("Enter the ProductId to remove: ");
            int RemoveId = Convert.ToInt32(Console.ReadLine());

            if (Products.ContainsKey(RemoveId))
            {
                Products.Remove(RemoveId);
                Console.WriteLine($"\nProduct with ProductId {RemoveId} removed successfully.");
            }
            else
            {
                Console.WriteLine($"Product with ProductId {RemoveId} does not exist.");
            }
        }
    }
}
