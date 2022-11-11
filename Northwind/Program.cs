// See https://aka.ms/new-console-template for more information
using NorthWind.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");
HttpClient client = new HttpClient();
int ch = 1;
do
{
    Console.WriteLine("Enter the option ");
    Console.WriteLine("1");
    Console.WriteLine("2");
    Console.WriteLine("3");
    Console.WriteLine("4");
     int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.WriteLine("Enter the name to Search for the product");
            string product = Console.ReadLine();
            var result = await client.GetFromJsonAsync<List<Customer>>($"https://localhost:7083/api/Search/{product}");
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
    }

    Console.WriteLine("Enter 0 to exit");
    ch = Convert.ToInt32(Console.ReadLine());
} while (ch != 0);
