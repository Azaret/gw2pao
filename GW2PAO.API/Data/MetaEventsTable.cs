using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GW2PAO.API.Constants;
using GW2PAO.API.Data.Entities;

namespace GW2PAO.API.Data
{
    /// <summary>
    /// Data table containing meta event cycle information
    /// </summary>
    public class MetaEventsTable
    {
        /// <summary>
        /// File name for the data xml file
        /// </summary>
        public static readonly string Filename = "MetaEventTable.xml";

        /// <summary>
        /// List of meta events and their details
        /// </summary>
        public List<MetaEvent> MetaEvents { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MetaEventsTable()
        {
            this.MetaEvents = new List<MetaEvent>();
        }

        /// <summary>
        /// Loads the meta events data xml file
        /// </summary>
        /// <returns>The loaded meta events data</returns>
        public static MetaEventsTable LoadTable()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(MetaEventsTable));
            TextReader reader = new StreamReader(MetaEventsTable.Filename);
            MetaEventsTable loadedData = null;
            try
            {
                object obj = deserializer.Deserialize(reader);
                loadedData = (MetaEventsTable)obj;
            }
            finally
            {
                reader.Close();
            }

            return loadedData;
        }

        /// <summary>
        /// Creates the meta events data xml file
        /// </summary>
        /// <returns></returns>
        public static void CreateTable()
        {
            MetaEventsTable met = new MetaEventsTable();

            // Note: Names actually come from a localized names provider, but are left here for reference
            // in the xml file

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Dry Top",
                ID = MetaEventID.DryTop,
                MapID = 988,
                StartOffset = new SerializableTimespan(0, 0, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.DryTop_CrashSite, Name = "Crash Site", Duration = new SerializableTimespan(0, 40, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.DryTop_Sandstorm, Name = "Sandstorm", Duration = new SerializableTimespan(0, 20, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Verdant Brink",
                ID = MetaEventID.VerdantBrink,
                MapID = 1052,
                StartOffset = new SerializableTimespan(0, 10, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.VerdantBrink_NightBosses, Name = "Night Bosses", Duration = new SerializableTimespan(0, 20, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.VerdantBrink_Daytime, Name = "Daytime", Duration = new SerializableTimespan(1, 15, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.VerdantBrink_Night, Name = "Night", Duration = new SerializableTimespan(0, 25, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Auric Basin",
                ID = MetaEventID.AuricBasin,
                MapID = 1043,
                StartOffset = new SerializableTimespan(0, 45, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.AuricBasin_Challenges, Name = "Challenges", Duration = new SerializableTimespan(0, 15, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.AuricBasin_Octovine, Name = "Octovine", Duration = new SerializableTimespan(0, 20, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.AuricBasin_Reset, Name = "Reset", Duration = new SerializableTimespan(0, 10, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.AuricBasin_Pylons, Name = "Pylons", Duration = new SerializableTimespan(1, 15, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Tangled Depths",
                ID = MetaEventID.TangledDepths,
                MapID = 1045,
                StartOffset = new SerializableTimespan(0, 25, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.TangledDepths_Preparation, Name = "Preparation", Duration = new SerializableTimespan(0, 5, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.TangledDepths_ChakGerent, Name = "Chak Gerent", Duration = new SerializableTimespan(0, 20, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.TangledDepths_HelpOutposts, Name = "Help Outposts", Duration = new SerializableTimespan(1, 35, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Dragon's Stand",
                ID = MetaEventID.DragonsStand,
                MapID = 1041,
                StartOffset = new SerializableTimespan(1, 30, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.DragonsStand_MapActive, Name = "Map Active", Duration = new SerializableTimespan(2, 0, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Lake Doric",
                ID = MetaEventID.LakeDoric,
                MapID = 1185,
                StartOffset = new SerializableTimespan(0, 30, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.LakeDoric_NoransHomestead, Name = "Noran's Homestead", Duration = new SerializableTimespan(0, 30, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.LakeDoric_SaidrasHaven, Name = "Saidra's Haven", Duration = new SerializableTimespan(0, 45, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.LakeDoric_NewLoamhurst, Name = "New Loamhurst", Duration = new SerializableTimespan(0, 45, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Crystal Oasis",
                ID = MetaEventID.CrystalOasis,
                MapID = 1210,
                StartOffset = new SerializableTimespan(0, 5, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.CrystalOasis_CasinoBlitz, Name = "Casino Blitz", Duration = new SerializableTimespan(0, 25, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.Inactive, Name = "", Duration = new SerializableTimespan(1, 35, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Desert Highlands",
                ID = MetaEventID.DesertHighlands,
                MapID = 1211,
                StartOffset = new SerializableTimespan(1, 0, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.DesertHighlands_BuriedTreasure, Name = "Buried Treasure", Duration = new SerializableTimespan(0, 20, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.Inactive, Name = "", Duration = new SerializableTimespan(1, 40, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Domain of Vabbi",
                ID = MetaEventID.DomainOfVabbi,
                MapID = 1248,
                StartOffset = new SerializableTimespan(0, 0, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.DomainOfVabbi_SerpentsIre, Name = "Serpents' Ire", Duration = new SerializableTimespan(0, 30, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.Inactive, Name = "", Duration = new SerializableTimespan(1, 0, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Domain of Istan",
                ID = MetaEventID.DomainOfIstan,
                MapID = 1263,
                StartOffset = new SerializableTimespan(1, 45, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.DomainOfIstan_Palawadan, Name = "Palawadan", Duration = new SerializableTimespan(0, 30, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.Inactive, Name = "", Duration = new SerializableTimespan(1, 30, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Jahai Bluffs",
                ID = MetaEventID.JahaiBluffs,
                MapID = 1301,
                StartOffset = new SerializableTimespan(1, 0, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.JahaiBluffs_DangerousPrey, Name = "Dangerous Prey", Duration = new SerializableTimespan(0, 30, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.Inactive, Name = "", Duration = new SerializableTimespan(1, 30, 0) }
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Thunderhead Peaks",
                ID = MetaEventID.ThunderheadPeaks,
                MapID = 1310,
                StartOffset = new SerializableTimespan(0, 45, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { ID = MetaEventStageID.ThunderheadPeaks_TheOilFloes, Name = "The Oil Floes", Duration = new SerializableTimespan(0, 15, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.Inactive, Name = "", Duration = new SerializableTimespan(0, 45, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.ThunderheadPeaks_ThunderheadKeep, Name = "Thunderhead Keep", Duration = new SerializableTimespan(0, 20, 0) },
                    new MetaEventStage() { ID = MetaEventStageID.Inactive, Name = "", Duration = new SerializableTimespan(0, 40, 0) }
                }
            });

            met.MetaEvents.Add(new MultiMapMetaEvent()
            {
                Name = "Ley-Line Anomaly",
                ID = MetaEventID.LeyLineAnomaly,
                StartOffset = new SerializableTimespan(0, 20, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_TimberlineFalls, Name = "Timberline Falls"},
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_IronMarches, Name = "Iron Marches"},
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_GendarranFields, Name = "Gendarran Fields"},
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_TimberlineFalls, Name = "Timberline Falls"},
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_IronMarches, Name = "Iron Marches"},
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_GendarranFields, Name = "Gendarran Fields"},
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_TimberlineFalls, Name = "Timberline Falls"},
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_IronMarches, Name = "Iron Marches"},
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_GendarranFields, Name = "Gendarran Fields"},
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_TimberlineFalls, Name = "Timberline Falls"},
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 25, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_IronMarches, Name = "Iron Marches"},
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { MapID = 24, Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.LeyLineAnomaly_GendarranFields, Name = "Gendarran Fields"},
                    new MetaEventStage() { MapID = 29, Duration = new SerializableTimespan(1, 45, 0), ID = MetaEventStageID.Inactive, Name = "" },
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Grothmar Valley",
                ID = MetaEventID.GrothmarValley,
                MapID = 1330,
                StartOffset = new SerializableTimespan(0, 10, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.GrothmarValley_Effigy, Name = "Effigy" },
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 13, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 22, 0), ID = MetaEventStageID.GrothmarValley_DoomloreShrine, Name = "Doomlore Shrine" },
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 05, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 20, 0), ID = MetaEventStageID.GrothmarValley_OozePits, Name = "Ooze Pits" },
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.Inactive, Name = "" },
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.GrothmarValley_MetalConcert, Name = "Metal Concert" },
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 15, 0), ID = MetaEventStageID.Inactive, Name = "" },
                }
            });

            met.MetaEvents.Add(new SingleMapMetaEvent()
            {
                Name = "Bjora Marches",
                ID = MetaEventID.BjoraMarches,
                MapID = 1343,
                StartOffset = new SerializableTimespan(1, 35, 0),
                Stages = new List<MetaEventStage>()
                {
                    new MetaEventStage() { Duration = new SerializableTimespan(0, 35, 0), ID = MetaEventStageID.BjoraMarches_StormsOfWinter, Name = "Storms of Winter" },
                    new MetaEventStage() { Duration = new SerializableTimespan(1, 25, 0), ID = MetaEventStageID.Inactive, Name = "" },
                }
            });

            XmlSerializer serializer = new XmlSerializer(typeof(MetaEventsTable));
            TextWriter textWriter = new StreamWriter(MetaEventsTable.Filename);
            serializer.Serialize(textWriter, met);
            textWriter.Close();
        }
    }
}
