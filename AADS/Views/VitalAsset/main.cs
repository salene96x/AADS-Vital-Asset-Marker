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
        private static main instance;
        private static GMarkerGoogle marker;
        private static GMapOverlay vitOverlay;
        private static Bitmap vitPolitical;
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
            loadIcons();
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
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_pushpin);
            vitOverlay = new GMapOverlay("vitManual");
            vitOverlay.Markers.Add(marker);
            mainForm1.mainMap.Overlays.Add(vitOverlay);
            mainForm1.setCurrentMarkerStatus(false);
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            manualMark();
            mainForm1.updateMap();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm1.mainMap.Overlays.Remove(vitOverlay);
            double lat = Convert.ToDouble(txtPointLat.Text);
            double lng = Convert.ToDouble(txtPointLng.Text);
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), vitPolitical);
            vitOverlay = new GMapOverlay(comboBox1.SelectedItem.ToString());
            vitOverlay.Markers.Add(marker);
            mainForm1.mainMap.Overlays.Add(vitOverlay);
            mainForm1.updateMap();
        }
        void loadIcons()
        {
            Image politicalIcon = AADS.Properties.Resources.vitalAssetPolitical;
            vitPolitical = new Bitmap(politicalIcon);
        }

        private void tbPriority_Scroll(object sender, EventArgs e)
        {
            txtPriority.Text = tbPriority.Value.ToString();
        }

        private void txtPriority_TextChanged(object sender, EventArgs e)
        {
            if (txtPriority.Text is null)
            {
                tbPriority.Value = 1;
                txtPriority.Text = tbPriority.Value.ToString();
            }
            else
            {
                try
                {
                    tbPriority.Value = (int)Convert.ToInt16(txtPriority.Text);
                }
                catch
                {
                    txtPriority.Text = tbPriority.Value.ToString();
                }
                
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool nullChecked = CheckNullTxt();
            if (nullChecked)
            {
                DialogResult dialogResult = MessageBox.Show("ยืนยันที่จะเพิ่มตำบลสำคัญใช่หรือไม่", "ตำบลสำคัญ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult is DialogResult.Yes)
                {
                    MessageBox.Show("เพิ่มตำบลสำคัญเสร็จสิ้น", "ตำบลสำคัญ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("เพิ่มตำบลสำคัญไม่เสร็จสิ้น กรุณากรอกข้อมูลให้ครบถ้วน", "ตำบลสำคัญ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        private bool CheckNullTxt()
        {
            foreach (var txt in this.Controls)
            {
                if (txt.GetType() is TextBox)
                {
                    TextBox txt2 = txt as TextBox;
                    if (txt2.Text is null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }
    }
}
