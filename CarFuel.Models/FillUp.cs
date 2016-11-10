using System.Collections.Generic;

namespace CarFuel.Models {

    public class FillUp {

        public int Id { get; set; }

        public double? ConsumptionRate {
            get {

                if (NextFillUp != null) {
                    return (NextFillUp.Odometer - Odometer) / NextFillUp.Liters;
                }
                return null;
            }
        }

        public bool IsFull { get; set; } = true;

        public double Liters { get; set; }

        public virtual FillUp NextFillUp { get; set; }

        public int Odometer { get; set; }

        public int? Distance {
            get {
                return NextFillUp?.Odometer-Odometer;
            }
        }
        public FillUp() {

        }

        public FillUp(int odometer, double liters) {
            Odometer = odometer;
            Liters = liters;
        }

    }
}