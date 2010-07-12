using System;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public class Oppenent
    {
        private Location myLocation;
        public Location MyLocation { get { return myLocation; } }
        private Random random;

        public Oppenent(Location startLocation)
        {
            myLocation = startLocation;
            random = new Random();
        }

        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                if (1 == random.Next(2))
                {
                    IHasExteriorDoor hasDoor = myLocation as IHasExteriorDoor;
                    myLocation = hasDoor.DoorLocation;
                }
                else
                {
                    myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                }
            }
            else
            {
                myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
            }
            Console.WriteLine(myLocation.Name);
        }

        public bool Check(Location location)
        {
            if (location == myLocation)
                return true;
            else
                return false;
        }

        public void Hide()
        {
            for (int i = 0; i < 10; i++)
            {
                Move();
            }
            if (myLocation is IHidingPlace)
                return;
            else
            {
                while (myLocation is IHidingPlace)
                {
                    Move();
                }
            }
        }
    }
}
