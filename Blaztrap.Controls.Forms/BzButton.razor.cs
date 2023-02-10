using Microsoft.AspNetCore.Components;

namespace Blaztrap.Controls;

public partial class BzButton
{
    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? LoadingText { get; set; }
}
