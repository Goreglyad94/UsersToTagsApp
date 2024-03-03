using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersToTagsApp
{
    public class ConsoleHelper
    {
        public delegate void Action();
        private Dictionary<string, Action> _commands = new Dictionary<string, Action>();

        public void Run(string[] args = null)
        {
            while (true)
            {
                try
                {
                    ExecuteCommand(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Возникла ошибка {ex.Message}");
                }
            }
        }

        public void AddCommand(string id, Action action)
        {
            _commands.Add(id, action);
        }

        private void ExecuteCommand(string command, bool getApprove = false)
        {
            if (!_commands.ContainsKey(command))
            {
                Console.WriteLine("Данная команда отсутствует " + command);
                return;
            }

            var tt = _commands[command];

            _commands[command]();
        }
    }
}
