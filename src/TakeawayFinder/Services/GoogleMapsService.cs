using Microsoft.JSInterop;
using TakeawayFinder.Interop;
using TakeawayFinder.Models;

namespace TakeawayFinder.Services;

public class GoogleMapsService : IGoogleMapsService
{
    private readonly GoogleMapsInterop _interop;
    
    public GoogleMapsService(GoogleMapsInterop interop)
    {
        _interop = interop;
    }

    public async Task InitMapAsync(double latitude, double longitude, int zoom)
    {
        await _interop.InitMapAsync( latitude, longitude, zoom);
    }

    public async Task AddMarkerAsync(List<RestaurantDto> restaurant)
    {
        await _interop.AddMarkerAsync(restaurant);
    }
}