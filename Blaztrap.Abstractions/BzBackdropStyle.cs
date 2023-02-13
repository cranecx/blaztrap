namespace Blaztrap.Abstractions;

public enum BzBackdropStyle
{
    Default = 0,

    [BzAttribute("data-bs-backdrop", "static")]
    Static = 1,
}
