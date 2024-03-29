using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCRebornAgain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Content;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.ObjectData;
using Terraria.UI.Chat;
using Terraria.Utilities;
using AlchemistNPCRebornAgain.Interface;
using AlchemistNPCRebornAgain.Items;
using AlchemistNPCRebornAgain.NPCs;

namespace AlchemistNPCRebornAgain
{
    public class AlchemistNPCRebornPlayer : ModPlayer
    {
        public int Shield = 0;
        public int Timer = 0;
        public int fc = 0;
        public bool Barrage = false;
        public bool Blinker = false;
        public bool BoomBox = false;
        public bool MasterYoyoBag = false;
        public bool TimeTwist = false;
        public bool HPJ = false;
        public bool DeltaRune = false;
        public bool PB4K = false;
        public bool PH = false;
        public bool DistantPotionsUse = false;
        public bool Voodoo = false;
        public bool CursedMirror = false;
        public bool ShieldBelt = false;
        public bool MysticAmuletMount = false;
        public bool TerrarianBlock = false;
        public bool Luck = false;
        public bool Illuminati = false;
        public bool AutoinjectorMK2 = false;
        public bool AlchemistCharmTier1 = false;
        public bool AlchemistCharmTier2 = false;
        public bool AlchemistCharmTier3 = false;
        public bool AlchemistCharmTier4 = false;
        public bool BeeHeal = false;
        public bool Pandora = false;
        public bool TS = false;
        public bool Symbiote = false;
        public bool Akumu = false;
        public bool DriedFish = false;
        public bool SolarFish = false;
        public bool NebulaFish = false;
        public bool VortexFish = false;
        public bool StardustFish = false;
        public bool MiniShark = false;
        public bool Manna = false;
        public bool Traps = false;
        public bool Yui = false;
        public bool YuiS = false;
        public bool Extractor = false;
        public bool Scroll = false;
        public bool EyeOfJudgement = false;
        public bool LaetitiaSet = false;
        public bool LaetitiaGift = false;
        public bool SFU = false;
        public bool SF = false;
        public bool PGSWear = false;
        public bool RevSet = false;
        public bool XtraT = false;
        public bool BuffsKeep = false;
        public bool MemersRiposte = false;
        public bool ModPlayer = true;
        public bool lf = false;
        public bool GC = false;
        public int lamp = 0;
        public bool ParadiseLost = false;
        public bool Rampage = false;
        public bool LilithEmblem = false;
        public bool trigger = true;
        public bool turret = false;
        public bool watchercrystal = false;
        public bool devilsknife = false;
        public bool uw = false;
        public bool grimreaper = false;
        public bool snatcher = false;
        public bool sscope = false;
        public bool lwm = false;
        public bool DB = false;
        public bool GlobalTeleporter = false;
        public bool GlobalTeleporterUp = false;
        public bool MeatGrinderOnUse = false;

        public bool AllDamage10 = false;
        public bool AllCrit10 = false;
        public bool Defense8 = false;
        public bool DR10 = false;
        public float EndurancePotDR = 0;
        public bool Regeneration = false;
        public bool Lifeforce = false;
        public bool MS = false;

        public int DisasterGauge = 0;
        public int chargetime = 0;
        public int MeatGrinderUsetime = 0;

        private const int maxBBP = -1;
        public int BBP = 0;
        private const int maxRCT1 = -1;
        public int RCT1 = 0;
        private const int maxRCT2 = -1;
        public int RCT2 = 0;
        private const int maxRCT3 = -1;
        public int RCT3 = 0;
        private const int maxRCT4 = -1;
        public int RCT4 = 0;
        private const int maxRCT5 = -1;
        public int RCT5 = 0;
        private const int maxRCT6 = -1;
        public int RCT6 = 0;
        private const int maxSnatcherCounter = -1;
        public int SnatcherCounter = 0;
        private const int maxLifeElixir = 2;
        public int LifeElixir = 0;
        private const int maxFuaran = 1;
        public int Fuaran = 0;
        private const int maxKeepBuffs = 1;
        public int KeepBuffs = 0;
        private const int maxWellFed = 1;
        public int WellFed = 0;
        private const int maxBillIsDowned = 1;
        public int BillIsDowned = 0;

