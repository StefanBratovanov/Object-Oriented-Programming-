
namespace Blobs.Interfaces
{
    public interface ICommandExecutor
    {
        string ExecuteCommand(ICommand command);
    }
}
