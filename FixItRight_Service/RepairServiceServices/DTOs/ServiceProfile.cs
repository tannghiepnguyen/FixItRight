using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.RepairServiceServices.DTOs
{
	public class ServiceProfile : Profile
	{
		public ServiceProfile()
		{
			CreateMap<ServiceForCreationDto, Service>().ForSourceMember(c => c.File, opt => opt.DoNotValidate());
			CreateMap<ServiceForUpdateDto, Service>().ForSourceMember(c => c.File, opt => opt.DoNotValidate());
			CreateMap<Service, ServiceForReturnDto>();
		}
	}
}
