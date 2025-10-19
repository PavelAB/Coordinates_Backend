using Azure;
using Coordiantes_Tools.Results;
using Coordinates_CQS_Domain.Entities.Track;
using Coordinates_CQS_Domain.Mappers;
using Coordinates_CQS_Domain.Queries.ORS;
using Coordinates_CQS_Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Services
{
    public class ORSService : IORSRepository
    {

        public async ValueTask<ICqsResult<TrackCreate>> ExecuteAsync(GetTrackORSQuery query)
        {
            string url = $"https://api.openrouteservice.org/v2/directions/cycling-road?start={query.Start}&end={query.End}";

            using (HttpClient httpClient = new())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", query.Key); // Validation
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json, application/geo+json, application/gpx+xml, image/png; charset=utf-8");

                using (HttpResponseMessage response = await httpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    string responseData = await response.Content.ReadAsStringAsync();
                    return ICqsResult<TrackCreate>.Success(Mapper.MapToTrackCreate(responseData));
                }
            }
        }
    }
}
