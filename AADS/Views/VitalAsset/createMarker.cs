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
        private int mouseX;
        private int mouseY;
        private VitalAsset.main vitalMain = VitalAsset.main.getInstace();
        private PointLatLng point;
        public static GMapOverlay ovl;
        private mainForm mainForm1 = mainForm.GetInstance();
        public static GMarkerGoogle marker;
        public createMarker(int x, int y)
    {
            main = mainForm.GetInstance();
            mouseX = x;
            mouseY = y;
    }
        public void singleMark()
        {
            point = main.mainMap.FromLocalToLatLng(mouseX, mouseY);
            GMapOverlay overlay = mainForm1.GetOverlay("markersP");
            marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
            overlay.Markers.Add(marker);
            setValueVital();
            main.setVitClickedValue(false);
            main.setCurrentMarkerStatus(false);
            updateMap();
        }
        public GMarkerGoogle getMarker()
        {
            return marker;
        }
        public GMapOverlay getOverlay()
        {
            return ovl;
        }
        void updateMap()
        {
            main.mainMap.Zoom += 0.01;
            main.mainMap.Zoom -= 0.01;
        }

        void setValueVital()
        {
            vitalMain = VitalAsset.main.getInstace();
            vitalMain.txtPointLat.Text = point.Lat.ToString();
            vitalMain.txtPointLng.Text = point.Lng.ToString();
        }
    }
}
