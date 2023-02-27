namespace Blaztrap.Abstractions;

public enum BzBackdrop
{
    Default = 0,

    [BzAttribute("data-bs-backdrop", "static")]
    Static = 1,
}
