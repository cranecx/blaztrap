using System.Runtime.CompilerServices;

namespace Blaztrap.Extensions;

    public interface IAsyncHolderService
    {
        event OperationsChangedEventHandler? OnChange;
        AsyncOperation StartOperation([CallerMemberName] string name = "");
        bool IsRunning(string? filter);
        bool IsRunning(params string[] names);
    }
