using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntQuiz
{
    class AntString
    {
        private String str;
        private int keyPosition;

        public AntString(String str)
        {
            this.str = str;
            this.keyPosition = 0;
        }

        private string getChar(int position)
        {
            return this.str.Substring(position, 1);
        }

        public String getNextAnt()
        {
            String result = "";
            int sameCount = 0;
            do
            {
                sameCount = getSameCount();
                result += getKey() + sameCount;
            } while (nextKeyPosition(sameCount));

            return result;
        }

        internal Boolean isSameWithKey(int index)
        {
            if (inValidPosition(index))
                return false;

            return getKey().Equals(getChar(keyPosition + index));
        }

        internal int getSameCount()
        {
            int count;
            for (count = 0; isSameWithKey(count); count++) ;
            return count;
        }

        internal String getKey()
        {
            return getChar(this.keyPosition);
        }

        internal Boolean nextKeyPosition(int p)
        {
            if (inValidPosition(p))
                return false;
            else
            {
                this.keyPosition += p;
                return true;
            }
        }

        private Boolean inValidPosition(int p)
        {
            return this.str.Length <= keyPosition + p;
        }
    }
}
