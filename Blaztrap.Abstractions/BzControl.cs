﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blaztrap.Abstractions;
public abstract class BzControl : ComponentBase
{
    protected IJSObjectReference? _module;
    protected ElementReference _element;

    public BzControl()
    {
        AdditionalAttributes = new Dictionary<string, object>();
    }

    [Inject]
    public IJSRuntime? JS { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; }

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

    public virtual void Enable()
    {
        Enabled = true;
    }

    public virtual void Disable()
    {
        Enabled = false;
    }
}