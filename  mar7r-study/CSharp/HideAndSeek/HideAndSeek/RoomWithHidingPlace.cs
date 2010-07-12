using System;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public class RoomWithHidingPlace : Room, IHidingPlace
    {
        private string hidingPlace;

        public RoomWithHidingPlace(string name, string decoration, string hidingPlace)
            : base(name, decoration)
        {
            this.hidingPlace = hidingPlace;
        }

        #region IHidingPlace 멤버

        public string HidingPlace
        {
            get { return hidingPlace; }
        }

        #endregion
    }
}
