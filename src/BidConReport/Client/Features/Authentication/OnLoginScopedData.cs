using Microsoft.Graph;

namespace BidConReport.Client.Features.Authentication;

public class OnLoginScopedData
{
    private readonly GraphServiceClient _graphServiceClient;
    private string _profilePhotoString = string.Empty;

    public OnLoginScopedData(GraphServiceClient graphServiceClient)
    {
        _graphServiceClient = graphServiceClient;
    }

    public string ProfilePhotoString
    {
        get => _profilePhotoString; set
        {
            _profilePhotoString = value;
            StateChanged?.Invoke();
        }
    }
    public event Action? StateChanged;
    public async Task SetPhotoStringAsync()
    {
        var photo = await _graphServiceClient.Me.Photo.Request().GetAsync();
        if (!photo.AdditionalData.ContainsKey("error"))
        {
            var ms = new MemoryStream();
            var photoStream = await _graphServiceClient.Me.Photo.Content.Request().GetAsync();
            photoStream.CopyTo(ms);
            var photoBytes = ms.ToArray();
            var photoBase64 = Convert.ToBase64String(photoBytes);
            ProfilePhotoString = $"data:image/png;base64,{photoBase64}";
        }
        //ProfilePhotoString = string.Empty;
    }
}
