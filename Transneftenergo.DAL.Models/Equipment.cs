using System;

namespace Transneftenergo.DAL.Models
{
    public abstract class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime VerificationDate { get; set; }

        public int ElectricityMeasurementPointId { get; set; }
        public virtual ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
    }
}
