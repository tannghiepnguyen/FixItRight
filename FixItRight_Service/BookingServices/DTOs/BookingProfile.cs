using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.BookingServices.DTOs
{
	public class BookingProfile : Profile
	{
		public BookingProfile()
		{
			CreateMap<BookingForCreationDto, Booking>();
			CreateMap<BookingForUpdateDto, Booking>();
			CreateMap<Booking, BookingForReturnDto>();
		}
	}
}
