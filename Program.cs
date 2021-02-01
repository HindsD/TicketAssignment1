using System;
using System.IO;

namespace Class2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            do
            {
                // ask user a question if they want to look at a ticket or make a ticket
                Console.WriteLine("1) Look at tickets.");
                Console.WriteLine("2) Create new ticket.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from the csv file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split('|');
                            
                            // display array data that shows ticket information
                            Console.WriteLine("Ticket ID: {0}\n Ticket Summary: {1}\n Status: {2}\n Priority: {3}\n Submitter: {4}\n Assigned: {5}\n Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // creates the csv file from data
                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 0; i < 10; i++)
                    {
                        // ask a question about entering a ticket
                        Console.WriteLine("Enter a ticket? (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }
                        // prompt for ticket id
                        Console.WriteLine("Enter the Ticket ID.");
                        // saves the id
                        string ticketID = Console.ReadLine();
                        // prompt for ticket summary
                        Console.WriteLine("Enter the ticket summary.");
                        // save the summary
                        string tSummary = Console.ReadLine();
                        //prompt for the status
                        Console.WriteLine("Enter the status.");
                        // save status
                        string tStatus = Console.ReadLine();
                        // prompt for priority
                        Console.WriteLine("Enter the priority.");
                        // save priority
                        string tPriority = Console.ReadLine();
                        // prompt who submitted the ticket
                        Console.WriteLine("Enter who submitted the ticket.");
                        // save the submitter
                        string tSubmitter = Console.ReadLine();
                        // prompt who was assigned the ticket
                        Console.WriteLine("Enter who is assigned to the ticket");
                        // save who was assigned
                        string tAssigned = Console.ReadLine();
                        // prompt for a wtchlist
                        Console.WriteLine("Enter the watchlist.");
                        // save the watchlist
                        string tWatched = Console.ReadLine();
                        sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", ticketID, tSummary, tStatus, tPriority, tSubmitter, tAssigned, tWatched);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
