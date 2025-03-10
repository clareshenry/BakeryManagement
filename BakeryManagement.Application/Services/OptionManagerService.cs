using BakeryManagement.Application.Utils;

namespace BakeryManagement.Application.Services
{
    public class OptionManagerService
    {
        // private readonly Dictionary<int, Func<Task>> _options = new Dictionary<int, Func<Task>>();
        private readonly Dictionary<int, (Func<Task> Action, string Description)> _options =
            new Dictionary<int, (Func<Task>, string)>();

        public void AddOption(int optionNumber, Func<Task> action, string description)
        {
            if (!_options.ContainsKey(optionNumber))
            {
                _options.Add(optionNumber, (action, description));
            }
            else
            {
                Console.WriteLine($"Option {optionNumber} already exists.");
            }
        }

        public async Task ShowOptionsAsync()
        {
            while (true)
            {
                foreach (var option in _options)
                {
                    Console.WriteLine($"{option.Key}. {option.Value.Description}");
                }

                string input = Validation.GetValidInput("Select an option (0 to exit):");

                if (int.TryParse(input, out int optionNumber) && _options.ContainsKey(optionNumber))
                {
                    if (optionNumber == 0)
                    {
                        break;
                    }

                    if (_options.ContainsKey(optionNumber))
                    {
                        Console.WriteLine($"Executing option {optionNumber}...");
                        Console.WriteLine("\n");
                        await _options[optionNumber].Action();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}
