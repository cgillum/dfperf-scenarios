using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DFPerfScenarios
{
    public static class Common
	{
		[FunctionName("HelloSequence")]
		public static async Task<List<string>> HelloSequence([OrchestrationTrigger] IDurableOrchestrationContext context)
		{
			List<string> outputs = new List<string>();
            outputs.Add(await context.CallActivityAsync<string>("SayHello", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("SayHello", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("SayHello", "London"));
			return outputs;
		}

		[FunctionName("SayHello")]
		public static string SayHello([ActivityTrigger] string name)
		{
			return "Hello " + name + "!";
		}
	}
}