        private const int maxKingSlimeBooster = 1;
        public int KingSlimeBooster = 0;
        private const int maxEyeOfCthulhuBooster = 1;
        public int EyeOfCthulhuBooster = 0;
        private const int maxEaterOfWorldsBooster = 1;
        public int EaterOfWorldsBooster = 0;
        private const int maxBrainOfCthulhuBooster = 1;
        public int BrainOfCthulhuBooster = 0;
        private const int maxQueenBeeBooster = 1;
        public int QueenBeeBooster = 0;
        private const int maxSkeletronBooster = 1;
        public int SkeletronBooster = 0;
        private const int maxWoFBooster = 1;
        public int WoFBooster = 0;
        private const int maxDarkMageBooster = 1;
        public int DarkMageBooster = 0;
        private const int maxDestroyerBooster = 1;
        public int DestroyerBooster = 0;
        private const int maxCustomBooster1 = 1;
        public int CustomBooster1 = 0;
        private const int maxCustomBooster2 = 1;
        public int CustomBooster2 = 0;
        private const int maxPrimeBooster = 1;
        public int PrimeBooster = 0;
        private const int maxTwinsBooster = 1;
        public int TwinsBooster = 0;
        private const int maxPlanteraBooster = 1;
        public int PlanteraBooster = 0;
        private const int maxIceGolemBooster = 1;
        public int IceGolemBooster = 0;
        private const int maxPigronBooster = 1;
        public int PigronBooster = 0;
        private const int maxOgreBooster = 1;
        public int OgreBooster = 0;
        private const int maxGolemBooster = 1;
        public int GolemBooster = 0;
        private const int maxBetsyBooster = 1;
        public int BetsyBooster = 0;
        private const int maxGSummonerBooster = 1;
        public int GSummonerBooster = 0;
        private const int maxFishronBooster = 1;
        public int FishronBooster = 0;
        private const int maxMartianSaucerBooster = 1;
        public int MartianSaucerBooster = 0;
        private const int maxCultistBooster = 1;
        public int CultistBooster = 0;
        private const int maxMoonLordBooster = 1;
        public int MoonLordBooster = 0;

        public Vector2 spawnPosition;
        private DateTime now2;

        public bool Bewitched = false;
        public bool Sharpen = false;
        public bool Clairvoyance = false;
        public bool AmmoBox = false;
        public bool SugarRush = false;
        public bool Lamps = false;
        public bool rainbowdust = false;

        public override void ResetEffects()
        {
            if (AlchemistNPCRebornWorld.foundAntiBuffMode)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.AntiBuff>(), 2);
            }

            if (Shield < 0)
            {
                Shield = 0;
            }

            Item.potionDelay = 3600;
            Barrage = false;
            Blinker = false;
            BoomBox = false;
            MasterYoyoBag = false;
            TimeTwist = false;
            HPJ = false;
            DeltaRune = false;
            PH = false;
            PB4K = false;
            DistantPotionsUse = false;
            CursedMirror = false;
            Voodoo = false;
            ShieldBelt = false;
            MysticAmuletMount = false;
            Luck = false;
            TerrarianBlock = false;
            AlchemistGlobalItem.Luck = false;
            AlchemistGlobalItem.Luck2 = false;
            AlchemistGlobalItem.PerfectionToken = false;
            AlchemistGlobalItem.Menacing = false;
            AlchemistGlobalItem.Lucky = false;
            AlchemistGlobalItem.Violent = false;
            AlchemistGlobalItem.Warding = false;
            AlchemistNPCRebornAgain.GreaterDangersense = false;
            AlchemistNPCRebornAgain.BastScroll = false;
            AlchemistNPCRebornAgain.Stormbreaker = false;
            MeatGrinderOnUse = false;
            AlchemistCharmTier1 = false;
            AlchemistCharmTier2 = false;
            AlchemistCharmTier3 = false;
            AlchemistCharmTier4 = false;
            Illuminati = false;
            BeeHeal = false;
            Pandora = false;
            TS = false;
            Symbiote = false;
            DriedFish = false;
            SolarFish = false;
            NebulaFish = false;
            VortexFish = false;
            StardustFish = false;
            MiniShark = false;
            Manna = false;
            Akumu = false;
            AutoinjectorMK2 = false;
            EyeOfJudgement = false;
            LaetitiaSet = false;
            LaetitiaGift = false;
            Scroll = false;
            SFU = false;
            SF = false;
            XtraT = false;
            RevSet = false;
            MemersRiposte = false;
            PGSWear = false;
            Extractor = false;
            ParadiseLost = false;
            Rampage = false;
            LilithEmblem = false;
            turret = false;
            watchercrystal = false;
            devilsknife = false;
            uw = false;
            grimreaper = false;
            snatcher = false;
            rainbowdust = false;
            sscope = false;
            lwm = false;
            Yui = false;
            YuiS = false;
            Traps = false;
            GlobalTeleporter = false;
            GlobalTeleporterUp = false;

            AllDamage10 = false;
            AllCrit10 = false;
            Defense8 = false;
            DR10 = false;
            Regeneration = false;
            Lifeforce = false;
            MS = false;

            Bewitched = false;
            Sharpen = false;
            Clairvoyance = false;
            AmmoBox = false;
            SugarRush = false;
            Lamps = false;

            Player.statLifeMax2 += LifeElixir * 50;
            Player.statManaMax2 += Fuaran * 100;

            if (KeepBuffs == 1)
            {
                BuffsKeep = true;
                Player.pStone = true;
            }

            if (WellFed == 1)
            {
                Player.AddBuff(BuffID.WellFed, 2);
            }

            if (KeepBuffs == 0)
            {
                BuffsKeep = false;
            }

