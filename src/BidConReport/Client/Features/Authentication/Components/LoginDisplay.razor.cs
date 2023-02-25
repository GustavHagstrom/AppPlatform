using BidConReport.Client.Messages;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Microsoft.Graph;

namespace BidConReport.Client.Features.Authentication.Components;

public partial class LoginDisplay : IRecipient<AuthenticationChangedMessage>
{
    [Inject] public required GraphServiceClient GraphClient { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }
    [CascadingParameter] public required MudTheme Theme { get; set; }
    public bool IsOpen { get; set; } = false;
    public string PhotoString { get; set; } = string.Empty;

    protected override void OnInitialized()
    {
        WeakReferenceMessenger.Default.Register<AuthenticationChangedMessage>(this);
    }
    protected override async Task OnInitializedAsync()
    {
        await GetPhotoStringAsync();
    }
    public void ToggleOpen()
    {
        if (IsOpen)
            IsOpen = false;
        else
            IsOpen = true;
    }
    public string GetInitials(string? name)
    {
        if (name is null) return string.Empty;
        var names = name.Split(" ");
        var initials = string.Empty;
        foreach (var item in names)
        {
            initials += item.First();
        }
        return initials;
    }
    public void BeginLogOut()
    {
        IsOpen= false;
        NavigationManager.NavigateToLogout("authentication/logout");
    }
    public async void Receive(AuthenticationChangedMessage message)
    {
        await GetPhotoStringAsync();
    }
    public async Task GetPhotoStringAsync()
    {
        var photo = await GraphClient.Me.Photo.Request().GetAsync();
        if (!photo.AdditionalData.ContainsKey("error"))
        {
            var ms = new MemoryStream();
            var photoStream = await GraphClient.Me.Photo.Content.Request().GetAsync();
            photoStream.CopyTo(ms);
            var photoBytes = ms.ToArray();
            var photoBase64 = Convert.ToBase64String(photoBytes);
            PhotoString = $"data:image/png;base64,{photoBase64}";
        }
        else
        {
            PhotoString = string.Empty;
        }
        StateHasChanged();
    }
}
