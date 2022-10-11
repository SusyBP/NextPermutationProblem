namespace NextPermutationWebAPI
{
    public class NextPermutationResult
    {
        public NextPermutationResult(string statusMessage, int[] nums)
        {
            Permutation = nums;
            StatusMessage = statusMessage;
        }
        public int[] Permutation { get; set; }

        public string StatusMessage { get; set; }

    }
}