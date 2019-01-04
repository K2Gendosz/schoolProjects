using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataBase
{
   

    class Program
    {

         static List<Person> PersonList = new List<Person>(); 


        public struct Person
        {
        public string Name, LastName, PESEL ;
        public int Age ;
            
        }

        //-------------------------------------------

        static bool ShowMenu()
        {
            int choice;

            Console.WriteLine("***** MAIN MENU *****");
            Console.WriteLine("1. Show the list");
            Console.WriteLine("2. Add the person");
            Console.WriteLine("3. Remove the record");
            Console.WriteLine("4. Modify the person");
            Console.WriteLine("5. Show data of a person");
            Console.WriteLine("6. Read from file");
            Console.WriteLine("7. Save to file");
            Console.WriteLine("8. Delete a database file");
            Console.WriteLine("0. Exit\n");
            Console.Write("   Choose an option : ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(),out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ShowShortList();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            return true;
                        case 2:
                            AddPerson();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            return true;
                        case 3:
                            RemoveRecord();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            break;
                        case 4:
                            ModifyPerson();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            break;
                        case 5:
                            FullInfo();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            return true;
                        case 6:
                            ReadFromFile();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            return true;
                        case 7:
                            SaveToFile();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            return true;
                        case 8:
                            DeleteDatabaseFile();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                            return true;

                        case 0:
                            return false;
                        default:
                            Console.Write("Almost good. Try one mor time : ");
                            continue;
                    }
                    return true;
                }
                else
                {
                    Console.Write("Almost good. Try one mor time : ");
                }
            }
        }

        //---------------------------------------


        static void ShowShortList()
        {
            if (PersonList.Count!=0)
            {
                for (int i = 0; i < PersonList.Count; i++)
                 {
                     Console.WriteLine($"{i+1} - {PersonList[i].Name} {PersonList[i].LastName}");
                 }
            }
            else
            {
                Console.WriteLine("There are no records.");
            }
            
        }

        static void AddPerson()
        {
            Person Person = new Person();
            Person.Name = EnterData("Name",0);
            Person.LastName = EnterData("Last Name",0);
            Person.PESEL = VerifyPesel(0).ToString();
            Person.Age = EnterAge(0);

            PersonList.Add(Person);

        }

        static void RemoveRecord()
        {
            ShowShortList();

            Console.WriteLine("0 - Return to menu");
            Console.Write("Which record you want to remove : ");
            int index;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out index) && index <= PersonList.Count)
                {
                    if (index == 0)
                    {
                        return;
                    }
                    PersonList.RemoveAt(index-1);
                    break;
                }
                else
                {
                    Console.Write("Wrong index. Try one more time : ");
                }
            }
        }

        static void ModifyPerson()
        {
            Person Person = new Person();
             string name, lastName, pesel;
             int age;
            ShowShortList();
            Console.WriteLine("0 - Return to menu");

            Console.Write("Which record you want to modify : ");
            int index;
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out index) && index <= PersonList.Count)
                {
                    if (index==0)
                    {
                        return;
                    }
                    break;
                }
                else
                {
                    Console.Write("Wrong index. Try one more time : ");
                }
            }

            Console.Write($"Current value : {PersonList[index-1].Name}. ");
            name = EnterData("Name",1);
            if (!string.IsNullOrEmpty(name))
            { Person.Name = name; }
            else
            { Person.Name = PersonList[index - 1].Name; }

            Console.Write($"Current value : {PersonList[index - 1].LastName}. ");
            lastName = EnterData("Last Name",1);
            if (!string.IsNullOrEmpty(lastName))
            { Person.LastName = lastName; }
            else
            { Person.LastName = PersonList[index - 1].LastName; }

            Console.Write($"Current value : {PersonList[index - 1].PESEL}. ");
            pesel = VerifyPesel(1).ToString();
            if (!string.IsNullOrEmpty(pesel)&&pesel!="0")
            { Person.PESEL = pesel; }
            else
            { Person.PESEL = PersonList[index - 1].PESEL; }

            Console.Write($"Current value : {PersonList[index - 1].Age}. ");
            age = EnterAge(1);
            if (!string.IsNullOrEmpty(age.ToString())&&age!=0)
            { Person.Age = age; }
            else
            { Person.Age = PersonList[index - 1].Age; }

            PersonList.RemoveAt(index-1);
            PersonList.Insert(index - 1, Person);

        }

        static void FullInfo()
        {
            ShowShortList();
            Console.WriteLine("0 - Return to menu");
            Console.Write("Which record you want to print : ");
            
            int index;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out index) && index <= PersonList.Count)
                {
                    if (index == 0)
                    {
                        return;
                    }
                    break;
                }
                else
                {
                    Console.Write("Wrong index. Try one more time : ");
                }
            }

            Console.WriteLine($"{index}. {PersonList[index-1].Name} {PersonList[index-1].LastName} {PersonList[index-1].PESEL}  {PersonList[index-1].Age}");

        }

        static void ReadFromFile()
        {

            

            if (!Directory.Exists("databases"))
            {
                Console.WriteLine("No databases.");
                return;
            }

            string[] fileNames = Directory.GetFileSystemEntries("databases");

            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileName(fileNames[i]);
            }

            if (fileNames.Length==0)
            {
                Console.WriteLine("No databases.");
                return;
            }
            Console.WriteLine("If you want back to menu press Enter.");

            for (int i = 0; i < fileNames.Length; i++)
            {
                
                Console.WriteLine($"{i+1} - {fileNames[i]}");
            }
            Console.Write("Enter the name of database : ");
            string name = Console.ReadLine();
            if(File.Exists(@"databases\" + name + ".txt"))
            {
               

                StreamReader reader = new StreamReader(@"databases\" + name + ".txt");
                Person Person = new Person();

                PersonList.Clear();

                string line;
                char delimiter = ' ';
                string[] tab;
                while ((line = reader.ReadLine()) != null)
                {
                    tab = line.Split(delimiter);
                    if (tab.Length == 5)
                    {
                        Console.WriteLine($"{tab[1]} {tab[2]} {tab[3]} {tab[4]}");
                        Person.Name = tab[1];
                        Person.LastName = tab[2];
                        Person.PESEL = tab[3];
                        Person.Age = int.Parse(tab[4]);

                        PersonList.Add(Person);
                    }
                }
                reader.Close();
            }
            
        }


            static void SaveToFile()
        {
            if (PersonList.Count==0)
            {
                Console.WriteLine("No databases.");
                return;
            }

            if (!Directory.Exists("databases"))
            {
                Directory.CreateDirectory("databases");
            }

            Console.Write("Enter the name of new database : ");
            string name = Console.ReadLine();

            if (!File.Exists(@"databases\"+name+".txt"))
            {
                StreamWriter create = new StreamWriter(@"databases\" + name + ".txt");
                create.WriteLine("CLIENT - Database File");
                create.WriteLine(PersonList.Count);
                for (int i = 0; i < PersonList.Count; i++)
                {
                    create.WriteLine($"{i+1}. {PersonList[i].Name} {PersonList[i].LastName} {PersonList[i].PESEL} {PersonList[i].Age}");
                }
                    create.Close();
            }
            else
            {
                Console.WriteLine("You want to overwrite the database. ");
                Console.WriteLine("If you sure enter y and press Enter key. ");
                Console.WriteLine("If you don't want to overwrite the databas enter n and press Enter key");
                char ch =' ';
                while (true)
                {
                    if (char.TryParse(Console.ReadLine(),out ch)&&(ch=='y'||ch=='n'))
                    {
                        if (ch=='y')
                        {
                            StreamWriter create = new StreamWriter($"{name}.txt");
                            create.WriteLine("CLIENT - Database File");
                            create.WriteLine(PersonList.Count);
                            for (int i = 0; i < PersonList.Count; i++)
                            {
                                create.WriteLine($"{i + 1}. {PersonList[i].Name} {PersonList[i].LastName} {PersonList[i].PESEL} {PersonList[i].Age}");
                            }
                            create.Close();
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.Write("Enter y/n and press Enter key : ");
                    }
                }


            }
            
        }

        static void DeleteDatabaseFile()
        {
            if (!Directory.Exists("databases"))
            {
                Console.WriteLine("No databases.");
                return;
            }

            string[] filePaths = Directory.GetFiles("databases");
            string[] fileNames = filePaths;

            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileName(filePaths[i]);
                filePaths[i] = Path.GetFullPath(filePaths[i]);
            }

            if (fileNames.Length == 0)
            {
                Console.WriteLine("No databases.");
                return;
            }
            Console.WriteLine("If you want back to menu press Enter.");

            for (int i = 0; i < fileNames.Length; i++)
            {

                Console.WriteLine($"{i + 1} - {fileNames[i]}");
            }

            for (int i = 0; i < filePaths.Length; i++)
            {
                Console.WriteLine(filePaths[i]);
            }

        }

        //=======================================



        static void Main(string[] args)
        {
           
            while(ShowMenu())
            {
                Console.Clear();
            }
            
        }

        //========================================

        static string EnterData(string a,int b)
        {
            string data = "";
            Console.Write($"Enter the {a} : ");
            while (true)
            {
                data = Console.ReadLine();
               if(!string.IsNullOrEmpty(data)||b==1)
                { break; }
                else
                {
                    Console.Write("Field can't be empty. Try one mor time : ");
                }

            }

            return data;
        }

        static long VerifyPesel(int b)
        {
            Console.Write("Enter the PESEL number : ");
            long pesel;
            while (true)
            {
                
                if (long.TryParse(Console.ReadLine(),out pesel)&& pesel.ToString().Length==11||b==1)
                {
                    break;
                }
                else
                {
                    Console.Write("Pesel has eleven number. Try one more time : ");
                }
            }

            return pesel;

        }
        
        static int EnterAge(int b)
        {
                int age = 0;
                Console.Write("Enter the Age value : ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out age)||b==1)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Almost good. Try one mor time : ");
                    }
                }
                return age;
            
        }


    }
}
