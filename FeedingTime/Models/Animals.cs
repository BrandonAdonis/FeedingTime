using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedingTime.Models
{
    public class Animals
    {
        public int AnimalsID { get; set; }
        public string AnimalName { get; set; }
        public string Habitat { get; set; }
        public string Category { get; set; }
        public string AgeOfAnimal { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime FeedingTime { get; set; }
        public DateTime AnimalCheckup { get; set; }

        public ICollection<StaffMembers> StaffMembers { get; set; }
    }
}

