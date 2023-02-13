using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;

namespace Blaztrap.Abstractions;
public abstract class BzControl : ComponentBase
{
    private bool _enabled = true;
    public bool Enabled
    {
        get { return _enabled; }
        protected set
        {
            _enabled = value;
            StateHasChanged();
        }
    }
    protected IJSObjectReference? Module { get; set; }
    protected ElementReference Element { get; set; }


    [Inject]
    public IJSRuntime? JS { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }

    public BzControl()
    {
        InputAttributes = new();
    }


    public virtual void Enable()
    {
        Enabled = true;
    }

    public virtual void Disable()
    {
        Enabled = false;
    }
}