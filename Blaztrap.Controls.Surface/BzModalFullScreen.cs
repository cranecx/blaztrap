using Blaztrap.Abstractions;

namespace Blaztrap.Controls;

public enum BzModalFullScreen
{
    None = 0,

    [BzClass("modal-fullscreen")]
    Always = 1,

    [BzClass("modal-fullscreen-sm-down")]
    WhenSmall = 2,

    [BzClass("modal-fullscreen-md-down")]
    WhenMiddle = 3,

    [BzClass("modal-fullscreen-lg-down")]
    WhenLarge = 4,

    [BzClass("modal-fullscreen-xl-down")]
    WhenXLarge = 5,

    [BzClass("modal-fullscreen-xxl-down")]
    WhenXXLarge = 6
}
