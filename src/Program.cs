using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExample
{
    class Program
    {
        static async Task Main(string[] args)  
        {  
        var order1Ticket = MakeOrderAsync(1, "Cheeseburger", "Hamburger"); 
        
        Console.WriteLine("Let's do some other order in a meantime....");
        var order2Ticket = MakeOrderAsync(2, "Cheeseburger", "FishMac", "BigMac", "McRoyal");
        
        Console.WriteLine("Again...let's do some other order in a meantime...."); 
        var order3Ticket = MakeOrderAsync(3, "Hamburger"); 

        await Task.WhenAll(order1Ticket, order2Ticket, order3Ticket);
        Console.WriteLine("All orders completed!");
        }  
        
        static async Task<IEnumerable<string>> MakeOrderAsync(int orderNumber, params string[] burgers)  
        {  
        var orderProcessingTime = burgers.Length * 1000;  
        Console.WriteLine($"Preparing order #{orderNumber}... ETA: {orderProcessingTime} ms");  
        await Task.Delay(orderProcessingTime);  
        Console.WriteLine($"Order #{orderNumber} ready!");  

        return burgers;
        }
    }
}