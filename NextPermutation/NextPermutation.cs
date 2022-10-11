namespace NextPermutation
{
    public class NextPermutation
    {
        /// <summary>
        /// Modifies the input array to the next lexicographically greater permutation of its integers
        /// </summary>
        /// <param name="nums">Array of intergers</param>
        /// <exception cref="ArgumentException">The length of the array must not exceed 100 elements and all integers must be less than 100</exception>
        public void GetNextPermutation(int[] nums)
        {
            //Validate input
            if (nums == null || nums.Length <= 0 || nums.Length > 100)
                throw new ArgumentException("The length of the input array must not exceed 100 elements.");
            if (nums.Any(n => n > 100))
                throw new ArgumentException("Each integer must be between 0 and 100");          

            //Find the pivot: the first element where nums[i - 1] < nums[i] from right to left ( 0 < i < nums.Length)
            int pivot = -1;
            int pivotIndex = -1;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if(nums[i] > nums[i - 1])
                {
                    pivot = nums[i - 1];
                    pivotIndex = i - 1;
                    break;
                }
            }
            //If the pivot didn't change it means the array is sorted ascending, therefore lets sort it descending (reverse)
            if (pivot == -1)
            {
                Reverse(nums, 0, nums.Length - 1);
                return;
            }
            //Look for the first element (from right to left) greater than the pivot
            int rightmostSuccessor, rightmostSuccessorIndex = -1;
            for (int i = nums.Length - 1; i > pivotIndex; i--)
            {
                if (nums[i] > pivot)
                {
                    rightmostSuccessor = nums[i];
                    rightmostSuccessorIndex = i;
                    break;
                }
            }
            //Swap the pivot with the rightmost successor
            Swap(nums, pivotIndex, rightmostSuccessorIndex);

            //Reverse the range from the elemt right next to the pivot to the end of the array
            Reverse(nums, pivot + 1, nums.Length - 1);
        }

        /// <summary>
        /// Swap the elements at indexes i and j
        /// </summary>
        /// <param name="nums">Input array</param>
        /// <param name="i">First element to swap</param>
        /// <param name="j">Second element to swap</param>
        private static void Swap(int[] nums, int i, int j)
        {
            if (i < nums.Length && i >= 0 && j < nums.Length && j >= 0) {
                (nums[j], nums[i]) = (nums[i], nums[j]);
            }
        }
        /// <summary>
        /// Reverse an array of intergers from the start index to the end index
        /// </summary>
        /// <param name="nums">Input array</param>
        /// <param name="start">Starting index</param>
        /// <param name="end">Ending index</param>
        private static void Reverse(int[] nums, int start, int end)
        {
            int s = start;
            int e = end;
            while (s < e)
            {
                Swap(nums, s, e);
                s++;
                e--;
            }
        }
    }
}