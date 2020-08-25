using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Logic.FriendsMatcher
{
    public class MatchCommonInObjectCollection
    {
        public void Match<T>(FacebookObjectCollection<T> i_FirstObjects, FacebookObjectCollection<T> i_SecondObjects, ref int o_CountOfCommon, ref int o_CountOfTotal)
        {
            if (i_FirstObjects != null && i_SecondObjects != null)
            {
                o_CountOfTotal += i_SecondObjects.Count;
                foreach (T obj in i_FirstObjects)
                {
                    if (i_SecondObjects.Contains(obj))
                    {
                        o_CountOfCommon++;
                    }
                }
            }
        }
    }
}
