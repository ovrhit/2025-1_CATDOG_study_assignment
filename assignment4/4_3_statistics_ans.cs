using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            
            // Avg scores

            Console.WriteLine("Average scores:");
            for (int i = 2; i < data.GetLength(1); i++) {
                double subjectTotal = 0;
                for (int j = 1; j < 1 + stdCount; j++) {
                    subjectTotal += double.Parse(data[j,i]);
                }
                subjectTotal /= stdCount;
                Console.WriteLine($"{data[0,i].ToString()}: {subjectTotal, 0:N2}");
            }
            
            // Max & min scores
            
            Console.WriteLine("\nMax and min scores:");
            for (int i = 2; i < data.GetLength(1); i++) {
                int mx = 0; int mn = 100;
                for (int j = 1; j < 1 + stdCount; j++) {
                    if (int.Parse(data[j,i]) > mx) mx = int.Parse(data[j,i]);
                    if (int.Parse(data[j,i]) < mn) mn = int.Parse(data[j,i]);
                }
                Console.WriteLine($"{data[0,i].ToString()}: ({mn}, {mx})");
            }
            
            // Rank by total

            Console.WriteLine("\nStudents rank by total scores:");
            
            // Initiate Array total in format of [[total score, place]]
            int[,] total = new int[stdCount,2];
            for (int i = 1; i < data.GetLength(0); i++) {
                int scoreTotal = 0;
                for (int j = 2; j < data.GetLength(1); j++) {
                    scoreTotal += int.Parse(data[i,j]);
                }
                total[i-1,0] = scoreTotal;
            }

            for (int i = 0; i < stdCount; i++) {
                int place = 1;
                for (int j = 0; j < stdCount; j++) {
                    if (i != j && total[i,0] < total[j,0]) place++;
                }
                total[i,1] = place;
            }

            // Choosing prefixes and print
            for (int i = 1; i <= stdCount; i++) {
                string name = data[i,1];
                string prefix = "th";
                int place = total[i-1,1];

                if (place % 10 == 1 && place / 10 != 1) prefix = "st";
                if (place % 10 == 2 && place / 10 != 1) prefix = "nd";

                Console.WriteLine($"{name}: {place.ToString()}{prefix}");
            }
            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 2nd
Bob: 5th
Charlie: 1st
David: 4th
Eve: 3rd

*/
