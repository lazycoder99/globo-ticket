using AutoMapper;
using GloboTicket.Application.Common.Settings;
using GloboTicket.Application.Models.Http;
using GloboTicket.Web.Models;

namespace GloboTicket.Web.Common
{
    public static class MapperExtensions
    {
        public static ApiResponse<TDestination> MapToApiResponse<TDestination>(this IMapper profile,
            ResultSet result)
        {
            if (result.Data != null)
            {
                var res = profile.Map<TDestination>(result?.Data);
                return new ApiResponse<TDestination>(new ResultSet(res));
            }

            return new ApiResponse<TDestination>(result) ??
                   new ApiResponse<TDestination>(new ResultSet(Error.FailedToFormatResponse));
        }
    }
}
