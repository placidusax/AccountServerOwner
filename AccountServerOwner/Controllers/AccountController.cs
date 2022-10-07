using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AccountsByOwner(Guid OwnerId)
        {
            var accounts = _repository.Account.AccountsByOwner(OwnerId);

            _logger.LogInfo($"Returned all Account from database.");

            var accountsResult = _mapper.Map<IEnumerable<AccountDto>>(accounts);// if didn't use the dto then the owner will be null.. 
            return Ok(accountsResult);
            //return Ok(accounts);
        }
        //do one more for 1 id for the owner
    }
}
