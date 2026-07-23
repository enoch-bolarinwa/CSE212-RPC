using System.Text.Json.Serialization;

/// <summary>
/// Represents the top-level GeoJSON object returned by the USGS earthquake feed.
/// See: https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
/// </summary>
public class FeatureCollection
{
    public string Type { get; set; } = "";

    public List<Feature> Features { get; set; } = new();
}

/// <summary>
/// Represents a single earthquake entry ("feature") in the GeoJSON feed.
/// </summary>
public class Feature
{
    public string Type { get; set; } = "";

    public FeatureProperties Properties { get; set; } = new();
}

/// <summary>
/// The subset of earthquake properties we care about: location and magnitude.
/// The USGS feed contains many more fields (time, url, tsunami, etc.), but only
/// 'place' and 'mag' are needed here.
/// </summary>
public class FeatureProperties
{
    public double Mag { get; set; }

    public string Place { get; set; } = "";
}
