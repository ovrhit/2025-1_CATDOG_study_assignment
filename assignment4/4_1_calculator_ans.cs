using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        public double Gcd(double num1, double num2) {
            if (num1 < num2) {
                double temp;
                temp = num1;
                num1 = num2;
                num2 = temp;
            }
            while (num2 != 0) {
                double tmp = num1 % num2;
                num1 = num2;
                num2 = tmp;
            }
            
            return num1;
        }
        
        // ---------- TODO ----------
        public double Calculate(double num1, string op, double num2) {
            
            switch (op) {
                
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "**": 
                    double result = 1;
                    bool neg = (num2 < 0) ? true : false;
                    if (neg) {
                        for (int i = 0; i > num2; i--) {
                            result /= num1;
                        }
                    } else {
                         for (int i = 0; i < num2; i++) {
                             result *= num1;
                         }
                    }
                    return result;
                case "%": return num1 % num2;
                case "G": return Gcd(num1, num2);
                case "L": return num1 * num2 / Gcd(num1, num2);
                case "/":
                    if (num2 == 0) {
                        throw new DivideByZeroException("Division by zero is not allowed");
                    } else return num1 / num2;
                default: throw new InvalidOperationException("Invalid operator");
            }
        
        }
        // --------------------
    }
}

