using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.TransactionServices.DTOs
{
	public class TransactionProfile : Profile
	{
		public TransactionProfile()
		{
			CreateMap<TransactionForCreationDto, Transaction>();
			CreateMap<Transaction, TransactionForReturnDto>();
		}
	}
}
