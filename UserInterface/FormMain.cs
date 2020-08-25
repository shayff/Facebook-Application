using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using GMap.NET;
using Logic;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Logic.Facades;
using Logic.FriendsMatcher;

namespace UserInterface
{
    public partial class FormMain : Form
    {
        private User m_LoggedInUser;
        private ICalendarItem m_EventSelected;
        private readonly LoginManager r_LoginFacade;
        private CalendarManager m_CalendarManager;
        private LastestPhotosManager m_LastestPhotosManager;
        private readonly List<PictureBox> r_PictureBoxList;
        private readonly FormExit r_FormExit = new FormExit();

        #region Ctor and Init

        public FormMain()
        {
            r_LoginFacade = new LoginManager();
            InitializeComponent();
            InitializeMap();

            r_PictureBoxList = new List<PictureBox>()
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10,

            };

            rankByBox.Items.Add(new RankByMostEventsCommon());
            rankByBox.Items.Add(new RankByMostFriendsCommon());
            rankByBox.Items.Add(new RankByMostGroupsCommon());

            r_FormExit.m_ExiAppNotifier += exitApp;

        }


        private void InitializeMap()
        {
            gMapControlMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
        }

        #endregion

        #region Login
        private void tryLogin()
        {
            try
            {
                r_LoginFacade.Login();
                doWhenLogin();
                showOnLogin();
            }
            catch
            {
                doWhenLogout();
            }
        }

        private void doWhenLogout()
        {
            buttonLoginLogout.Text = "Login";
            r_LoginFacade.ClearAppSettings();
            m_LoggedInUser = null;
            checkBoxRememberUser.Checked = false;
            pictureBoxUser.Image = null;
            labelHelloUser.Text = "Hello";
            hideOnLogout();
            iCalendarItemBindingSource.Clear();

            userBindingSource.Clear();
        }

        private void showOnLogin()
        {
            panelMainForm.Invoke(new Action(() =>
            {
                panelMainForm.Visible = true;

                tabControl1.TabPages.Add(tabPage2);
                tabControl1.TabPages.Add(tabPage3);
                tabControl1.TabPages.Add(tabPage4);
            }
            ));
        }

