using CarFuel.Models.Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFuel.Data;

namespace CarFuel.Services {
    public class CarService : ServiceBase<Car> {

        private readonly IUserService _userService;

        public CarService(IRepository<Car> baseRepo, IUserService userService) : base(baseRepo) {
            _userService = userService;
        }

        public override Car Find(params object[] keys) {
            Guid id = (Guid)keys[0];
            return Query(x => x.Id == id).SingleOrDefault();
        }

        public override IQueryable<Car> All() {
            return base.Query(c => c.Owner == _userService.CurrentUserId());
        }

        public override Car Add(Car item) {
            if(All().Any(c=>c.PlateNo == item.PlateNo)) {
                throw new Exception("Can't duplicate car's");
            }

            if (All().Count() >= 2) {
                throw new Exception("Can't add more car");
            }

            item.Owner = _userService.CurrentUserId();
                      

            return base.Add(item);
        }

        

    }
}
