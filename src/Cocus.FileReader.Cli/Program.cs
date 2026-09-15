using Cocus.FileReader.Cli;

var prompt = new ConsolePrompt(Console.In, Console.Out);
var app = new FileReaderApp(prompt, new FileReaderFactory(), EncryptionDiscovery.FindAll());

app.Run();
