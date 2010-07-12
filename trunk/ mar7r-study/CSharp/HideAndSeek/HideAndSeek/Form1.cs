using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HideAndSeek
{
    public partial class Form1 : Form
    {
        private Location currentLocation;

        private Oppenent thief;

        RoomWithDoor livingRoom, kitchen;
        RoomWithHidingPlace stairs, masterBedroom, secondBedroom, bathroom;
        Room diningRoom, upstairsHallway;

        OutsideWithDoor frontYard, backYard;
        OutsideWithHidingPlace garden;
        Outside driveway;

        public Form1()
        {
            InitializeComponent();
            CreateObject();
            thief = new Oppenent(livingRoom);
            MoveToANewLocation(livingRoom);
            thief.Hide();
        }

        private void CreateObject()
        {
            livingRoom = new RoomWithDoor("Living Room", "antique capet", "under the capet","an oak door with a brass knob");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "under the table", "screen door");

            stairs = new RoomWithHidingPlace("Stairs", "picture of a dog", "closet");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom", "large bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("Second Bedroom", "small bed", "under the bed");
            bathroom = new RoomWithHidingPlace("Bathroom", "sink, toilet, shower", "shower");

            diningRoom = new Room("Dining Room", "crystal chandelier");
            upstairsHallway = new Room("Upstairs Hallway", "moody light");
            
            frontYard = new OutsideWithDoor("Front Yard", false, "garage", "an oak door with a brass knob");
            backYard = new OutsideWithDoor("Back Yard", true, "garage", "screen door");

            garden = new OutsideWithHidingPlace("Garden", false, "shed");

            driveway = new Outside("Driveway", false);

            livingRoom.Exits = new Location[] { diningRoom, stairs };
            livingRoom.DoorLocation = frontYard;

            kitchen.Exits = new Location[] { diningRoom };
            kitchen.DoorLocation = backYard;

            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            upstairsHallway.Exits = new Location[] { masterBedroom, secondBedroom, bathroom };

            frontYard.Exits = new Location[] { garden, driveway };
            frontYard.DoorLocation = livingRoom;

            garden.Exits = new Location[] { frontYard, backYard };

            backYard.Exits = new Location[] { garden, driveway };
            backYard.DoorLocation = kitchen;

            driveway.Exits = new Location[] { frontYard, backYard };
        }

        public void MoveToANewLocation(Location location)
        {
            currentLocation = location;
            exits.Items.Clear();
            foreach (Location l in currentLocation.Exits)
            {
                exits.Items.Add(l.Name);
            }
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description;
            if (location is IHidingPlace)
            {
                IHidingPlace hidingPlace = location as IHidingPlace;
                btnCheck.Visible = true;
                btnCheck.Text = "check " + hidingPlace.HidingPlace;
            }
            else
            {
                btnCheck.Visible = false;
            }
                

            if (location is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoorLocation = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoorLocation.DoorLocation);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (thief.Check(currentLocation))
                MessageBox.Show("Found thief!!!!");
        }
    }
}
