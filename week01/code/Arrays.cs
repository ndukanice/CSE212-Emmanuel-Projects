using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of doubles with size equal to 'length'
        // Step 2: Use a loop to fill each position in the array
        //         - At index i, store number * (i + 1)
        // Step 3: Return the filled array

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find the split point (where the list will be cut)
        //         - splitIndex = data.Count - amount
        // Step 2: Take the last 'amount' elements (right side)
        // Step 3: Take the first 'splitIndex' elements (left side)
        // Step 4: Clear the original list
        // Step 5: Add the right side first, then the left side back into 'data'

        int splitIndex = data.Count - amount;

        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
