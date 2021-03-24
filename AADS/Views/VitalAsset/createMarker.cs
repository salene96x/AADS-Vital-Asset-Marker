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
    class createMarker
    {
        private int mouseX;
        private int mouseY;
        public createMarker(int x, int y)
    {   
            mouseX = x;
            mouseY = y;
    }
        public void singleMark()
        {
            var mainForm = new AADS.mainForm();
            var point = mainForm.mainMap.FromLocalToLatLng(mouseX, mouseY);
            GMapOverlay markersOvl = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
            
            markersOvl.Markers.Add(marker);
            mainForm.mainMap.Overlays.Add(markersOvl);
            //var main = new Views.VitalAsset.main();
            //main.txtPointLat.Text = point.Lat.ToString();
            //main.txtPointLng.Text = point.Lng.ToString();
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
