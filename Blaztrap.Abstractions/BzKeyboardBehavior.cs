namespace Blaztrap.Abstractions;

public enum BzKeyboardBehavior
{
    Default = 0,

    [BzAttribute("data-bs-keyboard", "false")]
    None = 1,
}
