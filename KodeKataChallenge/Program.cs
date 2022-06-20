// See https://aka.ms/new-console-template for more information
using KodeKataChallenge;

var service = new OvkService(OvkData.Data);

Console.WriteLine(service.FindOVKKode("00001", "HAPS Aps", "3376543210"));
Console.WriteLine(service.FindOVKKode("00001", "HAPS Aps", "3377492716"));
Console.WriteLine(service.FindOVKKode("22222", "Werners Burgerbar", "3377492716"));
Console.WriteLine(service.FindOVKKode("22222", "Werners Burgerbar", "3379874352"));
Console.WriteLine(service.FindOVKKode("18776", "Werners Burgerbar", "3379874352"));
Console.WriteLine(service.FindOVKKode("30303", "Werners Burgerbar", "3384376583"));
Console.WriteLine(service.FindOVKKode("30303", "Heinos Udstoppede Dyr", "3332576411"));
Console.WriteLine(service.FindOVKKode("30303", "Torsten Trykker VVS", "3301290522"));
Console.WriteLine(service.FindOVKKode("75005", "IKEA", "3376119800"));
Console.WriteLine(service.FindOVKKode("75005", "Den Lille Florist", "3376119800"));

