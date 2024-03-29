using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using AlchemistNPCRebornAgain.NPCs;
using AlchemistNPCRebornAgain;
using Terraria.Localization;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using AlchemistNPCRebornAgain.Interface;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Brewer : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool Shop21 = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public override string Texture
        {
            get
            {
                return "AlchemistNPCRebornAgain/NPCs/Brewer";
            }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.ShopB1"), () => "1st shop Vanilla");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.ShopB2"), () => "2nd shop (AlchemistNPC Mod)");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.ShopB21"), () => "3rd shop (CalamityMod)");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.ShopB3"), () => "4th shop (ThoriumMod)");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.ShopsChanger"), () => "Shops Changer");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Names.Lillian"), () => "Lillian");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Names.Lucy"), () => "Lucy");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Names.Alice"), () => "Alice");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Names.Rocksahn"), () => "Rocksahn");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Names.Agness"), () => "Agness");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Names.Mary"), () => "Mary");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B1"), () => "Care to try this potion? It's supposed to grant wings.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B2"), () => "I don't think that was a Spelunker potion...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B3"), () => "I got my degrees in Riddle University.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B4"), () => "There's a legendary yoyo known as the Sasscade.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B5"), () => "Aww, bread crumbs and beaver spit!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B6"), () => "Hi, *cough* that wasn't an Inferno potion!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B7"), () => "Have you seen two mechanical eyes around?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B8"), () => "That silly goose ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B9"), () => " is too afraid of using occult powers in Alchemy. And so his potions are just some useless water.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B10"), () => "*sneezes* Eww... I always sneeze while these Goblins are around!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B11"), () => "Just don't let them in my house... There are so many needed supplies and instruments.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B12"), () => "Is this a Martians Invasion? Are they going to enslave us all? Or they want to destroy us all? No one knows the answer...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B13"), () => "Is it Blood Moon in the sky? I love it! It is so beautiful!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B14"), () => "I was born under the light of Blood Moon. I am always so excited when IT appears!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B15"), () => "Yeah, I can understand why the other girls are annoyed, but that's not stopping me!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B16"), () => "As happy as I am, I'm not giving discounts - I'm not dumb.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B17"), () => "Normally I'm confused with how ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B18"), () => " is just as calm as I am, but then I remember ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Brewer.Text.B19"), () => "I once traveled far away from Terraria to learn more about Alchemy. In my travels I met a ''scientist of magic'' called Azanor. He showed me the secrets of something called ''thaumaturgy''.");
            
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers{ Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<YoungBrewer>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection<Alchemist>(AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.WitchDoctor,AffectionLevel.Dislike);
        }
		
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.Brewer"))
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
            NPC.defense = 100;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Mechanic;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (NPC.downedBoss1 && AlchemistNPCRebornAgain.modConfiguration.BrewerSpawn)
                return true;
            
            return false;
        }
        

        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Names.Lillian")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Names.Lucy")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Names.Alice")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Names.Rocksahn")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Names.Agness")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Names.Mary"))
        };

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 10;
            }
            if (!NPC.downedMoonlord && Main.hardMode)
            {
                damage = 25;
            }
            if (NPC.downedMoonlord)
            {
                damage = 100;
            }
            knockback = 8f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (NPC.downedMoonlord)
            {
                projType = ModContent.ProjectileType<Projectiles.CorrosiveFlask>();
            }
            else
            {
                projType = ProjectileID.ToxicFlask;
            }
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 1f;
        }


        public override string GetChat()
        {
            int Alchemist = NPC.FindFirstNPC(ModContent.NPCType<Alchemist>());
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (Main.bloodMoon && partyGirl >= 0 && Alchemist >= 0 && Main.rand.Next(4) == 0)
            {
                
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B17")) + Main.npc[partyGirl].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B18")) + Main.npc[Alchemist].GivenName + ".";
            }
            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B13"));
                    case 1:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B14"));
                    case 2:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B15"));
                    case 3:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B16"));
                }
            }
            if (Main.invasionType == 1)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B10"));
            }
            if (Main.invasionType == 3)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B11"));
            }
            if (Main.invasionType == 4)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B12"));
            }
            if (Alchemist >= 0 && Main.rand.Next(4) == 0)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B8")) + Main.npc[Alchemist].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B9"));
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B2"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B3"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B4"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B5"));
                case 5:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B6"));
                case 6:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B19"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.Text.B7"));
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {

            

            if (Shop1)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.ShopB1"));
            }
            if (Shop2)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.ShopB2"));
            }
            if (Shop21)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.ShopB21"));
            }
            if (Shop3)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.ShopB3"));
            }
            if (NPC.FindBuffIndex(119) >= 0 && NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && !NPC.AnyNPCs(ModContent.NPCType<YoungBrewer>()))
            {
                button2 = "???";
            }
            else
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Brewer.ShopsChanger"));
            }
        }
        
        public override void AddShops()
        {
            new NPCShop(Type, "Shop").Register(); // empty shop we will fill this with the modifyactiveshop!
        }

        private static void addModItemToShop(Mod sourceMod, string id, int cost, ref Item[] items, ref int nextSlot)
        {
            if (ExternalModCache.GetOrCreateModItem(sourceMod, id, out var item) && item != null)
            {
                items[nextSlot].type = (item.Type);
                items[nextSlot].shopCustomPrice = cost;
                nextSlot += 1;
            }
        }


        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Shop";
                ShopChangeUI.visible = false;
            }
            else
            {
                if (NPC.HasBuff(119) && NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && !NPC.AnyNPCs(ModContent.NPCType<YoungBrewer>()))
                {
                    for (int k = 0; k < 255; k++)
                    {
                        Player player = Main.player[k];
                        if (player.active)
                        {
                            NPC.SpawnOnPlayer(k, ModContent.NPCType<YoungBrewer>());
                            return;
                        }
                    }
                }
                if(!ShopChangeUI.visible) ShopChangeUI.timeStart = Main.GameUpdateCount;
                ShopChangeUI.visible = true;
            }
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
        public bool SacredToolsDownedAbaddon
        {
        	get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }

        public bool SacredToolsDownedSerpent
        {
        	get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }

        public bool SacredToolsDownedLunarians
        {
        	get { return SacredTools.ModdedWorld.downedLunarians; }
        }
		*/
        private bool CalamityModRevengeance
        {
            get {
                if(ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)) {
                    return (bool)calamityMod.Call("GetDifficultyActive", "revengeance");
                }
                return false;
            }
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            int nextSlot = 0;
            if (Shop1)
            {
                items[nextSlot].type = (ItemID.SwiftnessPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.IronskinPotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.RegenerationPotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.MiningPotion);
                items[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                items[nextSlot].type = (ItemID.BuilderPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.ArcheryPotion);
                items[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                items[nextSlot].type = (ItemID.SummoningPotion);
                items[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                items[nextSlot].type = (ItemID.EndurancePotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.HeartreachPotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.AmmoReservationPotion);
                items[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                items[nextSlot].type = (ItemID.ThornsPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.ShinePotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.NightOwlPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.WarmthPotion);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                items[nextSlot].type = (ItemID.SpelunkerPotion);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                items[nextSlot].type = (ItemID.HunterPotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.TrapsightPotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.FlipperPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.GillsPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.InvisibilityPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.WaterWalkingPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.ObsidianSkinPotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.FeatherfallPotion);
                items[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                items[nextSlot].type = (ItemID.GravitationPotion);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                items[nextSlot].type = (ItemID.MagicPowerPotion);
                items[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                items[nextSlot].type = (ItemID.ManaRegenerationPotion);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                items[nextSlot].type = (ItemID.TitanPotion);
                items[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                items[nextSlot].type = (ItemID.BattlePotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.CalmingPotion);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.LifeforcePotion);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.InfernoPotion);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ItemID.WrathPotion);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.RagePotion);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }
                items[nextSlot].type = (ItemID.StinkPotion);
                items[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.LovePotion);
                    items[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                }
                if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
                {
                    items[nextSlot].type = (ItemID.FishingPotion);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.SonarPotion);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.CratePotion);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }
                items[nextSlot].type = (ItemID.GenderChangePotion);
                items[nextSlot].shopCustomPrice = 100000;
                nextSlot++;
            }
            if (Shop2)
            {
                items[nextSlot].type = (ModContent.ItemType<Items.SunshinePotion>());
                items[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.Dopamine>());
                items[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.GreaterDangersensePotion>());
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.NatureBlessingPotion>());
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.BewitchingPotion>());
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ModContent.ItemType<Items.FortitudePotion>());
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.InvincibilityPotion>());
                        items[nextSlot].shopCustomPrice = 30000;
                        nextSlot++;
                        items[nextSlot].type = (ModContent.ItemType<Items.TitanSkinPotion>());
                        items[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        if (ModLoader.GetMod("CalamityMod") != null)
                        {
                            if (CalamityModRevengeance)
                            {
                            items[nextSlot].type =  (ModContent.ItemType<Items.HeartAttackPotion>());
                            items[nextSlot].shopCustomPrice = 250000;
                            nextSlot++;
                            }
                        }
                        if (NPC.downedMechBossAny && !NPC.downedMoonlord)
                        {
                            items[nextSlot].type = (ModContent.ItemType<Items.DiscordPotion>());
                            items[nextSlot].shopCustomPrice = 200000;
                            nextSlot++;
                        }
                        if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                        {
                            items[nextSlot].type = (ModContent.ItemType<Items.BlurringPotion>());
                            items[nextSlot].shopCustomPrice = 150000;
                            nextSlot++;
                            if (NPC.downedPlantBoss)
                            {
                                items[nextSlot].type = (ModContent.ItemType<Items.NinjaPotion>());
                                items[nextSlot].shopCustomPrice = 75000;
                                nextSlot++;
                            }
                            if (NPC.downedGolemBoss)
                            {
                                items[nextSlot].type = (ModContent.ItemType<Items.TrapsPotion>());
                                items[nextSlot].shopCustomPrice = 50000;
                                nextSlot++;
                            }
                        }
                    }
                }
                
            }
            if (Shop21)
            {
                
                if (ExternalModCache.findMod("CalamityMod", out var Calamity) && Calamity != null)
                {
                    
                    addModItemToShop(Calamity, "BoundingPotion", 20000, ref items, ref nextSlot);
                    addModItemToShop(Calamity, "CalciumPotion", 35000, ref items, ref nextSlot);
                    addModItemToShop(Calamity, "TriumphPotion", 30000, ref items, ref nextSlot);
                    addModItemToShop(Calamity, "TeslaPotion", 25000, ref items, ref nextSlot);
                    addModItemToShop(Calamity, "SulphurskinPotion", 15000, ref items, ref nextSlot);
                    if (NPC.downedBoss3)
                    {
                        addModItemToShop(Calamity, "PotionofOmniscience", 20000, ref items, ref nextSlot);
                        if (NPC.downedPlantBoss)
                        {
                            addModItemToShop(Calamity, "ZergPotion", 30000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "ZenPotion", 30000, ref items, ref nextSlot);
                        }
                        addModItemToShop(Calamity, "YharimsStimulants", 100000, ref items, ref nextSlot);
                        if (Main.hardMode)
                        {
                            addModItemToShop(Calamity, "CrumblingPotion", 50000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "PhotosynthesisPotion", 50000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "SoaringPotion", 40000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "CadancePotion", 40000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "FabsolsVodka", 100000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "RevivifyPotion", 50000, ref items, ref nextSlot);
                            if ((bool)Calamity.Call("Downed", "astrum aureus"))
                            {
                                addModItemToShop(Calamity, "AstralInjection", 10000, ref items, ref nextSlot);
                                addModItemToShop(Calamity, "GravityNormalizerPotion", 30000, ref items, ref nextSlot);
                            }
                            if (NPC.downedPlantBoss)
                            {
                                addModItemToShop(Calamity, "PenumbraPotion", 100000, ref items, ref nextSlot);
                            }
                            if (NPC.downedGolemBoss)
                            {
                                addModItemToShop(Calamity, "TitanScalePotion", 40000, ref items, ref nextSlot);
                                addModItemToShop(Calamity, "ShatteringPotion", 100000, ref items, ref nextSlot);
                            }
                            if (NPC.downedMoonlord)
                            {
                                addModItemToShop(Calamity, "HolyWrathPotion", 100000, ref items, ref nextSlot);
                                addModItemToShop(Calamity, "ProfanedRagePotion", 100000, ref items, ref nextSlot);
                            }
                            if ((bool)Calamity.Call("Downed", "polterghast"))
                            {
                                addModItemToShop(Calamity, "CeaselessHungerPotion", 25000, ref items, ref nextSlot);
                            }
                            if ((bool)Calamity.Call("Downed", "yharon"))
                            {
                                addModItemToShop(Calamity, "DraconicElixir", 250000, ref items, ref nextSlot);
                            }
                        }
                    }
                }
            }
            if (Shop3)
            {
                if (ExternalModCache.findMod("ThoriumMod", out var ThoriumMod) && ThoriumMod != null)
                {
                	if (NPC.downedBoss3)
                	{
                		addModItemToShop(ThoriumMod, "CreativityPotion", 10000, ref items, ref nextSlot);
                		addModItemToShop(ThoriumMod, "EarwormPotion", 10000, ref items, ref nextSlot);
                		addModItemToShop(ThoriumMod, "AssassinPotion", 10000, ref items, ref nextSlot);
                	}
                	if (Main.hardMode)
                	{
                		addModItemToShop(ThoriumMod, "InspirationReachPotion", 20000, ref items, ref nextSlot);
                	}
                	addModItemToShop(ThoriumMod, "GlowingPotion", 20000, ref items, ref nextSlot);
                	if (Main.hardMode)
                	{
                		addModItemToShop(ThoriumMod, "HolyPotion", 20000, ref items, ref nextSlot);
                		addModItemToShop(ThoriumMod, "DashPotion", 20000, ref items, ref nextSlot);
                	}
                	addModItemToShop(ThoriumMod, "HydrationPotion", 10000, ref items, ref nextSlot);
                	addModItemToShop(ThoriumMod, "BloodPotion", 10000, ref items, ref nextSlot);
                	addModItemToShop(ThoriumMod, "ConflagrationPotion", 10000, ref items, ref nextSlot);
                	addModItemToShop(ThoriumMod, "SilverTonguePotion", 20000, ref items, ref nextSlot);
                	addModItemToShop(ThoriumMod, "AquaPotion", 10000, ref items, ref nextSlot);
                	addModItemToShop(ThoriumMod, "FrenzyPotion", 20000, ref items, ref nextSlot);
                }
            }
            if (Shop4)
            {
				
			}
        }
    }
}
