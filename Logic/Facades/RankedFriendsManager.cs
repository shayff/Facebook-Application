using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using Logic.FriendsMatcher;

namespace Logic.Facades
{
    public class RankedFriendsManager
    {
        private readonly FriendsMatcher.FriendsMatcher r_RankedFriends;

        public List<User> LlistOfMatchedFriends { get; set; }

        public RankedFriendsManager(User i_LoggedInUser, IRankable i_RankByStargety)
        {
            r_RankedFriends = new FriendsMatcher.FriendsMatcher(i_LoggedInUser, i_RankByStargety);
        }

        public List<User> GetRankedFriends()
        {
            return r_RankedFriends.MatchFriends();
        }
    }
}
