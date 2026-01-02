using Microsoft.JSInterop;
using TakeawayFinder.Models;

namespace TakeawayFinder.Interop;

public class GoogleMapsInterop : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;

    public GoogleMapsInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    private async Task EnsureModuleAsync()
    {
        _module = await _jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./googleMapsInterop.js");
    }

    public async Task InitMapAsync(double latitude, double longitude, int zoom)
    {
        await EnsureModuleAsync();
        await _module.InvokeVoidAsync("initMapAsync", latitude, longitude, zoom);
    }

    public async Task AddMarkerAsync(List<RestaurantDto> restaurant)
    {
        await EnsureModuleAsync();
        await _module.InvokeVoidAsync("addMarkerAsync", restaurant);
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            await _module.DisposeAsync();
        }
    }
}