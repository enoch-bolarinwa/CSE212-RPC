public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
   {
        // Plan (Problem 1):
        // Step 1: Create a new double array called 'result' with a size equal to 'length'.
        //         This array will hold every multiple we calculate.
        double[] result = new double[length];

        // Step 2: Loop through the array using an index 'i' that goes from 0 up to (but not
        //         including) 'length'. This ensures we fill every slot in the array exactly once.
        for (int i = 0; i < length; i++)
        {
            // Step 3: For each index 'i', calculate the multiple as 'number' times (i + 1).
            //         We use (i + 1) instead of 'i' because the first multiple in the array
            //         should be 1 * number (not 0 * number), the second should be 2 * number,
            //         and so on, matching the example: MultiplesOf(7, 5) -> {7, 14, 21, 28, 35}.
            result[i] = number * (i + 1);
        }

            // Step 4: Once every slot has been filled, return the completed 'result' array.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    / </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan (Problem 2):
        // Step 1: Rotating right by 'amount' means the last 'amount' elements of the list need
        //         to move to the front, and everything before them shifts to the back.
        //         Calculate the index where that "last amount elements" section begins:
        //         splitIndex = data.Count - amount.
        int splitIndex = data.Count - amount;

        // Step 2: Extract the elements from splitIndex to the end of the list. These are the
        //         elements that need to move to the front. Store them in a temporary list 'tail'.
        List<int> tail = data.GetRange(splitIndex, amount);

        // Step 3: Extract the elements from index 0 up to (but not including) splitIndex. These
        //         are the elements that need to move to the back. Store them in a temporary
        //         list 'head'.
        List<int> head = data.GetRange(0, splitIndex);

        // Step 4: Clear out the original 'data' list so it can be rebuilt in the rotated order.
        data.Clear();

        // Step 5: Add 'tail' back into 'data' first (since those elements now come first after
        //         rotating), followed by 'head' (since those elements now come last).
        //         This modifies 'data' in place rather than returning a new list.
        data.AddRange(tail);
        data.AddRange(head);
    }
}
