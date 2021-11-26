using System.ComponentModel.DataAnnotations.Schema;

namespace Transneftenergo.DAL.Models
{
    // точка постоновления энергии
    public class ElectricitySupplyPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MaxKw { get; set; }

        public int ConsumptionObjectId { get; set; }
        [ForeignKey("ConsumptionObjectId")]
        public ConsumptionObject ConsumptionObject { get; set; }

        public int CalculationAccountingDeviceId { get; set; }
        [ForeignKey("CalculationAccountingDeviceId")]
        public CalculationAccountingDevice CalculationAccountingDevice { get; set; }


        
    }
}