            if (BillIsDowned == 1)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.DemonSlayer>(), 2);
            }

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    ShopChangeUI.visible = false;
                    ShopChangeUIA.visible = false;
                    ShopChangeUIO.visible = false;
                    ShopChangeUIM.visible = false;
                    ShopChangeUIT.visible = false;
                }
            }

            if (Player.talkNPC == -1)
            {
                for (int index1 = 0; index1 < 40; ++index1)
                {
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier1>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier2>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier3>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier4>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier5>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier6>())
                    {
                        Player.bank3.item[index1].TurnToAir();
                    }
                }
            }
        }

        public override void OnEnterWorld()
        {
            now2 = DateTime.Now;
            if (now2.Month == 4)
            {
                now2 = DateTime.Now;
                if (now2.Day == 1)
                {
                    if (AlchemistNPCRebornAgain.modConfiguration.GameError)
                    {
                        ModLoader.TryGetMod("AlchemistNPCLite", out Mod Lite);
                        if (Lite != null)
                        {
                            NPC.SpawnOnPlayer(Main.LocalPlayer.whoAmI, ModContent.NPCType<NPCs.GameError>());
                            ModGlobalNPC.geru = true;
                            ModGlobalNPC.gr = 0;
                            ModGlobalNPC.gu = false;
                        }
                    }
                }
            }
        }

        //public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        //{
        //    Item item = new Item();
        //    item.SetDefaults(ModContent.ItemType<Items.Misc.AntiBuffItem>());
        //    item.stack = 1;
        //    IEnumerable<Item>.Add(item);
        //}

        public override void PostBuyItem(NPC vendor, Item[] shopInventory, Item item)
        {
            bool Casket = false;
            for (int j = 0; j < Player.inventory.Length; j++)
            {
                if (Player.inventory[j].type == Mod.Find<ModItem>("DimensionalCasket").Type)
                {
                    Casket = true;
                    break;
                }
            }

            if (vendor.type == Mod.Find<ModNPC>("Operator").Type || Casket)
            {
                for (int index1 = 0; index1 < 40; ++index1)
                {
                    if (Player.bank3.item[index1].type == Mod.Find<ModItem>("ReversivityCoinTier1").Type)
                    {
                        RCT1 = Player.bank3.item[index1].stack;
                        continue;
                    }

                    if (Player.bank3.item[index1].type == Mod.Find<ModItem>("ReversivityCoinTier2").Type)
                    {
                        RCT2 = Player.bank3.item[index1].stack;
                        continue;
                    }

                    if (Player.bank3.item[index1].type == Mod.Find<ModItem>("ReversivityCoinTier3").Type)
                    {
                        RCT3 = Player.bank3.item[index1].stack;
                        continue;
                    }

                    if (Player.bank3.item[index1].type == Mod.Find<ModItem>("ReversivityCoinTier4").Type)
                    {
                        RCT4 = Player.bank3.item[index1].stack;
                        continue;
                    }

                    if (Player.bank3.item[index1].type == Mod.Find<ModItem>("ReversivityCoinTier5").Type)
                    {
                        RCT5 = Player.bank3.item[index1].stack;
                        continue;
                    }

                    if (Player.bank3.item[index1].type == Mod.Find<ModItem>("ReversivityCoinTier6").Type)
                    {
                        RCT6 = Player.bank3.item[index1].stack;
                        break;
                    }
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (SnatcherCounter >= 12500 && Player.HasBuff(Mod.Find<ModBuff>("Snatcher").Type))
                Projectile.NewProjectile(((Entity)this.Player).GetSource_FromThis((string)null), target.Center.X, target.Center.Y, 0f, 0f, Mod.Find<ModProjectile>("Returner2").Type, damageDone * 10, 0, Player.whoAmI);

            if (CursedMirror)
            {
                target.AddBuff(BuffID.Regeneration, 100);
            }

            if (target.friendly == false)
            {
                if (Player.HasBuff(ModContent.BuffType<Buffs.RainbowFlaskBuff>()))
                {
                    target.buffImmune[BuffID.BetsysCurse] = false;
                    target.buffImmune[BuffID.Ichor] = false;
                    target.buffImmune[BuffID.Daybreak] = false;
                    target.AddBuff(ModContent.BuffType<Buffs.Corrosion>(), 600);
                    target.AddBuff(BuffID.BetsysCurse, 600);
                    target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.Daybreak, 600);
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.friendly == false)
            {
                if (Player.HasBuff(ModContent.BuffType<Buffs.RainbowFlaskBuff>()))
                {
                    target.buffImmune[BuffID.BetsysCurse] = false;
                    target.buffImmune[BuffID.Ichor] = false;
                    target.buffImmune[BuffID.Daybreak] = false;
                    target.AddBuff(ModContent.BuffType<Buffs.Corrosion>(), 600);
                    target.AddBuff(BuffID.BetsysCurse, 600);
                    target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.Daybreak, 600);
                }
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (!target.friendly && Player.HasBuff(ModContent.BuffType<Buffs.GuarantCrit>()))
            {
                modifiers.SetCrit();
                GC = false;
            }

            if (Player.HasBuff(ModContent.BuffType<Buffs.ExecutionersEyes>()) && Main.rand.NextBool(20))
                modifiers.CritDamage *= 2;
            if (MemersRiposte)
                modifiers.CritDamage *= 2;
            
        }


        public override bool CanBeHitByProjectile(Projectile projectile)
        {
            //if (player.HasBuff(ModContent.BuffType<Buffs.Akumu>()) || player.HasBuff(mod.BuffType("TrueAkumu")))
            if (Player.HasBuff(ModContent.BuffType<Buffs.Akumu>()))
            {
                return false;
            }

            return true;
        }

        public override void PostUpdate()
        {
            Player player = Main.LocalPlayer;
            if (MysticAmuletMount)
            {
                player.hairFrame.Y = 5 * player.hairFrame.Height;
                player.headFrame.Y = 5 * player.headFrame.Height;
                player.legFrame.Y = 5 * player.legFrame.Height;
            }
        }


        public override void CopyClientState(ModPlayer clientClone)
        {
            AlchemistNPCRebornPlayer clone = clientClone as AlchemistNPCRebornPlayer;
            clone.RCT1 = RCT1;
            clone.RCT2 = RCT2;
            clone.RCT3 = RCT3;
            clone.RCT4 = RCT4;
            clone.RCT5 = RCT5;
            clone.RCT6 = RCT6;

            clone.KeepBuffs = KeepBuffs;
            clone.BillIsDowned = BillIsDowned;

            clone.KingSlimeBooster = KingSlimeBooster;
            clone.EyeOfCthulhuBooster = EyeOfCthulhuBooster;
            clone.EaterOfWorldsBooster = EaterOfWorldsBooster;
            clone.BrainOfCthulhuBooster = BrainOfCthulhuBooster;
            clone.QueenBeeBooster = QueenBeeBooster;
            clone.SkeletronBooster = SkeletronBooster;
            clone.WoFBooster = WoFBooster;
            clone.DarkMageBooster = DarkMageBooster;
            clone.CustomBooster1 = CustomBooster1;
            clone.CustomBooster2 = CustomBooster2;
            clone.DestroyerBooster = DestroyerBooster;
            clone.PrimeBooster = PrimeBooster;
            clone.TwinsBooster = TwinsBooster;
            clone.IceGolemBooster = IceGolemBooster;
            clone.PigronBooster = PigronBooster;
            clone.OgreBooster = OgreBooster;
            clone.PlanteraBooster = PlanteraBooster;
            clone.GolemBooster = GolemBooster;
            clone.BetsyBooster = BetsyBooster;
            clone.GSummonerBooster = GSummonerBooster;
            clone.FishronBooster = FishronBooster;
            clone.MartianSaucerBooster = MartianSaucerBooster;
            clone.CultistBooster = CultistBooster;
            clone.MoonLordBooster = MoonLordBooster;

            clone.BBP = BBP;
            clone.SnatcherCounter = SnatcherCounter;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            AlchemistNPCRebornPlayer clone = (AlchemistNPCRebornPlayer)clientPlayer;

            if (KeepBuffs != clone.KeepBuffs ||
                BillIsDowned != clone.BillIsDowned ||
                KingSlimeBooster != clone.KingSlimeBooster ||
                EyeOfCthulhuBooster != clone.EyeOfCthulhuBooster ||
                EaterOfWorldsBooster != clone.EaterOfWorldsBooster ||
                BrainOfCthulhuBooster != clone.BrainOfCthulhuBooster ||
                QueenBeeBooster != clone.QueenBeeBooster ||
                SkeletronBooster != clone.SkeletronBooster ||
                WoFBooster != clone.WoFBooster ||
                DarkMageBooster != clone.DarkMageBooster ||
                CustomBooster1 != clone.CustomBooster1 ||
                CustomBooster2 != clone.CustomBooster2 ||
                DestroyerBooster != clone.DestroyerBooster ||
                PrimeBooster != clone.PrimeBooster ||
                TwinsBooster != clone.TwinsBooster ||
                IceGolemBooster != clone.IceGolemBooster ||
                PigronBooster != clone.PigronBooster ||
                OgreBooster != clone.OgreBooster ||
                PlanteraBooster != clone.PlanteraBooster ||
                GolemBooster != clone.GolemBooster ||
                BetsyBooster != clone.BetsyBooster ||
                GSummonerBooster != clone.GSummonerBooster ||
                FishronBooster != clone.FishronBooster ||
                MartianSaucerBooster != clone.MartianSaucerBooster ||
                CultistBooster != clone.CultistBooster ||
                MoonLordBooster != clone.MoonLordBooster ||
                BBP != clone.BBP ||
                SnatcherCounter != clone.SnatcherCounter)


                SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
        }

        public static void AddToList(List<string> lister, string stringer, int integer)
        {
            if (integer == 1)
            {
                lister.Add(stringer);
            }
        }

        public override void SaveData(TagCompound tag)
        {
            List<string> boosts = new List<string>();
            AddToList(boosts, "KeepBuffs", KeepBuffs);
            AddToList(boosts, "BillIsDowned", BillIsDowned);
            //AddToList(boosts, "RCT1", RCT1);
            //AddToList(boosts, "RCT2", RCT2);
            //AddToList(boosts, "RCT3", RCT3);
            //AddToList(boosts, "RCT4", RCT4);
            //AddToList(boosts, "RCT5", RCT5);
            //AddToList(boosts, "RCT6", RCT6);
            //AddToList(boosts, "BBP", BBP);
            AddToList(boosts, "KingSlimeBooster", KingSlimeBooster);
            AddToList(boosts, "EyeOfCthulhuBooster", EyeOfCthulhuBooster);
            AddToList(boosts, "EaterOfWorldsBooster", EaterOfWorldsBooster);
            AddToList(boosts, "BrainOfCthulhuBooster", BrainOfCthulhuBooster);
            AddToList(boosts, "QueenBeeBooster", QueenBeeBooster);
            AddToList(boosts, "SkeletronBooster", SkeletronBooster);
            AddToList(boosts, "WoFBooster", WoFBooster);
            AddToList(boosts, "DarkMageBooster", DarkMageBooster);
            AddToList(boosts, "CustomBooster1", CustomBooster1);
            AddToList(boosts, "CustomBooster2", CustomBooster2);
            AddToList(boosts, "DestroyerBooster", DestroyerBooster);
            AddToList(boosts, "PrimeBooster", PrimeBooster);
            AddToList(boosts, "TwinsBooster", TwinsBooster);
            AddToList(boosts, "IceGolemBooster", IceGolemBooster);
            AddToList(boosts, "PigronBooster", PigronBooster);
            AddToList(boosts, "OgreBooster", OgreBooster);
            AddToList(boosts, "PlanteraBooster", PlanteraBooster);
            AddToList(boosts, "GolemBooster", GolemBooster);
            AddToList(boosts, "BetsyBooster", BetsyBooster);
            AddToList(boosts, "GSummonerBooster", GSummonerBooster);
            AddToList(boosts, "FishronBooster", FishronBooster);
            AddToList(boosts, "MartianSaucerBooster", MartianSaucerBooster);
            AddToList(boosts, "CultistBooster", CultistBooster);
            AddToList(boosts, "MoonLordBooster", MoonLordBooster);

            tag["boosts"] = (object)boosts;

            List<string> snatcherC = new List<string>();
            snatcherC.Add(SnatcherCounter.ToString());

            tag["snatcherC"] = (object)snatcherC;

            List<string> lifeC = new List<string>();
            lifeC.Add(LifeElixir.ToString());

            tag["lifeC"] = (object)lifeC;
        }

        public override void LoadData(TagCompound tag)
        {
            IList<string> boosts = tag.GetList<string>("boosts");
            if (boosts.Contains("KeepBuffs"))
            {
                KeepBuffs = 1;
            }

            if (boosts.Contains("BillIsDowned"))
            {
                BillIsDowned = 1;
            }

            if (boosts.Contains("KingSlimeBooster"))
            {
                KingSlimeBooster = 1;
            }

            if (boosts.Contains("EyeOfCthulhuBooster"))
            {
                EyeOfCthulhuBooster = 1;
            }

            if (boosts.Contains("EaterOfWorldsBooster"))
            {
                EaterOfWorldsBooster = 1;
            }

            if (boosts.Contains("BrainOfCthulhuBooster"))
            {
                BrainOfCthulhuBooster = 1;
            }

            if (boosts.Contains("QueenBeeBooster"))
            {
                QueenBeeBooster = 1;
            }

            if (boosts.Contains("SkeletronBooster"))
            {
                SkeletronBooster = 1;
            }

            if (boosts.Contains("WoFBooster"))
            {
                WoFBooster = 1;
            }

            if (boosts.Contains("DarkMageBooster"))
            {
                DarkMageBooster = 1;
            }

            if (boosts.Contains("CustomBooster1"))
            {
                CustomBooster1 = 1;
            }

            if (boosts.Contains("CustomBooster2"))
            {
                CustomBooster2 = 1;
            }

            if (boosts.Contains("DestroyerBooster"))
            {
                DestroyerBooster = 1;
            }

            if (boosts.Contains("PrimeBooster"))
            {
                PrimeBooster = 1;
            }

            if (boosts.Contains("TwinsBooster"))
            {
                TwinsBooster = 1;
            }

            if (boosts.Contains("IceGolemBooster"))
            {
                IceGolemBooster = 1;
            }

            if (boosts.Contains("PigronBooster"))
            {
                PigronBooster = 1;
            }

            if (boosts.Contains("OgreBooster"))
            {
                OgreBooster = 1;
            }

            if (boosts.Contains("PlanteraBooster"))
            {
                PlanteraBooster = 1;
            }

            if (boosts.Contains("GolemBooster"))
            {
                GolemBooster = 1;
            }

            if (boosts.Contains("BetsyBooster"))
            {
                BetsyBooster = 1;
            }

            if (boosts.Contains("GSummonerBooster"))
            {
                GSummonerBooster = 1;
            }

            if (boosts.Contains("FishronBooster"))
            {
                FishronBooster = 1;
            }

            if (boosts.Contains("MartianSaucerBooster"))
            {
                MartianSaucerBooster = 1;
            }

            if (boosts.Contains("CultistBooster"))
            {
                CultistBooster = 1;
            }

            if (boosts.Contains("MoonLordBooster"))
            {
                MoonLordBooster = 1;
            }

            IList<string> snatcherC = tag.GetList<string>("snatcherC");
            for (int i = 0; i < 9999; i++)
            {
                if (snatcherC.Contains(i.ToString()))
                {
                    SnatcherCounter = i;
                }
            }

            IList<string> lifeC = tag.GetList<string>("lifeC");
            for (int i = 0; i < 3; i++)
            {
                if (lifeC.Contains(i.ToString()))
                {
                    LifeElixir = i;
                }
            }
        }

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (attempt.questFish == ModContent.ItemType<Items.QuestFishes.MutantFish>() && Main.rand.Next(8) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.MutantFish>();
            }

            if (Player.ZoneTowerSolar && attempt.questFish == ModContent.ItemType<Items.QuestFishes.SolarFish>() && Main.rand.Next(5) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.SolarFish>();
            }

            if (Player.ZoneTowerNebula && attempt.questFish == ModContent.ItemType<Items.QuestFishes.NebulaFish>() && Main.rand.Next(5) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.NebulaFish>();
            }

            if (Player.ZoneTowerVortex && attempt.questFish == ModContent.ItemType<Items.QuestFishes.VortexFish>() && Main.rand.Next(5) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.VortexFish>();
            }

            if (Player.ZoneTowerStardust && attempt.questFish == ModContent.ItemType<Items.QuestFishes.StardustFish>() && Main.rand.Next(5) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.StardustFish>();
            }

            if (Player.ZoneBeach && attempt.questFish == ModContent.ItemType<Items.QuestFishes.MiniShark>() && Main.rand.Next(8) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.MiniShark>();
            }

            if (Player.ZoneDesert && attempt.questFish == ModContent.ItemType<Items.QuestFishes.MosesFish>() && Main.rand.Next(20) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.MosesFish>();
            }

            if (Player.ZoneDesert && attempt.questFish == ModContent.ItemType<Items.QuestFishes.MosesFish>() && Main.rand.Next(10) == 0)
            {
                itemDrop = ModContent.ItemType<Items.QuestFishes.MosesFish>();
            }
        }

        public override void AnglerQuestReward(float quality, List<Item> rewardItems)
        {
            if (DriedFish)
            {
                Item vobla = new Item();
                vobla.SetDefaults(ModContent.ItemType<Items.Weapons.DriedFish>());
                vobla.stack = 1;
                rewardItems.Add(vobla);
            }

            if (SolarFish)
            {
                Item solar = new Item();
                solar.SetDefaults(ItemID.FragmentSolar);
                solar.stack = 25;
                rewardItems.Add(solar);
            }

            if (NebulaFish)
            {
                Item nebula = new Item();
                nebula.SetDefaults(ItemID.FragmentNebula);
                nebula.stack = 25;
                rewardItems.Add(nebula);
            }

            if (VortexFish)
            {
                Item vortex = new Item();
                vortex.SetDefaults(ItemID.FragmentVortex);
                vortex.stack = 25;
                rewardItems.Add(vortex);
            }

            if (StardustFish)
            {
                Item stardust = new Item();
                stardust.SetDefaults(ItemID.FragmentStardust);
                stardust.stack = 25;
                rewardItems.Add(stardust);
            }

            if (MiniShark)
            {
                Item minishark = new Item();
                minishark.SetDefaults(ItemID.Minishark);
                minishark.stack = 1;
                rewardItems.Add(minishark);
            }

            if (Manna)
            {
                Item manna = new Item();
                manna.SetDefaults(ModContent.ItemType<Items.Misc.MannafromHeaven>());
                manna.stack = 1;
                rewardItems.Add(manna);
            }
        }

        public override void UpdateEquips()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.TryFind<ModBuff>("HolyWrathBuff", out ModBuff buff);
                if (buff != null && !Player.HasBuff(buff.Type) && AllDamage10) Player.GetDamage(DamageClass.Generic) += 0.1f;
                Calamity.TryFind<ModBuff>("ProfanedRageBuff", out buff);
                if (buff != null && !Player.HasBuff(buff.Type) && AllCrit10)
                {
                    Player.GetCritChance(DamageClass.Melee) += 10;
                    Player.GetCritChance(DamageClass.Ranged) += 10;
                    Player.GetCritChance(DamageClass.Magic) += 10;
                    Player.GetCritChance(DamageClass.Throwing) += 10;
                    Calamity.Call("AddRogueCrit", Player, 10);
                }

                Calamity.TryFind<ModBuff>("CadancesGrace", out buff);
                if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && buff != null && !Player.HasBuff(buff.Type) && Regeneration) Player.lifeRegen += 4;
                if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && buff != null && !Player.HasBuff(buff.Type) && Regeneration) Player.lifeRegen += 4;
                if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && buff != null && !Player.HasBuff(buff.Type) && Lifeforce)
                {
                    Player.lifeForce = true;
                    Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
                }
            }

            if (Calamity == null)
            {
                if (AllDamage10) Player.GetDamage(DamageClass.Generic) += 0.1f;
                if (AllCrit10)
                {
                    Player.GetCritChance(DamageClass.Melee) += 10;
                    Player.GetCritChance(DamageClass.Ranged) += 10;
                    Player.GetCritChance(DamageClass.Magic) += 10;
                    Player.GetCritChance(DamageClass.Throwing) += 10;
                }

                if (Regeneration) Player.lifeRegen += 4;
                if (Lifeforce)
                {
                    Player.lifeForce = true;
                    Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
                }
            }

            if (MS) Player.moveSpeed += 0.25f;
            if (Defense8) Player.statDefense += 8;
            if (DR10) Player.endurance += 0.1f;
            if (Bewitched) ++Player.maxMinions;
            if (Sharpen)
            {
                Player.GetArmorPenetration(DamageClass.Melee) += 12;
                Player.GetArmorPenetration(DamageClass.Summon) += 12;
            }

            if (Clairvoyance)
            {
                Player.GetDamage(DamageClass.Magic) += 0.05f;
                Player.GetCritChance(DamageClass.Magic) += 2;
                Player.statManaMax2 += 20;
                Player.manaCost -= 0.02f;
            }

            if (AmmoBox) Player.ammoBox = true;
            if (SugarRush)
            {
                Player.pickSpeed -= 0.2f;
                Player.moveSpeed += 0.2f;
            }

            if (Lamps)
            {
                Player.manaRegenBonus += 2;
                Main.SceneMetrics.HasHeartLantern = true;
                Main.SceneMetrics.HasCampfire = true;
            }
        }

        private bool QuickBuff_ShouldBotherUsingThisBuff(int attemptedType)
        {
            bool result = true;
            for (int i = 0; i < 22; i++)
            {
                if (attemptedType == 27 && (Player.buffType[i] == 27 || Player.buffType[i] == 101 || Player.buffType[i] == 102))
                {
                    result = false;
                    break;
                }

                if (BuffID.Sets.IsWellFed[attemptedType] && BuffID.Sets.IsWellFed[Player.buffType[i]])
                {
                    result = false;
                    break;
                }

                if (Player.buffType[i] == attemptedType)
                {
                    result = false;
                    break;
                }

                if (Main.meleeBuff[attemptedType] && Main.meleeBuff[Player.buffType[i]])
                {
                    result = false;
                    break;
                }
            }

            if (Main.lightPet[attemptedType] || Main.vanityPet[attemptedType])
            {
                for (int j = 0; j < 22; j++)
                {
                    if (Main.lightPet[Player.buffType[j]] && Main.lightPet[attemptedType])
                    {
                        result = false;
                    }

                    if (Main.vanityPet[Player.buffType[j]] && Main.vanityPet[attemptedType])
                    {
                        result = false;
                    }
                }
            }

            return result;
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (GlobalTeleporter || GlobalTeleporterUp)
            {
                bool allow = true;
                for (int v = 0; v < 200; ++v)
                {
                    NPC npc = Main.npc[v];
                    if (npc.active && npc.boss)
                    {
                        allow = false;
                        break;
                    }
                }

                if (GlobalTeleporterUp && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {
                    int mapWidth = Main.maxTilesX * 16;
                    int mapHeight = Main.maxTilesY * 16;
                    Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

                    cursorPosition.X -= Main.screenWidth / 2;
                    cursorPosition.Y -= Main.screenHeight / 2;

                    Vector2 mapPosition = Main.mapFullscreenPos;
                    Vector2 cursorWorldPosition = mapPosition;

                    cursorPosition /= 16;
                    cursorPosition *= 16 / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16;

                    cursorWorldPosition.Y -= Player.height;
                    if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
                    else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
                    if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
                    else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

                    Player.Teleport(cursorWorldPosition, 0, 0);
                    NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
                    Main.mapFullscreen = false;

                    for (int index = 0; index < 120; ++index)
                        Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                }

                if (GlobalTeleporter && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {
                    int mapWidth = Main.maxTilesX * 16;
                    int mapHeight = Main.maxTilesY * 16;
                    Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

                    cursorPosition.X -= Main.screenWidth / 2;
                    cursorPosition.Y -= Main.screenHeight / 2;

                    Vector2 mapPosition = Main.mapFullscreenPos;
                    Vector2 cursorWorldPosition = mapPosition;

                    cursorPosition /= 16;
                    cursorPosition *= 16 / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16;

                    cursorWorldPosition.Y -= Player.height;
                    if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
                    else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
                    if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
                    else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

                    Player.Teleport(cursorWorldPosition, 0, 0);
                    NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
                    Main.mapFullscreen = false;
                    Item[] inventory = Player.inventory;
                    for (int k = 0; k < inventory.Length; k++)
                    {
                        if (inventory[k].type == ModContent.ItemType<Items.Misc.GlobalTeleporter>())
                        {
                            inventory[k].stack--;
                            break;
                        }
                    }

                    for (int index = 0; index < 120; ++index)
                        Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                }
            }

            if (DistantPotionsUse && PlayerInput.Triggers.Current.QuickBuff)
            {
                SoundStyle type1 = SoundID.Item3;
                bool flag = true;
                bool dosound = false;
                for (int index1 = 0; index1 < 40; ++index1)
                {
                    flag = true;
                    if (Player.CountBuffs() == 22) return;
                    Item bankitem = Player.bank.item[index1];
                    if (bankitem.stack <= 0 || bankitem.type <= 0 || bankitem.buffType <= 0 || bankitem.CountsAsClass(DamageClass.Summon))
                    {
                        continue;
                    }

                    //ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                    int num2 = bankitem.buffType;
                    flag = QuickBuff_ShouldBotherUsingThisBuff(num2);
                    if (bankitem.mana > 0 && flag)
                    {
                        if (Player.statMana >= (int)((float)bankitem.mana * Player.manaCost))
                        {
                            Player.manaRegenDelay = (int)Player.maxRegenDelay;
                            Player.statMana -= (int)((float)bankitem.mana * Player.manaCost);
                        }
                        else
                        {
                            flag = false;
                        }
                    }

                    if (Player.whoAmI == Main.myPlayer && bankitem.type == 603 && !Main.runningCollectorsEdition)
                    {
                        flag = false;
                    }

                    if (num2 == 27)
                    {
                        num2 = Main.rand.Next(3);
                        if (num2 == 0)
                        {
                            num2 = 27;
                        }

                        if (num2 == 1)
                        {
                            num2 = 101;
                        }

                        if (num2 == 2)
                        {
                            num2 = 102;
                        }
                    }

                    if (!flag)
                    {
                        continue;
                    }

                    int num3 = bankitem.buffTime;
                    if (num3 == 0)
                    {
                        num3 = 3600;
                    }

                    Player.AddBuff(num2, num3);
                    if (Player.CountBuffs() == 22)
                    {
                        break;
                    }

                    dosound = true;

                    if (bankitem.consumable)
                    {
                        if (AlchemistCharmTier4 == true)
                        {
                            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                            if (Calamity != null)
                            {
                                if ((bool)Calamity.Call("Downed", "supreme calamitas"))
                                {
                                }
                                else if (Main.rand.NextFloat() >= .25f)
                                {
                                }
                                else
                                {
                                    --bankitem.stack;
                                }
                            }
                            else if (Main.rand.NextFloat() >= .25f)
                            {
                            }
                            else
                            {
                                --bankitem.stack;
                            }
                        }

                        else if (AlchemistCharmTier3 == true)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                            }
                            else
                            {
                                --bankitem.stack;
                            }
                        }

                        else if (AlchemistCharmTier2 == true)
                        {
                            if (Main.rand.Next(4) == 0)
                            {
                            }
                            else
                            {
                                --bankitem.stack;
                            }
                        }

                        else if (AlchemistCharmTier1 == true)
                        {
                            if (Main.rand.Next(10) == 0)
                            {
                            }
                            else
                            {
                                --bankitem.stack;
                            }
                        }
                        else
                        {
                            --bankitem.stack;
                        }

                        if (bankitem.stack <= 0)
                            bankitem.TurnToAir();
                    }
                }

                //if (type1 == null)
                //return;
                if (dosound) SoundEngine.PlaySound(type1, Player.position);
                //Recipe.FindRecipes();
            }

            if (AlchemistNPCRebornAgain.DiscordBuff.JustPressed)
            {
                if (Main.myPlayer == Player.whoAmI && Player.HasBuff(ModContent.BuffType<Buffs.DiscordBuff>()))
                {
                    Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    if (!Collision.SolidCollision(vector2, Player.width, Player.height))
                    {
                        Player.Teleport(vector2, 1, 0);
                        NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)vector2.X, (float)vector2.Y, 1, 0, 0);
                        if (Player.chaosState)
                        {
                            Player.statLife = Player.statLife - Player.statLifeMax2 / 3;
                            PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                            if (Main.rand.Next(2) == 0)
                                damageSource = PlayerDeathReason.ByOther(Player.Male ? 14 : 15);
                            if (Player.statLife <= 0)
                                Player.KillMe(damageSource, 1.0, 0, false);
                            Player.lifeRegenCount = 0;
                            Player.lifeRegenTime = 0;
                        }

                        Player.AddBuff(88, 600, true);
                        Player.AddBuff(164, 60, true);
                    }
                }

                if (Main.myPlayer == Player.whoAmI && Player.HasBuff(ModContent.BuffType<Buffs.TrueDiscordBuff>()))
                {
                    Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    if (!Collision.SolidCollision(vector2, Player.width, Player.height))
                    {
                        Player.Teleport(vector2, 1, 0);
                        NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)vector2.X, (float)vector2.Y, 1, 0, 0);
                        if (Player.chaosState)
                        {
                            Player.statLife = Player.statLife - Player.statLifeMax2 / 7;
                            PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                            if (Main.rand.Next(2) == 0)
                                damageSource = PlayerDeathReason.ByOther(Player.Male ? 14 : 15);
                            if (Player.statLife <= 0)
                                Player.KillMe(damageSource, 1.0, 0, false);
                            Player.lifeRegenCount = 0;
                            Player.lifeRegenTime = 0;
                        }

                        Player.AddBuff(88, 360, true);
                    }
                }
            }
        }
    }
}
