using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Coordiantes_Tools.External.ORS.Dtos
{
    public sealed record OrsFeatureCollection(
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("bbox")] List<decimal> Bbox,
            [property: JsonPropertyName("features")] List<OrsFeatures> Features
            //[property: JsonPropertyName("metadata")] OrsMetadata Metadata
        );
    public sealed record OrsFeatures(
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("properties")] OrsProperties Properties,
            [property: JsonPropertyName("geometry")] OrsGeometry Geometry
        );
    public sealed record OrsProperties(
            [property: JsonPropertyName("summary")] OrsSummary Summary,
            [property: JsonPropertyName("way_points")] List<int> WayPoints
        );
    public sealed record OrsSummary(
            [property: JsonPropertyName("distance")] decimal Distance,
            [property: JsonPropertyName("duration")] decimal Duration
       );
    public sealed record OrsGeometry(
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("coordinates")] List<List<decimal>> Coordinates
        );
}
