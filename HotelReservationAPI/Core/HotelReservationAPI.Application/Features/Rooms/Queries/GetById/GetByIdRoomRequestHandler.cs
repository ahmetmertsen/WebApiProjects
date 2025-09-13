using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Rooms.Queries.GetById
{
    public class GetByIdRoomRequestHandler : IRequestHandler<GetByIdRoomRequest, RoomDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdRoomRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomDto> Handle(GetByIdRoomRequest request,  CancellationToken cancellationToken)
        {
            var user =  await _unitOfWork.RoomRepository.GetByIdAsync(request.Id);
            return _mapper.Map<RoomDto>(user);
        }
    }
}
