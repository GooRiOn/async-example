## Sync version

```csharp
static void Main(string[] args)  
{  
  MakeOrder(1, "Cheeseburger", "Hamburger"); 
  MakeOrder(2, "Cheeseburger", "FishMac", "BigMac", "McRoyal"); 
  MakeOrder(3, "Hamburger");   
  
  Console.ReadLine(); 
}  
  
static void MakeOrder(int orderNumber, params string[] burgers)  
{  
  var orderProcessingTime = burgers.Length * 1000;  
  Console.WriteLine($"Preparing order #{orderNumber}... ETA: {orderProcessingTime} ms");  
  Thread.Sleep(orderProcessingTime);  
  Console.WriteLine($"Order #{orderNumber} ready!");  
}
```

## Async void version


```csharp
static void Main(string[] args)  
{  
  MakeOrderAsync(1, "Cheeseburger", "Hamburger"); 
  
  Console.WriteLine("Let's do some other order in a meantime....");
  MakeOrderAsync(2, "Cheeseburger", "FishMac", "BigMac", "McRoyal");
  
  Console.WriteLine("Again...let's do some other order in a meantime...."); 
  MakeOrderAsync(3, "Hamburger");   
  
  Console.ReadLine(); 
}  
  
static async void MakeOrderAsync(int orderNumber, params string[] burgers)  
{  
  var orderProcessingTime = burgers.Length * 1000;  
  Console.WriteLine($"Preparing order #{orderNumber}... ETA: {orderProcessingTime} ms");  
  await Task.Delay(orderProcessingTime);  
  Console.WriteLine($"Order #{orderNumber} ready!");  
}
```

## Async/await "synchronous" version

Change `void` to `Task`. There's no difference to `async void` but gives the control.

```csharp
static async Task Main(string[] args)  
{  
  await MakeOrderAsync(1, "Cheeseburger", "Hamburger"); 
  
  Console.WriteLine("Let's do some other order in a meantime....");
  await MakeOrderAsync(2, "Cheeseburger", "FishMac", "BigMac", "McRoyal");
  
  Console.WriteLine("Again...let's do some other order in a meantime...."); 
  await MakeOrderAsync(3, "Hamburger");   
  
  Console.ReadLine(); 
}  
  
static async Task MakeOrderAsync(int orderNumber, params string[] burgers)  
{  
  var orderProcessingTime = burgers.Length * 1000;  
  Console.WriteLine($"Preparing order #{orderNumber}... ETA: {orderProcessingTime} ms");  
  await Task.Delay(orderProcessingTime);  
  Console.WriteLine($"Order #{orderNumber} ready!");  
}
```

## Change return type

```csharp
static async Task Main(string[] args)  
{  
  await MakeOrderAsync(1, "Cheeseburger", "Hamburger"); 
  
  Console.WriteLine("Let's do some other order in a meantime....");
  await MakeOrderAsync(2, "Cheeseburger", "FishMac", "BigMac", "McRoyal");
  
  Console.WriteLine("Again...let's do some other order in a meantime...."); 
  await MakeOrderAsync(3, "Hamburger");   
  
  Console.ReadLine(); 
}  
  
static async Task<IEnumerable<string>> MakeOrderAsync(int orderNumber, params string[] burgers)  
{  
  var orderProcessingTime = burgers.Length * 1000;  
  Console.WriteLine($"Preparing order #{orderNumber}... ETA: {orderProcessingTime} ms");  
  await Task.Delay(orderProcessingTime);  
  Console.WriteLine($"Order #{orderNumber} ready!");  

  return burgers;
}
```

## VIP Customer

```csharp
static async Task Main(string[] args)  
{  
  var order1Ticket = MakeOrderAsync(1, "Cheeseburger", "Hamburger"); 
  
  Console.WriteLine("Let's do some other order in a meantime....");
  var order2Ticket = MakeOrderAsync(2, "Cheeseburger", "FishMac", "BigMac", "McRoyal");
  
  Console.WriteLine("Again...let's do some other order in a meantime...."); 
  var order3Ticket = MakeOrderAsync(3, "Hamburger"); 

  var order2 = await order2Ticket;  
  Console.WriteLine($"Order 2 picked up!");
  
  var order1 = await order1Ticket;
  Console.WriteLine($"Order 1 picked up!");
  
  var order3 = await order3Ticket;
  Console.WriteLine($"Order 3 picked up!");
  
  Console.ReadLine(); 
}  
  
static async Task<IEnumerable<string>> MakeOrderAsync(int orderNumber, params string[] burgers)  
{  
  var orderProcessingTime = burgers.Length * 1000;  
  Console.WriteLine($"Preparing order #{orderNumber}... ETA: {orderProcessingTime} ms");  
  await Task.Delay(orderProcessingTime);  
  Console.WriteLine($"Order #{orderNumber} ready!");  

  return burgers;
}
```

## When All

```csharp
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
```
