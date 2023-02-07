using Microsoft.AspNetCore.Components;

namespace Blaztrap.Controls;

    public partial class AsyncFieldset
    {

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
