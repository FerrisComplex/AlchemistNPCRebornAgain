using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.WorldBuilding;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using AlchemistNPCRebornAgain.ExternalHelpers;
using AlchemistNPCRebornAgain.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    [JITWhenModsEnabled("Redemption")]
    public class Operator : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public static bool Shop5 = false;
        public static bool Shop6 = false;
        public const string MaterialShop = "Materials";
        public const string ModMaterialShop = "ModMaterials";
        public const string VanillaBagsShop = "VanillaBags";
        public const string Bags1Shop = "ModBags1";
        public const string Bags2Shop = "ModBags2";
        public const string Bags3Shop = "ModBags3";

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Operator"; }
        }
        //Possibly Removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Operator";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -6;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Cyborg, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Steampunker, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.Clothier, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCRebornAgain.Bestiary.Operator")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 50;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Steampunker;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) /* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.downedBoss2 && AlchemistNPCRebornAgain.modConfiguration.OperatorSpawn)
            {
                return true;
            }

            return false;
        }

        public override List<string> SetNPCNameList()
        {
            string Angela = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Angela");
            string Carmen = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Carmen");

            return new List<string>()
            {
                Angela,
                Carmen
            };
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 20;
            }

            if (Main.hardMode && !NPC.downedMoonlord)
            {
                damage = 75;
            }

            if (NPC.downedMoonlord)
            {
                damage = 500;
            }

            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            attackDelay = 10;
            if (!Main.hardMode)
            {
                projType = 14;
            }

            if (Main.hardMode && !NPC.downedMoonlord)
            {
                attackDelay = 10;
                projType = 279;
            }

            if (NPC.downedMoonlord)
            {
                attackDelay = 4;
                projType = 638;
            }
        }

        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset) /* tModPorter Note: closeness is now horizontalHoldoutOffset, use 'horizontalHoldoutOffset = Main.DrawPlayerItemPos(1f, itemtype) - originalClosenessValue' to adjust to the change. See docs for how to use hook with an item type. */ //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            horizontalHoldoutOffset = 20;
            if (!Main.hardMode)
            {
                item = TextureAssets.Item[ItemID.FlintlockPistol].Value;
            }

            if (Main.hardMode && !NPC.downedMoonlord)
            {
                item = TextureAssets.Item[ItemID.Shotgun].Value;
            }

            if (NPC.downedMoonlord)
            {
                item = TextureAssets.Item[ItemID.VortexBeater].Value;
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
        }


        public override string GetChat()
        {
            //npc chat
            string EntryO1 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO1");
            string EntryO2 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO2");
            string EntryO3 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO3");
            string EntryO4 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO4");
            string EntryO5 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO5");
            string EntryO6 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO6");
            string EntryO7 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO7");
            string EntryO8 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO8");
            string EntryO9 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO9");
            string EntryO10 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO10");
            string EntryO11 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO11");
            string EntryO12 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO12");
            string EntryO13 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO13");
            string EntryO14 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO14");
            string EntryO15 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO15");
            string EntryO16 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO16");
            string EntryO17 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO17");
            string EntryO18 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO18");
            string EntryO19 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO19");
            string EntryO20 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO20");
            string EntryO21 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO21");
            string EntryO22 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO22");
            string EntryO23 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO23");
            string EntryO24 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO24");
            string EntryO25 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO25");
            string EntryO26 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO26");
            string EntryO27 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO27");
            string EntryO28 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO28");
            string EntryO29 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO29");
            string EntryO30 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO30");
            string EntryO31 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO31");
            string EntryO32 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO32");
            string EntryO33 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO33");
            string EntryO34 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO34");
            string EntryO35 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO35");
            string EntryO36 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryO36");

            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return EntryO14;
                    case 1:
                        return EntryO15;
                    case 2:
                        return EntryO16;
                }
            }

            if (Main.invasionType == 1)
            {
                return EntryO11;
            }

            if (Main.invasionType == 3)
            {
                return EntryO12;
            }

            if (Main.invasionType == 4)
            {
                return EntryO13;
            }

            if (Main.rand.NextBool(5))
            {
                if (!WorldGen.crimson)
                {
                    return EntryO5;
                }

                if (WorldGen.crimson)
                {
                    return EntryO8;
                }
            }

            if (Calamity != null && NPC.downedBoss3)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO17;
                }
            }

            if (NPC.downedPlantBoss)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO19;
                }
            }

            if (NPC.downedGolemBoss)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO20;
                }
            }

            if (Calamity != null && NPC.downedMoonlord)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO18;
                }
            }

            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ThoriumMod != null)
            {
                if (Main.rand.Next(6) == 0)
                {
                    return EntryO2;

                }
            }
            if (ThoriumMod != null && Main.hardMode)
            {
                if (Main.rand.Next(6) == 0)
                {
                return EntryO6;
                }
            }
            */
            if (Main.rand.NextBool(5) && Main.hardMode)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return EntryO9;
                    case 1:
                        return EntryO10;
                }
            }

            if (Main.rand.NextBool(5) && NPC.downedQueenBee)
            {
                return EntryO21;
            }

            if (Calamity != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "plaguebringer goliath"))
                {
                    return EntryO22;
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "cryogen"))
                {
                    return EntryO25;
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "providence"))
                {
                    return EntryO28;
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "ravager"))
                {
                    return EntryO29;
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "bumblebirb"))
                {
                    return EntryO30;
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "dog"))
                {
                    return EntryO31;
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "supreme calamitas"))
                {
                    return EntryO33;
                }
            }

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod) && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && (bool)ThoriumMod.Call("GetDownedBoss", "FallenBeholder"))
                {
                    return EntryO23;
                }

                if (Main.rand.NextBool(5) && (bool)ThoriumMod.Call("GetDownedBoss", "StarScouter"))
                {
                    return EntryO24;
                }
            }

            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("SacredTools") != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && SacredToolsDownedAbbadon)
                {
                    return EntryO32;
                }
            }

            if (ModLoader.GetMod("SpiritMod") != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && SpiritModDownedStarplateRaider)
                {
                    return EntryO26;
                }
                if (Main.rand.NextBool(5) && SpiritModDownedOverseer)
                {
                    return EntryO27;
                }
            }
            */
            switch (Main.rand.Next(6))
            {
                case 0:
                    return EntryO1;
                case 1:
                    return EntryO3;
                case 2:
                    return EntryO4;
                case 3:
                    return EntryO34;
                case 4:
                    return EntryO35;
                default:
                    return EntryO7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string BossDropsShop = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BossDropsShop");
            string BossDropsModsShop = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BossDropsModsShop");
            string VanillaTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.VanillaTreasureBagsShop");
            string ModdedTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ModdedTreasureBagsShop");
            string ModdedTreasureBagsShop2 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ModdedTreasureBagsShop2");
            string ModdedTreasureBagsShop3 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ModdedTreasureBagsShop3");
            string ShopChanger = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ShopChanger");
            button = BossDropsShop;
            if (!Main.expertMode)
            {
                button2 = BossDropsModsShop;
            }

            if (Main.expertMode)
            {
                button2 = ShopChanger;
            }

            if (Shop1)
            {
                button = BossDropsShop;
            }

            if (Shop2)
            {
                button = BossDropsModsShop;
            }

            if (Shop3)
            {
                button = VanillaTreasureBagsShop;
            }

            if (Shop4)
            {
                button = ModdedTreasureBagsShop;
            }

            if (Shop5)
            {
                button = ModdedTreasureBagsShop2;
            }

            if (Shop6)
            {
                button = ModdedTreasureBagsShop3;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                if (!Main.expertMode)
                {
                    Shop1 = true;
                    Shop2 = false;
                    Shop3 = false;
                    Shop4 = false;
                    Shop5 = false;
                    Shop6 = false;
                    shopName = MaterialShop;
                }

                if (Main.expertMode)
                {
                    shopName = ShopChangeUIO.Shop;
                    ShopChangeUIO.visible = false;
                }
            }
            else
            {
                if (!Main.expertMode)
                {
                    Shop2 = true;
                    Shop1 = false;
                    Shop3 = false;
                    Shop4 = false;
                    Shop5 = false;
                    Shop6 = false;
                    shopName = ModMaterialShop;
                }

                if (Main.expertMode)
                {
                    if (!ShopChangeUIO.visible) ShopChangeUIO.timeStart = Main.GameUpdateCount;
                    ShopChangeUIO.visible = true;
                }
            }
        }
        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        public bool ThoriumModDownedGTBird
        {
            get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
        public bool ThoriumModDownedQueenJelly
        {
            get { return ThoriumMod.ThoriumWorld.downedJelly; }
        }
        public bool ThoriumModDownedViscount
        {
            get { return ThoriumMod.ThoriumWorld.downedBat; }
        }
        public bool ThoriumModDownedStorm
        {
            get { return ThoriumMod.ThoriumWorld.downedStorm; }
        }
        public bool ThoriumModDownedChampion
        {
            get { return ThoriumMod.ThoriumWorld.downedChampion; }
        }
        public bool ThoriumModDownedStarScout
        {
            get { return ThoriumMod.ThoriumWorld.downedScout; }
        }
        public bool ThoriumModDownedBoreanStrider
        {
            get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }
        public bool ThoriumModDownedFallenBeholder
        {
            get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        public bool ThoriumModDownedLich
        {
            get { return ThoriumMod.ThoriumWorld.downedLich; }
        }
        public bool ThoriumModDownedAbyssion
        {
            get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }
        public bool ThoriumModDownedRagnarok
        {
            get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }

        public bool SacredToolsDownedDecree
        {
            get { return SacredTools.ModdedWorld.downedDecree; }
        }
        public bool SacredToolsDownedPumpkin
        {
            get { return SacredTools.ModdedWorld.downedPumpboi; }
        }
        public bool SacredToolsDownedHarpyPreHM
        {
            get { return SacredTools.ModdedWorld.downedHarpy; }
        }
        public bool SacredToolsDownedAraneas
        {
            get { return SacredTools.ModdedWorld.downedAraneas; }
        }
        public bool SacredToolsDownedHarpyHM
        {
            get { return SacredTools.ModdedWorld.downedRaynare; }
        }
        public bool SacredToolsDownedPrimordia
        {
            get { return SacredTools.ModdedWorld.downedPrimordia; }
        }
        public bool SacredToolsDownedAbbadon
        {
            get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }
        public bool SacredToolsDownedAraghur
        {
            get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }
        public bool SacredToolsDownedLunarians
        {
            get { return SacredTools.ModdedWorld.downedLunarians; }
        }
        public bool SacredToolsDownedChallenger
        {
            get { return SacredTools.ModdedWorld.downedChallenger; }
        }

        public bool SpiritModDownedScarabeus
        {
            get { return SpiritMod.MyWorld.downedScarabeus; }
        }
        public bool SpiritModDownedBane
        {
            get { return SpiritMod.MyWorld.downedReachBoss; }
        }
        public bool SpiritModDownedFlier
        {
            get { return SpiritMod.MyWorld.downedAncientFlier; }
        }
        public bool SpiritModDownedStarplateRaider
        {
            get { return SpiritMod.MyWorld.downedRaider; }
        }
        public bool SpiritModDownedInfernon
        {
            get { return SpiritMod.MyWorld.downedInfernon; }
        }
        public bool SpiritModDownedDusking
        {
            get { return SpiritMod.MyWorld.downedDusking; }
        }
        public bool SpiritModDownedEtherialUmbra
        {
            get { return SpiritMod.MyWorld.downedSpiritCore; }
        }
        public bool SpiritModDownedIlluminantMaster
        {
            get { return SpiritMod.MyWorld.downedIlluminantMaster; }
        }
        public bool SpiritModDownedAtlas
        {
            get { return SpiritMod.MyWorld.downedAtlas; }
        }
        public bool SpiritModDownedOverseer
        {
            get { return SpiritMod.MyWorld.downedOverseer; }
        }

        public bool EnigmaDownedSharkron
        {
            get { return Laugicality.LaugicalityWorld.downedDuneSharkron; }
        }
        public bool EnigmaDownedHypothema
        {
            get { return Laugicality.LaugicalityWorld.downedHypothema; }
        }
        public bool EnigmaDownedRagnar
        {
            get { return Laugicality.LaugicalityWorld.downedRagnar; }
        }
        public bool EnigmaDownedAnDio
        {
            get { return Laugicality.LaugicalityWorld.downedAnDio; }
        }
        public bool EnigmaDownedAnnihilator
        {
            get { return Laugicality.LaugicalityWorld.downedAnnihilator; }
        }
        public bool EnigmaDownedSlybertron
        {
            get { return Laugicality.LaugicalityWorld.downedSlybertron; }
        }
        public bool EnigmaDownedSteamTrain
        {
            get { return Laugicality.LaugicalityWorld.downedSteamTrain; }
        }
        public bool EnigmaDownedEtheria
        {
            get { return Laugicality.LaugicalityWorld.downedTrueEtheria; }
        }

        public bool PinkymodDownedST
        {
            get { return pinkymod.Global.Pinkyworld.downedSunlightTrader; }
        }
        public bool PinkymodDownedMS
        {
            get { return pinkymod.Global.Pinkyworld.downedMythrilSlime; }
        }
        public bool PinkymodDownedVD
        {
            get { return pinkymod.Global.Pinkyworld.downedValdaris; }
        }
        public bool PinkymodDownedAD
        {
            get { return pinkymod.Global.Pinkyworld.downedAbyssmalDuo; }
        }

        public bool AAModDownedMonarch
        {
            get { return AAMod.AAWorld.downedMonarch; }
        }
        public bool AAModDownedGrips
        {
            get { return AAMod.AAWorld.downedGrips; }
        }
        public bool AAModDownedTruffleToad
        {
            get { return AAMod.AAWorld.downedToad; }
        }
        public bool AAModDownedBrood
        {
            get { return AAMod.AAWorld.downedBrood; }
        }
        public bool AAModDownedHydra
        {
            get { return AAMod.AAWorld.downedHydra; }
        }
        public bool AAModDownedSerpent
        {
            get { return AAMod.AAWorld.downedSerpent; }
        }
        public bool AAModDownedDjinn
        {
            get { return AAMod.AAWorld.downedDjinn; }
        }
        public bool AAModDownedEquinox
        {
            get { return AAMod.AAWorld.downedEquinox; }
        }
        public bool AAModDownedSisters
        {
            get { return AAMod.AAWorld.downedSisters; }
        }
        public bool AAModDownedYamata
        {
            get { return AAMod.AAWorld.downedYamata; }
        }
        public bool AAModDownedAkuma
        {
            get { return AAMod.AAWorld.downedAkuma; }
        }
        public bool AAModDownedZero
        {
            get { return AAMod.AAWorld.downedZero; }
        }
        public bool AAModDownedShen
        {
            get { return AAMod.AAWorld.downedZero; }
        }

        public bool EADownedWasteland
        {
            get { return ElementsAwoken.MyWorld.downedWasteland; }
        }
        public bool EADownedWyrm
        {
            get { return ElementsAwoken.MyWorld.downedAncientWyrm; }
        }
        public bool EADownedInfernace
        {
            get { return ElementsAwoken.MyWorld.downedInfernace; }
        }
        public bool EADownedScourgeFighter
        {
            get { return ElementsAwoken.MyWorld.downedScourgeFighter; }
        }
        public bool EADownedRegaroth
        {
            get { return ElementsAwoken.MyWorld.downedRegaroth; }
        }
        public bool EADownedObsidious
        {
            get { return ElementsAwoken.MyWorld.downedObsidious; }
        }
        public bool EADownedPermafrost
        {
            get { return ElementsAwoken.MyWorld.downedPermafrost; }
        }
        public bool EADownedAqueous
        {
            get { return ElementsAwoken.MyWorld.downedAqueous; }
        }
        public bool EADownedGuardian
        {
            get { return ElementsAwoken.MyWorld.downedGuardian; }
        }
        public bool EADownedVolcanox
        {
            get { return ElementsAwoken.MyWorld.downedVolcanox; }
        }
        public bool EADownedVoidLevi
        {
            get { return ElementsAwoken.MyWorld.downedVoidLeviathan; }
        }
        public bool EADownedAzana
        {
            get { return ElementsAwoken.MyWorld.downedAzana; }
        }
        public bool EADownedAncients
        {
            get { return ElementsAwoken.MyWorld.downedAncients; }
        }
        */

        //[]
        //public bool ReDownedChicken
        //{
        //    get { return Redemption.Globals.RedeBossDowned.downedKingChicken; }
        //}

        /*[JITWhenModsEnabled("ShardsOfAtheria")]
        public static class ShardsConditions
        {
            public static bool DownedNova
            {
                get { return ShardsOfAtheria.Systems.ShardsDownedSystem.downedValkyrie; }
            }
        }*/

        // Possibly redundant with ModGlobalNPC
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npcLoot);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Summoning.APMC>(), 1));
        }

        public override void AddShops()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            ModLoader.TryGetMod("Redemption", out Mod Redemption);
            //ModLoader.TryGetMod("ShardsOfAtheria", out Mod Atheria);

            var shop = new NPCShop(Type, MaterialShop)
                .Add(new Item(ItemID.Lens) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.DemoniteOre) { shopCustomPrice = 1500 })
                .Add(new Item(ItemID.ShadowScale) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.RottenChunk) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.CrimtaneOre) { shopCustomPrice = 1500 })
                .Add(new Item(ItemID.TissueSample) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.Vertebrae) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.BeeWax) { shopCustomPrice = 10000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.Stinger) { shopCustomPrice = 75000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.JungleSpores) { shopCustomPrice = 10000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.Vine) { shopCustomPrice = 15000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.Feather) { shopCustomPrice = 25000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.SharkFin) { shopCustomPrice = 25000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.Bone) { shopCustomPrice = 10000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.AncientBattleArmorMaterial) { shopCustomPrice = 200000 }, new Condition("", () => AlchemistNPCRebornWorld.downedSandElemental))
                .Add(new Item(ItemID.SoulofLight) { shopCustomPrice = 15000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.SoulofNight) { shopCustomPrice = 15000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.SoulofFlight) { shopCustomPrice = 25000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.SoulofMight) { shopCustomPrice = 30000 }, new Condition("", () => NPC.downedMechBoss1))
                .Add(new Item(ItemID.SoulofSight) { shopCustomPrice = 30000 }, new Condition("", () => NPC.downedMechBoss2))
                .Add(new Item(ItemID.BlackLens) { shopCustomPrice = 200000 }, new Condition("", () => NPC.downedMechBoss2))
                .Add(new Item(ItemID.SoulofFright) { shopCustomPrice = 30000 }, new Condition("", () => NPC.downedMechBoss3))
                .Add(new Item(ItemID.HallowedBar) { shopCustomPrice = 20000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.Ectoplasm) { shopCustomPrice = 35000 }, new Condition("", () => NPC.downedPlantBoss))
                .Add(new Item(ItemID.FragmentSolar) { shopCustomPrice = 100000 }, new Condition("", () => NPC.downedMoonlord))
                .Add(new Item(ItemID.FragmentNebula) { shopCustomPrice = 100000 }, new Condition("", () => NPC.downedMoonlord))
                .Add(new Item(ItemID.FragmentVortex) { shopCustomPrice = 100000 }, new Condition("", () => NPC.downedMoonlord))
                .Add(new Item(ItemID.FragmentStardust) { shopCustomPrice = 100000 }, new Condition("", () => NPC.downedMoonlord));
            shop.Register();
            shop = new NPCShop(Type, ModMaterialShop)
                .Add(new Item(ModContent.ItemType<Items.Misc.GlobalTeleporter>()), new Condition("", () => Main.hardMode))
                .Add(new Item(ModContent.ItemType<Items.Misc.WorldControlUnit>()) { shopCustomPrice = 3000000 }, new Condition("", () => Main.hardMode))
                .Add(new Item(ModContent.ItemType<Items.Misc.GlobalTeleporterUp>()), new Condition("", () => NPC.downedMoonlord))
                .AddModItemToShop(ThoriumMod, "Petal", 10000)
                .AddModItemToShop(ThoriumMod, "BrokenHeroFragment", 250000, () => NPC.downedGolemBoss)
                .AddModItemToShop(ThoriumMod, "WhiteDwarfFragment", 100000, () => NPC.downedMoonlord)
                .AddModItemToShop(ThoriumMod, "CometFragment", 100000, () => NPC.downedMoonlord)
                .AddModItemToShop(ThoriumMod, "CelestialFragment", 100000, () => NPC.downedMoonlord)
                .AddModItemToShop(Calamity, "TrueShadowScale", 20000, () => (bool)Calamity.Call("Downed", "hive mind"))
                .AddModItemToShop(Calamity, "BloodSample", 20000, () => (bool)Calamity.Call("Downed", "perforators"))
                .AddModItemToShop(Calamity, "EbonianGel", 25000, () => (bool)Calamity.Call("Downed", "slime god"))
                .AddModItemToShop(Calamity, "PurifiedGel", 30000, () => (bool)Calamity.Call("Downed", "slime god"))
                .AddModItemToShop(Calamity, "UnholyCore", 100000, () => (bool)Calamity.Call("Downed", "calamitas doppelganger"))
                .AddModItemToShop(Calamity, "EssenceofEleum", 25000, () => NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "cryogen"))
                .AddModItemToShop(Calamity, "EssenceofCinder", 25000, () => NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "aquatic scourge"))
                .AddModItemToShop(Calamity, "EssenceofChaos", 25000, () => NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "brimstone elemental"))
                //.addModItemToShop(Calamity, "Tenebris", 30000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "Lumenite", 50000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "DepthCells", 30000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "AstralJelly", 50000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                .AddModItemToShop(Calamity, "Stardust", 10000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                .AddModItemToShop(Calamity, "LivingShard", 30000, () => (bool)Calamity.Call("Downed", "leviathan"))
                .AddModItemToShop(Calamity, "SolarVeil", 50000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "BarofLife", 100000, () => (bool)Calamity.Call("Downed", "ravager"))
                .AddModItemToShop(Calamity, "MeldBlob", 10000, () => (bool)Calamity.Call("Downed", "astrum deus"))
                .AddModItemToShop(Calamity, "UnholyEssence", 50000, () => (bool)Calamity.Call("Downed", "profaned guardians"))
                .AddModItemToShop(Calamity, "BloodOrb", 50000, () => (bool)Calamity.Call("Downed", "polterghast"))
                .AddModItemToShop(Calamity, "Phantoplasm", 100000, () => (bool)Calamity.Call("Downed", "polterghast"))
                .AddModItemToShop(Calamity, "NightmareFuel", 120000, () => (bool)Calamity.Call("Downed", "dog") && AlchemistNPCRebornWorld.downedDOGPumpking)
                .AddModItemToShop(Calamity, "EndothermicEnergy", 120000, () => (bool)Calamity.Call("Downed", "dog") && AlchemistNPCRebornWorld.downedDOGIceQueen)
                .AddModItemToShop(Calamity, "DarksunFragment", 150000, () => (bool)Calamity.Call("Downed", "buffed mothron"));
            //if (ModLoader.GetMod("SpiritMod") != null)
            //{
            //    .addModItemToShop(SpiritMod, "BrokenParts", 500000, NPC.downedGolemBoss);
            //    .addModItemToShop(SpiritMod, "BrokenStaff", 500000, NPC.downedGolemBoss);
            //}
            //if (ModLoader.GetMod("LithosArmory") != null)
            //{
            //    .addModItemToShop(LithosArmory, "BrokenHeroFlail", 500000, NPC.downedGolemBoss);
            //    .addModItemToShop(LithosArmory, "BrokenHeroGreatbow", 500000, NPC.downedGolemBoss);
            //    .addModItemToShop(LithosArmory, "BrokenHeroShotgun", 500000, NPC.downedGolemBoss);
            //    .addModItemToShop(LithosArmory, "BrokenHeroSling", 500000, NPC.downedGolemBoss);
            //    .addModItemToShop(LithosArmory, "BrokenHeroSpear", 500000, NPC.downedGolemBoss);
            //    .addModItemToShop(LithosArmory, "BrokenHeroWand", 500000, NPC.downedGolemBoss);
            //}
            /*.AddModItemToShop(Atheria, "EmptyNeedle", 500)
            .AddModItemToShop(Atheria, "SoulOfDaylight", 1000)
            .AddModItemToShop(Atheria, "SoulOfTwilight", 1000)
            .AddModItemToShop(Atheria, "SoulOfSpite", 1000)
            .AddModItemToShop(Atheria, "AreusShard", 10000, Condition.DownedEowOrBoc)
            .AddModItemToShop(Atheria, "HardlightPrism", 15000, () => ShardsConditions.DownedNova)
            .AddModItemToShop(Atheria, "BrokenHeroGun", 45000, Condition.DownedGolem)
            .AddModItemToShop(Atheria, "FragmentEntropy", 180000, Condition.DownedMoonLord)
            .AddModItemToShop(Atheria, "MemoryFragment", 10000, Condition.DownedMoonLord);*/
            shop.Register();

            shop = new NPCShop(Type, VanillaBagsShop)
                .Add(new Item(ModContent.ItemType<Items.Notes.InformatingNote>()) { shopCustomPrice = 30000 },
                    new Condition("", () => !NPC.downedBoss3))
                .Add(new Item(ItemID.KingSlimeBossBag) { shopCustomPrice = 250000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.EyeOfCthulhuBossBag) { shopCustomPrice = 350000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.EaterOfWorldsBossBag) { shopCustomPrice = 500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.BrainOfCthulhuBossBag) { shopCustomPrice = 500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.QueenBeeBossBag) { shopCustomPrice = 750000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.SkeletronBossBag) { shopCustomPrice = 1000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.DeerclopsBossBag) { shopCustomPrice = 1500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedDeerclops)).AddModItemToShop(ThoriumMod, "DarkMageBag", 1000000, () => NPC.downedBoss3 && Main.expertMode && DD2Event.DownedInvasionT1)
                .Add(new Item(ItemID.WallOfFleshBossBag) { shopCustomPrice = 1750000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && Main.hardMode))
                .Add(new Item(ItemID.QueenSlimeBossBag) { shopCustomPrice = 1500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedQueenSlime))
                .Add(new Item(ItemID.DestroyerBossBag) { shopCustomPrice = 2000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3))
                .Add(new Item(ItemID.TwinsBossBag) { shopCustomPrice = 2000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3))
                .Add(new Item(ItemID.SkeletronPrimeBossBag) { shopCustomPrice = 2000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3))
                .AddModItemToShop(ThoriumMod, "OgreBag", 1000000, () => NPC.downedBoss3 && Main.expertMode && DD2Event.DownedInvasionT2 && NPC.downedMechBossAny)
                .Add(new Item(ItemID.PlanteraBossBag) { shopCustomPrice = 2500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedPlantBoss))
                .Add(new Item(ItemID.FairyQueenBossBag) { shopCustomPrice = 2500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedEmpressOfLight))
                .Add(new Item(ItemID.GolemBossBag) { shopCustomPrice = 3000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedGolemBoss))
                .Add(new Item(ItemID.BossBagBetsy) { shopCustomPrice = 3500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && DD2Event.DownedInvasionT3 && NPC.downedGolemBoss))
                .Add(new Item(ItemID.FishronBossBag) { shopCustomPrice = 3500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedFishron))
                .Add(new Item(ItemID.MoonLordBossBag) { shopCustomPrice = 4000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMoonlord));
            shop.Register();

            shop = new NPCShop(Type, Bags1Shop)
                    .AddModItemToShop(Calamity, "DesertScourgeBag", 375000, () => (bool)Calamity.Call("Downed", "desert scourge"))
                    .AddModItemToShop(Calamity, "CrabulonBag", 700000, () => (bool)Calamity.Call("Downed", "crabulon"))
                    .AddModItemToShop(Calamity, "HiveMindBag", 1000000, () => (bool)Calamity.Call("Downed", "hive mind") || (bool)Calamity.Call("Downed", "perforators"))
                    .AddModItemToShop(Calamity, "PerforatorBag", 1000000, () => (bool)Calamity.Call("Downed", "hive mind") || (bool)Calamity.Call("Downed", "perforators"))
                    .AddModItemToShop(Calamity, "SlimeGodBag", 1000000, () => (bool)Calamity.Call("Downed", "slime god"))
                    .AddModItemToShop(Calamity, "CryogenBag", 2000000, () => (bool)Calamity.Call("Downed", "cryogen"))
                    .AddModItemToShop(Calamity, "AquaticScourgeBag", 2000000, () => (bool)Calamity.Call("Downed", "aquatic scourge"))
                    .AddModItemToShop(Calamity, "BrimstoneWaifuBag", 5000000, () => (bool)Calamity.Call("Downed", "brimstone elemental"))
                    .AddModItemToShop(Calamity, "CalamitasBag", 5000000, () => (bool)Calamity.Call("Downed", "calamitas doppelganger"))
                    .AddModItemToShop(Calamity, "LeviathanBag", 4250000, () => (bool)Calamity.Call("Downed", "leviathan"))
                    .AddModItemToShop(Calamity, "AstrageldonBag", 5000000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                    .AddModItemToShop(Calamity, "PlaguebringerGoliathBag", 5750000, () => (bool)Calamity.Call("Downed", "plaguebringer goliath"))
                    .AddModItemToShop(Calamity, "RavagerBag", 5500000, () => (bool)Calamity.Call("Downed", "ravager"))
                    .AddModItemToShop(Calamity, "AstrumDeusBag", 6500000, () => (bool)Calamity.Call("Downed", "astrum deus"))
                    .AddModItemToShop(Calamity, "BumblebirbBag", 8500000, () => (bool)Calamity.Call("Downed", "dragonfolly"))
                    .AddModItemToShop(Calamity, "ProvidenceBag", 22000000, () => (bool)Calamity.Call("Downed", "providence"))
                    .AddModItemToShop(Calamity, "StormWeaverBag", 12500000, () => (bool)Calamity.Call("Downed", "stormweaver"))
                    .AddModItemToShop(Calamity, "CeaselessVoidBag", 12500000, () => (bool)Calamity.Call("Downed", "ceaselessvoid"))
                    .AddModItemToShop(Calamity, "SignusBag", 12500000, () => (bool)Calamity.Call("Downed", "signus"))
                    .AddModItemToShop(Calamity, "PolterghastBag", 22500000, () => (bool)Calamity.Call("Downed", "polterghast"))
                    .AddModItemToShop(Calamity, "OldDukeBag", 25000000, () => (bool)Calamity.Call("Downed", "old duke"))
                    .AddModItemToShop(Calamity, "DevourerofGodsBag", 25000000, () => (bool)Calamity.Call("Downed", "dog"))
                    .AddModItemToShop(Calamity, "YharonBag", 75000000, () => (bool)Calamity.Call("Downed", "yharon"))
                    .AddModItemToShop(Calamity, "DraedonTreasureBag", 115000000, () => (bool)Calamity.Call("Downed", "exomechs"))
                    .AddModItemToShop(Calamity, "SCalBag", 200000000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
                    .AddModItemToShop(ThoriumMod, "ThunderBirdBag", 500000, () => (bool)ThoriumMod.Call("GetDownedBoss", "TheGrandThunderBird"))
                    .AddModItemToShop(ThoriumMod, "JellyFishBag", 750000, () => (bool)ThoriumMod.Call("GetDownedBoss", "QueenJellyfish"))
                    .AddModItemToShop(ThoriumMod, "CountBag", 850000, () => (bool)ThoriumMod.Call("GetDownedBoss", "Viscount"))
                    .AddModItemToShop(ThoriumMod, "GraniteBag", 1000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "GraniteEnergyStorm"))
                    .AddModItemToShop(ThoriumMod, "HeroBag", 1000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "BuriedChampion"))
                    .AddModItemToShop(ThoriumMod, "ScouterBag", 1250000, () => (bool)ThoriumMod.Call("GetDownedBoss", "StarScouter"))
                    .AddModItemToShop(ThoriumMod, "BoreanBag", 1500000, () => (bool)ThoriumMod.Call("GetDownedBoss", "BoreanStrider"))
                    .AddModItemToShop(ThoriumMod, "BeholderBag", 2000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "FallenBeholder"))
                    .AddModItemToShop(ThoriumMod, "LichBag", 3000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "Lich"))
                    .AddModItemToShop(ThoriumMod, "AbyssionBag", 3500000, () => (bool)ThoriumMod.Call("GetDownedBoss", "ForgottenOne"))
                    .AddModItemToShop(ThoriumMod, "RagBag", 5000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "ThePrimordials"))
                ;
            shop.Register();

            shop = new NPCShop(Type, Bags2Shop);
            //.AddModItemToShop(Atheria, "NovaBossBag", 1500000, () => ShardsConditions.DownedNova);
            shop.Register();

            shop = new NPCShop(Type, Bags3Shop)
                    /*
                    //.addModItemToShop(Redemption, "KingChickenBag", 150000, () => Operator.RedemptionDowned.ReDownedChicken)
                    .AddModItemToShop(Redemption, "ThornBag", 250000, () => RedemptionDowned.Thorn)
                    .AddModItemToShop(Redemption, "KeeperBag", 350000, () => RedemptionDowned.Keeper)
                    //.addModItemToShop(Redemption, "XenomiteCrystalBag", 500000, () => RedemptionDowned.ReDownedCrystal)
                    //.addModItemToShop(Redemption, "InfectedEyeBag", 1000000, () => RedemptionDowned.ReDownedIEye)
                    .AddModItemToShop(Redemption, "SoIBag", 1000000, () => RedemptionDowned.SeedOfInfection)
                    .AddModItemToShop(Redemption, "SlayerBag", 1500000, () => RedemptionDowned.KingSlayer)
                    .AddModItemToShop(Redemption, "OmegaGigaporaBag", 3000000, () => RedemptionDowned.OmegaGigapora)
                    .AddModItemToShop(Redemption, "OmegaOblitBag", 5000000, () => RedemptionDowned.Obliterator)
                    .AddModItemToShop(Redemption, "PZBag", 6000000, () => RedemptionDowned.PatientZero)
                    .AddModItemToShop(Redemption, "UkkoBag", 6000000, () => RedemptionDowned.DeityDuo)
                    .AddModItemToShop(Redemption, "AkkaBag", 6000000, () => RedemptionDowned.DeityDuo)
                    .AddModItemToShop(Redemption, "NebBag", 10000000, () => RedemptionDowned.Nebuleus)*/
                ;
            shop.Register();
        }
    }
}
