using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Model;

namespace AccountServerOwner
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<OwnerForCreationDto, Owner>();

            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
