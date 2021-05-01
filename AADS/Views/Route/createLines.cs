using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AADS.Views.Route
{
    class createLines
    {
        private mainForm main;
        private GMapOverlay overlay;
        private GMapOverlay overlayMarker;
        private static int counter = 0;
        public createLines() 
        {
            main = mainForm.GetInstance();
            overlay = main.GetOverlay("routeAndCorridor");
            overlayMarker = main.GetOverlay("markersP");
        }
        public void CreateLine(List<PointLatLng> pointsArr)
        {
            GMapMarker marker = new GMarkerGoogle(pointsArr[counter], GMarkerGoogleType.red_dot);
            overlayMarker.Markers.Add(marker);
            GMapRoute route = new GMapRoute(pointsArr, "route");
            overlay.Routes.Add(route);
            counter++;
        }

    }
}
