﻿namespace HotelReservationAPI.WebAPI.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message ?? "Successfully"
            };
        }
        public static ApiResponse<T> FailResponse(string message = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message ?? "Error"
            };
        }
    }
}
