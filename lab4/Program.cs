class Program
{
    static void Main(string[] args)
    {
        string directory;
        string fileTemplate;
        string attributeOptions;
        
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: FileAttributesChanger.exe <directory> <file_template> [-h] [-r] [-a]");
            Console.WriteLine("Please enter the required information:");

            Console.Write("Directory: ");
            directory = Console.ReadLine();

            Console.Write("File template: ");
            fileTemplate = Console.ReadLine();

            Console.WriteLine("Attribute options (optional):");
            Console.WriteLine("-h : Change hidden attribute");
            Console.WriteLine("-r : Change read-only attribute");
            Console.WriteLine("-a : Change archive attribute");
            Console.WriteLine("Enter the attribute options (separated by space):");
            attributeOptions = Console.ReadLine();

            args = new string[] { directory, fileTemplate, attributeOptions };
        }

        if (args.Length < 2)
        {
            Console.WriteLine("Invalid arguments.");
            return;
        }

        directory = args[0];
        fileTemplate = args[1];
        bool changeHiddenAttribute = args.Length > 2 && args[2].Contains("-h", StringComparison.OrdinalIgnoreCase);
        bool changeReadOnlyAttribute = args.Length > 2 && args[2].Contains("-r", StringComparison.OrdinalIgnoreCase);
        bool changeArchiveAttribute = args.Length > 2 && args[2].Contains("-a", StringComparison.OrdinalIgnoreCase);

        try
        {
            var files = Directory.GetFiles(directory, fileTemplate);

            foreach (var file in files)
            {
                FileAttributes attributes = File.GetAttributes(file);

                if (changeHiddenAttribute)
                    attributes = attributes | FileAttributes.Hidden;

                if (changeReadOnlyAttribute)
                    attributes = attributes | FileAttributes.ReadOnly;

                if (changeArchiveAttribute)
                    attributes = attributes | FileAttributes.Archive;

                File.SetAttributes(file, attributes);

                Console.WriteLine($"Changed attributes of file '{file}'");
            }

            Console.WriteLine("File attribute change completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}