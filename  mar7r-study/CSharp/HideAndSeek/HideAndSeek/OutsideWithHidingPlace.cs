using System;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        private string hidingPlace;

        public OutsideWithHidingPlace(string name, bool hot, string hidingPlace)
            : base(name, hot)
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
