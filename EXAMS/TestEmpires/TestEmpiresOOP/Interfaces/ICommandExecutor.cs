

namespace TestEmpiresOOP.Execution
{
    using TestEmpiresOOP.Interfaces;

    public interface ICommandExecutor
    {
        string ExecuteCommand(ICommand command);
    }
}
