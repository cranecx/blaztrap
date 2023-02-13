using Blaztrap.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blaztrap.Controls;

public partial class BzModal
{
	[Parameter]
	public RenderFragment? Header { get; set; }

	[Parameter]
	public RenderFragment? Body { get; set; }

	[Parameter]
	public RenderFragment? Footer { get; set; }

	[Parameter]
	public bool Scrollable { get; set; }

	[Parameter]
	public BzModalSize Size { get; set; }

    [Parameter]
    public BzBackdropStyle BackdropStyle { get; set; }

    [Parameter]
    public BzKeyboardBehavior KeyboardBehavior { get; set; }

    [Parameter]
	public BzModalFullScreenBehavior FullScreenBehavior { get; set; }

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender)
		{
			Module = await JS!.InvokeAsync<IJSObjectReference>(
				"import", "./_content/Blaztrap.Controls.Surface/Modal.js");
		}
	}

	public async Task Show()
	{
		await Module!.InvokeVoidAsync("showModal", Element);
	}
	public async Task Hide()
	{
		await Module!.InvokeVoidAsync("hideModal", Element);
	}
}
