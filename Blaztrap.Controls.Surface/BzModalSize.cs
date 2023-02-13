using Blaztrap.Abstractions;

namespace Blaztrap.Controls;

public enum BzModalSize
{
    Default = 0,

    [BzClass("modal-sm")]
    Small = 1,

    [BzClass("modal-lg")]
    Large = 2,

    [BzClass("modal-xl")]
    ExtraLarge = 3
}
