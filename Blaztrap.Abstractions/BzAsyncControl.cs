using Blaztrap.Extensions;
using Microsoft.AspNetCore.Components;

namespace Blaztrap.Abstractions;

public abstract class BzAsyncControl : BzControl
{
    [Parameter]
    public string? OperationsFilter { get; set; }

    [Inject]
    public IAsyncHolderService? AsyncHolder { get; set; }

    private bool _isLoading;
    protected bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                InvokeAsync(() => StateHasChanged());
            }
        }
    }

    public BzAsyncControl()
    {
        InputAttributes = new();
    }

    protected override void OnInitialized()
    {
        AsyncHolder!.OnChange += AsyncHolderOnChange;
    }

    private void AsyncHolderOnChange()
    {
        IsLoading = AsyncHolder!.IsRunning(OperationsFilter!);
    }
}
