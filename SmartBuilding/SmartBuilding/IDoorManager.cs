using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuilding
{
    public interface IDoorManager : IManager
    {
        public bool OpenDoor(int doorID);

        public bool LockDoor(int doorID);

        public bool OpenAllDoors();

        public bool LockAllDoors();

        //public string GetStatus();
    }
}
