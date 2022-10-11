using Microsoft.AspNetCore.Mvc;

namespace NextPermutationWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NextPermutationController : ControllerBase
    {     

        [HttpPost(Name = "GetNextPermutation")]
        public  NextPermutationResult Post([FromBody] int[] nums)
        {
            var np = new NextPermutation.NextPermutation();
            try
            {
                np.GetNextPermutation(nums);
            }
            catch (Exception e)
            {
                return new NextPermutationResult(statusMessage: e.Message, Array.Empty<int>()); ;
            }
           
            return new NextPermutationResult(statusMessage: "OK", nums);
        }

    }
}