using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.RepairServiceServices.DTOs
{
	public class ServiceProfile : Profile
	{
		public ServiceProfile()
		{
			CreateMap<ServiceForCreationDto, Service>();
			CreateMap<ServiceForUpdateDto, Service>();
			CreateMap<Service, ServiceForReturnDto>();
		}
	}
}
