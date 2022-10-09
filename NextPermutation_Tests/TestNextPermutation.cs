using Xunit;
using NextPermutation;
using System;
using System.Linq;

namespace NextPermutation_Tests
{
    public class TestNextPermutation
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [InlineData(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 1, 5 }, new int[] { 1, 5, 1 })]
        public void NextPermutation_ValidateExpectedResults(int[] nums, int[] expectedResult)
        {
            //Arrange
            var np = new NextPermutation.NextPermutation();

            //Act
            var result = np.GetNextPermutation(nums);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 10, 50, 100, 150 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                                21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                                41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
                                61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                                81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 })]
        public void NextPermutation_InvalidArguments_ThrowsArgumentException(int[] nums)
        {
            //Arrange
            var np = new NextPermutation.NextPermutation();

            //Act
            var action = () => np.GetNextPermutation(nums);

            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(action);
            Assert.Equal("expected error message here", exception.Message);
        }

        [Theory]
        [InlineData(new int[] { 1 })]
        public void NextPermutation_InputArrayWithOneElement_ReturnsSameArray(int[] nums)
        {
            //Arrange
            var np = new NextPermutation.NextPermutation();

            //Act
            var result = np.GetNextPermutation(nums);

            //Assert
            Assert.Equal(nums, result);
        }


    }
}