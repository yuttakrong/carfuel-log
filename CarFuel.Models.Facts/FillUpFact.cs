using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Models.Facts {
    public class FillUpFact {

        public class GeneralUsage {

            [Fact]
            public void NewFillUp() {
                FillUp f;

                f = new FillUp();

                Assert.Equal(0, f.Odometer);
                Assert.Equal(0.0, f.Liters);
                Assert.True(f.IsFull);
            }

            public class ConsumptionRatePropperty {

                [Fact]
                public void FirstFillUp_ReturnNull() {
                    // arrange
                    var f = new FillUp();
                    f.Odometer = 1000;
                    f.Liters = 40;
                    f.NextFillUp = null;

                    // act
                    double? result = f.ConsumptionRate;

                    // asset
                    Assert.Null(result);
                }

                [Fact]
                public void TwoFillUp_1_2() {
                    // arrange
                    var f1 = new FillUp();
                    f1.Odometer = 1000;
                    f1.Liters = 40.0;

                    var f2 = new FillUp();
                    f2.Odometer = 1600;
                    f2.Liters = 50.0;
                    f2.NextFillUp = null;

                    f1.NextFillUp = f2;

                    // act
                    double? result1 = f1.ConsumptionRate;
                    double? result2 = f2.ConsumptionRate;

                    // asset
                    Assert.Equal(12.0, result1);
                    Assert.Null(result2);
                }

                [Fact]
                public void TwoFillUp_2_3() {
                    // arrange            
                    var f2 = new FillUp();
                    f2.Odometer = 1600;
                    f2.Liters = 50.0;

                    var f3 = new FillUp();
                    f3.Odometer = 2200;
                    f3.Liters = 60;
                    f3.NextFillUp = null;

                    f2.NextFillUp = f3;

                    // act
                    double? result2 = f2.ConsumptionRate;
                    double? result3 = f3.ConsumptionRate;

                    // asset
                    Assert.Equal(10.0, result2);
                    Assert.Null(result3);
                }


            }

        }

    }
}
