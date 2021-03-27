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
        private VitalAsset.main vitalMain;
        private PointLatLng point;
        public static GMapOverlay ovl;
        public createMarker(int x, int y)
    {
            main = mainForm.GetInstance();
            mouseX = x;
            mouseY = y;
    }
        public void singleMark()
        {
            point = main.mainMap.FromLocalToLatLng(mouseX, mouseY);
            GMapOverlay markersOvl = new GMapOverlay("vitMarkers");
            ovl = markersOvl;
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
            markersOvl.Markers.Add(marker);
            main.mainMap.Overlays.Add(markersOvl);
            setValueVital();
            main.setVitClickedValue(false);
            main.setCurrentMarkerStatus(false);
            updateMap();
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
