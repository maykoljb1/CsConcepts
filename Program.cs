using System;
using System.Linq;
using System.Threading.Tasks;

namespace BigO {
    class Program {
        const int waitForMilliseconds = 500;

        static void Main (string[] args) {
            Console.WriteLine ("What is Big O Notation:");

            var inputData = getRandomArray (11);
            OuOne(inputData);
            OuN(inputData);
            OuNSquare(inputData);
            OuLogN (inputData);
        }

        static int[] getRandomArray (int arraySize = 10) {
            var randNum = new Random ();
            return Enumerable
                .Repeat (0, arraySize)
                .Select (i => randNum.Next (0, 100))
                .ToArray ();
        }

        static int[] OuOne (int[] inputData) {
            var iterations = 0;
            var executionTime = 0;
            Console.WriteLine ("O(1): The size of inputData will NOT affect the time execution of this function.");
            
            iterations++;            
            inputData[0] = 0;
            Task.Delay (waitForMilliseconds).Wait ();
            executionTime+=waitForMilliseconds;

            Console.WriteLine($"Iterations: {iterations} Execution Time: {executionTime} Milliseconds");
            return inputData;
        }

        static int[] OuN (int[] inputData) {
            var iterations = 0;
            var executionTime = 0;
            Console.WriteLine ("O(2): This function will take 500*n Milliseconds per each element in inputData to complete (n = inputData size).");

            foreach (var item in inputData) {
                iterations++;
                Task.Delay (waitForMilliseconds).Wait ();
                Console.WriteLine (item);
                executionTime+=waitForMilliseconds;
            }

            Console.WriteLine($"Iterations: {iterations} Execution Time: {executionTime} Milliseconds");
            return inputData;
        }

        static int[] OuNSquare (int[] inputData) {
            var iterations = 0;
            var executionTime = 0;
            
            Console.WriteLine ("O(n^2): This function will take 500*n^2 milliseconds (where n = inputData size) to complete.");

            for (var i = 0; i < inputData.Length; i++) {
                Task.Delay (waitForMilliseconds).Wait ();
                Console.WriteLine ($"Item in outer array: {inputData[i]}");                
                
                for (var j = inputData.Length -1; j >= 0; j--) {
                    iterations++;
                    Task.Delay (waitForMilliseconds).Wait ();
                    Console.WriteLine ($"Item in inner array: {inputData[j]}");
                    executionTime+=waitForMilliseconds;
                }
            }

            Console.WriteLine($"Iterations: {iterations} Execution Time: {executionTime} Milliseconds");
            return inputData;
        }
        static int[] OuLogN (int[] inputData) {
            var iterations = 0;
            var executionTime = 0;
            var idx = 0;
            var lBound = 0;
            var uBound = inputData.Length;                        
            
            Console.WriteLine ("O(Log(n)): This function will take less time to complete than it would if it had to iterate over each element");
            var numberToFind = inputData[new Random().Next(0, uBound - 1)];
            Console.WriteLine($"Looking for value: {numberToFind}");            

            Array.Sort(inputData);
            do {
                iterations++;
                idx = lBound + (uBound - lBound) / 2;

                if(numberToFind == inputData[idx]) {
                    lBound = uBound + 1;
                } else if(numberToFind < inputData[idx]) {
                    uBound = idx;
                } else {
                    lBound = idx;
                }

                Task.Delay (waitForMilliseconds).Wait();
                executionTime+=waitForMilliseconds;
            } while(lBound <= uBound);

            Console.WriteLine($"Value found at position: {idx}");
            Console.WriteLine($"Iterations: {iterations} Execution Time: {executionTime} Milliseconds");
            return inputData;
        }
    }
}