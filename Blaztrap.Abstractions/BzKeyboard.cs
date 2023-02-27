namespace Blaztrap.Abstractions;

public enum BzKeyboard
{
    Default = 0,

    [BzAttribute("data-bs-keyboard", "false")]
    None = 1,
}
