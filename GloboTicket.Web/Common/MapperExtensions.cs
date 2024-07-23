﻿using AutoMapper;
using GloboTicket.Application.Common.Settings;
using GloboTicket.Application.Models.Http;

namespace GloboTicket.Web.Common
{
    public static class MapperExtensions
    {
        public static ApiResponse<TDestination> MapToApiResponse<TSource, TDestination>(this IMapper profile,
            ResultSet result)
        {
            if (result.Data != null)
            {
                var res = profile.Map<TSource, TDestination>(result?.Data);
                return new ApiResponse<TDestination>(new ResultSet(res));
            }

            return new ApiResponse<TDestination>(result) ??
                   new ApiResponse<TDestination>(new ResultSet(Error.FailedToFormatResponse));
        }
    }
}