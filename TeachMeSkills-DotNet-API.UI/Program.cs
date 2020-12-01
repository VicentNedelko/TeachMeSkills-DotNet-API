using System;
using System.Collections.Generic;
using TeachMeSkills_DotNet_API.Core.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Linq;
using TeachMeSkills_DotNet_API.Core.Services;
using TeachMeSkills_DotNet_API.Core.Commons;

namespace TeachMeSkills_DotNet_API.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestService reqService = new RequestService();
            Parameters commons = new Parameters();
            while (true)
            {
                Console.WriteLine();
                ShowUserMenu();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.N:
                        Console.WriteLine();
                        Console.WriteLine("+++++++");
                        Console.Write("Enter Name : ");
                        var nameBrewery =
                            reqService.RequestByName(Console.ReadLine()).Result;
                        if (nameBrewery.Count() != 0)
                        {
                            MoveToBinFile(nameBrewery, commons.filePathName);
                            PrintList(nameBrewery);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No items found.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.C:
                        Console.WriteLine();
                        Console.WriteLine("+++++++");
                        Console.Write("Enter city : ");
                        var cityBrewery = reqService.RequestDataByCity(Console.ReadLine()).Result;
                        if (cityBrewery.Count() != 0)
                        {
                            MoveToBinFile(cityBrewery, commons.filePathCity);
                            PrintList(cityBrewery);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No items found.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.T:
                        Console.WriteLine();
                        Console.WriteLine("+++++++");
                        var typeBrewery = reqService.RequestByType().Result;
                        if (typeBrewery.Count() != 0)
                        {
                            MoveToBinFile(typeBrewery, commons.filePathType);
                            PrintList(typeBrewery);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No items found.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.F:
                        var fullList = reqService.RequestFullList().Result;
                        MoveToBinFile(fullList, commons.filePathFull);
                        PrintList(fullList);
                        break;
                    case ConsoleKey.O:
                        Console.Clear();
                        FileMenuPrint();
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.A:
                                PrintList(GetFromBin(commons.filePathName));
                                break;
                            case ConsoleKey.I:
                                PrintList(GetFromBin(commons.filePathCity));
                                break;
                            case ConsoleKey.Y:
                                PrintList(GetFromBin(commons.filePathType));
                                break;
                            default:
                                Console.WriteLine("Error! Wrong key entered.");
                                break;
                        }
                        break;
                    case ConsoleKey.E:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Wrong key entered.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
        public static void ShowUserMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------User Menu-------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Search by Name - \"N\"");
            Console.WriteLine("Search by City - \"C\"");
            Console.WriteLine("Search by Type - \"T\"");
            Console.WriteLine("Show full list - \"F\"");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+++++++++++++++++++++++");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Open recent query - \"O\"");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+++++++++++++++++++++++");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Exit - \"E\"");
            Console.Write("Enter : ");
        }
        public static void FileMenuPrint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Open Searched by Name - \"A\"");
            Console.WriteLine("Open Searched by City - \"I\"");
            Console.WriteLine("Open Searched by Type - \"Y\"");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter : ");
        }
        public static void MoveToBinFile(IEnumerable<Brewery> brewList, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, brewList);
            }
        }
        public static IEnumerable<Brewery> GetFromBin(string filePath)
        {
            IEnumerable<Brewery> breweries = new List<Brewery>();
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fsr = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    breweries = (IEnumerable<Brewery>)formatter.Deserialize(fsr);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found - {e.Message}");
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Serialization exception - {e.Message}");
            }
            return breweries;
        }
        public static void PrintList(IEnumerable<Brewery> listToPrint)
        {
            if (listToPrint.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! No data found. Check the file existence.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (Brewery brewery in listToPrint)
                {
                    Console.WriteLine();
                    Console.WriteLine("-------");
                    Console.WriteLine($"ID : {brewery.id}");
                    Console.WriteLine($"Name : {brewery.name}");
                    Console.WriteLine($"City : {brewery.city}");
                    Console.WriteLine($"Type - {brewery.brewery_type}");
                    Console.WriteLine();
                }
            }
        }
    }
}
