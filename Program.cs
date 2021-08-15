using System;

namespace FxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor processor = new Processor(new RateDefinition());
            Console.WriteLine("Please enter command in following format: 'Exchange xxx/yyy 223.4' format");
            while (true)
            {
                var commandLine  = Console.ReadLine();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var processable = processor.ValidateAndArrange(commandLine);
                        var result = processor.Convert(processable);
                        Console.WriteLine(result);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
