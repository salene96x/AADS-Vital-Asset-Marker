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
        private static mainForm main;
        private int mouseX;
        private int mouseY;
        public createMarker(int x, int y)
    {   
            mouseX = x;
            mouseY = y;
    }
        public void singleMark(int x, int y)
        {
            main = new mainForm();
            var point = main.mainMap.FromLocalToLatLng(mouseX, mouseY);
            GMapOverlay markersOvl = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
            
            markersOvl.Markers.Add(marker);
            main.mainMap.Overlays.Add(markersOvl);

            using (Views.VitalAsset.main main = new main(point))
            {
                main mainVital = new main(point);
                mainVital.txtPointLat.Text = point.Lat.ToString();
                mainVital.txtPointLng.Text = point.Lng.ToString();
            }
            updateMap();
        }
        void updateMap()
        {
            var mainForm = new AADS.mainForm();
            mainForm.mainMap.Zoom -= 0.1;
            mainForm.mainMap.Zoom += 0.1;
        }
    }
}
