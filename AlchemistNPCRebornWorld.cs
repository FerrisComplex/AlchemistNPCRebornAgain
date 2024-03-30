using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using AlchemistNPCRebornAgain.Interface;
using Terraria.ModLoader.Config;

namespace AlchemistNPCRebornAgain
{
    public class AlchemistNPCRebornWorld : ModSystem
    {
        private const int saveVersion = 0;
        public static bool foundAglet;
		public static bool foundClimbingClaws;
		public static bool foundAnklet;
		public static bool foundShoeSpikes;
		public static bool foundBalloon;
		public static bool foundHermesBoots;
		public static bool foundFlippers;
		public static bool foundFrogLeg;
		public static bool foundCloud;
		public static bool foundBlizzard;
		public static bool foundSandstorm;
		public static bool foundPuffer;
		public static bool foundTsunami;
		public static bool foundWWB;
		public static bool foundIceSkates;
		public static bool foundLavaCharm;
		public static bool foundHorseshoe;
		public static bool foundCMagnet;
		public static bool foundPStone;
		public static bool foundHTFL;
		public static bool foundAnglerEarring;
		public static bool foundTackleBox;
		public static bool foundJFNeck;
		public static bool foundFlowerBoots;
		public static bool foundTabi;
		public static bool foundGoldRing;
		public static bool foundLuckyCoin;
		public static bool foundDiscountCard;
		public static bool foundNeptuneShell;
		public static bool foundString;
		public static bool foundGreenCW;
		public static bool foundYoyoGlove;
		public static bool foundBlindfold;
		public static bool foundArmorPolish;
		public static bool foundVitamins;
		public static bool foundBezoar;
		public static bool foundAdhesiveBandage;
		public static bool foundFastClock;
		public static bool foundTrifoldMap;
		public static bool foundMegaphone;
		public static bool foundNazar;
		public static bool foundSorcE;
		public static bool foundWE;
		public static bool foundRE;
		public static bool foundSumE;
		public static bool foundFeralClaw;
		public static bool foundTitanGlove;
		public static bool foundMagmaStone;
		public static bool foundSharkTooth;
		public static bool foundBlackBelt;
		public static bool foundMoonCharm;
		public static bool foundMoonStone;
		public static bool foundRifleScope;
		public static bool foundPaladinShield;
		public static bool foundFrozenTurtleShell;
		public static bool foundPutridScent;
		public static bool foundFleshKnuckles;
		public static bool foundMagicQuiver;
		public static bool foundCobaltShield;
		public static bool foundPanicNecklace;
		public static bool foundCrossNecklace;
		public static bool foundStarCloak;
		public static bool foundNecromanticScroll;
		public static bool foundObsidianRose;
		public static bool foundShackle;
		public static bool foundSunStone;
		public static bool foundHerculesBeetle;
		public static bool foundPygmyNecklace;
		public static bool foundMP7;
		public static bool foundT1;
		public static bool foundT2;
		public static bool foundT3;
		public static bool foundPHD;
        public static bool downedDOGPumpking;
        public static bool downedDOGIceQueen;
        public static bool downedSandElemental;
        public static bool foundAntiBuffMode;
        public static bool foundFlyingCarpet;
		public static bool foundDivingHelmet;
		public static bool foundPMirror;
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;
		private UserInterface alchemistUserInterfaceT;
        private UserInterface alchemistUserInterfaceH;
        internal HealingUI alchemistUIH;
        private UserInterface alchemistUserInterfaceDC;
        internal DimensionalCasketUI alchemistUIDC;

    

