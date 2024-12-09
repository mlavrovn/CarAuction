using CarAuction.Domain.Interfaces;
using CarAuction.Domain.Vehicles;

namespace CarAuction.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {

        private List<Vehicle> _vehicles = new List<Vehicle>();

        public Vehicle Add(Vehicle entity)
        {
            _vehicles.Add(entity);
            return entity;
        }

        public List<Vehicle> SearchBy(VehicleType? vehicleType, string? manufacturer, string? model, int? year)
        {
            var query = _vehicles.AsQueryable();

            if (vehicleType.HasValue)
            {
                query = query.Where(v => v.VehicleType == vehicleType);
            }

            if (!string.IsNullOrEmpty(manufacturer))
            {
                query = query.Where(v => v.Manufacturer.Equals(manufacturer, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(v => v.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
            }

            if (year.HasValue)
            {
                query = query.Where(v => v.Year == year.Value);
            }

            return query.ToList();
        }

        public void Delete(Vehicle entity)
        {
            var vehicleToRemove = _vehicles.FirstOrDefault(v => v.Id == entity.Id);
            if (vehicleToRemove != null)
            {
                _vehicles.Remove(vehicleToRemove);
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
           return _vehicles;
        }

        public Vehicle? GetById(long id)
        {
            return _vehicles.FirstOrDefault(v => v.Id == id);
        }

        public Vehicle Update(Vehicle vehicle)
        {
            return vehicle;
        }
    }
}
