using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Logic;

namespace UserInterface
{
    public partial class FormNavigator : Form
    {
        private PointLatLng m_Start;
        private PointLatLng m_End;

        public FormNavigator(ICalendarItem i_Event)
        {
            InitializeComponent();
            gMapControlNavigator.MapProvider = GoogleMapProvider.Instance;
            gMapControlNavigator.Position = i_Event.Position;
            labelNameOfEvent.Text = i_Event.EventName;

            m_End = gMapControlNavigator.Position;
        }

        private void buttonNavigate_Click(object sender, EventArgs e)
        {
            navigate();
        }

        private void navigate()
        {
            GMapOverlay routesOverlay = new GMapOverlay("routes");

            if (m_Start != PointLatLng.Empty)
            {
                GDirections directions;
                GoogleMapProvider.Instance.GetDirections(out directions, m_Start, m_End, false, false, false, false, true);
                if (directions != null)
                {
                    GMapRoute mapRoute = new GMapRoute(directions.Route, "route");
                    routesOverlay.Routes.Clear();
                    routesOverlay.Routes.Add(mapRoute);
                    gMapControlNavigator.Overlays.Remove(routesOverlay);
                    gMapControlNavigator.Overlays.Add(routesOverlay);
                }
                else
                {
                    MessageBox.Show("There is no route between these points");
                }
            }
            else
            {
                MessageBox.Show("You didn't choose a start point");
            }

            gMapControlNavigator.Position = m_Start;
            gMapControlNavigator.Zoom = 15;
        }

        private void gMapControlNavigator_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double lat = gMapControlNavigator.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMapControlNavigator.FromLocalToLatLng(e.X, e.Y).Lng;
                m_Start = new PointLatLng(lat, lng);
                navigate();
            }
        }
    }
}
