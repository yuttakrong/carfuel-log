using System;
using System.Collections.Generic;

namespace CarFuel.Models.Facts {
    public class Car {

        public Car() {
            Make = "Make";
            Model = "Model";
            FillUps = new List<FillUp>();
        }

        public double? AverageConsumptionRate {

            get {  
                              
                int tempOdo = 0;
                double tempLitre = 0;                                
                if (FillUps.Count > 0) 
                {
                    for (int i = 1; i < FillUps.Count; i++)
                    {                        
                        tempOdo += (FillUps[i].Odometer - FillUps[i - 1].Odometer);
                        tempLitre += FillUps[i].Liters;
                    }
                }
                else
                {
                    return null;
                }       
                         
                if (tempOdo == 0 && tempLitre == 0) { return null; }

                return Math.Round((tempOdo / tempLitre), 2);
            }
        }
        public List<FillUp> FillUps { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public FillUp AddFillUp(int odometer, double liters) {
            //throw new NotImplementedException();
            FillUp f = new FillUp(odometer, liters);

            if (FillUps.Count > 0) {
                FillUps[FillUps.Count - 1].NextFillUp = f;
            }

            FillUps.Add(f);

            return f;
        }

    }
}