using Cocus.FileReader;
using Cocus.FileReader.Cli;

var prompt = new ConsolePrompt(Console.In, Console.Out);
var app = new FileReaderApp(
    prompt,
    new FileReaderFactory(),
    ImplementationDiscovery.FindAll<IEncryption>(),
    ImplementationDiscovery.FindAll<IAccessPolicy>());

app.Run();
