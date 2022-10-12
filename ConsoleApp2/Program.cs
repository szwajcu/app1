using ConsoleApp2;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Models;
using Microsoft.Extensions.Logging;

//setup logging
using var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

// setup console output
using var consoleStream = Console.OpenStandardOutput();
using var streamWriter = new StreamWriter(consoleStream);
Console.SetOut(streamWriter);

//to be DI driven
var kata = new DiamondKata(new DiamondCreator(), new DiamondRenderer(), new DiamondValidator(), loggerFactory.CreateLogger<DiamondKata>(), streamWriter);

try
{
    // create diamond and render to given stream or throw error
    kata.CreateDiamond(new CreateDiamondModel(Environment.GetCommandLineArgs()[1][0]));
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(-1);
}
catch (Exception)
{
    Console.WriteLine("Unhandled error occured");
    Environment.Exit(-2);
}