        private void hideOnLogout()
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            clearCalendarEventPanel();
            panelMainForm.Visible = false;
            panelRankedFriends.Visible = false;
            monthCalendarEvents.RemoveAllBoldedDates();
        }

        private void doWhenLogin()
        {

            buttonLoginLogout.Invoke(new Action(() => buttonLoginLogout.Text = "logout"));
            m_LoggedInUser = r_LoginFacade.User;

            try
            {
                new Thread(fetchData).Start();
                Logger.Instance.WriteMessage("Successful fetch data");
            }
            catch
            {
                Logger.Instance.WriteMessage("Faild fetch data");
                MessageBox.Show("There was error fetching data");
            }

        }

        private void exitApp()
        {
            Application.Exit();
        }

        #endregion

        #region Fetchdata
        private void clearCalendarEventPanel()
        {
            gMapControlMap.Visible = false;
            buttonNavigator.Visible = false;
            iCalendarItemBindingSource.Clear();
            foreach (Control ctrl in panelEventAdapter.Controls)
            {
                if (ctrl is TextBox || ctrl is DateTimePicker)
                {
                    ctrl.Text = string.Empty;
                }
            }
        }

        private void fetchMainTabData()
        {
            new Thread(fetchPosts).Start();
            new Thread(fetchFriends).Start();
            new Thread(fetchPages).Start();
            new Thread(fetchGroups).Start();
        }

        private void fetchData()
        {
            pictureBoxUser.Load(m_LoggedInUser.PictureNormalURL);
            labelHelloUser.Invoke(new Action(() => labelHelloUser.Text = string.Format("Hello {0}", m_LoggedInUser.Name)));
            fetchMainTabData();
            m_LastestPhotosManager = new LastestPhotosManager(r_PictureBoxList, m_LoggedInUser);
        }

        private void fetchRankedFriends()
        {
            if (rankByBox.SelectedItem is IRankable SelectedRankStargety)
            {
                RankedFriendsManager rankedFriendsList = new RankedFriendsManager(m_LoggedInUser, SelectedRankStargety);
                userBindingSource.DataSource = rankedFriendsList.GetRankedFriends();
            }
            else
            {
                MessageBox.Show("Select Rank option");
            }
        }

        private void fetchPosts()
        {
            listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Clear()));
            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Message)));
                }
                else if (post.Caption != null)
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Caption)));
                }
                else
                {
                    listBoxPosts.Invoke(new Action(() => string.Format("[{0}]", post.Type)));
                }
            }

            if (m_LoggedInUser.Posts.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve ");
            }
        }

        private void fetchFriends()
        {
            listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Clear()));
            listBoxFriends.Invoke(new Action(() => listBoxFriends.DisplayMember = "Name"));
            foreach (User friend in m_LoggedInUser.Friends)
            {
                listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add(friend)));
            }

            if (m_LoggedInUser.Friends.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve");
            }
        }

        private void fetchPages()
        {
            try
            {
                listBoxPages.Invoke(new Action(() => listBoxPages.Items.Clear()));
                listBoxPages.Invoke(new Action(() => listBoxPages.DisplayMember = "Name"));

                if (m_LoggedInUser.LikedPages.Count == 0)
                {
                    MessageBox.Show("No liked pages to retrieve ");
                }
                else
                {
                    foreach (Page page in m_LoggedInUser.LikedPages)
                    {
                        listBoxPages.Invoke(new Action(() => listBoxPages.Items.Add(page)));
                    }
                }
            }
            catch
            {
                Logger.Instance.WriteMessage("Failed fetch pages");
            }
        }

        private void fetchGroups()
        {
            try
            {
                listBoxGroups.Invoke(new Action(() => listBoxGroups.Items.Clear()));
                listBoxGroups.Invoke(new Action(() => listBoxGroups.DisplayMember = "Name"));

                if (m_LoggedInUser.Groups.Count == 0)
                {
                    MessageBox.Show("No liked groups to retrieve ");
                }
                else
                {
                    foreach (Group group in m_LoggedInUser.Groups)
                    {
                        listBoxGroups.Invoke(new Action(() => listBoxGroups.Items.Add(group)));
                    }
                }
            }
            catch
            {
                Logger.Instance.WriteMessage("Failed fetch groups");
            }
        }

        private void fetchEventsToCalendar()
        {
            m_CalendarManager = new CalendarManager(m_LoggedInUser);
            foreach (Event evnt in m_LoggedInUser.Events)
            {
                monthCalendarEvents.AddBoldedDate((DateTime)evnt.StartTime);
            }
        }

        private void fetchFriendsBirthdayToCalendar()
        {
            foreach (User user in m_LoggedInUser.Friends)
            {
                UserAdapter adaptUser = new UserAdapter(user);
                monthCalendarEvents.AddBoldedDate((DateTime)adaptUser.StartTime);
            }
        }

        private void updateMap(ICalendarItem i_Event)
        {
            if (i_Event != null && i_Event.PlaceName != null)
            {
                buttonNavigator.Visible = true;
                gMapControlMap.Visible = true;
                gMapControlMap.Position = i_Event.Position;
            }
            else
            {
                buttonNavigator.Visible = false;
                gMapControlMap.Visible = false;
            }
        }

        private void updateUserProfieLink(User i_SelectedUser)
        {
            linkProfileFacebook.Links.Clear();
            LinkLabel.Link link = new LinkLabel.Link
            {
                LinkData = i_SelectedUser.Link
            };
            linkProfileFacebook.Links.Add(link);
        }

        #endregion

        #region Events
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (r_LoginFacade.RememberUser)
            {
                try
                {
                    m_LoggedInUser = r_LoginFacade.Connect();
                }
                catch
                {
                    hideOnLogout();
                    Logger.Instance.WriteMessage("Failed login");
                }

                if (m_LoggedInUser != null)
                {
                    new Thread(doWhenLogin).Start();
                    checkBoxRememberUser.Checked = true;
                }
            }
            else
            {
                hideOnLogout();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                r_FormExit.ShowDialog();
                e.Cancel = true;
            }
            else
            {
                Logger.Instance.WriteMessage("### Application closed ###");
            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            r_LoginFacade.SaveAppSettings(checkBoxRememberUser.Checked);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                tryLogin();
            }
            else
            {
                r_LoginFacade.Logout(doWhenLogout);
            }
        }

        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_LoggedInUser.PostStatus(textBoxStatus.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
                Logger.Instance.WriteMessage("Successful Post Status");
            }
            catch
            {
                Logger.Instance.WriteMessage("Failed Post Status");
                MessageBox.Show("Error: can't Post Status");
            }
        }

        private void monthCalendarEvents_DateSelected(object sender, DateRangeEventArgs e)
        {
            iCalendarItemBindingSource.DataSource = m_CalendarManager.GetEvents(e);
        }

        private void listBoxEventsOfSelectedDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICalendarItem selectedEvent = listBoxEventsOfSelectedDate.SelectedItem as ICalendarItem;
            updateMap(selectedEvent);
            m_EventSelected = selectedEvent;
            try
            {
                imageNormalPictureBox1.Load(selectedEvent.ImageNormal);
            }
            catch
            {
                Logger.Instance.WriteMessage("Failed No picture found In the Event");
            }
        }

        private void buttonFetchEvents_Click(object sender, EventArgs e)
        {
            monthCalendarEvents.RemoveAllBoldedDates();
            fetchEventsToCalendar();
            fetchFriendsBirthdayToCalendar();
        }

        private void buttonFetchRankedFriends_Click(object sender, EventArgs e)
        {
            fetchRankedFriends();
            panelRankedFriends.Visible = true;
        }

        private void buttonPostFriendMatch_Click(object sender, EventArgs e)
        {
            User selectedUser = ListBoxFriendsMatch.SelectedItem as User;
            try
            {
                Status postedStatus = selectedUser.PostStatus(textBoxSetPostToFriendMatch.Text);
                MessageBox.Show("Status Posted! ");
                textBoxSetPostToFriendMatch.Clear();
                Logger.Instance.WriteMessage("Successful Post to a friends match");
            }
            catch
            {
                MessageBox.Show("Error: can't Post Status");
                Logger.Instance.WriteMessage("Failed Post to a friends match");
                textBoxSetPostToFriendMatch.Clear();
            }
        }

        private void buttonExportFriends_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "Text (*.txt)|*.txt"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter stream = new StreamWriter(saveFile.FileName, false))
                {
                    foreach (User friend in ListBoxFriendsMatch.Items)
                    {
                        stream.Write(friend.Name + Environment.NewLine);
                    }
                    MessageBox.Show("Saved!");
                }
            }
        }

        private void buttonNavigator_Click(object sender, EventArgs e)
        {
            FormNavigator navigateForm = new FormNavigator(m_EventSelected);
            navigateForm.ShowDialog();
        }

        private void linkProfileFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User selectedUser = ListBoxFriendsMatch.SelectedItem as User;
            updateUserProfieLink(selectedUser);
        }
        #endregion

    }
}
