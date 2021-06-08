using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
namespace DataInventoryManagement
{
    class Program
    {
        
       
            /// creating a json file and adding inventory to it and
            /// reading json file and deserializing it to string format
            /// also calculating the total value for inventory.
            
            static void Main(string[] args)
            {
            Console.WriteLine("welcome to Data Inventory Management");
                Inventory rice = new Inventory()
                {
                    ItemNo = 1,
                    name = "Rice",
                    weight = 25,
                    price = 50
                }; Inventory pulses = new Inventory()
                {
                    ItemNo = 2,
                    name = "Pulses",
                    weight = 50,
                    price = 75
                };
                Inventory wheats = new Inventory()
                {
                    ItemNo = 3,
                    name = "Wheat",
                    weight = 100,
                    price = 25
                };

                List<Inventory> inventories = new List<Inventory>();
                inventories.Add(rice);
                inventories.Add(pulses);
                inventories.Add(wheats);

                //Serialization object from string to json format.//
                string strResult = JsonConvert.SerializeObject(inventories);
                File.WriteAllText(@"Inventort.json", strResult);
                Console.WriteLine("Stored successfully!!");

                //Deserialization object from json file to string format.//
                strResult = File.ReadAllText(@"Inventort.json");
                var list = JsonConvert.DeserializeObject<List<Inventory>>(strResult);
                float totalValue = 0;
                foreach (Inventory inventory in list)
                {
                    Console.WriteLine($"Serial Number: {inventory.ItemNo}\n Name: {inventory.name}\n Weight: {inventory.weight}\n Price: {inventory.price}/Kg\n Total Price: {inventory.weight * inventory.price}\n");
                    totalValue += (inventory.price * inventory.weight);
                }
                Console.WriteLine($"Total Value of inventory:{totalValue}");

            }
        }
    }

