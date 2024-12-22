using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace miniproject
{
    class userclass
    {
        static string connectionString = "Server=ICS-LT-D244D67P;Database=mini_project;Trusted_Connection=True;";
        public static void usermenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. Book Ticket\n2. Cancel Ticket\n3. Show All Trains\n4.bookings & Cancellations \n5. Exit");
                Console.Write("Select Option: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    BookTicket();
                }
                else if (choice == 2)
                {
                    CancelTicket();
                }
                else if (choice == 3)
                {
                    ShowAllTrainss();
                }
                else if(choice==4)
                {
                    ShowBookings();
                    //break;
                   // Program.Main(); 
                }
                else
                {
                    Program.Main();
                    break;
                }

            }
        }
        //static void ShowAllTrains()
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("sp_ShowAllTrains", con) { CommandType = CommandType.StoredProcedure };
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        Console.WriteLine("Available Trains:");
        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"ID: {reader["TrainID"]}, Name: {reader["TrainName"]}, Source: {reader["Source"]}, Destination: {reader["Destination"]}");
        //        }
        //    }
        //}

        static void BookTicket()
        {
            ShowAllTrainss();
            Console.WriteLine("Enter Train Number:");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Passenger Name: ");
            string passengerName = Console.ReadLine();

            Console.Write("Passenger Age: ");
            int passengerAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Class Type (First/Second/Sleeper): ");
            string classType = Console.ReadLine();

            Console.Write("Number of Seats: ");
            int numberOfSeats = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_BookTicket", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@PassengerName", passengerName);
                    cmd.Parameters.AddWithValue("@PassengerAge", passengerAge);
                    cmd.Parameters.AddWithValue("@ClassType", classType);
                    cmd.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Ticket booked successfully.");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }





        static void CancelTicket()
        {
            Console.WriteLine("Enter Ticket ID to cancel:");
            int ticketID = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_CancelTicket", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Ticket canceled successfully.");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        static void ShowBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_ShowBookings", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        Console.WriteLine("\nBooking Details:");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("TicketID | PassengerName | Age | Class | Seats | TrainNo | TrainName | Source -> Destination | Status");
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                        while (reader.Read())
                        {
                            string status = (bool)reader["BookingStatus"] ? "Booked" : "Canceled";
                            Console.WriteLine($"{reader["TicketID"],-8} | {reader["PassengerName"],-15} | {reader["PassengerAge"],-3} | {reader["ClassType"],-7} | {reader["NumberOfSeats"],-5} | {reader["TrainNo"],-7} | {reader["TrainName"],-10} | {reader["Source"]} --> {reader["Destination"],-15} | {status}");
                        }

                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        public static void ShowAllTrainss()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ShowAllTrainss", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Available Trains:");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("TrainNo |   TrainName   |  Source  |  Destination  | First_class_seats  | second_class_seats  | sleeper_class_seats");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["TrainNo"],-7} | {reader["TrainName"],-14} |{reader["Source"],-10} | {reader["Destination"],-12} | {reader["first_class_available"],-14}  |  {reader["second_class_available"],-14}  | {reader["sleeper_class_available"],-14}");
                    
                }
            }
        }


    }




}
