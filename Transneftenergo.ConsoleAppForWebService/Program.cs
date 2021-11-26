using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.ConsoleAppForWebService
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string url = "https://localhost:8050/";
        static async Task Main(string[] args)
        {

            Console.WriteLine("█▀▀ █▀█ █▄ █ █▀ █▀█ █   █▀▀       ▄▀█ █▀█ █▀█");
            Console.WriteLine("█▄▄ █▄█ █ ▀█ ▄█ █▄█ █▄▄ ██▄       █▀█ █▀▀ █▀▀");

            while (true)
            {
                HttpResponseMessage response = new HttpResponseMessage();

                Console.WriteLine("\n\n\n\nВыбери пункт:\n\n");
                Console.WriteLine("1 - Выбрать все расчетные приборы учета в 2018 году.");
                Console.WriteLine("2 - По указанному объекту потребления выбрать все счетчики с закончившимся сроком поверке.");
                Console.WriteLine("3 - По указанному объекту потребления выбрать все трансформаторы напряжения с закончившимся сроком поверке");
                Console.WriteLine("4 - По указанному объекту потребления выбрать все трансформаторы тока с закончившимся сроком поверке.");

                Console.WriteLine("\n\nВведи номер пункта");
                var res = Console.ReadLine();

                switch (res)
                {
                    case "1":
                         response = await client.GetAsync(url + "GetCalculationAccountingDevice/Get2018Year");
                        if (!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("ОШИБКА");
                            break;
                        }
                        List<CalculationAccountingDevice> calculationAccountingDevice = await response.Content.ReadAsAsync<List<CalculationAccountingDevice>>();

                        if (calculationAccountingDevice.Count < 1) Console.WriteLine($"ПУСТО");

                        foreach (var item in calculationAccountingDevice)
                        {
                            Console.WriteLine($"{item.Id}.....{item.From}.....{item.To}");
                        }

                        break;

                    case "2":
                        Console.WriteLine($"Выбери обект потрбления");
                        var resA = Console.ReadLine();
                         response = await client.GetAsync(url + $"GetCurrentTransformer/GetOverdueEquipmentByConsumptionObject/{resA}");
                        if (!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("ОШИБКА");
                            break;
                        }
                        List<CurrentTransformer> currentTransformers = await response.Content.ReadAsAsync<List<CurrentTransformer>>();

                        if (currentTransformers.Count < 1) Console.WriteLine($"ПУСТО");

                        foreach (var item in currentTransformers)
                        {
                            Console.WriteLine($"{item.Id}.....{item.KTT}.....{item.Number}.....{item.Type}");
                        }

                        break;

                    case "3":
                        Console.WriteLine($"Выбери обект потрбления");
                        var resB = Console.ReadLine();
                        response = await client.GetAsync(url + $"/GetElectricEnergyMeter/GetOverdueEquipmentByConsumptionObject/{resB}");
                        if (!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("ОШИБКА");
                            break;
                        }
                        List<ElectricEnergyMeter> electricEnergyMeter = await response.Content.ReadAsAsync<List<ElectricEnergyMeter>>();

                        if (electricEnergyMeter.Count < 1) Console.WriteLine($"ПУСТО");

                        foreach (var item in electricEnergyMeter)
                        {
                            Console.WriteLine($"{item.Id}.....{item.Number}.....{item.Type}");
                        }

                        break;

                    case "4":
                        Console.WriteLine($"Выбери обект потрбления");
                        var resC = Console.ReadLine();
                        response = await client.GetAsync(url + $"GetVoltageTransformer/GetOverdueEquipmentByConsumptionObject/{resC}");
                        if (!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("ОШИБКА");
                            break;
                        }
                        List<VoltageTransformer> voltageTransformer = await response.Content.ReadAsAsync<List<VoltageTransformer>>();

                        if (voltageTransformer.Count < 1) Console.WriteLine($"ПУСТО");

                        foreach (var item in voltageTransformer)
                        {
                            Console.WriteLine($"{item.Id}.....{item.KTN}.....{item.Number}.....{item.Type}");
                        }

                        break;

                    default:
                        Console.WriteLine($"Не корректный ответ");
                        break;
                }
            }
        }
    }

}
