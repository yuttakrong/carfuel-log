using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity; //For DbContext
using CarFuel.Models.Facts;//using CarFuel.Models;

namespace CarFuel.Data {

    public class CarFuelDb: DbContext {

        public DbSet<Car> Cars { get; set; }

    }

}
