using CarFuel.Models.Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace CarFuel.Data {
    public class CarRepositor : RepositoryBase<Car> {
        public CarRepositor(DbContext context) : base(context) {

        }
    }
}
