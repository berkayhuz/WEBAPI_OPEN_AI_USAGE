using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace AIApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatGPTController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string input)
        {
            string output = "";

            try
            {
                var openai = new OpenAIAPI("API_ANAHTARI");

                CompletionRequest completionRequest = new CompletionRequest();
                completionRequest.Prompt = input;
                completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
                completionRequest.MaxTokens = 1024;

                var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

                foreach (var completion in completions.Completions)
                {
                    output += completion.Text;
                }

                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }
    }
}
