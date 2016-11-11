﻿using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Models.Facts {

    public class CarFact {

        public class GeneralUsage {

            [Fact]
            public void NewCar() {

                Car c = new Facts.Car();


                c.Make.ShouldEqual("Make");
                c.Model.ShouldEqual("Model");
                c.FillUps.ShouldNotBeNull();
                c.FillUps.ShouldBeEmpty();

                //การใช้ระหว่าง Should vs Asset

                //Assert.Equal("Make", c.Make);
                //Assert.Equal("Model", c.Model);
                //Assert.NotNull(c.FillUps);
                //Assert.Empty(c.FillUps);
            }

        }

        public class AddFillUpMethod {

            [Fact]
            public void AddFirstFillUp() {
                Car c = new Facts.Car();

                FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);

                Assert.Equal(1, c.FillUps.Count);
                Assert.Equal(1000, f1.Odometer);
                Assert.Equal(40.0, f1.Liters);
            }

            [Fact]
            public void AddTwoFillUp() {
                Car c = new Facts.Car();

                FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);
                FillUp f2 = c.AddFillUp(odometer: 1600, liters: 50.0);

                Assert.Same(f2, f1.NextFillUp);
                Assert.Equal(2, c.FillUps.Count);
            }

        }

        public class AverageConsumptionRateProperty {

            [Fact]
            public void FillUp1AverageConsumptionRate() {

                Car c = new Car();

                FillUp f1 = c.AddFillUp(odometer: 0, liters: 0);

                Assert.Null(c.AverageConsumptionRate);
            }

            [Fact]
            public void FillUp2AverageConsumptionRate() {

                Car c = new Car();

                //FillUp f1 = c.AddFillUp(odometer: 0, liters: 0);
                FillUp f2 = c.AddFillUp(odometer: 1000, liters: 40);

                Assert.Null(c.AverageConsumptionRate);
            }

            [Fact]
            public void FillUp3AverageConsumptionRate() {

                Car c = new Car();

                //FillUp f1 = c.AddFillUp(odometer: 0, liters: 0);
                FillUp f2 = c.AddFillUp(odometer: 1000, liters: 40.0);
                FillUp f3 = c.AddFillUp(odometer: 1600, liters: 50.0);

                Assert.Equal(12.0, c.AverageConsumptionRate);
            }

            [Fact]
            public void FillUp4AverageConsumptionRate() {

                Car c = new Car();

                //FillUp f1 = c.AddFillUp(odometer: 0, liters: 0);
                FillUp f2 = c.AddFillUp(odometer: 1000, liters: 40.0);
                FillUp f3 = c.AddFillUp(odometer: 1600, liters: 50.0);
                FillUp f4 = c.AddFillUp(odometer: 2200, liters: 60.0);

                Assert.Equal(10.91, c.AverageConsumptionRate);
            }

        }

    }
}
