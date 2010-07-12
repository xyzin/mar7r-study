using System;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public class OutsideWithDoor : OutsideWithHidingPlace, IHasExteriorDoor
    {
        private string doorDescription;
        private Location doorLocation;
    
        public OutsideWithDoor(string name, bool hot, string hidingPlace, string doorDescription) : base(name, hot, hidingPlace)
        {
            this.doorDescription = doorDescription;
        }
        #region IHasExteriorDoor 멤버

        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }

        public Location DoorLocation
        {
            get
            {
                return doorLocation;
            }
            set
            {
                this.doorLocation = value;
            }
        }

        #endregion

        public override string Description
        {
            get
            {
                return base.Description + " You see " + doorDescription + ".";
            }
        }
    }
}