        public override void OnWorldLoad()
        {
            foundAglet = false;
			foundClimbingClaws = false;
			foundAnklet = false;
			foundShoeSpikes = false;
			foundBalloon = false;
			foundHermesBoots = false;
			foundFlippers = false;
			foundFrogLeg = false;
			foundCloud = false;
			foundBlizzard = false;
			foundSandstorm = false;
			foundPuffer = false;
			foundTsunami = false;
			foundWWB = false;
			foundIceSkates = false;
			foundLavaCharm = false;
			foundHorseshoe = false;
			foundCMagnet = false;
			foundPStone = false;
			foundHTFL = false;
			foundAnglerEarring = false;
			foundTackleBox = false;
			foundJFNeck = false;
			foundFlowerBoots = false;
			foundTabi = false;
			foundGoldRing = false;
			foundLuckyCoin = false;
			foundDiscountCard = false;
			foundNeptuneShell = false;
			foundString = false;
			foundGreenCW = false;
			foundYoyoGlove = false;
			foundBlindfold = false;
			foundArmorPolish = false;
			foundVitamins = false;
			foundBezoar = false;
			foundAdhesiveBandage = false;
			foundFastClock = false;
			foundTrifoldMap = false;
			foundMegaphone = false;
			foundNazar = false;
			foundSorcE = false;
			foundWE = false;
			foundRE = false;
			foundSumE = false;
			foundFeralClaw = false;
			foundTitanGlove = false;
			foundMagmaStone = false;
			foundSharkTooth = false;
			foundBlackBelt = false;
			foundMoonCharm = false;
			foundMoonStone = false;
			foundRifleScope = false;
			foundPaladinShield = false;
			foundFrozenTurtleShell = false;
			foundPutridScent = false;
			foundFleshKnuckles = false;
			foundMagicQuiver = false;
			foundCobaltShield = false;
			foundPanicNecklace = false;
			foundCrossNecklace = false;
			foundStarCloak = false;
			foundNecromanticScroll = false;
			foundObsidianRose = false;
			foundShackle = false;
			foundSunStone = false;
			foundHerculesBeetle = false;
			foundPygmyNecklace = false;
			foundMP7 = false;
			foundT1 = false;
			foundT2 = false;
			foundT3 = false;
			foundPHD = false;
			foundAntiBuffMode = false;
			foundFlyingCarpet = false;
			foundDivingHelmet = false;
			foundPMirror = false;
            downedDOGIceQueen = false;
            downedDOGPumpking = false;
            downedSandElemental = false;
            if (!Main.dedServ)
            {
                alchemistUI = new ShopChangeUI();
                alchemistUI.Activate();
                alchemistUserInterface = new UserInterface();
                alchemistUserInterface.SetState(alchemistUI);

                alchemistUIA = new ShopChangeUIA();
                alchemistUIA.Activate();
                alchemistUserInterfaceA = new UserInterface();
                alchemistUserInterfaceA.SetState(alchemistUIA);

                alchemistUIO = new ShopChangeUIO();
                alchemistUIO.Activate();
                alchemistUserInterfaceO = new UserInterface();
                alchemistUserInterfaceO.SetState(alchemistUIO);

                alchemistUIM = new ShopChangeUIM();
                alchemistUIM.Activate();
                alchemistUserInterfaceM = new UserInterface();
                alchemistUserInterfaceM.SetState(alchemistUIM);
                
                alchemistUIH = new HealingUI();
                alchemistUIH.Activate();
                alchemistUserInterfaceH = new UserInterface();
                alchemistUserInterfaceH.SetState(alchemistUIH);

                alchemistUIDC = new DimensionalCasketUI();
                alchemistUIDC.Activate();
                alchemistUserInterfaceDC = new UserInterface();
                alchemistUserInterfaceDC.SetState(alchemistUIDC);
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedDOGPumpking = downed.Contains("DOGPumpking");
            downedDOGIceQueen = downed.Contains("DOGIceQueen");
            downedSandElemental = downed.Contains("SandElemental");
            var found = tag.GetList<string>("found");
            foundAglet = found.Contains("Aglet");
			foundClimbingClaws = found.Contains("ClimbingClaws");
			foundAnklet = found.Contains("Anklet");
			foundShoeSpikes = found.Contains("ShoeSpikes");
			foundBalloon = found.Contains("Balloon");
			foundHermesBoots = found.Contains("HermesBoots");
			foundFlippers = found.Contains("Flippers");
			foundFrogLeg = found.Contains("FrogLeg");
			foundCloud = found.Contains("Cloud");
			foundBlizzard = found.Contains("Blizzard");
			foundSandstorm = found.Contains("Sandstorm");
			foundPuffer = found.Contains("Puffer");
			foundTsunami = found.Contains("Tsunami");
			foundWWB = found.Contains("WWB");
			foundIceSkates = found.Contains("IceSkates");
			foundLavaCharm = found.Contains("LavaCharm");
			foundHorseshoe = found.Contains("Horseshoe");
			foundCMagnet = found.Contains("CMagnet");
			foundPStone = found.Contains("PStone");
			foundHTFL = found.Contains("HTFL");
			foundAnglerEarring = found.Contains("AnglerEarring");
			foundTackleBox = found.Contains("TackleBox");
			foundJFNeck = found.Contains("JFNeck");
			foundFlowerBoots = found.Contains("FlowerBoots");
			foundTabi = found.Contains("Tabi");
			foundGoldRing = found.Contains("GoldRing");
			foundLuckyCoin = found.Contains("LuckyCoin");
			foundDiscountCard = found.Contains("DiscountCard");
			foundNeptuneShell = found.Contains("NeptuneShell");
			foundString = found.Contains("String");
			foundGreenCW = found.Contains("GreenCW");
			foundYoyoGlove = found.Contains("YoyoGlove");
			foundBlindfold = found.Contains("Blindfold");
			foundArmorPolish = found.Contains("ArmorPolish");
			foundVitamins = found.Contains("Vitamins");
			foundBezoar = found.Contains("Bezoar");
			foundAdhesiveBandage = found.Contains("AdhesiveBandage");
			foundFastClock = found.Contains("FastClock");
			foundTrifoldMap = found.Contains("TrifoldMap");
			foundMegaphone = found.Contains("Megaphone");
			foundNazar = found.Contains("Nazar");
			foundSorcE = found.Contains("SorcE");
			foundWE = found.Contains("WE");
			foundRE = found.Contains("RE");
			foundSumE = found.Contains("SumE");
			foundFeralClaw = found.Contains("FeralClaw");
			foundTitanGlove = found.Contains("TitanGlove");
			foundMagmaStone = found.Contains("MagmaStone");
			foundSharkTooth = found.Contains("SharkTooth");
			foundBlackBelt = found.Contains("BlackBelt");
			foundMoonCharm = found.Contains("MoonCharm");
			foundMoonStone = found.Contains("MoonStone");
			foundRifleScope = found.Contains("RifleScope");
			foundPaladinShield = found.Contains("PaladinShield");
			foundFrozenTurtleShell = found.Contains("FrozenTurtleShell");
			foundPutridScent = found.Contains("PutridScent");
			foundFleshKnuckles = found.Contains("FleshKnuckles");
			foundMagicQuiver = found.Contains("MagicQuiver");
			foundCobaltShield = found.Contains("CobaltShield");
			foundPanicNecklace = found.Contains("PanicNecklace");
			foundCrossNecklace = found.Contains("CrossNecklace");
			foundStarCloak = found.Contains("StarCloak");
			foundNecromanticScroll = found.Contains("NecromanticScroll");
			foundObsidianRose = found.Contains("ObsidianRose");
			foundShackle = found.Contains("Shackle");
			foundSunStone = found.Contains("SunStone");
			foundHerculesBeetle = found.Contains("HerculesBeetle");
			foundPygmyNecklace = found.Contains("PygmyNecklace");
			foundMP7 = found.Contains("MP7");
			foundT1 = found.Contains("T1");
			foundT2 = found.Contains("T2");
			foundT3 = found.Contains("T3");
			foundPHD = found.Contains("PHD");
			foundAntiBuffMode = found.Contains("AntiBuffMode");
			foundFlyingCarpet = found.Contains("FlyingCarpet");
			foundDivingHelmet = found.Contains("DivingHelmet");
			foundPMirror = found.Contains("PMirror");
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedDOGPumpking) downed.Add("DOGPumpking");
            if (downedDOGIceQueen) downed.Add("DOGIceQueen");
            if (downedSandElemental) downed.Add("SandElemental");

            tag["downed"] = downed;

            var found = new List<string>();

			if (foundAglet) found.Add("Aglet");
			if (foundClimbingClaws) found.Add("ClimbingClaws");
			if (foundAnklet) found.Add("Anklet");
			if (foundShoeSpikes) found.Add("ShoeSpikes");
			if (foundBalloon) found.Add("Balloon");
			if (foundHermesBoots) found.Add("HermesBoots");
			if (foundFlippers) found.Add("Flippers");
			if (foundFrogLeg) found.Add("FrogLeg");
			if (foundCloud) found.Add("Cloud");
			if (foundBlizzard) found.Add("Blizzard");
			if (foundSandstorm) found.Add("Sandstorm");
			if (foundPuffer) found.Add("Puffer");
			if (foundTsunami) found.Add("Tsunami");
			if (foundWWB) found.Add("WWB");
			if (foundIceSkates) found.Add("IceSkates");
			if (foundLavaCharm) found.Add("LavaCharm");
			if (foundHorseshoe) found.Add("Horseshoe");
			if (foundCMagnet) found.Add("CMagnet");
			if (foundPStone) found.Add("PStone");
			if (foundHTFL) found.Add("HTFL");
			if (foundAnglerEarring) found.Add("AnglerEarring");
			if (foundTackleBox) found.Add("TackleBox");
			if (foundJFNeck) found.Add("JFNeck");
			if (foundFlowerBoots) found.Add("FlowerBoots");
			if (foundTabi) found.Add("Tabi");
			if (foundGoldRing) found.Add("GoldRing");
			if (foundLuckyCoin) found.Add("LuckyCoin");
			if (foundDiscountCard) found.Add("DiscountCard");
			if (foundNeptuneShell) found.Add("NeptuneShell");
			if (foundString) found.Add("String");
			if (foundGreenCW) found.Add("GreenCW");
			if (foundYoyoGlove) found.Add("YoyoGlove");
			if (foundBlindfold) found.Add("Blindfold");
			if (foundArmorPolish) found.Add("ArmorPolish");
			if (foundVitamins) found.Add("Vitamins");
			if (foundBezoar) found.Add("Bezoar");
			if (foundAdhesiveBandage) found.Add("AdhesiveBandage");
			if (foundFastClock) found.Add("FastClock");
			if (foundTrifoldMap) found.Add("TrifoldMap");
			if (foundMegaphone) found.Add("Megaphone");
			if (foundNazar) found.Add("Nazar");
			if (foundSorcE) found.Add("SorcE");
			if (foundWE) found.Add("WE");
			if (foundRE) found.Add("RE");
			if (foundSumE) found.Add("SumE");
			if (foundFeralClaw) found.Add("FeralClaw");
			if (foundTitanGlove) found.Add("TitanGlove");
			if (foundMagmaStone) found.Add("MagmaStone");
			if (foundSharkTooth) found.Add("SharkTooth");
			if (foundBlackBelt) found.Add("BlackBelt");
			if (foundMoonCharm) found.Add("MoonCharm");
			if (foundMoonStone) found.Add("MoonStone");
			if (foundRifleScope) found.Add("RifleScope");
			if (foundPaladinShield) found.Add("PaladinShield");
			if (foundFrozenTurtleShell) found.Add("FrozenTurtleShell");
			if (foundPutridScent) found.Add("PutridScent");
			if (foundFleshKnuckles) found.Add("FleshKnuckles");
			if (foundMagicQuiver) found.Add("MagicQuiver");
			if (foundCobaltShield) found.Add("CobaltShield");
			if (foundPanicNecklace) found.Add("PanicNecklace");
			if (foundCrossNecklace) found.Add("CrossNecklace");
			if (foundStarCloak) found.Add("StarCloak");
			if (foundNecromanticScroll) found.Add("NecromanticScroll");
			if (foundObsidianRose) found.Add("ObsidianRose");
			if (foundShackle) found.Add("Shackle");
			if (foundSunStone) found.Add("SunStone");
			if (foundHerculesBeetle) found.Add("HerculesBeetle");
			if (foundPygmyNecklace) found.Add("PygmyNecklace");
			if (foundMP7) found.Add("MP7");
			if (foundT1) found.Add("T1");
			if (foundT2) found.Add("T2");
			if (foundT3) found.Add("T3");
			if (foundPHD) found.Add("PHD");
			if (foundAntiBuffMode) found.Add("AntiBuffMode");
			if (foundFlyingCarpet) found.Add("FlyingCarpet");
			if (foundDivingHelmet) found.Add("DivingHelmet");
            if (foundPMirror) found.Add("PMirror");

            tag["found"] = found;
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
			flags[0] = foundAglet;
			flags[1] = foundClimbingClaws;
			flags[2] = foundAnklet;
			flags[3] = foundShoeSpikes;
			flags[4] = foundBalloon;
			flags[5] = foundHermesBoots;
			flags[6] = foundFlippers;
			flags[7] = foundFrogLeg;
			writer.Write(flags);
			
			BitsByte flags2 = new BitsByte();
			flags2[0] = foundCloud;
			flags2[1] = foundBlizzard;
			flags2[2] = foundSandstorm;
			flags2[3] = foundPuffer;
			flags2[4] = foundTsunami;
			flags2[5] = foundWWB;
			flags2[6] = foundIceSkates;
			flags2[7] = foundLavaCharm;
			writer.Write(flags2);
			
			BitsByte flags3 = new BitsByte();
			flags3[0] = foundHorseshoe;
			flags3[1] = foundCMagnet;
			flags3[2] = foundPStone;
			flags3[3] = foundHTFL;
			flags3[4] = foundAnglerEarring;
			flags3[5] = foundTackleBox;
			flags3[6] = foundJFNeck;
			flags3[7] = foundFlowerBoots;
			writer.Write(flags3);
			
			BitsByte flags4 = new BitsByte();
			flags4[0] = foundTabi;
			flags4[1] = foundGoldRing;
			flags4[2] = foundLuckyCoin;
			flags4[3] = foundDiscountCard;
			flags4[4] = foundNeptuneShell;
			flags4[5] = foundString;
			flags4[6] = foundGreenCW;
			flags4[7] = foundYoyoGlove;
			writer.Write(flags4);
			
			BitsByte flags5 = new BitsByte();
			flags5[0] = foundArmorPolish;
			flags5[1] = foundVitamins;
			flags5[2] = foundBezoar;
			flags5[3] = foundAdhesiveBandage;
			flags5[4] = foundFastClock;
			flags5[5] = foundTrifoldMap;
			flags5[6] = foundMegaphone;
			flags5[7] = foundNazar;
			writer.Write(flags5);
			
			BitsByte flags6 = new BitsByte();
			flags6[0] = foundBlindfold;
			flags6[1] = foundSorcE;
			flags6[2] = foundWE;
			flags6[3] = foundRE;
			flags6[4] = foundSumE;
			flags6[5] = foundFeralClaw;
			flags6[6] = foundTitanGlove;
			flags6[7] = foundMagmaStone;
			writer.Write(flags6);
			
			BitsByte flags7 = new BitsByte();
			flags7[0] = foundSharkTooth;
			flags7[1] = foundBlackBelt;
			flags7[2] = foundMoonCharm;
			flags7[3] = foundMoonStone;
			flags7[4] = foundRifleScope;
			flags7[5] = foundPaladinShield;
			flags7[6] = foundFrozenTurtleShell;
			flags7[7] = foundPutridScent;
			writer.Write(flags7);
			
			BitsByte flags8 = new BitsByte();
			flags8[0] = foundFleshKnuckles;
			flags8[1] = foundMagicQuiver;
			flags8[2] = foundCobaltShield;
			flags8[3] = foundPanicNecklace;
			flags8[4] = foundCrossNecklace;
			flags8[5] = foundStarCloak;
			flags8[6] = foundNecromanticScroll;
			flags8[7] = foundObsidianRose;
			writer.Write(flags8);
			
			BitsByte flags9 = new BitsByte();
			flags9[0] = foundShackle;
			flags9[1] = foundSunStone;
			flags9[2] = foundHerculesBeetle;
			flags9[3] = foundPygmyNecklace;
			flags9[4] = foundMP7;
			flags9[5] = foundT1;
			flags9[6] = foundT2;
			flags9[7] = foundT3;
			writer.Write(flags9);

            BitsByte flags10 = new BitsByte();
			flags10[0] = foundPHD;
			flags10[1] = foundAntiBuffMode;
			flags10[2] = foundFlyingCarpet;
			flags10[3] = foundDivingHelmet;
			flags10[4] = foundPMirror;
			writer.Write(flags10);

            BitsByte flags11 = new BitsByte();
            flags11[0] = downedDOGPumpking;
            flags11[1] = downedDOGIceQueen;
            flags11[2] = downedSandElemental;
            writer.Write(flags11);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
			foundAglet = flags[0];
			foundClimbingClaws = flags[1];
			foundAnklet = flags[2];
			foundShoeSpikes = flags[3];
			foundBalloon = flags[4];
			foundHermesBoots = flags[5];
			foundFlippers = flags[6];
			foundFrogLeg = flags[7];
			
			BitsByte flags2 = reader.ReadByte();
			foundCloud = flags2[0];
			foundBlizzard = flags2[1];
			foundSandstorm = flags2[2];
			foundPuffer = flags2[3];
			foundTsunami = flags2[4];
			foundWWB = flags2[5];
			foundIceSkates = flags2[6];
			foundLavaCharm = flags2[7];
			
			BitsByte flags3 = reader.ReadByte();
			foundHorseshoe = flags3[0];
			foundCMagnet = flags3[1];
			foundPStone = flags3[2];
			foundHTFL = flags3[3];
			foundAnglerEarring = flags3[4] ;
			foundTackleBox = flags3[5];
			foundJFNeck = flags3[6];
			foundFlowerBoots = flags3[7];
			
			BitsByte flags4 = reader.ReadByte();
			foundTabi = flags4[0];
			foundGoldRing = flags4[1];
			foundLuckyCoin = flags4[2];
			foundDiscountCard = flags4[3];
			foundNeptuneShell = flags4[4];
			foundString = flags4[5];
			foundGreenCW = flags4[6];
			foundYoyoGlove = flags4[7];
			
			BitsByte flags5 = reader.ReadByte();
			foundArmorPolish = flags5[0];
			foundVitamins = flags5[1];
			foundBezoar = flags5[2];
			foundAdhesiveBandage = flags5[3];
			foundFastClock = flags5[4];
			foundTrifoldMap = flags5[5];
			foundMegaphone = flags5[6];
			foundNazar = flags5[7];
			
			BitsByte flags6 = reader.ReadByte();
			foundBlindfold = flags6[0];
			foundSorcE = flags6[1];
			foundWE = flags6[2];
			foundRE = flags6[3];
			foundSumE = flags6[4];
			foundFeralClaw = flags6[5];
			foundTitanGlove = flags6[6];
			foundMagmaStone = flags6[7];
			
			BitsByte flags7 = reader.ReadByte();
			foundSharkTooth = flags7[0];
			foundBlackBelt = flags7[1];
			foundMoonCharm = flags7[2];
			foundMoonStone = flags7[3];
			foundRifleScope = flags7[4];
			foundPaladinShield = flags7[5];
			foundFrozenTurtleShell = flags7[6];
			foundPutridScent = flags7[7];
			
			BitsByte flags8 = reader.ReadByte();
			foundFleshKnuckles = flags8[0];
			foundMagicQuiver = flags8[1];
			foundCobaltShield = flags8[2];
			foundPanicNecklace = flags8[3];
			foundCrossNecklace = flags8[4];
			foundStarCloak = flags8[5];
			foundNecromanticScroll = flags8[6];
			foundObsidianRose = flags8[7];
			
			BitsByte flags9 = reader.ReadByte();
			foundShackle = flags9[0];
			foundSunStone = flags9[1];
			foundHerculesBeetle = flags9[2];
			foundPygmyNecklace = flags9[3];
			foundMP7 = flags9[4];
			foundT1 = flags9[5];
			foundT2 = flags9[6];
			foundT3 = flags9[7];

            BitsByte flags10 = reader.ReadByte();
			foundPHD = flags10[0];
			foundAntiBuffMode = flags10[1];
			foundFlyingCarpet = flags10[2];
			foundDivingHelmet = flags10[3];
			foundDivingHelmet = flags10[4];

            BitsByte flags11 = reader.ReadByte();
            downedDOGPumpking = flags11[0];
            downedDOGIceQueen = flags11[1];
            downedSandElemental = flags11[2];
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "AlchemistNPCRebornAgain: Shop Selector",
                    delegate
                    {
                        if (ShopChangeUI.visible)
                        {
                            alchemistUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexA = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexA != -1)
            {
                layers.Insert(MouseTextIndexA, new LegacyGameInterfaceLayer(
                    "AlchemistNPCRebornAgain: Shop Selector A",
                    delegate
                    {
                        if (ShopChangeUIA.visible)
                        {
                            alchemistUIA.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexO = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexO != -1)
            {
                layers.Insert(MouseTextIndexO, new LegacyGameInterfaceLayer(
                    "AlchemistNPCRebornAgain: Shop Selector O",
                    delegate
                    {
                        if (ShopChangeUIO.visible)
                        {
                            alchemistUIO.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexM = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexM != -1)
            {
                layers.Insert(MouseTextIndexM, new LegacyGameInterfaceLayer(
                    "AlchemistNPCRebornAgain: Shop Selector M",
                    delegate
                    {
                        if (ShopChangeUIM.visible)
                        {
                            alchemistUIM.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            
            int MouseTextIndexH = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexH != -1)
            {
                layers.Insert(MouseTextIndexH, new LegacyGameInterfaceLayer(
                    "AlchemistNPCRebornAgain: Healing UI",
                    delegate
                    {
                        if (HealingUI.visible)
                        {
                            alchemistUIH.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
			
            //int MouseTextIndexDC = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            //if (MouseTextIndexDC != -1)
            //{
            //    layers.Insert(MouseTextIndexDC, new LegacyGameInterfaceLayer(
            //        "AlchemistNPC: Dimensional Casket UI",
            //        delegate
            //        {
            //            if (DimensionalCasketUI.visible)
            //            {
            //                alchemistUIDC.Draw(Main.spriteBatch);
            //            }
            //            return true;
            //        },
            //        InterfaceScaleType.UI)
            //    );
            //}
			int LocatorArrowIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (LocatorArrowIndex != -1)
            {
                layers.Insert(LocatorArrowIndex, new LegacyGameInterfaceLayer(
                    "AlchemistNPCRebornAgain: Locator Arrow",
                    delegate
                    {
                        Player player = Main.LocalPlayer;
                        if (player.accCritterGuide && AlchemistNPCRebornAgain.modConfiguration.LifeformAnalyzer)
                        {
                            for (int v = 0; v < 200; ++v)
                            {
                                NPC npc = Main.npc[v];
                                if (npc.active && npc.rarity >= 1 && !AlchemistNPCRebornAgain.modConfiguration.DisabledLocatorNpcs.Contains(new NPCDefinition(npc.type)))
                                {
                                    // Adapted from Census mod
                                    Vector2 playerCenter = Main.LocalPlayer.Center + new Vector2(0, Main.LocalPlayer.gfxOffY);
                                    var vector = npc.Center - playerCenter;
                                    var distance = vector.Length();
                                    if (distance > 40 && distance <= AlchemistNPCRebornAgain.modConfiguration.LocatorRange)
                                    {
                                        var offset = Vector2.Normalize(vector) * Math.Min(70, distance - 20);
                                        float rotation = vector.ToRotation() + (float)(Math.PI / 2);
                                        var drawPosition = playerCenter - Main.screenPosition + offset;
                                        float fade = Math.Min(1f, (distance - 20) / 70);
											Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Projectiles/LocatorProjectile").Value, drawPosition, null, Color.White * fade, rotation, TextureAssets.Cursors[1].Size() / 2, Vector2.One, SpriteEffects.None, 0);
                                    }
                                }
                            }
                        }
                        return true;
                    }, InterfaceScaleType.Game)
                );
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (alchemistUserInterface != null && ShopChangeUI.visible)
            {
                alchemistUserInterface.Update(gameTime);
            }

            if (alchemistUserInterfaceA != null && ShopChangeUIA.visible)
            {
                alchemistUserInterfaceA.Update(gameTime);
            }

            if (alchemistUserInterfaceO != null && ShopChangeUIO.visible)
            {
                alchemistUserInterfaceO.Update(gameTime);
            }

            if (alchemistUserInterfaceM != null && ShopChangeUIM.visible)
            {
                alchemistUserInterfaceM.Update(gameTime);
            }

            if (alchemistUserInterfaceH != null && HealingUI.visible)
            {
                alchemistUserInterfaceH.Update(gameTime);
            }

            //if (alchemistUserInterfaceDC != null && DimensionalCasketUI.visible)
            //{
            //    alchemistUserInterfaceDC.Update(gameTime);
            //}
        }

        public override void PostUpdateWorld()
		{
			Player player = Main.player[Main.myPlayer];
			if (!Main.dayTime && Main.time == 32400.0 && Main.bloodMoon && Main.rand.NextBool(5))
			{
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Something is falling from the sky...", 200, 150, 255);
				else ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Something is falling from the sky..."), new Color(200, 150, 255)); 
				
				float X = player.position.X + Main.rand.Next(-1200, 1200);
				float Y = player.position.Y - Main.rand.Next(500, 800);
				float num1 = (float) (player.position.X + (double) (player.width / 2) - X);
				float num2 = (float) (player.position.Y + (double) (player.height / 2) - Y);
				float num3 = num1 + (float) Main.rand.Next(-100, 101);
				float num4 = 23f / (float) Math.Sqrt((double) num3 * (double) num3 + (double) num2 * (double) num2);
				float SpeedX = (num3 * num4);
				float SpeedY = num2 * num4;
				int index2 = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), X, Y, SpeedX * 1.5f, SpeedY * Main.rand.NextFloat(0.8f,1.2f), Mod.Find<ModProjectile>("SymbioteMeteor").Type, 10000, 8f, player.whoAmI, 0f, 0f);
			}
		}
    }
}
