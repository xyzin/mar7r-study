using System;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public interface IHasExteriorDoor
    {
        string DoorDescription
        {
            get;
        }

        Location DoorLocation
        {
            get;
            set;
        }
    }
}
