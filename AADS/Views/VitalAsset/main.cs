using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADS.Views.VitalAsset
{
    public partial class main : UserControl
    {
        private mainForm mainForm1;
        public static string txtLat;
        public static string txtLng;
        public static PointLatLng pointP;
        private static main instance;
        public main()
        {
            mainForm1 = mainForm.GetInstance();
            instance = this;
            InitializeComponent();
        }

        public void setString(string lat, string lng)
        {
            txtPointLat.Text = lat;
            txtPointLng.Text = lng;
        }

        internal static main getInstace()
        {
            return instance;
        }

        private void main_Load(object sender, EventArgs e)
        {
            txtPointLat.Text = txtLat;
            txtPointLng.Text = txtLng;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public main getInstance()
        {
            return instance;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManual.Checked)
            {
                mainForm1.setVitClickedValue(false);
                txtPointLat.Enabled = true;
                txtPointLng.Enabled = true;
                btnMark.Visible = true;
                
            } else if (rdbAuto.Checked)
            {
                mainForm1.setVitClickedValue(true);
            }
        }
        void manualMark() 
        {
            double lat = Convert.ToDouble(txtPointLat.Text);
            double lng = Convert.ToDouble(txtPointLng.Text);
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_pushpin);
            GMapOverlay vitOverlayManual = new GMapOverlay("vitManual");
            vitOverlayManual.Markers.Add(marker);
            mainForm1.mainMap.Overlays.Add(vitOverlayManual);
            mainForm1.setCurrentMarkerStatus(false);
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            manualMark();
            mainForm1.updateMap();
        }
    }
}
