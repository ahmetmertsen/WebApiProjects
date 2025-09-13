using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Queries.GetAll
{
    public class GetAllReservationsRequestHandler : IRequestHandler<GetAllReservationsRequest, List<ReservationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReservationsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReservationDto>> Handle(GetAllReservationsRequest request, CancellationToken cancellationToken)
        {
            var reservations = await _unitOfWork.ReservationRepository.GetAllAsync();
            return _mapper.Map<List<ReservationDto>>(reservations);
        }
    }
}
