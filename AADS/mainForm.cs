using Demo.WindowsForms.CustomMarkers;
using Demo.WindowsForms.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Net_GmapMarkerWithLabel;
using NewRadarUX;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADS
{
    public partial class mainForm : Form
    {
        private List<PointLatLng> _points = new List<PointLatLng>();
        //public Dictionary <int Id, GMarkerGoogle marker> markersDict;
        internal readonly GMapOverlay top = new GMapOverlay();
        internal readonly GMapOverlay markersP = new GMapOverlay("markersP");
        internal readonly GMapOverlay Radar = new GMapOverlay("Radar");
        internal readonly GMapOverlay lineDistance = new GMapOverlay("lineDistance");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        internal readonly GMapOverlay Track = new GMapOverlay("Track");
        internal readonly GMapOverlay Test = new GMapOverlay("Test");
        internal readonly GMapOverlay BordersTrack = new GMapOverlay("BordersTrack");
        internal readonly GMapOverlay midlineDistance = new GMapOverlay("midlineDistance");
        internal readonly GMapOverlay minMapOverlay = new GMapOverlay("minMapOverlay");
        internal readonly GMapOverlay routeAndCorridor = new GMapOverlay("routeAndCorridor");
        internal readonly Dictionary<int, GMarkerGoogle> markersDict = new Dictionary<int, GMarkerGoogle>();
        

        List<MapMode> mapModes = new List<MapMode>();
        GMapMarker currentMarker;
        GMapMarkerRect CurentRectMarker = null;



        GMapMarker markertag = null;
        GMapPolygon polygon;
        string action = null;
        static int simID = 300;
        bool minMapAutoZoom = false;

        MarkerAndPolygon markerAndPolygon;
        public RadarOverlay radarP;
        public GMapOverlay GetOverlay(string Name)
        {
            return mainMap.Overlays.FirstOrDefault(x => x.Id == Name);
        }
        public static mainForm GetInstance()
        {
            return Instance;
        }
        public GMapControl GetmainMap()
        {
            return mainMap;
        }
        public static mainForm Instance;
        private void readJsonMap()
        {
            using (StreamReader reader = new StreamReader("Maps.json"))
            {
                string json = reader.ReadToEnd();
                JArray list = JArray.Parse(json);
                foreach (JObject data in list.Children())
                {
                    mapModes.Add(new MapMode
                    {
                        Name = (string)data["Name"],
                        MapProvider = GMapProviders.TryGetProvider((string)data["Type"]),
                        MainMapMinZoom = (int)data["MainMapMinZoom"],
                        MainMapMaxZoom = (int)data["MainMapMaxZoom"],
                        MiniMapMinZoom = (int)data["MiniMapMinZoom"],
                        MiniMapMaxZoom = (int)data["MiniMapMaxZoom"]
                    });
                }
            }
        }
        public mainForm()
        {
            InitializeComponent();
            Instance = this;
            mainMap.OnMarkerClick += new MarkerClick(mainMap_OnMarkerClick_1);
            mainMap.Manager.BoostCacheEngine = true;
            mainMap.MapScaleInfoEnabled = true;
            mainMap.MapScaleInfoPosition = MapScaleInfoPosition.Bottom;

            readJsonMap();

            if (!GMapControl.IsDesignerHosted)
            {
                mainMap.Overlays.Add(Radar);
                mainMap.Overlays.Add(polygons);
                mainMap.Overlays.Add(lineDistance);
                mainMap.Overlays.Add(midlineDistance);
                mainMap.Overlays.Add(markersP);
                mainMap.Overlays.Add(objects);
                mainMap.Overlays.Add(Test);
                mainMap.Overlays.Add(Track);
                mainMap.Overlays.Add(BordersTrack);
                mainMap.Overlays.Add(top);
                minMap1.Overlays.Add(minMapOverlay);

                mainMap.Manager.Mode = AccessMode.ServerAndCache;
                mainMap.MapProvider = mapModes[0].MapProvider;
                mainMap.Position = new PointLatLng(13.7563, 100.5018);
                mainMap.MinZoom = mapModes[0].MainMapMinZoom;
                mainMap.MaxZoom = mapModes[0].MainMapMaxZoom;
                mainMap.Zoom = 10;

                minMap1.Manager.Mode = AccessMode.ServerAndCache;
                minMap1.MapProvider = mapModes[0].MapProvider;
                minMap1.Position = new PointLatLng(13.7563, 100.5018);
                minMap1.MinZoom = mapModes[0].MiniMapMinZoom;
                minMap1.MaxZoom = mapModes[0].MiniMapMaxZoom;
                minMap1.Zoom = 6;

                {
                    mainMap.OnPositionChanged += new PositionChanged(mainMap_OnPositionChanged);

                    //mainMap.OnMapZoomChanged += new MapZoomChanged(mainMap_OnMapZoomChanged);
                    mainMap.OnMapTypeChanged += new MapTypeChanged(mainMap_OnMapTypeChanged);

                    mainMap.MouseUp += new MouseEventHandler(mainMap_MouseUp);
                    mainMap.MouseDown += new MouseEventHandler(mainMap_MouseDown);
                    mainMap.MouseMove += new MouseEventHandler(mainMap_MouseMove);
                    mainMap.MouseClick += new MouseEventHandler(mainMap_MouseClick);

                    mainMap.OnMarkerClick += new MarkerClick(mainMap_OnMarkerClick);
                }

                {
                    flightWorker.DoWork += new DoWorkEventHandler(flight_DoWork);
                    flightWorker.ProgressChanged += new ProgressChangedEventHandler(flight_ProgressChanged);
                    flightWorker.WorkerSupportsCancellation = true;
                    flightWorker.WorkerReportsProgress = true;
                }

                flightWorker.RunWorkerAsync();

                currentMarker = new GMarkerGoogle(mainMap.Position, GMarkerGoogleType.arrow);
                currentMarker.IsHitTestVisible = false;
                top.Markers.Add(currentMarker);
                //Console.WriteLine(CPC.Intersection(new PointLatLng(51.8853, 0.2545), new PointLatLng(49.0034, 2.5735), 108.547, 32.435).ToString());
                //Console.WriteLine(CPC.destinationPoint(new PointLatLng(51.127, 1.338), 40300, 116.7));
                //Console.WriteLine(CPC.rhumbBearingTo(new PointLatLng(51.127, 1.338),new PointLatLng(50.964, 1.853)).ToString());
            }
        }
        void updateMinMap()
        {
            minMap1.Position = mainMap.Position;
            List<PointLatLng> plist = new List<PointLatLng>();
            int width = mainMap.Size.Width - 1;
            int height = mainMap.Size.Height - 1;
            plist.Add(mainMap.FromLocalToLatLng(0, 0));
            plist.Add(mainMap.FromLocalToLatLng(width, 0));
            plist.Add(mainMap.FromLocalToLatLng(width, height));
            plist.Add(mainMap.FromLocalToLatLng(0, height));
            GMapPolygon poly = new GMapPolygon(plist, "");
            poly.Fill = Brushes.Transparent;
            poly.Stroke = new Pen(Brushes.Red, 1.6f);
            minMapOverlay.Polygons.Clear();
            minMapOverlay.Polygons.Add(poly);
            if (minMapAutoZoom)
            {
                int minMapArea = minMap1.Size.Height * minMap1.Size.Width;
                long dX = minMap1.FromLatLngToLocal(poly.Points[1]).X - minMap1.FromLatLngToLocal(poly.Points[0]).X;
                long dY = minMap1.FromLatLngToLocal(poly.Points[2]).Y - minMap1.FromLatLngToLocal(poly.Points[1]).Y;
                long area = dX * dY;
                double ratio = (double)area / minMapArea;
                if (ratio < 0.2)
                {
                    minMap1.Zoom++;
                }
                else if (ratio > 0.8)
                {
                    minMap1.Zoom--;
                }
            }
        }
        #region -- flight Progress --

        BackgroundWorker flightWorker = new BackgroundWorker();

        void flight_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!flightWorker.CancellationPending)
            {
                try
                {
                    /*string sql = "SELECT * FROM `info_track`";
                    MySqlConnection com = new MySqlConnection("host=10.109.68.154;user=adminRadar;password=AdminPK23710;database=radar_info;Max Pool Size=100;");
                    MySqlCommand cmd = new MySqlCommand(sql, com);

                    try
                    {
                        com.Open();
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            var ex = new GMapMarkerPlane(PositionConverter.ParsePointFromString(dataReader.GetString("TK_PosX") + "," + dataReader.GetString("TK_PosY")), (float)dataReader.GetInt32("TK_Dir"));

                            int status = dataReader.GetInt32("TK_IFF");
                            if (status == 0)
                            {
                                ex.icon = (Bitmap)Image.FromFile("Images/airplane_Friendly.png");
                            }
                            else if (status == 1)
                            {
                                ex.icon = (Bitmap)Image.FromFile("Images/airplane_Hostile.png");
                            }
                            else
                            {
                                ex.icon = (Bitmap)Image.FromFile("Images/airplane_Unknown.png");
                            }

                            //ex.ToolTipText = PositionConverter.ParsePointToString(MainMap.Position, comboBoxScale.Text);
                            //ex.ToolTipPosition.Offset(ex.Offset);
                            //ex.ToolTipMode = MarkerTooltipMode.Always;
                            Track.Markers.Add(ex);
                        }
                    }
                    finally
                    {
                        com.Close();
                    }*/

                    flightWorker.ReportProgress(100);
                }
                finally
                {

                }
                Thread.Sleep(1 * 1000);
            }
        }

        private int index;
        private Track track = new Track();
        public int SearchPlane(int id)
        {
            foreach (int faker in track.Fakers)
            {
                FlightRadarData fd = track.GetFaker(faker);
                if (fd.Id == id)
                {
                    return faker;
                }
            }
            return -1;
        }
        bool IsPointInPolygon(List<PointLatLng> points, PointLatLng point)
        {
            bool isInside = false;
            for (int i = 0, j = points.Count - 1; i < points.Count; j = i++)
            {
                if (((points[i].Lat > point.Lat) != (points[j].Lat > point.Lat)) &&
                (point.Lng < (points[j].Lng - points[i].Lng) * (point.Lat - points[i].Lat) / (points[j].Lat - points[i].Lat) + points[i].Lng))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }
        private int indexfaker;
        public PointLatLng pointRader = new PointLatLng();
        public FlightRadarData TagPlane = null;
        void flight_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mainMap.HoldInvalidation = true;

            lock (track)
            {
                foreach (int id in ProcessFlight.AllflightMarkers.Keys)
                {
                    List<PointLatLng> points = new List<PointLatLng>();

                    points.Add(ProcessFlight.AllflightMarkers[id].Position);
                    points.Add(pointRader);
                    GMapPolygon Distance = new GMapPolygon(points, "Distance");

                    if (Distance.Distance > (double)RadarRadius)
                    {
                        track.RemoveFaker(id);
                        if (TagPlane != null && TagPlane.Id == id)
                        {
                            TagPlane = null;
                        }
                    }

                    /*if (flightIdInfo.Text != "" && ProcessFlight.AllflightMarkers[id].id == int.Parse(flightIdInfo.Text))
                    {
                        indexfaker = id;
                    }*/
                    Track.Markers.Remove(ProcessFlight.AllflightMarkers[id]);
                    BordersTrack.Markers.Remove(ProcessFlight.AllBordersTrack[id]);
                }
                ProcessFlight.AllflightMarkers.Clear();
                ProcessFlight.AllBordersTrack.Clear();

                ProcessFlight.testDoWork();
                MarkerAndPolygon map = MarkerAndPolygon.GetInstance();
                foreach (int faker in track.Fakers)
                {
                    FlightRadarData fd = track.GetFaker(faker);

                    var ex = new GMapMarkerPlane(fd.point, (float)fd.bearing, fd.speed, fd.Id, mainMap.Zoom);
                    ex.id = fd.Id;
                    ex.setIcon(fd.identification);
                    ex.flight = fd;
                    ex.Tag = new SimpleTrackInfo(TrackType.Faker, fd.Id);
                    //ex.ToolTipText = PositionConverter.ParsePointToString(MainMap.Position, comboBoxScale.Text);
                    //ex.ToolTipPosition.Offset(ex.Offset);
                    //ex.ToolTipMode = MarkerTooltipMode.Always;

                    GMapMarkerRectPlane mBorders = new GMapMarkerRectPlane(ex.Position);
                    mBorders.InnerMarker = ex;

                    ProcessFlight.AllflightMarkers.Add(fd.Id, ex);
                    ProcessFlight.AllBordersTrack.Add(fd.Id, mBorders);

                    bool isInside = false;
                    foreach (GMapPolygon poly in map.RestrictedArea)
                    {
                        isInside = IsPointInPolygon(poly.Points, fd.point);
                        if (isInside) break;
                    }
                    if (!isInside || track.isFollow(faker))
                    {
                        BordersTrack.Markers.Add(mBorders);
                        Track.Markers.Add(ex);
                    }
                    /*var strDecoder = ConvertDataDecoder.Convertcode(fd.point, fd.bearing, fd.altitude, fd.speed, fd.Id, fd.identification, SetSerialPort.decoder);
                    if (SetSerialPort.sportPort_send.IsOpen)
                    {
                        SetSerialPort.sportPort_send.Write(strDecoder);
                        Console.WriteLine(strDecoder);
                    }

                    // to Wait for correction
                    Encoder encoder = new Encoder();
                    Radar radar = new Radar(41, radarP.Position);
                    string strdecode = encoder.Encode(fd, radar);
                    Console.WriteLine(strdecode);
                    SetSerialPort.sportPort_send.Write(strdecode);*/
                }

                Dictionary<int, FlightRadarData> realTrack = track.CloneRealTrack();

                foreach (int real in realTrack.Keys)
                {
                    FlightRadarData fd = realTrack[real];
                    var ex = new GMapMarkerPlane(fd.point, (float)fd.bearing, fd.speed, fd.Id, mainMap.Zoom);
                    ex.setIcon(track.getStatus(fd.Id));
                    ex.flight = fd;
                    ex.Tag = new SimpleTrackInfo(TrackType.Real, fd.Id);

                    GMapMarkerRectPlane mBorders = new GMapMarkerRectPlane(ex.Position);
                    mBorders.InnerMarker = ex;

                    ProcessFlight.AllflightMarkers.Add(fd.Id, ex);
                    ProcessFlight.AllBordersTrack.Add(fd.Id, mBorders);

                    bool isInside = false;
                    foreach (GMapPolygon poly in map.RestrictedArea)
                    {
                        isInside = IsPointInPolygon(poly.Points, fd.point);
                        if (isInside) break;
                    }
                    if (!isInside || track.isFollow(real))
                    {
                        BordersTrack.Markers.Add(mBorders);
                        Track.Markers.Add(ex);
                    }
                }
                track.Save();
            }

            //updateline();
            //CalculateCPC();
            //updatePlaneInfo();
            mainMap.Refresh();
        }
        #endregion

        #region -- event mainMap --
        void mainMap_OnPositionChanged(PointLatLng point)
        {
            updateMinMap();
        }

        void mainMap_OnMapTypeChanged(GMapProvider type)
        {

        }

        void mainMap_OnMapZoomChanged()
        {
            updateMinMap();
        }
        void mainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {

        }

        bool isMouseDown = false;
        bool isRightClick = false;
        Point lastLocation;
        void mainMap_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        void mainMap_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            isRightClick = e.Button == MouseButtons.Right;
        }

        void mainMap_MouseMove(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        void mainMap_MouseClick(object sender, MouseEventArgs e)
        {
            PointLatLng pnew = mainMap.FromLocalToLatLng(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                currentMarker.Position = pnew;
            }
           
            if (action != null)
            {
                string ca = action;
                action = null;
                if (ca == "fixedPointAdd")
                {
                    labelCurrentAction.Text = "Action: Free";
                    callFixedPoint();
                }
            }
        }
        #endregion

        #region -- data Code --
        private int RadarRadius = 140;
        private Dictionary<string, RadarOverlay> radars = new Dictionary<string, RadarOverlay>();
        private void loadPointR()
        {
            //first section
            {
                string path = @"พิกัดเรดาร์.txt";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            //PointLatLng pointR = PositionConverter.ParsePointFromString(line);
                            //pointRader = pointR;
                            //textBoxPositionR.Text = PositionConverter.ParsePointToString(pointR, comboBoxScale.Text);
                        }
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("13.75, 100.517");
                        //textBoxPositionR.Text = "13.75, 100.517";
                        writer.Close();
                    }
                }
            }
            string name = "Test";
            int interval = 140;//Convert.ToInt32(textBoxRadarInterval.Text);
            radarP = new RadarOverlay(name, Radar);
            int x = 0;
            //Int32.TryParse(textBoxRadarRadius.Text, out x);
            radarP.InitialRadar(PositionConverter.ParsePointFromString("13.75, 100.517"), x, interval);
            radars.Add(name, radarP);
        }
        #endregion
        private void updateCmbMapMode()
        {
            cmbMapMode.Items.Clear();
            foreach (MapMode mapMode in mapModes)
            {
                cmbMapMode.Items.Add(mapMode.Name);
            }
        }
        private Point label27Location;
        private void mainForm_Load(object sender, EventArgs e)
        {
            setOnlickMenuMarker(false);
            timeNow.Start();
            updateMinMap();
            updateCmbMapMode();
            cmbMapMode.SelectedIndex = 0;
            panelRight.Height = this.Height - panelControl.Height - panelTop.Height - panelBottom.Height;
            panelRight.Location = new Point(1950,93);
            label27Location = new Point(this.Width - label27.Width, label27.Location.Y);
            mainMap.Overlays.Add(routeAndCorridor);


        }
        private void closeBox_Click(object sender, EventArgs e)
        {
            timerClose.Start();
        }

        private void maximizeBox_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
            label27Location = new Point(this.Width - label27.Width, label27.Location.Y);
        }

        private void minimizeBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timeNow_Tick(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Now;
            dateLabel.Text = Date.ToString("dd-MMM-yyyy");
            time_label.Text = Date.ToString("HH:mm:ss");
        }
        private void callFixedPoint()
        {
            using (Views.FixedPoint.main form = new Views.FixedPoint.main())
            {
                form.OnClickAdd += new EventHandler(fixedPoint_ClickAdd);
                form.ShowDialog();
            }
        }
        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedIndex > -1)
            {
                if (cmbMenu.SelectedItem.ToString().Equals("Fixed Point"))
                {
                    callFixedPoint();
                }
            }
        }
        private void fixedPoint_ClickAdd(object sender, EventArgs e)
        {
            action = "fixedPointAdd";
            labelCurrentAction.Text = "Action: Fixed Point";
        }

        private void cmbMapMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbMapMode.SelectedIndex;
            MapMode mode = mapModes[index];
            if (mainMap.MapProvider != mode.MapProvider)
            {
                mainMap.MapProvider = mode.MapProvider;
                minMap1.MapProvider = mode.MapProvider;
                mainMap.MinZoom = mode.MainMapMinZoom;
                mainMap.MaxZoom = mode.MainMapMaxZoom;
                minMap1.MinZoom = mode.MiniMapMinZoom;
                minMap1.MaxZoom = mode.MiniMapMaxZoom;
            }
        }
        private bool hasPanelRight = false;
        private void label27_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        
      
        private void btnShow_Maker_Click(object sender, EventArgs e)
        {
            var MarkerPage = new Views.ShowCategory.Marker();
            panelRightShow.Controls.Clear();
            panelRightShow.Controls.Add(MarkerPage);

        }

        private void btnShow_Line_Click(object sender, EventArgs e)
        {
            var LinePage = new Views.ShowCategory.Line();
            panelRightShow.Controls.Clear();
            panelRightShow.Controls.Add(LinePage);
        }
        private void btnShow_Polygon_Click(object sender, EventArgs e)
        {
            var PlygonPage = new Views.ShowCategory.Polygon();
            panelRightShow.Controls.Clear();
            panelRightShow.Controls.Add(PlygonPage);
        }
        private void btnShow_Track_Click(object sender, EventArgs e)
        {
            var TrackPage = new Views.ShowCategory.Track();
            panelRightShow.Controls.Clear();
            panelRightShow.Controls.Add(TrackPage);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = panelRight.Location.X;
            int y = 93;
            if (hasPanelRight)
            {
                x = x + (panelRight.Width / 14);
                label27.Location = new Point(x, y);
                panelRight.Location = new Point(x, y);
                if (x >= this.Width)
                {
                    timer1.Stop();
                    hasPanelRight = false;
                    label27.Text = "<<<";
                    label27.Location = label27Location;
                }
            }
            else
            {
                x = x - (panelRight.Width / 14);
                label27.Location = new Point(x - label27.Width, y);
                panelRight.Location = new Point(x, y);
                if (x <= this.Width - panelRight.Width + 14)
                {
                    timer1.Stop();
                    hasPanelRight = true;
                    label27.Text = ">>>";
                }
            }
        }

        
        private void timerOpen_(object sender, EventArgs e)
        {
            Opacity += 0.05;
            if (Opacity >= 1)
            {
                timerOpen.Stop();
            }
        }
        private void timerClose_(object sender, EventArgs e)
        {
            Opacity -= 0.05;
            if (Opacity <= 0)
            {
                Application.Exit();
                timerOpen.Stop();
            }

        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            if (panelRightMap.Visible)
                panelRightShow.Controls.Clear();
            panelRightMap.Visible = false;
            panelRightUnit.Visible = true; 
           
        }
        private void btnMap_Click(object sender, EventArgs e)
        {
            if (!panelRightMap.Visible)
                panelRightShow.Controls.Clear();
            panelRightMap.Visible = true;
            panelRightUnit.Visible = false;
           
        }
        private void mainMap_Click(object sender, EventArgs e)
        {
        }
        public static int counter = 0;
        public int prevCounter;
        private List<PointLatLng> routePoints = new List<PointLatLng>();
        private List<GMapRoute> routeArr = new List<GMapRoute>();
        public bool isOnRouteFuncClicked = false;
        private void mainMap_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (vitCheck) 
            {
                var createMarker1 = new Views.VitalAsset.createMarker();
                createMarker1.singleMark(e.X, e.Y);
            }
            else if (isOnRouteFuncClicked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    string name = "route" + counter;
                    var point = mainMap.FromLocalToLatLng(e.X, e.Y);
                    routePoints.Add(point);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);
                    markersP.Markers.Add(marker);
                    GMapRoute route = new GMapRoute(routePoints, name);
                    routeAndCorridor.Routes.Add(route);
                }
            }
            else
            {
                prevCounter = counter;
                counter++;
            }
        }
        private static bool vitCheck = false;
        internal void setCurrentMarkerStatus(bool status)
        {
            currentMarker.IsVisible = status;
        }

        public void setVitClickedValue(bool checkVit)
        {
            vitCheck = checkVit;
        }
        public void updateMap()
        {
            mainMap.Zoom += 0.1;
            mainMap.Zoom -= 0.1;
        }
        private GMapMarker currentItem;

        private void mainMap_OnMarkerClick_1(GMapMarker item, MouseEventArgs e)
        {
            currentItem = item;
            if (isMenuMarkerClicked)
            {
                if (e.Button == MouseButtons.Right)
                {
                    menuMarker.Show(Cursor.Position);
                }
            }
            //foreach (var j in panelRight.Controls.OfType<UserControl>())
            //{
            //    var vitalMain = Views.VitalAsset.main.getInstace();
            //    if (j == vitalMain)
            //    {
            //        if (e.Button == MouseButtons.Right)
            //        {
            //            menuMarker.Show(Cursor.Position);
            //        }
            //    }
            //}
            
        }
        private static bool isMenuMarkerClicked;
        public void setOnlickMenuMarker(bool check)
        {
            isMenuMarkerClicked = check;
        }
        private void menuMarker_Click(object sender, EventArgs e)
        {
        }

        private void menuMarker_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            var vitalMain = Views.VitalAsset.main.getInstace();
            string itemName = clickedItem.Text;
            if (itemName.Equals("แก้ไข"))
            {
                vitalMain.editData(currentItem);
                setOnlickMenuMarker(false);
            }
            else if (itemName.Equals("ลบ"))
            {
                markersP.Markers.Remove(currentItem);
                vitalMain.setRdbAutoChecked(false);
                vitalMain.reset();
            }
        }

        private void mainMap_MouseMove_1(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = mainMap.FromLocalToLatLng(e.X, e.Y);
                } 
            }  
        }

        private void mainMap_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                if (currentMarker != null)
                {
                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = mainMap.FromLocalToLatLng(e.X, e.Y);
                    }
                }
                
            }
        }
    }
}
