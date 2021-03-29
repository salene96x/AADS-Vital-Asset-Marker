using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Drawing;
using System.Linq;
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
        private static Bitmap vitIcon;
        private double check1;
        private double check2;
        private TextBox txt2;

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

        public main getInstance()
        {
            return instance;
        }


        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManual.Checked)
            {
                mainForm1.setVitClickedValue(false);
                txtPointLat.Enabled = true;
                txtPointLng.Enabled = true;
                btnMark.Visible = true;
                
            } 
            else if (rdbAuto.Checked)
            {
                mainForm1.setVitClickedValue(true);
            }
        }
        void manualMark() 
        {
                double lat = Convert.ToDouble(txtPointLat.Text);
                double lng = Convert.ToDouble(txtPointLng.Text);
                marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_pushpin);
                GMapOverlay overlay = mainForm1.GetOverlay("markersP");
                overlay.Markers.Add(marker);
                //mainForm1.mainMap.Overlays.Add(vitOverlay);
                mainForm1.setCurrentMarkerStatus(false);  
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            manualMark();
            mainForm1.updateMap();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            createMarker removeMarker = new createMarker(0, 0);
            if (rdbAuto.Checked)
            {
                marker = removeMarker.getMarker();
            }
            GMapOverlay overlay = mainForm1.GetOverlay("markersP");
            overlay.Markers.Remove(marker);
            try
            {
                if (comboBox1.SelectedIndex != 0)
                {
                    if (comboBox1.SelectedItem == "Economic")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitEconomic);
                    }
                    else if (comboBox1.SelectedItem == "Military")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitMilitary);
                    }
                    else if (comboBox1.SelectedItem == "Psychological")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitPsychological);
                    }
                    else if (comboBox1.SelectedItem == "Political")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitalAssetPolitical);
                    }
                }
            }
            catch
            {
                comboBox1.SelectedIndex = 0;
            }
            

            double lat = Convert.ToDouble(txtPointLat.Text);
            double lng = Convert.ToDouble(txtPointLng.Text);
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), vitIcon);
            overlay.Markers.Add(marker);
            mainForm1.updateMap();    
                
                
            
        }
        void loadIcons()
        {
            Image IconPolitical = AADS.Properties.Resources.vitalAssetPolitical;
            Image IconEconomic = Properties.Resources.vitEconomic;
            Image IconMilitary = Properties.Resources.vitMilitary;
            Image IconPsychological = Properties.Resources.vitPsychological;

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
                    reset();
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
                if (txt.GetType() == typeof(TextBox))
                {
                    txt2 = txt as TextBox;
                    if (txt2.Text == "")
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

        private void txtPointLat_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            bool isDouble = Double.TryParse(txtPointLat.Text, out check1);
            bool isDouble2 = Double.TryParse(txtPointLng.Text, out check2);
            if (!isDouble && !isDouble2)
            {
                txtPointLat.Text = "";
                txtPointLng.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                txtUnitStatus.Text = "Active";
            }
        }
        void reset()
        {
            foreach (var x in this.Controls)
            {
                if (x.GetType() == typeof(TextBox))
                {
                    var x2 = x as TextBox;
                    x2.Text = "";
                }
                else if (x.GetType() == typeof(RadioButton))
                {
                    var rdbX = x as RadioButton;
                    rdbX.Checked = false;
                }
                else if (x.GetType() == typeof(ComboBox))
                {
                    var cbbX = x as ComboBox;
                    cbbX.SelectedIndex = 0;
                }
            }
        }
        public void setRdbAutoChecked(bool status)
        {
            rdbAuto.Checked = status;
        }
    }
}
