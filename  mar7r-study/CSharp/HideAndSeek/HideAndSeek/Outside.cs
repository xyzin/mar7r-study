using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HideAndSeek
{
    public class Outside : Location
    {
        private bool hot;
        public Outside(string name, bool hot) : base(name)
        {
            this.hot = hot;
        }
    
        public bool Hot
        {
            get
            {
                return hot;
            }
        }

        public override string Description
        {
            get
            {
                string NewDescription = base.Description;
                if (hot)
                    NewDescription += " It's very hot.";
                return NewDescription;
            }
        }
    }
}
