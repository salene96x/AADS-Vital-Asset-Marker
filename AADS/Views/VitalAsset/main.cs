using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
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
        private GMarkerGoogle marker;
        private static Bitmap vitIcon;
        private double check1;
        private double check2;
        private TextBox txt2;
        private Dictionary<GMapMarker, List<string>> markers = new Dictionary<GMapMarker, List<string>>();
        private List<string> addList;

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
                btnMark.Visible = false;
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
        }

        public void addData()
        {
            string name = txtName.Text;
            string pointLat = txtPointLat.Text;
            string pointLng = txtPointLng.Text;
            string type = comboBox1.SelectedItem.ToString();
            string priority = tbPriority.Value.ToString();
            string province = txtProvince.Text;
            string size = txtSize.Text;
            string unitResponsible = comboBox2.SelectedItem.ToString();
            string responsePerson = comboBox3.SelectedItem.ToString();
            
            
            this.addList = new List<string>();

            this.addList.Add(name);
            this.addList.Add(pointLat);
            this.addList.Add(pointLng);
            this.addList.Add(type);
            this.addList.Add(priority);
            this.addList.Add(province);
            this.addList.Add(size);
            this.addList.Add(unitResponsible);
            this.addList.Add(responsePerson);

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GMapOverlay overlay = mainForm1.GetOverlay("markersP");
            if (rdbAuto.Checked)
            {
                var removeMarker = createMarker.marker;
                overlay.Markers.Remove(removeMarker);
                marker = removeMarker;
            }
            overlay.Markers.Remove(marker);
            try
            {
                if (comboBox1.SelectedIndex != 0)
                {
                    if (comboBox1.SelectedItem == "Economic")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitEconomic); 
                        vitIcon = new Bitmap(Properties.Resources.vitEconomic);
                        overlay.Markers.Remove(marker);
                    }
                    else if (comboBox1.SelectedItem == "Military")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitMilitary);
                        overlay.Markers.Remove(marker);
                    }
                    else if (comboBox1.SelectedItem == "Psychological")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitPsychological);
                        overlay.Markers.Remove(marker);
                    }
                    else if (comboBox1.SelectedItem == "Political")
                    {
                        vitIcon = new Bitmap(Properties.Resources.vitalAssetPolitical);
                        overlay.Markers.Remove(marker);
                    }
                }
                double lat = Convert.ToDouble(txtPointLat.Text);
                double lng = Convert.ToDouble(txtPointLng.Text);
                if (vitIcon == null)
                {
                    this.marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_dot);
                }
                else
                {
                    this.marker = new GMarkerGoogle(new PointLatLng(lat, lng), vitIcon);
                }
                overlay.Markers.Add(marker);
            }
            catch
            {
                comboBox1.SelectedIndex = 0;
            } 
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
            //addToolTips();
            bool nullChecked = CheckNullTxt();
            if (nullChecked)
            {
                DialogResult dialogResult = MessageBox.Show("ยืนยันที่จะเพิ่มตำบลสำคัญใช่หรือไม่", "ตำบลสำคัญ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult is DialogResult.Yes)
                {
                    addData();
                    MessageBox.Show("เพิ่มตำบลสำคัญเสร็จสิ้น", "ตำบลสำคัญ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    markers.Add(marker, addList);
                    this.marker.ToolTipText = $"\nMarker type : Vital Asset \nName : {this.markers[marker][0]} \nLatitude : {this.markers[marker][1]} \nLongitude : {this.markers[marker][2]}";
                    mainForm1.setOnlickMenuMarker(true);
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
            //just a dummy data
            if (comboBox2.SelectedIndex == 0)
            {
                txtUnitStatus.Text = "Active";
            }
        }
        public void reset()
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
                    cbbX.SelectedItem = null;
                }
            }
            tbPriority.Value = 1;
            txtPriority.Text = "";
        }
        public void setRdbAutoChecked(bool status)
        {
            rdbAuto.Checked = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private GMapMarker idMarker;
        public void editData(GMapMarker id)
        {
            idMarker = id;
            try
            {
                txtName.Text = markers[id][0];
                txtPointLat.Text = markers[id][1];
                txtPointLng.Text = markers[id][2];
                comboBox1.SelectedItem = markers[id][3];
                tbPriority.Value = (int)Convert.ToInt64(markers[id][4]);
                txtProvince.Text = markers[id][5];
                txtSize.Text = markers[id][6];
                comboBox2.SelectedItem = markers[id][7];
                comboBox3.SelectedItem = markers[id][8];
                btnConfirmEdit.Location = btnConfirm.Location;
                btnConfirm.Visible = false;
                btnConfirmEdit.Visible = true;
            }
            catch
            {

            }
            
        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            markers[idMarker][0] = txtName.Text;
            markers[idMarker][1] = txtPointLat.Text;
            markers[idMarker][2] = txtPointLng.Text;
            markers[idMarker][3] = comboBox1.SelectedItem.ToString();
            markers[idMarker][4] = tbPriority.Value.ToString();
            markers[idMarker][5] = txtProvince.Text;
            markers[idMarker][6] = txtSize.Text;
            markers[idMarker][7] = comboBox2.SelectedItem.ToString();
            markers[idMarker][8] = comboBox3.SelectedItem.ToString();

            if (CheckNullTxt())
            {
                DialogResult dialogResult = MessageBox.Show("ยืนยันที่จะเพิ่มตำบลสำคัญใช่หรือไม่", "ตำบลสำคัญ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult is DialogResult.Yes)
                {
                    MessageBox.Show("แก้ไขตำบลสำคัญเสร็จสิ้น", "ตำบลสำคัญ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    markers.Add(marker, addList);
                    this.marker.ToolTipText = $"\nMarker type : Vital Asset \nName : {this.markers[idMarker][0]} \nLatitude : {this.markers[idMarker][1]} \nLongitude : {this.markers[idMarker][2]}";
                }
            }
            else
            {
                MessageBox.Show("แก้ไขตำบลสำคัญไม่เสร็จสิ้น กรุณากรอกข้อมูลให้ครบถ้วน", "ตำบลสำคัญ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
        
}
