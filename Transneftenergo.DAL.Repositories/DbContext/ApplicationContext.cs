using Microsoft.EntityFrameworkCore;
using System;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.DAL.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; }
        public DbSet<CalculationAccountingDevice> CalculationAccountingDevices { get; set; }
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; }
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public DbSet<ElectricEnergyMeter> ElectricEnergyMeters { get; set; }
        public DbSet<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
        public DbSet<CalculationAccountingDeviceElectricityMeasurementPoint> CalculationAccountingDeviceElectricityMeasurementPoints { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculationAccountingDevice>().HasIndex(u => new { u.From, u.To }).IsUnique();

            modelBuilder.Entity<ElectricityMeasurementPoint>().HasIndex(u => new { u.From, u.To }).IsUnique();

            modelBuilder.Entity<CalculationAccountingDeviceElectricityMeasurementPoint>()
            .HasOne(p => p.CalculationAccountingDevice)
            .WithMany(t => t.CalculationAccountingDeviceElectricityMeasurementPoints)
            .HasForeignKey(p => new { p.FromCAD, p.ToCAD })
            .HasPrincipalKey(t => new { t.From, t.To });

            modelBuilder.Entity<CalculationAccountingDeviceElectricityMeasurementPoint>()
            .HasOne(p => p.ElectricityMeasurementPoint)
            .WithMany(t => t.CalculationAccountingDeviceElectricityMeasurementPoints)
            .HasForeignKey(p => new { p.FromEMP, p.ToEMP })
            .HasPrincipalKey(t => new { t.From, t.To });


            modelBuilder.Entity<Organization>().HasData(
              new Organization[]{
                new Organization { Id=1,Address="string",Name="Organization_A"},
            }
                );
            modelBuilder.Entity<SubsidiaryOrganization>().HasData(
                new SubsidiaryOrganization { Id = 1, Address = "string", Name = "SubsidiaryOrganization_A", OrganizationId = 1, }
                );
            modelBuilder.Entity<CalculationAccountingDevice>().HasData(
                   new CalculationAccountingDevice { Id = 1, From = new DateTime(2018, 2, 3), To = new DateTime(2018, 3, 3) }
                );
            modelBuilder.Entity<ConsumptionObject>().HasData(
                 new ConsumptionObject { Id = 1, Address = "string", Name = "SubsidiaryOrganization_A", SubsidiaryOrganizationId = 1 }
                );
            modelBuilder.Entity<CurrentTransformer>().HasData(
                 new CurrentTransformer { Id = 1, ElectricityMeasurementPointId = 1, KTT = 323, Number = 32, Type = "Type_A", VerificationDate = DateTime.Now.AddDays(-1) }
                );
            modelBuilder.Entity<ElectricEnergyMeter>().HasData(
                new ElectricEnergyMeter { Id = 1, ElectricityMeasurementPointId = 1, Number = 32, Type = "Type_A", VerificationDate = DateTime.Now.AddDays(+10) }
                );
            modelBuilder.Entity<ElectricityMeasurementPoint>().HasData(
                    new ElectricityMeasurementPoint { Id = 1, ConsumptionObjectId = 1, CurrentTransformerId = 1, ElectricEnergyMeterId = 1, VoltageTransformerId = 1, Name = "ElectricityMeasurementPoint_A", From = new DateTime(2018, 2, 3), To = new DateTime(2018, 3, 3) }
                );
            modelBuilder.Entity<ElectricitySupplyPoint>().HasData(
                 new ElectricitySupplyPoint { Id = 1, ConsumptionObjectId = 1, CalculationAccountingDeviceId = 1, MaxKw = 4324, Name = "ElectricitySupplyPoint_A" }
                );
            modelBuilder.Entity<VoltageTransformer>().HasData(
                     new VoltageTransformer { Id = 1, ElectricityMeasurementPointId = 1, KTN = 3423, Number = 32, Type = "Type_A", VerificationDate = DateTime.Now.AddDays(+10) }
                );
            modelBuilder.Entity<CalculationAccountingDeviceElectricityMeasurementPoint>().HasData(
                   new CalculationAccountingDeviceElectricityMeasurementPoint { Id = 1, FromCAD = new DateTime(2018, 2, 3), ToCAD = new DateTime(2018, 3, 3), FromEMP = new DateTime(2018, 2, 3), ToEMP = new DateTime(2018, 3, 3) }
                );

        }
    }
}
