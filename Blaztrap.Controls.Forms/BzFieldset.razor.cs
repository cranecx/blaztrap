using Microsoft.AspNetCore.Components;

namespace Blaztrap.Controls;

    public partial class BzFieldset
    {

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
