using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Queries.GetById
{
    public class GetByIdReservationRequestHandler : IRequestHandler<GetByIdReservationRequest, ReservationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdReservationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(GetByIdReservationRequest request, CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
