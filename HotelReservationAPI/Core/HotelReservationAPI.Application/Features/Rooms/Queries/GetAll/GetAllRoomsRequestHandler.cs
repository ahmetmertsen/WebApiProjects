using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Rooms.Queries.GetAll
{
    public class GetAllRoomsRequestHandler : IRequestHandler<GetAllRoomsRequest, List<RoomDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRoomsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RoomDto>> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _unitOfWork.RoomRepository.GetAllAsync();
            return _mapper.Map<List<RoomDto>>(rooms);
        }
    }
}
