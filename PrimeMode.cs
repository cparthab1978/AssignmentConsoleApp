using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_ConsoleApp
{
    public interface IMode
    {
        int Execute(); // Method to execute a specific operation
        void Initialize(Dictionary<string, object> parameters); // Method to initialize the mode with parameters

    }
    public class PrimeMode : IMode
    {


        private int start; // Private member to store the start of the range
        private int end;   // Private member to store the end of the range

        /// <summary>
        /// Initialize method to set start and end values
        /// Assumes the dictionary contains keys "START" and "END" with integer values.
        /// </summary>
        /// <param name="parameters">Dictionary containing "START" and "END" keys.</param>
        public void Initialize(Dictionary<string, object> parameters)
        {
            // Assumption: The dictionary contains "START" and "END" keys.
            start = parameters.ContainsKey("START") ? Convert.ToInt32(parameters["START"]) : 0;
            end = parameters.ContainsKey("END") ? Convert.ToInt32(parameters["END"]) : 0;
        }


        /// <summary>
        /// Execute the logic to calculate the number of prime numbers in the range (start, end).
        /// </summary>
        /// <returns>Number of prime numbers between start and end (exclusive).</returns>
        public int Execute()
        {
            if (start >= end)
            {
                return 0; // If start is greater than or equal to end, there are no primes in the range
            }

            int primeCount = 0;
            for (int i = start + 1; i < end; i++)
            {
                if (IsPrime(i))
                {
                    primeCount++;
                }
            }

            return primeCount;
        }

        /// <summary>
        /// Helper method to check if a number is prime.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is prime, false otherwise.</returns>
        private bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false; // Numbers less than or equal to 1 are not prime
            }

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false; // If divisible by any number other than 1 and itself, it's not prime
                }
            }

            return true;
        }



    }
}
