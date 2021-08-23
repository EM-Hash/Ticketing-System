using System;
using System.IO;

namespace Ticketing_System
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            while(cont){
            //Does the user want to view tickets, add tickets, or erase all the tickets?
            Console.WriteLine("Welcome to the Ticketing Service!");
            Console.WriteLine("What would you like to do?:");
            Console.WriteLine("1.) View Tickets");
            Console.WriteLine("2.) Add Tickets");
            Console.WriteLine("3.) Clear Tickets");
            string answer = Console.ReadLine();
            if (answer == "1"){
                //If the user wants to read...
                //Create a reader
                StreamReader sr = new StreamReader("Tickets.csv");
                //For each line...
                while(!sr.EndOfStream){
                    //Separate out the sections
                    string line = sr.ReadLine();
                    string[] phrase = line.Split(',');
                    //Start printing out the sections with a | in between
                    for (int i = 0; i < phrase.Length - 1; i++){
                        Console.Write(phrase[i] + " | ");
                    }
                    //For the Watching, split it again based on the | and print w/ commas
                    string[] names = phrase[phrase.Length - 1].Split('|');
                    for (int i = 0; i < names.Length - 1; i++){
                        Console.Write(names[i] + ", ");
                    }
                    Console.WriteLine(names[names.Length - 1]);
                    Console.WriteLine();
                }
                sr.Close();
            } else if (answer == "2"){
                //If the user wants to write...
                //Create a writer
                StreamWriter sw = new StreamWriter("Tickets.csv", append:true);
                //Prompt the user for the different categories:
                Console.WriteLine("What is the...");
                //TicketID
                Console.WriteLine("Ticked ID?");
                string ID = Console.ReadLine();
                //Summary
                Console.WriteLine("Summary?");
                string Summary = Console.ReadLine();
                //Status
                Console.WriteLine("Status?");
                string Status = Console.ReadLine();
                //Priority
                Console.WriteLine("Priority?");
                string Priority = Console.ReadLine();
                //Submitter
                Console.WriteLine("Submitter?");
                string Submitter = Console.ReadLine();
                //Assigned
                Console.WriteLine("Assigned?");
                string Assigned = Console.ReadLine();
                //Watching
                Console.WriteLine("Watching?");
                string Watching = Console.ReadLine();
                //Write to the file
                sw.WriteLine();
                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}\n",ID,Summary,Status,Priority,
                Submitter,Assigned,Watching);
                sw.Close();
                Console.WriteLine("The ticket has been added.");
            } else if (answer == "3"){
                //If the user wants to clear the tickets...
                //Make sure they really wanna
                Console.WriteLine("Are you sure? This cannot be undone. (Y/N): ");
                answer = Console.ReadLine().ToUpper();
                if (answer == "Y"){
                    //If they really want to...
                    //Create a reader
                    StreamWriter sw = new StreamWriter("Tickets.csv");
                    //Add in the staple top line
                    sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                    sw.Close();
                    Console.WriteLine("The tickets have been cleared.");
                } else {
                    //If they don't, just pass and go back to the menu
                    continue;
                }
            } else {
                cont = false;
            }
            }
            Console.WriteLine("Thank you for using the Ticketing Service, goodbye!");
        }
    }
}
