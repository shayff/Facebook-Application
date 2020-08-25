using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Logic.FriendsMatcher
{
    public interface IRankable
    {
        string Name { get; }

        double RankFriend(User i_User, User i_FriendToCompare);
    }
}
