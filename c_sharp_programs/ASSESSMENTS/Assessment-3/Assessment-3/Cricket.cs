using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    public class CricketTeam
    {
        public string TeamName
        {
            get;
            set;
        }
        public int Matches
        {
            get;
            set;
        }
        public int Sum
        {
            get;
            set;
        }
        public double Average
        {
            get;
            set;
        }
        public (int,int,double)pointscalculation(int noOfMatches)
        {
            Sum = 0;
            for(int i = 0; i < noOfMatches; i++)
            {
                Console.WriteLine($"enter score for match {i + 1} : ");
                Sum += Convert.ToInt32(Console.ReadLine());
            }
            Matches = noOfMatches;
            Average = (double)Sum / noOfMatches;
            return (Matches, Sum, Average);
        }
    }

    class Cricket
    {
        public static void Main()
        {
            CricketTeam team = new CricketTeam();
            Console.Write("enter the team name : ");
            string Teamname = Console.ReadLine();
            Console.Write("enter the number of matches : ");
            int noOfMatches = Convert.ToInt32(Console.ReadLine());

            var (matches, sum, average) = team.pointscalculation(noOfMatches);
            Console.WriteLine("====== The statistics=======");
            Console.WriteLine($"Team :{Teamname}\n Matches:{ matches}\n Sum: {sum}\n Average :{average}");

            Console.Read();
        }
    }
}
