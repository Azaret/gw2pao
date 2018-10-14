using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2PAO.API.Constants
{
    public class MetaEventID
    {
        public static readonly Guid DryTop = new Guid("F19EA7AF-7FFD-42A0-B20A-530C8F55DB32");
        public static readonly Guid VerdantBrink = new Guid("F65F53A9-9665-4049-8518-C04F4FAADA44");
        public static readonly Guid AuricBasin = new Guid("5544E617-3930-42C0-93D5-9FA0F938E5AD");
        public static readonly Guid TangledDepths = new Guid("7A2F2E16-CDE1-4C02-82BC-F37199301515");
        public static readonly Guid DragonsStand = new Guid("B03463F6-5CA6-4F0D-B614-B2DC1DFBDF2A");
        public static readonly Guid LakeDoric = new Guid("811BC69E-E334-425B-A31B-A457A040D7B3");
        public static readonly Guid CrystalOasis = new Guid("9396A47B-543A-4E20-8955-70ECBD2BD316");
        public static readonly Guid DesertHighlands = new Guid("1463FD7A-4DBD-4FEB-8373-620C227D17FE");
        public static readonly Guid DomainOfVabbi = new Guid("CACE6C6E-9BFA-4A51-9307-1B17B0F515B1");
        public static readonly Guid DomainOfIstan = new Guid("6658D3D5-87F7-4A1F-8A09-5399667A72A3");
        public static readonly Guid JahaiBluffs = new Guid("A7DCAFB8-218E-4094-9B00-89BD31EA8602");
        public static readonly Guid LeyLineAnomaly = new Guid("644757FB-DE98-4798-B48E-3F273480DE49");
    }

    public class MetaEventStageID
    {
        public static readonly Guid Inactive = new Guid("713AE965-354E-4C82-B0CC-AACBE9EBCDDE");
        public static readonly Guid DryTop_CrashSite = new Guid("03E26C95-D7B6-4333-993C-1B2C1BB1CE10");
        public static readonly Guid DryTop_Sandstorm = new Guid("1C351A1B-3752-4758-B0C9-CAD397DAC3F8");
        public static readonly Guid VerdantBrink_NightBosses = new Guid("0C198B36-80D4-415D-836C-BFE02E6A1087");
        public static readonly Guid VerdantBrink_Daytime = new Guid("D766B894-11E2-4042-97F3-347DC14332E2");
        public static readonly Guid VerdantBrink_Night = new Guid("0E1D38EA-37BE-4C1B-8B28-B91727488B1B");
        public static readonly Guid AuricBasin_Challenges = new Guid("2F07D9A1-62F7-4F6D-BBDE-A4AE2CECC946");
        public static readonly Guid AuricBasin_Octovine = new Guid("2C3E6E9B-36E9-4EC0-A3E6-1088883FE92E");
        public static readonly Guid AuricBasin_Reset = new Guid("9CA89206-A892-4939-844A-02EFFA441494");
        public static readonly Guid AuricBasin_Pylons = new Guid("5D5886AE-6340-4B1F-A44F-52FA1C87ABD0");
        public static readonly Guid TangledDepths_Preparation = new Guid("8A9D1EDB-0F16-41F6-956B-1909E58D8293");
        public static readonly Guid TangledDepths_ChakGerent = new Guid("4D58ABE3-3506-4854-B28A-4860EBBA9615");
        public static readonly Guid TangledDepths_HelpOutposts = new Guid("8B298EE8-2C3C-491F-AA93-8F1A73D4D8CC");
        public static readonly Guid DragonsStand_MapActive = new Guid("79C4A416-50F1-4E0C-B7E7-DD096FFD6633");
        public static readonly Guid LakeDoric_NewLoamhurst = new Guid("A8947826-BA47-4F72-9678-129AAC6B179F");
        public static readonly Guid LakeDoric_NoransHomestead = new Guid("48020A8E-E256-4A9B-8CD8-17D36227A5D3");
        public static readonly Guid LakeDoric_SaidrasHaven = new Guid("FD82D9AD-905C-40B5-84CD-038B229784F5");
        public static readonly Guid CrystalOasis_CasinoBlitz = new Guid("E64A769A-A5AD-4F5D-93AF-CF2022BA88B3");
        public static readonly Guid DesertHighlands_BuriedTreasure = new Guid("5BB43CBC-5919-4961-8C24-1A65482BAC8A");
        public static readonly Guid DomainOfVabbi_SerpentsIre = new Guid("94B42DDA-FA09-4BA5-830C-526B9B7813BE");
        public static readonly Guid DomainOfIstan_Palawadan = new Guid("E68AA03E-C11D-4EC1-BD79-0D0880D4CF9E");
        public static readonly Guid JahaiBluffs_DangerousPrey = new Guid("A9EC79C9-809C-4BE2-BBBA-80CD1A067D75");
        public static readonly Guid LeyLineAnomaly_GendarranFields = new Guid("7418C0EB-BFFE-4899-871C-C63540502C8D");
        public static readonly Guid LeyLineAnomaly_TimberlineFalls = new Guid("E36B80D5-7373-4336-8954-86F886C9725D");
        public static readonly Guid LeyLineAnomaly_IronMarches = new Guid("6B0265A6-0085-4268-981E-1B91005E5995");
    }
}
