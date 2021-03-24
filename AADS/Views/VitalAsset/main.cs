using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADS.Views.VitalAsset
{
    public partial class main : UserControl
    {
        public static string txtLat;
        public static string txtLng;
        public static PointLatLng pointP;
        public main(PointLatLng point)
        {
            pointP = point;
            txtLat = point.Lat.ToString();
            txtLng = point.Lng.ToString();
            InitializeComponent();
        }

        public void setString()
        {
            txtLat = pointP.Lat.ToString();
            txtLng = pointP.Lng.ToString();
            txtPointLat.Text = txtLat;
            txtPointLng.Text = txtLng;
        }
        private void main_Load(object sender, EventArgs e)
        {
            txtPointLat.Text = txtLat;
            txtPointLng.Text = txtLng;
        }
    }
}
