using System;
using TestEmpiresOOP.Interfaces;
using TestEmpiresOOP.Models.Interfaces;
using TestEmpiresOOP.UserInterface;

namespace TestEmpiresOOP.Execution
{
    public class TestEngine : IEngine
    {
        private IUserInterface userInterface;
        private ICommandExecutor commandExecutor;

        public TestEngine()
        {
            this.userInterface = new ConsoleUserInterface();
            this.commandExecutor = new TestCommandExecutor();
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.userInterface.ReadLine();
                if (commandLine == "armistice")
                {
                    break;
                }
                var command = new Command(commandLine);

                string commandResult = this.commandExecutor.ExecuteCommand(command);

                if (commandResult != null)
                {
                    this.userInterface.WriteLine(commandResult);
                }
            }
        }

       
    }
}
