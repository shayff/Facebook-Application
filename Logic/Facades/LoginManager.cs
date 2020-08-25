using System;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Logic.Facades
{
    public class LoginManager
    {
        private readonly AppSetting r_AppSetting;

        private LoginResult m_LoginResult;

        public User User { get; set; }
        
        public bool RememberUser { get; set; }

        public LoginManager()
        {
            r_AppSetting = AppSetting.LoadFromFile();
            RememberUser = r_AppSetting.RememberUser;
        }

        public void SaveAppSettings(bool i_RememberUser)
        {          
            r_AppSetting.RememberUser = i_RememberUser;
            r_AppSetting.LastAccessToken = r_AppSetting.RememberUser ? m_LoginResult.AccessToken : null;
            r_AppSetting.SaveToFile();
        }

        public void ClearAppSettings()
        {
            r_AppSetting.Clear();
        }

        public User Connect()
        {
            m_LoginResult = FacebookService.Connect(r_AppSetting.LastAccessToken);
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                User = m_LoginResult.LoggedInUser;
                Logger.Instance.WriteMessage("Successful login to facebook");
            }
            else
            {
                Logger.Instance.WriteMessage("Failed login to facebook");
                throw new Exception(m_LoginResult.ErrorMessage);
            }

            return m_LoginResult.LoggedInUser;
        }

        public void Login()
        {
            m_LoginResult = FacebookService.Login(
                        "1450160541956417",
                        "public_profile",
                        "email",
                        "publish_to_groups",
                        "user_birthday",
                        "user_age_range",
                        "user_gender",
                        "user_link",
                        "user_tagged_places",
                        "user_videos",
                        "publish_to_groups",
                        "groups_access_member_info",
                        "user_friends",
                        "user_events",
                        "user_likes",
                        "user_location",
                        "user_photos",
                        "user_posts",
                        "user_hometown");
            
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                User = m_LoginResult.LoggedInUser;
                Logger.Instance.WriteMessage("Successful login to facebook");
            }
            else
            {
                m_LoginResult = null;
                Logger.Instance.WriteMessage("Failed login to facebook");
                throw new Exception(m_LoginResult.ErrorMessage);
            }
        }

        public void Logout(Action doWhenLogout)
        {
            m_LoginResult = null;
            FacebookService.Logout(doWhenLogout);
        }
    }
}
