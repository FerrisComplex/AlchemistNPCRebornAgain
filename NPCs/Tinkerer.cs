using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System;
using AlchemistNPCRebornAgain.Extensions;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using AlchemistNPCRebornAgain.Interface;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Tinkerer : ModNPC
    {
        public static bool TubePresent = false;
        public static bool TubePresent2 = false;
        public static bool TubePresent3 = false;
        public static int Shop = 1;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Tinkerer"; }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Names.Alexander"), () => "Alexander");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Names.Peter"), () => "Peter");


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Actions.TinkererButton1"), () => "Sell");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Actions.TinkererButton2"), () => "Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Actions.TinkererButton3"), () => "Reward");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E1"), () => "Do you need something special? Just say if so...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E2"), () => "Have you seen my elder sister yet? She is more Steampunker than Tinkerer...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E3"), () => "If you seen Paper Tube somewhere, bring it to me and I will unlock it for you.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E4"), () => "As you will progress through the world, you may found more valueable things. Counting blueprints for creating rarer accessories.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E5"), () => "You never know where you may get really rare or valueable things. So explore every possible corner with patience.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E6"), () => "If you wil collect every single blueprint, I will give you the special reward.");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.EntryTube.E1"), () => "You don't have any Paper Tubes for selling right now. Go and get some!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Tinkerer.EntryTube.E2"), () => "Here is some money, take it.");


            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Steampunker, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.DyeTrader, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.Tinkerer"))
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
            NPC.defense = 40;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
        }

        public override void ResetEffects()
        {
            TubePresent = false;
            TubePresent2 = false;
            TubePresent3 = false;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (NPC.downedBoss1) return AlchemistNPCRebornAgain.modConfiguration.TinkererSpawn;
            return false;
        }


        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Names.Alexander")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Names.Peter"))
        };

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = 14;
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 16f;
        }

        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            Main.GetItemDrawFrame(ItemID.FlintlockPistol, out Texture2D itemTexture2, out Rectangle itemRectangle2);
            item = itemTexture2;
            itemFrame = itemRectangle2;
            scale = 1;
            horizontalHoldoutOffset = 2;
        }


        public override string GetChat()
        {
            switch (Main.rand.Next(5))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E2"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E3"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E4"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Entry.E5"));
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (AlchemistNPCRebornWorld.foundT1 || AlchemistNPCRebornWorld.foundT2 || AlchemistNPCRebornWorld.foundT3)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Actions.TinkererButton1"));
            }

            button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Actions.TinkererButton2"));
            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == Mod.Find<ModItem>("PaperTube").Type)
                    {
                        TubePresent = true;
                    }

                    if (player.inventory[j].type == Mod.Find<ModItem>("PaperTube2").Type)
                    {
                        TubePresent2 = true;
                    }

                    if (player.inventory[j].type == Mod.Find<ModItem>("PaperTube3").Type)
                    {
                        TubePresent3 = true;
                    }
                }
            }

            if (NPC.downedMoonlord && !AlchemistNPCRebornWorld.foundMP7 && AlchemistNPCRebornWorld.foundT1 && AlchemistNPCRebornWorld.foundT2 && AlchemistNPCRebornWorld.foundT3)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.Actions.TinkererButton3"));
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                if (!TubePresent && !TubePresent2 && !TubePresent3)
                {
                    Main.npcChatText = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.EntryTube.E1"));
                }

                if (NPC.downedMoonlord && !AlchemistNPCRebornWorld.foundMP7 && AlchemistNPCRebornWorld.foundT1 && AlchemistNPCRebornWorld.foundT2 && AlchemistNPCRebornWorld.foundT3)
                {
                    for (int k = 0; k < 255; k++)
                    {
                        Player player = Main.player[k];
                        if (player.active)
                        {
                            var source = Main.player[Main.myPlayer].GetSource_FromAI();
                            player.QuickSpawnItem(source, Mod.Find<ModItem>("MP7").Type);
                        }
                    }
                }
                else if (AlchemistNPCRebornWorld.foundT1 || AlchemistNPCRebornWorld.foundT2 || AlchemistNPCRebornWorld.foundT3)
                {
                    Item[] inventory = Main.player[Main.myPlayer].inventory;
                    for (int k = 0; k < inventory.Length; k++)
                    {
                        if (TubePresent && AlchemistNPCRebornWorld.foundT1)
                        {
                            if (inventory[k].type == Mod.Find<ModItem>("PaperTube").Type && inventory[k].stack > 0)
                            {
                                TubePresent = false;
                                TubePresent2 = false;
                                TubePresent3 = false;
                                inventory[k].stack--;
                                var source = Main.player[Main.myPlayer].GetSource_FromAI();
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.npcChatText = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.EntryTube.E2"));
                            }
                        }
                        else if (TubePresent2 && AlchemistNPCRebornWorld.foundT2)
                        {
                            if (inventory[k].type == Mod.Find<ModItem>("PaperTube2").Type && inventory[k].stack > 0)
                            {
                                TubePresent = false;
                                TubePresent2 = false;
                                TubePresent3 = false;
                                inventory[k].stack--;
                                var source = Main.player[Main.myPlayer].GetSource_FromAI();
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.npcChatText = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.EntryTube.E2"));
                            }
                        }
                        else if (TubePresent3 && AlchemistNPCRebornWorld.foundT3)
                        {
                            if (inventory[k].type == Mod.Find<ModItem>("PaperTube3").Type && inventory[k].stack > 0)
                            {
                                TubePresent = false;
                                TubePresent2 = false;
                                TubePresent3 = false;
                                inventory[k].stack--;
                                var source = Main.player[Main.myPlayer].GetSource_FromAI();
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.player[Main.myPlayer].QuickSpawnItem(source, ItemID.GoldCoin);
                                Main.npcChatText = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Tinkerer.EntryTube.E2"));
                            }
                        }
                    }
                }
            }
            else
            {
                shop = "Shop";
                ShopChangeUIT.visible = true;
            }
        }
        
        public override void AddShops()
        {
            new NPCShop(Type, "Shop").Register(); // empty shop we will fill this with the modifyactiveshop!
        }


        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            int nextSlot = 0;
            if (Shop == 1)
            {
                if (AlchemistNPCRebornWorld.foundAglet)
                {
                    items[nextSlot].type = (ItemID.Aglet);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundAnklet)
                {
                    items[nextSlot].type = (ItemID.AnkletoftheWind);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundClimbingClaws)
                {
                    items[nextSlot].type = (ItemID.ClimbingClaws);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundShoeSpikes)
                {
                    items[nextSlot].type = (ItemID.ShoeSpikes);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundHermesBoots)
                {
                    items[nextSlot].type = (ItemID.HermesBoots);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundWWB)
                {
                    items[nextSlot].type = (ItemID.WaterWalkingBoots);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFlowerBoots)
                {
                    items[nextSlot].type = (ItemID.FlowerBoots);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundIceSkates)
                {
                    items[nextSlot].type = (ItemID.IceSkates);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFlyingCarpet)
                {
                    items[nextSlot].type = (ItemID.FlyingCarpet);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundTabi)
                {
                    items[nextSlot].type = (ItemID.Tabi);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFrogLeg)
                {
                    items[nextSlot].type = (ItemID.FrogLeg);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundJFNeck)
                {
                    items[nextSlot].type = (ItemID.JellyfishNecklace);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFlippers)
                {
                    items[nextSlot].type = (ItemID.Flipper);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundDivingHelmet)
                {
                    items[nextSlot].type = (ItemID.DivingHelmet);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundNeptuneShell)
                {
                    items[nextSlot].type = (ItemID.NeptunesShell);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundHorseshoe)
                {
                    items[nextSlot].type = (ItemID.LuckyHorseshoe);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundBalloon)
                {
                    items[nextSlot].type = (ItemID.ShinyRedBalloon);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundCloud)
                {
                    items[nextSlot].type = (ItemID.CloudinaBottle);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundBlizzard)
                {
                    items[nextSlot].type = (ItemID.BlizzardinaBottle);
                    items[nextSlot].shopCustomPrice = 40000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundSandstorm)
                {
                    items[nextSlot].type = (ItemID.SandstorminaBottle);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundPuffer)
                {
                    items[nextSlot].type = (ItemID.BalloonPufferfish);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundTsunami)
                {
                    items[nextSlot].type = (ItemID.TsunamiInABottle);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundLavaCharm)
                {
                    items[nextSlot].type = (ItemID.LavaCharm);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundCMagnet)
                {
                    items[nextSlot].type = (ItemID.CelestialMagnet);
                    items[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundPMirror)
                {
                    items[nextSlot].type = (ItemID.PocketMirror);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundPStone)
                {
                    items[nextSlot].type = (ItemID.PhilosophersStone);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundHTFL)
                {
                    items[nextSlot].type = (ItemID.HighTestFishingLine);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundAnglerEarring)
                {
                    items[nextSlot].type = (ItemID.AnglerEarring);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundTackleBox)
                {
                    items[nextSlot].type = (ItemID.TackleBox);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundGoldRing)
                {
                    items[nextSlot].type = (ItemID.GoldRing);
                    items[nextSlot].shopCustomPrice = 330000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundLuckyCoin)
                {
                    items[nextSlot].type = (ItemID.LuckyCoin);
                    items[nextSlot].shopCustomPrice = 330000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundDiscountCard)
                {
                    items[nextSlot].type = (ItemID.DiscountCard);
                    items[nextSlot].shopCustomPrice = 330000;
                    nextSlot++;
                }
            }

            if (Shop == 2)
            {
                if (AlchemistNPCRebornWorld.foundString)
                {
                    items[nextSlot].type = (ItemID.WhiteString);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundGreenCW)
                {
                    items[nextSlot].type = (ItemID.GreenCounterweight);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundYoyoGlove)
                {
                    items[nextSlot].type = (ItemID.YoYoGlove);
                    items[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundBlindfold)
                {
                    items[nextSlot].type = (ItemID.Blindfold);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundArmorPolish)
                {
                    items[nextSlot].type = (ItemID.ArmorPolish);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundVitamins)
                {
                    items[nextSlot].type = (ItemID.Vitamins);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundBezoar)
                {
                    items[nextSlot].type = (ItemID.Bezoar);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundAdhesiveBandage)
                {
                    items[nextSlot].type = (ItemID.AdhesiveBandage);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFastClock)
                {
                    items[nextSlot].type = (ItemID.FastClock);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundTrifoldMap)
                {
                    items[nextSlot].type = (ItemID.TrifoldMap);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundMegaphone)
                {
                    items[nextSlot].type = (ItemID.Megaphone);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundNazar)
                {
                    items[nextSlot].type = (ItemID.Nazar);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundSorcE)
                {
                    items[nextSlot].type = (ItemID.SorcererEmblem);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundWE)
                {
                    items[nextSlot].type = (ItemID.WarriorEmblem);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundRE)
                {
                    items[nextSlot].type = (ItemID.RangerEmblem);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundSumE)
                {
                    items[nextSlot].type = (ItemID.SummonerEmblem);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFeralClaw)
                {
                    items[nextSlot].type = (ItemID.FeralClaws);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundTitanGlove)
                {
                    items[nextSlot].type = (ItemID.TitanGlove);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundMagmaStone)
                {
                    items[nextSlot].type = (ItemID.MagmaStone);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundSharkTooth)
                {
                    items[nextSlot].type = (ItemID.SharkToothNecklace);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundBlackBelt)
                {
                    items[nextSlot].type = (ItemID.BlackBelt);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundMoonCharm)
                {
                    items[nextSlot].type = (ItemID.MoonCharm);
                    items[nextSlot].shopCustomPrice = 300000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundSunStone)
                {
                    items[nextSlot].type = (ItemID.SunStone);
                    items[nextSlot].shopCustomPrice = 350000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundMoonStone)
                {
                    items[nextSlot].type = (ItemID.MoonStone);
                    items[nextSlot].shopCustomPrice = 350000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundRifleScope)
                {
                    items[nextSlot].type = (ItemID.RifleScope);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundCobaltShield)
                {
                    items[nextSlot].type = (ItemID.CobaltShield);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundPaladinShield)
                {
                    items[nextSlot].type = (ItemID.PaladinsShield);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFrozenTurtleShell)
                {
                    items[nextSlot].type = (ItemID.FrozenTurtleShell);
                    items[nextSlot].shopCustomPrice = 350000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundPutridScent)
                {
                    items[nextSlot].type = (ItemID.PutridScent);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundFleshKnuckles)
                {
                    items[nextSlot].type = (ItemID.FleshKnuckles);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundMagicQuiver)
                {
                    items[nextSlot].type = (ItemID.MagicQuiver);
                    items[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundPanicNecklace)
                {
                    items[nextSlot].type = (ItemID.PanicNecklace);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundCrossNecklace)
                {
                    items[nextSlot].type = (ItemID.CrossNecklace);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundStarCloak)
                {
                    items[nextSlot].type = (ItemID.StarCloak);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundObsidianRose)
                {
                    items[nextSlot].type = (ItemID.ObsidianRose);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundShackle)
                {
                    items[nextSlot].type = (ItemID.Shackle);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundHerculesBeetle)
                {
                    items[nextSlot].type = (ItemID.HerculesBeetle);
                    items[nextSlot].shopCustomPrice = 330000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundPygmyNecklace)
                {
                    items[nextSlot].type = (ItemID.PygmyNecklace);
                    items[nextSlot].shopCustomPrice = 330000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.foundNecromanticScroll)
                {
                    items[nextSlot].type = (ItemID.NecromanticScroll);
                    items[nextSlot].shopCustomPrice = 330000;
                    nextSlot++;
                }
            }

            if (Shop == 3)
            {
                if (Main.hardMode)
                {
                    items[nextSlot].type = (Mod.Find<ModItem>("MenacingToken").Type);
                    nextSlot++;
                    items[nextSlot].type = (Mod.Find<ModItem>("LuckyToken").Type);
                    nextSlot++;
                    items[nextSlot].type = (Mod.Find<ModItem>("ViolentToken").Type);
                    nextSlot++;
                    items[nextSlot].type = (Mod.Find<ModItem>("WardingToken").Type);
                    nextSlot++;
                }
            }
        }
    }
}
