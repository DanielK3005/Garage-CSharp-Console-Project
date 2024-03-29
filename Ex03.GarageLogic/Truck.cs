﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck: Vehicle
    {
        private bool m_DangerousMaterials;
        private float m_CargoVolume;

        //empty constructor
        public Truck(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Owner) : base(i_PowerSystem, i_VehicleType, i_Owner)
        {
        }

        public Truck(string i_LicenseNumber, List<Wheel> i_Wheels, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus, float i_EnergyLeftPercentage, VehiclePowerSystem i_PowerSystem, bool i_DangerousMaterials, float i_CargoVolume)
        : base(i_LicenseNumber, i_Wheels, i_OwnerName, i_OwnerPhoneNumber, i_VehicleStatus, i_EnergyLeftPercentage, i_PowerSystem)
        {
            m_DangerousMaterials = i_DangerousMaterials;
            m_CargoVolume = i_CargoVolume;
        }

        
    }
}
