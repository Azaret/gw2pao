﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using GW2PAO.API.Data.Entities;
using GW2PAO.API.Services.Interfaces;
using GW2PAO.API.Util;
using GW2PAO.Modules.ZoneCompletion;
using GW2PAO.Modules.ZoneCompletion.Interfaces;
using GW2PAO.Modules.ZoneCompletion.Models;
using GW2PAO.Modules.ZoneCompletion.ViewModels;
using GW2PAO.Utility;
using MapControl;
using Microsoft.Practices.Prism.Mvvm;
using NLog;

namespace GW2PAO.Modules.Map.ViewModels
{
    [Export(typeof(MapViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MapViewModel : BindableBase
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const int DEFAULT_CONTINENT_ID = 1;

        private MapUserData userData;
        private ZoneCompletionUserData zoneUserData;
        private IZoneCompletionController zoneController;
        private IZoneService zoneService;
        private IPlayerService playerService;
        private ZoneItemsStore zoneItemsStore;
        private int floorId;
        private Continent continentData;
        private Location mapCenter;
        
        

        // TODO: Consider moving these to the UserData class
        private bool showWaypoints;
        private bool showPOIs;
        private bool showVistas;
        private bool showHeartQuests;
        private bool showHeroPoints;
        private bool showDungeons;

        /// <summary>
        /// Data for the displayed continent
        /// </summary>
        public Continent ContinentData
        {
            get { return this.continentData; }
            set
            {
                if (SetProperty(ref this.continentData, value))
                {
                    this.OnPropertyChanged(() => this.MapTileSourceString);
                }
            }
        }

        /// <summary>
        /// The active floor to show on the map
        /// </summary>
        public int FloorId
        {
            get { return this.floorId; }
            set
            {
                if (SetProperty(ref this.floorId, value))
                {
                    this.OnPropertyChanged(() => this.MapTileSourceString);
                }
            }
        }

        /// <summary>
        /// Final source string to use when retrieving map tiles
        /// </summary>
        public string MapTileSourceString
        {
            get
            {
                return string.Format("https://tiles.guildwars2.com/{0}/{1}/{2}.jpg", this.ContinentData.Id, this.FloorId, "{z}/{x}/{y}");
            }
        }

        /// <summary>
        /// The center location of the map
        /// </summary>
        public Location MapCenter
        {
            get { return this.mapCenter; }
            set { SetProperty(ref this.mapCenter, value); }
        }

        /// <summary>
        /// ViewModel object containing all data associated with the character pointer
        /// </summary>
        public CharacterPointerViewModel CharacterPointer
        {
            get;
            private set;
        }

        /// <summary>
        /// Collection of Waypoints for the current continent
        /// </summary>
        public ObservableCollection<ZoneItemViewModel> Waypoints
        {
            get { return this.zoneItemsStore.Data[this.ContinentData.Id].Waypoints; }
        }

        /// <summary>
        /// True if Waypoints should be shown on the map, else false
        /// </summary>
        public bool ShowWaypoints
        {
            get { return this.showWaypoints; }
            set { SetProperty(ref this.showWaypoints, value); }
        }

        /// <summary>
        /// Collection of Points of Interest for the current continent
        /// </summary>
        public ObservableCollection<ZoneItemViewModel> POIs
        {
            get { return this.zoneItemsStore.Data[this.ContinentData.Id].POIs; }
        }

        /// <summary>
        /// True if POIs should be shown on the map, else false
        /// </summary>
        public bool ShowPOIs
        {
            get { return this.showPOIs; }
            set { SetProperty(ref this.showPOIs, value); }
        }

        /// <summary>
        /// Collection of Vistas for the current continent
        /// </summary>
        public ObservableCollection<ZoneItemViewModel> Vistas
        {
            get { return this.zoneItemsStore.Data[this.ContinentData.Id].Vistas; }
        }

        /// <summary>
        /// True if Vistas should be shown on the map, else false
        /// </summary>
        public bool ShowVistas
        {
            get { return this.showVistas; }
            set { SetProperty(ref this.showVistas, value); }
        }

        /// <summary>
        /// Collection of Heart Quests for the current continent
        /// </summary>
        public ObservableCollection<ZoneItemViewModel> HeartQuests
        {
            get { return this.zoneItemsStore.Data[this.ContinentData.Id].HeartQuests; }
        }

        /// <summary>
        /// True if Heart Quests should be shown on the map, else false
        /// </summary>
        public bool ShowHeartQuests
        {
            get { return this.showHeartQuests; }
            set { SetProperty(ref this.showHeartQuests, value); }
        }

        /// <summary>
        /// Collection of Hero Points for the current continent
        /// </summary>
        public ObservableCollection<ZoneItemViewModel> HeroPoints
        {
            get { return this.zoneItemsStore.Data[this.ContinentData.Id].HeroPoints; }
        }

        /// <summary>
        /// True if Hero Points should be shown on the map, else false
        /// </summary>
        public bool ShowHeroPoints
        {
            get { return this.showHeroPoints; }
            set { SetProperty(ref this.showHeroPoints, value); }
        }

        /// <summary>
        /// Collection of Dungeons for the current continent
        /// </summary>
        public ObservableCollection<ZoneItemViewModel> Dungeons
        {
            get { return this.zoneItemsStore.Data[this.ContinentData.Id].Dungeons; }
        }

        /// <summary>
        /// True if Dungeons should be shown on the map, else false
        /// </summary>
        public bool ShowDungeons
        {
            get { return this.showDungeons; }
            set { SetProperty(ref this.showDungeons, value); }
        }

        /// <summary>
        /// Constructs a new MapViewModel
        /// </summary>
        [ImportingConstructor]
        public MapViewModel(IZoneCompletionController zoneController, IZoneService zoneService, IPlayerService playerService,
            ZoneItemsStore zoneItemsStore, MapUserData userData, ZoneCompletionUserData zoneUserData)
        {
            this.zoneController = zoneController;
            this.playerService = playerService;
            this.zoneService = zoneService;
            this.zoneUserData = zoneUserData;
            this.zoneItemsStore = zoneItemsStore;
            this.userData = userData;

            this.CharacterPointer = new CharacterPointerViewModel(zoneController, userData);
            this.CharacterPointer.PropertyChanged += CharacterPointer_PropertyChanged;

            this.FloorId = 1;

            this.ShowHeartQuests = true;
            this.ShowHeroPoints = true;
            this.ShowPOIs = true;
            this.ShowVistas = true;
            this.ShowWaypoints = true;
            this.ShowDungeons = true;

            if (this.playerService.HasValidMapId)
                this.ContinentData = this.zoneService.GetContinentByMap(this.playerService.MapId);
            else
                this.ContinentData = this.zoneService.GetContinent(DEFAULT_CONTINENT_ID);

            ((INotifyPropertyChanged)this.zoneController).PropertyChanged += ZoneControllerPropertyChanged;
            this.zoneController.Start();
        }

        /// <summary>
        /// Handles the PropertyChanged event of the Zone Controller
        /// </summary>
        private void ZoneControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ReflectionUtility.GetPropertyName(() => this.zoneController.ActiveMap))
            {
                this.ContinentData = this.zoneService.GetContinentByMap(this.zoneController.CurrentMapID);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of the CharacterPointer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterPointer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ReflectionUtility.GetPropertyName(() => this.CharacterPointer.CharacterLocation))
            {
                if (this.CharacterPointer.SnapToCharacter)
                    this.MapCenter = this.CharacterPointer.CharacterLocation;
            }
            else if (e.PropertyName == ReflectionUtility.GetPropertyName(() => this.CharacterPointer.SnapToCharacter))
            {
                if (this.CharacterPointer.SnapToCharacter)
                    this.MapCenter = this.CharacterPointer.CharacterLocation;
            }
        }
    }
}
