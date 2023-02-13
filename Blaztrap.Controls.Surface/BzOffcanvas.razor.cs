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
            Module = await JS!.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blaztrap.Controls.Surface/Offcanvas.js");
        }
    }

    public async Task Show()
    {
        await Module!.InvokeVoidAsync("showOffcanvas", Element);
    }
    public async Task Hide()
    {
        await Module!.InvokeVoidAsync("hideOffcanvas", Element);
    }

}
