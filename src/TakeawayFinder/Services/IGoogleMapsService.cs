namespace TakeawayFinder.Services;

public interface IGoogleMapsService
{
    Task InitMapAsync(
        double latitude,
        double longitude,
        int zoom);

    Task AddMarkerAsync(
        double latitude,
        double longitude);
}