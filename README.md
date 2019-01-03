# What the heck is Big O notation?

## TL;DR
In short “Big O notation” is way to express mathematically (with an small equation) how much will increase the time it takes for a function to complete, based on the length of data is inputted in the worst case scenario.

## All right!, now, how is this relevant in software development? 
One of the most important tasks for most of the systems we develop daily is to apply operations to big lists of data (some of a few thousands, other of millions of records), like sorting, ordering, transforming, and others. Having a good performance on the functions that do those operations is extremely important, nobody wants to get a call because the system has 24 hours running the data load, right?  Here is where Big O notation will help you to detect/predict the performance or time of completion of a function based on length of data is inputted in **the worst case scenario** (in other words if for a random reason the function omitted all our: if/then, exit/continue, etc checks, and has to iterate over each element of the array).

Now that we understand why it is relevant and benefits we can get, let's look at some concepts with code :)

### O(1): /ou one/ 
It means that **no matter the size of the input array of data the function receives it will ALWAYS take same amount of time to complete** it doesn’t matter if it is 1 hour or 2 seconds, or if it receives an array with a Billion of elements or 1 element it will always take the same amount of time to complete. Example:

``` cs
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
```

### O(n): /ou n/ 
It means that the function completion **time will increase in a constant way for each item in the input array**, so if your function takes 1 second to process 1 element, it will take 1000 seconds to process 1000 elements Example:
``` cs       
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
```

### O(n^2) /ou n square/ 
Be careful with this one, it means that **the execution time will be squared based on the input array length**, the most common example are 2 chained arrays (like in sort function) which may be ok but if we are not careful it can cause serious performance issues. Example:
``` cs       
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
```

### O(log(n)) /ou log n/
And you used to think that those mathematic classes at high school were not useful uh?, log(n) is equivalent to say: 2^x where x < n, which in good christian means that **the function will always do less iterations than the length of the array (therefore less time in compleat)**, sounds cool right? how can we accomplish that? A common example is by using binary search operation. Example:

``` cs
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
```       
