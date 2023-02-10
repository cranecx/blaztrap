using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blaztrap.Controls;
public partial class BzOffcanvas
{
    [Parameter]
    public string? Title {  get; set; }

    [Parameter]
    public RenderFragment? ChildContent {  get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JS!.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Pronostikapp.Express.Blazor.Controls/Offcanvas.js");
        }
    }

    public async Task Show()
    {
        await _module!.InvokeVoidAsync("showOffcanvas", _element);
    }
    public async Task Hide()
    {
        await _module!.InvokeVoidAsync("hideOffcanvas", _element);
    }

}
