using Microsoft.Extensions.DependencyInjection;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.BAL.Services;
using Transneftenergo.DAL.Models;
using Transneftenergo.DAL.Repositories;

namespace Transneftenergo.BAL.Services.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddEfRepositories(sqlConnectionString);

            services.AddTransient<ICalculationAccountingDeviceService, CalculationAccountingDeviceService>();
            services.AddTransient<IElectricityMeasurementPointService, ElectricityMeasurementPointService>();
            services.AddTransient<IEquipmentService<CurrentTransformer>, EquipmentService<CurrentTransformer>>();
            services.AddTransient<IEquipmentService<ElectricEnergyMeter>, EquipmentService<ElectricEnergyMeter>>();
            services.AddTransient<IEquipmentService<VoltageTransformer>, EquipmentService<VoltageTransformer>>();

            return services;
        }
    }

}
