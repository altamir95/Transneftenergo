using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Transneftenergo.DAL.Interfaces;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.DAL.Repositories
{
    public static class DbService
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services,string sqlConnectionString)
        {
            services.AddTransient<IRepository<CalculationAccountingDevice>, EfRepository<CalculationAccountingDevice>>();
            services.AddTransient<IRepository<ConsumptionObject>, EfRepository<ConsumptionObject>>();
            services.AddTransient<IRepository<CurrentTransformer>, EfRepository<CurrentTransformer>>();
            services.AddTransient<IRepository<ElectricEnergyMeter>, EfRepository<ElectricEnergyMeter>>();
            services.AddTransient<IRepository<ElectricityMeasurementPoint>, EfRepository<ElectricityMeasurementPoint>>();
            services.AddTransient<IRepository<ElectricitySupplyPoint>, EfRepository<ElectricitySupplyPoint>>();
            services.AddTransient<IRepository<Organization>, EfRepository<Organization>>();
            services.AddTransient<IRepository<SubsidiaryOrganization>, EfRepository<SubsidiaryOrganization>>();
            services.AddTransient<IRepository<VoltageTransformer>, EfRepository<VoltageTransformer>>();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(sqlConnectionString));

            return services;
        }

    }
}
