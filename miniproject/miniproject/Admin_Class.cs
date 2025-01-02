using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace miniproject
{
    class Admin_Class
    {

        static string connectionString = "Server=ICS-LT-D244D67P;Database=mini_project;Trusted_Connection=True;";
        public static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Train\n2. Modify Train\n3. Delete Train\n4. Show All Trains\n5. Exit");
                Console.Write("Select Option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    AddTrain();
                }
                else if (choice == 2)
                {
                    ModifyTrain();
                }
                else if (choice == 3)
                {
                    DeleteTrain();
                }
                else if (choice == 4)
                {
                    ShowAllTrains();
                }
                else if (choice == 5)
                {
                    //Console.WriteLine("exiting the admin menu");
                    Program.Main();
                    break;

                }
                else
                {
                    Console.WriteLine("enter valid option");
                }
            }
        }


        static void AddTrain()
        {
            Console.WriteLine("*********Enter train details*****");

            Console.WriteLine("enter train number");
            int trainno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Train Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("total seats in first class");
            int first_class_seats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("total available seats  in first class");
            int first_class_available = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("total seats in second class");
            int second_class_seats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("total available seats  in second class");
            int second_class_available = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("total seats in sleeper class");
            int sleeper_class_seats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("total available seats  in sleeper class");
            int sleeper_class_available = Convert.ToInt32(Console.ReadLine());


            Console.Write("Source: ");
            string source = Console.ReadLine();

            Console.Write("Destination: ");
            string destination = Console.ReadLine();

           

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AddTrains", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@TrainNo", trainno);
                cmd.Parameters.AddWithValue("@TrainName", name);
                cmd.Parameters.AddWithValue("@first_class_total", first_class_seats);
                cmd.Parameters.AddWithValue("@first_class_available", first_class_available);
                cmd.Parameters.AddWithValue("@second_class_total", second_class_seats);
                cmd.Parameters.AddWithValue("@second_class_available", first_class_available);
                cmd.Parameters.AddWithValue("@sleeper_class_total", sleeper_class_seats);
                cmd.Parameters.AddWithValue("@sleeper_class_available", sleeper_class_available);


                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);

               
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("train added successfully");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                }
            }

        

        }

        static void ModifyTrain()
        {
            Console.WriteLine("Enter the train number to modify:");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Train Name: ");
            string trainName = Console.ReadLine();

            Console.WriteLine("Total seats in first class:");
            int firstClassSeats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Total available seats in first class:");
            int firstClassAvailable = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Total seats in second class:");
            int secondClassSeats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Total available seats in second class:");
            int secondClassAvailable = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Total seats in sleeper class:");
            int sleeperClassSeats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Total available seats in sleeper class:");
            int sleeperClassAvailable = Convert.ToInt32(Console.ReadLine());

            Console.Write("Source: ");
            string source = Console.ReadLine();

            Console.Write("Destination: ");
            string destination = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_ModifyTrainDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@TrainName", trainName);
                    cmd.Parameters.AddWithValue("@first_class_total", firstClassSeats);
                    cmd.Parameters.AddWithValue("@first_class_available", firstClassAvailable);
                    cmd.Parameters.AddWithValue("@second_class_total", secondClassSeats);
                    cmd.Parameters.AddWithValue("@second_class_available", secondClassAvailable);
                    cmd.Parameters.AddWithValue("@sleeper_class_total", sleeperClassSeats);
                    cmd.Parameters.AddWithValue("@sleeper_class_available", sleeperClassAvailable);
                    cmd.Parameters.AddWithValue("@Source", source);
                    cmd.Parameters.AddWithValue("@Destination", destination);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Train details updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }
            

            static void DeleteTrain()
            {
                Console.Write("Train ID to Delete: ");
                int trainID = Convert.ToInt32(Console.ReadLine());
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteTrain", con)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@TrainNo", trainID);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("train marked as inactivee");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error message{ex.Message}");
                }
                }
               // Console.WriteLine("Train Deleted Successfully.");
            }
     
        public static void ShowAllTrains()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ShowAllTrains", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Available Trains:");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("TrainNo |   TrainName   |  Source  |  Destination  | Train_status ");
                Console.WriteLine("---------------------------------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["TrainNo"],-7} | {reader["TrainName"],-14} |{reader["Source"],-10} | {reader["Destination"],-10} | {reader["IsActive"]}");
                   
                }
            }
        }



    }
 }

