namespace BakeryManagement.Application.Services
{
    public class OptionManagerService
    {
        private Dictionary<int, Action> options;
        private Dictionary<int, string> descriptions;

        public OptionManagerService()
        {
            options = new Dictionary<int, Action>();
            descriptions = new Dictionary<int, string>();
        }

        public void AddOption(int key, string description, Action action)
        {
            if (options.ContainsKey(key))
                throw new ArgumentException($"The option {key} already exists.");

            options[key] = action;
            descriptions[key] = description;
        }

        public void PrintOptions()
        {
            foreach (var option in descriptions)
            {
                Console.WriteLine($"{option.Key}: {option.Value}");
            }
        }

        public void ExecuteOption(int key)
        {
            if (options.ContainsKey(key))
                options[key]();
            else
                Console.WriteLine($"The option {key} does not exist.");
        }
    }
}
