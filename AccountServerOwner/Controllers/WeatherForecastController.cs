using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountServerOwner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        //------------------------ logger controller 
        private readonly ILoggerManager _logger;
        //public WeatherForecastController(ILoggerManager logger)
        //{
        //    _logger = logger;
        //}
        //-----------------------------
        public WeatherForecastController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            //_logger.LogDebug("Here is debug message from the controller.");
            //_logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");
            var domesticAccounts = _repository.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owners = _repository.Owner.FindAll();
            return new string[] { "value1", "value2" };
        }
    }
}