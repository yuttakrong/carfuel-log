using System.Collections.Generic;

namespace CarFuel.Models {

    public class FillUp {

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

        public FillUp NextFillUp { get; set; }

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