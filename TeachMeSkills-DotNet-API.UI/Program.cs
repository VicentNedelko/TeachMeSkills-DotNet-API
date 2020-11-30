using System;
using System.Collections.Generic;
using TeachMeSkills_DotNet_API.Core.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TeachMeSkills_DotNet_API.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            static  void MoveToBinFile(IEnumerable<Brewery> brewList, string filePath)
            {

                Brewery brewery = new Brewery();
                Console.WriteLine("Объект создан");

                BinaryFormatter formatter = new BinaryFormatter();


                using (FileStream fs = new FileStream(filePath = @"C:\breweryListByCity.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, brewery);

                    Console.WriteLine("Объект сериализован");
                }

                using (FileStream fs = new FileStream(filePath = @"C:\breweryListByCity.dat", FileMode.OpenOrCreate))
                {
                    Brewery newBravery = (Brewery)formatter.Deserialize(fs);

                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine($"City: {newBravery.city} --- Address: {newBravery.county_province}");
                }

                using (FileStream fs = new FileStream(filePath = @"C:\breweryListByName.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, brewery);

                    Console.WriteLine("Объект сериализован");
                }

                using (FileStream fs = new FileStream(filePath = @"C:\breweryListByName.dat", FileMode.OpenOrCreate))
                {
                    Brewery newBravery = (Brewery)formatter.Deserialize(fs);

                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine($"Name: {newBravery.name} --- Phone: {newBravery.phone}");
                }

                using (FileStream fs = new FileStream(filePath = @"C:\breweryFullList.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, brewery);

                    Console.WriteLine("Объект сериализован");
                }

                using (FileStream fs = new FileStream(filePath = filePath = @"C:\breweryFullList.dat", FileMode.OpenOrCreate))
                {
                    Brewery newBravery = (Brewery)formatter.Deserialize(fs);

                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine($"Creat: {newBravery.created_at} --- ID: {newBravery.id}");
                }
                Console.ReadLine();
            }
        }
    }
}
