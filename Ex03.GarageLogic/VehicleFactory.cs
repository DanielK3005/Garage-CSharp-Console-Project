using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private const float k_ElectricCarMaxBatteryAmount = 5.2f; 
        private const float k_FuelCarMaxTankSize = 45;
        private const float k_FuelTruckMaxTankSize = 135;
        private const float k_ElectricMotorcycleMaxBatteryAmount = 2.6f;
        private const float k_FuelMotorcycleMaxTankSize = 6.4f;

        public bool TryCreateVehicle(string i_LicensePlate, Vehicle.eVehicleType i_VehicleType, out Vehicle o_Vehicle)
        {
            o_Vehicle = null;
            bool result = false;

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleType.ElectricCar:
                    o_Vehicle = new Car(new ElectricPowered(0, k_ElectricCarMaxBatteryAmount), i_VehicleType);
                    break;
                case Vehicle.eVehicleType.FuelCar:
                    o_Vehicle = new Car(new InternalCombustionPowered(InternalCombustionPowered.eFuelType.Octan95,0, k_FuelCarMaxTankSize), i_VehicleType);
                    break;
                case Vehicle.eVehicleType.Truck:
                    o_Vehicle = new Truck(new InternalCombustionPowered(InternalCombustionPowered.eFuelType.Soler, 0, k_FuelTruckMaxTankSize), i_VehicleType);
                    break;
                case Vehicle.eVehicleType.ElectricMotorcycle:
                    o_Vehicle = new Motorcycle(new ElectricPowered(0, k_ElectricMotorcycleMaxBatteryAmount), i_VehicleType);
                    break;
                case Vehicle.eVehicleType.FuelMotorcycle:
                    o_Vehicle = new Motorcycle(new InternalCombustionPowered(InternalCombustionPowered.eFuelType.Octan98, 0, k_FuelMotorcycleMaxTankSize), i_VehicleType);
                    break;
                default:
                    result = false; 
                    break;
            }

            //I have dillema, should I create license plate and vehicle status here or in the ui?


            return result;
        }
    }
}
