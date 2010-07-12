using System;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string hidingPlace, string doorDescription) : base(name, decoration, hidingPlace)
        {
            this.doorDescription = doorDescription;
        }
        #region IHasExteriorDoor 멤버

        private string doorDescription;
        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }

        private Location doorLocation;
        public Location DoorLocation
        {
            get
            {
                return doorLocation;
            }
            set
            {
                doorLocation = value;
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
