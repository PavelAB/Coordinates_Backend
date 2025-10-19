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
using System.Net.Http.Headers;
using System.Text.Json;

namespace Coordinates_CQS_Domain.Services
{
    public class ORSService : IORSRepository
    {

        public async ValueTask<ICqsResult<TrackCreate>> ExecuteAsync(GetTrackORSQuery query)
        {
            Uri baseAddress = new Uri("https://api.openrouteservice.org");
            try
            {

                object body = new
                {
                    coordinates = query.Coordinates
                    .Select(c => new[] { c.Longitude, c.Latitude })
                    .ToArray(),
                    elevation = true,
                    extra_info = new[] { "surface", "waytype" }
                };

                string json = JsonSerializer.Serialize(body);

                using (HttpClient httpClient = new() { BaseAddress = baseAddress })
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", query.Key);

                    using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))

                    using (HttpResponseMessage response = await httpClient.PostAsync("/v2/directions/cycling-road/geojson", content))
                    {

                        response.EnsureSuccessStatusCode();
                        string responseData = await response.Content.ReadAsStringAsync();
                        return ICqsResult<TrackCreate>.Success(Mapper.MapToTrackCreate(responseData));

                    }


                }

            }
            catch (Exception e)
            {
                return ICqsResult<TrackCreate>.Failure(e.Message);
            }

        }

    }
}
