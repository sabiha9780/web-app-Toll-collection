using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebAppTollCollection.Models;


namespace WebAppTollCollection.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string LicensePlate { get; set; }

        [Required]
        [MaxLength(20)]
        public string VehicleType { get; set; }
        public VehicleType vehicleType { get; set; }

        [Required]
        [MaxLength(50)]
        public string OwnerName { get; set; }
     

        
        public IList<TollRecord> TollRecords { get; set; } = new List<TollRecord>();
    }
    public enum VehicleType
    {
        // Passenger Vehicles
    
        Motorcycle,
        Van,
        Car,

        // Commercial Vehicles
        LightTruck,
        MediumTruck,
        HeavyTruck,
        DeliveryVan,

        // Special Purpose Vehicles
        Ambulance,
        FireTruck,
        Bulldozer,
        Excavator,

        // Non-Motorized Vehicles
        Bicycle,
        Rickshaw,
        HorseCarriage,

        // Electric and Hybrid Vehicles
        ElectricCar,
        PlugInHybrid,
        EBike



    }



}