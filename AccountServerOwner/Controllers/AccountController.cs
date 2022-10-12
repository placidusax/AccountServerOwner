using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountServerOwner.Controllers
{
    [Route("api/account/{ownerId}/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AccountController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AccountsByOwner(Guid OwnerId, [FromQuery] AccountParameters parameters)
        {
            var accounts = _repository.Account.AccountsByOwner(OwnerId, parameters);

            _logger.LogInfo($"Returned all Account from database.");

            var accountsResult = _mapper.Map<IEnumerable<AccountDto>>(accounts);// if didn't use the dto then the owner will be null.. 

            var metadata = new
            {
                accounts.TotalCount,
                accounts.PageSize,
                accounts.CurrentPage,
                accounts.TotalPages,
                accounts.HasNext,
                accounts.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            _logger.LogInfo($"Returned {accounts.TotalCount} owners from database.");

            return Ok(accountsResult);
            //return Ok(accounts);
        }
        //do one more for 1 id for the owner
    }
}
