using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADS.Views.VitalAsset
{
    public class createMarker
    {
        private mainForm main;
        private VitalAsset.main vitalMain = VitalAsset.main.getInstace();
        private PointLatLng point;
        private mainForm mainForm1 = mainForm.GetInstance();
        public static GMarkerGoogle marker;
        public createMarker()
    {
            main = mainForm.GetInstance();
    }
        public void singleMark(int x, int y)
        {
            point = main.mainMap.FromLocalToLatLng(x, y);
            GMapOverlay overlay = mainForm1.GetOverlay("markersP");
            marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
            marker.ToolTipText = $"\nMarker type : Vital Asset\nLatitude : {point.Lat.ToString()} \nLongitude : {point.Lng.ToString()}";
            overlay.Markers.Add(marker);
            setValueVital();
            main.setVitClickedValue(false);
            main.setCurrentMarkerStatus(false);
            vitalMain.plusMarkerCount();
        }
        public GMarkerGoogle getMarker()
        {
            return marker;
        }
        void setValueVital()
        {
            vitalMain = VitalAsset.main.getInstace();
            vitalMain.txtPointLat.Text = point.Lat.ToString();
            vitalMain.txtPointLng.Text = point.Lng.ToString();
        }
    }
}
