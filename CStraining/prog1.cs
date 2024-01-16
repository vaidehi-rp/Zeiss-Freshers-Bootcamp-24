using System;
namespace prog1 {
internal class HelloWorld {
  static void Main(string[] args) {
    //Console.WriteLine("Hello World");
    int EmployeeId = 0;
    string Name="";
    double Salary = 0.0;
    
    Console.WriteLine("enter employee id");
    // EmployeeID=Console.Readline() // but Readline returns a string
    EmployeeId=System.Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("enter name");
    Name=Console.ReadLine();
    
    Console.WriteLine("enter employee salary");
    Salary=Convert.ToDouble(Console.ReadLine());
    
    string msg="";
    msg += "EmployeeId: " + EmployeeId + "\n";
    msg += "Name: " + Name + "\n";
    msg += "Salary: " + Salary + "\n";
    
    Console.WriteLine(msg);
  }
 }
}
