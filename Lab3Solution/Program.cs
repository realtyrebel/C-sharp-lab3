using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Solution
{
    class Program
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };


        static void Main(string[] args)
        {
            //initialize variables            
            int numberOfComparison = 0;


            //print array of integers
            Console.WriteLine("The initial unsorted integer array is:");
            Console.WriteLine("");
            //display array
            PrintArray(intArray);

            //get input: integer
            int validInteger = getInteger();
            //Console.WriteLine(validInteger);

            //do LinearSearch
            //check if integer is found in the array of numbers
            if (validInteger > 0)
            {
                //Linear Search
                int integerFound = LinearSearch(intArray, validInteger, ref numberOfComparison);

                if (integerFound != -1)
                {
                    Console.WriteLine("Linear search found number " + validInteger + " at index " + integerFound + " in this unsorted array.");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Linear search made " + intArray.Length + " comparisons to find that " + validInteger + " was not found in this unsorted array.");
                    Console.WriteLine("");
                }

                //Bubble Sort
                int swaps = BubbleSort(intArray);

                //output sorted array
                Console.WriteLine("Bubble sort made " + swaps + " swaps to sort this array:");
                Console.WriteLine("");

                //display sorted array
                PrintArray(intArray);
            }

            //get input: integer
            validInteger = getInteger();
            //Console.WriteLine(validInteger);
            if (validInteger > 0)
            {
                int integerFound = BinarySearch(intArray, validInteger, ref numberOfComparison);

                if (integerFound != -1)
                {
                    Console.WriteLine("Binary search found number " + validInteger + " by completing " + numberOfComparison + " comparisons on the sorted array at index" + integerFound + ".");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Binary search made " + numberOfComparison + " comparisons to find that " + validInteger + " was not found in the sorted array.");
                    Console.WriteLine("");
                }
            }

            Console.ReadLine();
        }


        //This method gets a valid integer from the user
        static int getInteger(){
            bool validInput = false;
            int inputNumber;
            int integer = 0;

            Console.WriteLine("");

            //check for valid input
            do
            {
                Console.Write("Please input an integer ... and press Enter: ");

                //user inputs integer
                string inputString = Console.ReadLine();
                Console.WriteLine("");

                if (!string.IsNullOrEmpty(inputString))//if not null, process integer values
                {
                    //check if input is valid integer
                    if (int.TryParse(inputString, out inputNumber))
                    {
                        if (inputNumber < 0)
                        {
                            Console.WriteLine("Please enter a non-negative integer.");
                            Console.WriteLine("");
                        }
                        else
                        {
                            integer = inputNumber;
                            validInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine("");
                    }
                }
                else
                {//if null or empty
                    Console.WriteLine("You did not enter an integer.");
                    Console.WriteLine("");
                }

                //display what was inputted
                //Console.WriteLine(inputString);
            } while (validInput == false);

            return integer;
        }



        //This method returns the index of a given needle (an int) in the haystack (an int array)
        //by using linear search. It also returns the value of the number of comparison used to 
        //find the given needle through the reference parameter numOfComparison.
        static int LinearSearch(int[] haystack, int needle, ref int numOfComparison)
        {
            int needleIndex = -1;

            //check length of array
            //Console.WriteLine("Array length is " + haystack.Length);

            //Here you search the needle in the haystack.
            for (int i = 0; i < haystack.Length; i++)
            {
                //Console.WriteLine("element {0} = {1}", i, haystack[i]);

                //count number of comparisons performed
                //counting starts at 0
                //numOfComparison += 1;
                numOfComparison = i;
                //Console.WriteLine("Comparison number " + numOfComparison);

                //see if needle equals haystack
                if (haystack[i] == needle)
                {
                    needleIndex = numOfComparison;//set to comparison iteration number
                }
            }
            return needleIndex;
        }

        
        static int BubbleSort(int[] array)
        {
            int numOfSwaps = 0;

            //Here you implement the bubble sort to sort the integer array arr.
            int temp = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                        numOfSwaps += 1;
                    }
                }
            }
            intArray = array;

            return numOfSwaps;
        }

        //This method returns the index of a given niddle (an int) in the haystack (an int array)
        //by using binary search. It also returns the value of the number of comparison used to 
        //find the given niddle through the reference parameter numOfComparison.
        //Works only on a sorted list.
        static int BinarySearch(int[] haystack, int needle, ref int numOfComparison)
        {
            int needleIndex = -1;
            numOfComparison = 0;
            int lengthOfArray = haystack.Length;

            if (lengthOfArray > 0)
            {
                int min = 0;
                int max = lengthOfArray - 1;

                while (min <= max)
                {
                    numOfComparison += 1;
                    //Console.WriteLine("____________________________________________");
                    //Console.WriteLine("Comparison #{0}", numOfComparison);
                    //Console.WriteLine("haystack[{0}] >>> min = {1}", min, haystack[min]);
                    //Console.WriteLine("haystack[{0}] >>> max = {1}", max, haystack[max]);

                    int mid = (min + max) / 2;
                    //Console.WriteLine("haystack[{0}] >>> mid = {1}", mid, haystack[mid]);

                    if (needle == haystack[mid])
                    {
                        //Console.WriteLine("{0} equals {1}", needle, haystack[mid]);
                        return needleIndex = mid;
                        //return ++mid;
                    }
                    else if (needle < haystack[mid])
                    {
                        max = mid - 1;
                        //Console.WriteLine("{0} < {1}, so change max = {2} >>> haystack[{3}]", needle, haystack[mid], haystack[max], max);
                    }
                    else
                    {
                        min = mid + 1;
                        //Console.WriteLine("{0} > {1}, so change min = {2} >>> haystack[{3}]", needle, haystack[mid], haystack[min], min);
                    }
                }
            }
            return needleIndex;                
        }

        //call this method to print an integer array to the console.
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    Console.Write("{0}, ", arr[i]);
                }
                else
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.WriteLine();
        }


    }
}
