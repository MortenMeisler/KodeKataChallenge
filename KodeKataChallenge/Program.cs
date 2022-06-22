using Microsoft.Extensions.DependencyInjection;
using KodeKataChallenge;

var services = new ServiceCollection();

services.AddSingleton(serviceprovider =>
{
    return new InternalOvkService(OvkData.Data);
});

services.AddSingleton<OvkService>();

var serviceProvider = services.BuildServiceProvider();

// Use the service

var ovkService = serviceProvider.GetRequiredService<OvkService>();

Console.WriteLine(ovkService.FindOVKKode("00001", "HAPS Aps", "3376543210"));
Console.WriteLine(ovkService.FindOVKKode("00001", "HAPS Aps", "3377492716"));
Console.WriteLine(ovkService.FindOVKKode("22222", "Werners Burgerbar", "3377492716"));
Console.WriteLine(ovkService.FindOVKKode("22222", "Werners Burgerbar", "3379874352"));
Console.WriteLine(ovkService.FindOVKKode("18776", "Werners Burgerbar", "3379874352"));
Console.WriteLine(ovkService.FindOVKKode("30303", "Werners Burgerbar", "3384376583"));
Console.WriteLine(ovkService.FindOVKKode("30303", "Heinos Udstoppede Dyr", "3332576411"));
Console.WriteLine(ovkService.FindOVKKode("30303", "Torsten Trykker VVS", "3301290522"));
Console.WriteLine(ovkService.FindOVKKode("75005", "IKEA", "3376119800"));
Console.WriteLine(ovkService.FindOVKKode("75005", "Den Lille Florist", "3376119800"));

