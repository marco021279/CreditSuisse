using System;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using credit_suisse_app.Models;
using RestSharp;
 
namespace ConsoleApplicationVSCode
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            var client = new RestClient("http://localhost:5000/api/Trade/v1/get-all-categorized");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var result = JsonSerializer.Deserialize<ResultModel>(response.Content);
            Console.WriteLine(response.Content);

            if(result != null && result.result != null)
            {
                Console.WriteLine("Sample input");
                Console.WriteLine(result.result[0].referenceDate.ToString("MM/dd/yyyy"));
                Console.WriteLine(result.result[0].businessNumber.ToString());

                foreach(var l in result.result)
                {
                    if(l.ToString().Length > 10)
                    {
                        Console.WriteLine(l.value + " " + l.clientSector + " " + l.nextPaymentDate.ToString("MM/dd/yyyy"));
                    }
                }

                Console.WriteLine("Sample output");

                foreach(var l in result.result)
                {
                    if(l.ToString().Length > 10)
                    {
                        Console.WriteLine(l.category);
                    }
                }
            }
        }
    }
}