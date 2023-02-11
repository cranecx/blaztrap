using Microsoft.AspNetCore.Components;

namespace Blaztrap.Controls;

public partial class BzModal
{
    [Parameter]
    public string? TitleText { get; set; }

    [Parameter]
    public RenderFragment? Body { get; set; }

    [Parameter]
    public RenderFragment? Footer { get; set; }
}
