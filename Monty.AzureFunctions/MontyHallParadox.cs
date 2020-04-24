namespace Monty.AzureFunctions
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    using Monty.Simulations.InformedHost;
    using Monty.AzureFunctions.Models;

    public static class MontyHallParadox
    {
        private const string NumberOfGamesParameter = "numberOfGames";
        private const string SwitchDoorParameter = "switchDoor";

        [FunctionName("Simulation")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest request, ILogger log)
        {
            if(request == null)
            {
                return new BadRequestResult();
            }

            if (!request.Query.ContainsKey(NumberOfGamesParameter) || !int.TryParse(request.Query[NumberOfGamesParameter], out var numberOfGames) || numberOfGames <= 0)
            {
                return new BadRequestObjectResult($"Query parameter {NumberOfGamesParameter} must be supplied and have an integer value greater than zero.");
            }

            if(!request.Query.ContainsKey(SwitchDoorParameter) || !bool.TryParse(request.Query[SwitchDoorParameter], out var switchDoor))
            {
                return new BadRequestObjectResult($"Query parameter {SwitchDoorParameter} must be supplied and have a boolean value.");
            }

            log.LogInformation($"Azure Function \"Simulation\" performing simulation of {numberOfGames} games with strategy{(switchDoor ? " " : " do not ")}switch door.");

            var simulation = new InformedHostSimulation();
            var result = simulation.Run(numberOfGames, switchDoor);
            var response = new SimulationResponse(result);

            return new JsonResult(response);
        }
    }
}
