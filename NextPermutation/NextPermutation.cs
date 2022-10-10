namespace NextPermutation
{
    public class NextPermutation
    {
        public int[] GetNextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 0 || nums.Length > 100)
                throw new ArgumentException();
            if(nums.Any(n => n > 100))
                throw new ArgumentException();

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
            if(pivot == -1)
            {
                Reverse(nums, 0, nums.Length - 1);
                return nums;
            }

            int rightmostSuccessor = -1;
            int successorIndex = -1;
            for (int i = nums.Length - 1; i > pivotIndex; i--)
            {
                if (nums[i] > pivot)
                {
                    rightmostSuccessor = nums[i];
                    successorIndex = i;
                    break;
                }
            }
            //Swap
            Swap(nums, pivotIndex, successorIndex);

            //Reverse the suxfix
            Reverse(nums, pivot + 1, nums.Length - 1);

            return nums;
        }

        private void Swap(int[] nums, int i, int j)
        {
            if (i < nums.Length && i >= 0 && j < nums.Length && j >= 0) { 
                int aux = nums[i];
                nums[i] = nums[j];
                nums[j] = aux;
            }
        }
        /// <summary>
        /// Reverse an array of intergers from the start index to the end index
        /// </summary>
        /// <param name="nums">Imput array</param>
        /// <param name="start">The index from where to start to preform the reverse</param>
        /// <param name="end">The index from where to stop reversing</param>
        private void Reverse(int[] nums, int start, int end)
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