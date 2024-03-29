using System;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Jeweler : ModNPC
    {
        public static bool OH = false;
        public static bool SN = false;
        public static bool SN2 = false;
        public static bool SN3 = false;
        public static bool AS = false;
        public static bool TN1 = false;
        public static bool TN2 = false;
        public static bool TN3 = false;
        public static bool TN4 = false;
        public static bool TN5 = false;
        public static bool TN6 = false;
        public static bool TN7 = false;
        public static bool TN8 = false;
        public static bool TN9 = false;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Jeweler"; }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -2;

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Names.Carl"), () => "Carl");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Names.John"), () => "John");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Names.JanMare"), () => "JanMare");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Names.LuiFransua"), () => "LuiFransua");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Names.Daniel"), () => "Daniel");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Names.Charley"), () => "Charley");


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Actions.ArenaShop"), () => "Arena Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Actions.Combine"), () => "Combine notes");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A1"), () => "I found some gems for selling. Would you check them?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A2"), () => "Magic rings are not as powerful as Legendary Emblems, but still can give you some advantage against powerful creatures.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A3"), () => "Ouch... what do you want, my friend?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A4"), () => "I can make a Diamond Ring for you.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A5"), () => "No, don't think that I somehow related to Skeleton Merchant.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A6"), () => "If you somehow find all Magic Rings,then you could make the Omniring.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A7"), () => "Have you seen Mechanical Creatures?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A8"), () => "Did you notice that ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A9"), () => " and I looks almost the same? It's because we're twin brothers.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Jewler.Text.A10"), () => "Should you find enought of those torn notes, bring the to me and ill decipher them for you. Dont ask me why, just know that they hold a value for me.");


            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Merchant, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.Jeweler"))
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
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (NPC.downedBoss1 && AlchemistNPCRebornAgain.modConfiguration.JewelerSpawn)
                return true;
            return false;
        }


        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Names.Carl")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Names.John")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Names.JanMare")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Names.LuiFransua")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Names.Daniel")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Names.Charley"))
        };

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 20;
            }

            if (Main.hardMode && !NPC.downedMoonlord)
            {
                damage = 100;
            }

            if (NPC.downedMoonlord)
            {
                damage = 1000;
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
            projType = ModContent.ProjectileType<Projectiles.Gemstone>();
            attackDelay = 3;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 0f;
        }


        public override string GetChat()
        {
            int Merchant = NPC.FindFirstNPC(NPCID.Merchant);
            if (Merchant >= 0 && Main.rand.NextBool(5))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A8")) + Main.npc[Merchant].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A9"));
            }

            if (ExternalModCache.findMod("ThoriumMod", out var thorium) && thorium != null)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A2"));
                    case 1:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A7"));
                }
            }

            switch (Main.rand.Next(6))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A3"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A4"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A5"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A10"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Text.A7"));
            }
        }

        public override void ResetEffects()
        {
            SN = false;
            SN2 = false;
            SN3 = false;
            AS = false;
            TN1 = false;
            TN2 = false;
            TN3 = false;
            TN4 = false;
            TN5 = false;
            TN6 = false;
            TN7 = false;
            TN8 = false;
            TN9 = false;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Actions.ArenaShop"));
            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.SecretNote>())
                    {
                        SN = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.SecretNote2>())
                    {
                        SN2 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.SecretNote3>())
                    {
                        SN3 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote1>())
                    {
                        TN1 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote2>())
                    {
                        TN2 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote3>())
                    {
                        TN3 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote4>())
                    {
                        TN4 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote5>())
                    {
                        TN5 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote6>())
                    {
                        TN6 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote7>())
                    {
                        TN7 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote8>())
                    {
                        TN8 = true;
                    }

                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote9>())
                    {
                        TN9 = true;
                    }

                    if (TN1 && TN2 && TN3 && !SN)
                    {
                        button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Actions.Combine"));
                    }

                    if (TN4 && TN5 && TN6 && !SN2)
                    {
                        button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Actions.Combine"));
                    }

                    if (TN7 && TN8 && TN9 && !SN3)
                    {
                        button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Actions.Combine"));
                    }

                    if (SN && SN2 && SN3)
                    {
                        button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Jewler.Actions.Combine"));
                    }
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                OH = true;
                AS = false;
                shop = "Shop";
            }
            else
            {
                Player player = Main.player[Main.myPlayer];
                var source = NPC.GetSource_FromAI();
                if (TN1 && TN2 && TN3 && !SN)
                {
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Notes.SecretNote>());
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.TornNote1>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote1>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote2>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote3>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }

                if (TN4 && TN5 && TN6 && !SN2)
                {
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Notes.SecretNote2>());
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.TornNote4>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote4>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote5>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote6>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }

                if (TN7 && TN8 && TN9 && !SN3)
                {
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Notes.SecretNote3>());
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.TornNote7>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote7>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote8>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote9>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }

                if (SN && SN2 && SN3)
                {
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Summoning.NotesBook>());
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.SecretNote>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.SecretNote>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.SecretNote2>())
                            {
                                inventory[k].stack--;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.SecretNote3>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }

                OH = false;
                AS = true;
                shop = "Shop";
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

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            int nextSlot = 0;
            if (OH)
            {
                items[nextSlot].type = (ItemID.Amethyst);
                items[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Topaz);
                items[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.Sapphire);
                    items[nextSlot].shopCustomPrice = 3000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Emerald);
                    items[nextSlot].shopCustomPrice = 3000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Amber);
                    items[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FossilOre);
                    items[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;

                    if (ExternalModCache.findMod("ThoriumMod", out var thoriumMod) && thoriumMod != null)
                    {
                        addModItemToShop(thoriumMod, "Opal", 5000, ref items, ref nextSlot);
                        addModItemToShop(thoriumMod, "Onyx", 5000, ref items, ref nextSlot);
                    }

                    items[nextSlot].type = (ItemID.BandofStarpower);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.BandofRegeneration);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    if (Main.netMode == 1 || Main.netMode == 2)
                    {
                        items[nextSlot].type = (ItemID.LifeCrystal);
                        items[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedGolemBoss)
                        {
                            items[nextSlot].type = (ItemID.LifeFruit);
                            items[nextSlot].shopCustomPrice = 200000;
                            nextSlot++;
                        }
                    }
                }

                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ItemID.Ruby);
                    items[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Diamond);
                    items[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.DiamondRing);
                    items[nextSlot].shopCustomPrice = 2000000;
                    nextSlot++;
                    items[nextSlot].type = (ModContent.ItemType<Items.Summoning.HorrifyingSkull>());
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;

                    if (ExternalModCache.findMod("Tremor", out var tremorMod) && tremorMod != null)
                    {
                        addModItemToShop(tremorMod, "Rupicide", 5000, ref items, ref nextSlot);
                        addModItemToShop(tremorMod, "Opal", 30000, ref items, ref nextSlot);
                        if (Main.hardMode)
                        {
                            addModItemToShop(tremorMod, "MagiumShard", 7500, ref items, ref nextSlot);
                            addModItemToShop(tremorMod, "RuneBar", 7500, ref items, ref nextSlot);
                        }

                        if (NPC.downedMoonlord)
                        {
                            addModItemToShop(tremorMod, "LapisLazuli", 150000, ref items, ref nextSlot);
                        }
                    }

                    if (ExternalModCache.findMod("ThoriumMod", out var thoriumMod) && thoriumMod != null)
                    {
                        addModItemToShop(thoriumMod, "GraniteEnergyCore", 10000, ref items, ref nextSlot);
                        addModItemToShop(thoriumMod, "BronzeFragments", 10000, ref items, ref nextSlot);
                    }

                    if (ExternalModCache.findMod("SpiritMod", out var spiritMod) && spiritMod != null)
                    {
                        addModItemToShop(spiritMod, "GraniteChunk", 10000, ref items, ref nextSlot);
                        addModItemToShop(spiritMod, "MarbleChunk", 10000, ref items, ref nextSlot);
                    }

                    if (Main.hardMode)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.Summoning.AlchemistHorcrux>());
                        items[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        items[nextSlot].type = (ModContent.ItemType<Items.Summoning.BrewerHorcrux>());
                        items[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        items[nextSlot].type = (ModContent.ItemType<Items.Summoning.JewelerHorcrux>());
                        items[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        items[nextSlot].type = (ModContent.ItemType<Items.Summoning.ArchitectHorcrux>());
                        items[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        items[nextSlot].type = (ModContent.ItemType<Items.Summoning.TinkererHorcrux>());
                        items[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        items[nextSlot].type = (ModContent.ItemType<Items.Summoning.MusicianHorcrux>());
                        items[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                    }
                }
            }

            if (AS)
            {
                items[nextSlot].type = (ItemID.Campfire);
                items[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                if (NPC.downedBoss2)
                {

                    if (ExternalModCache.findMod("ThoriumMod", out var thoriumMod) && thoriumMod != null)
                    {
                        addModItemToShop(thoriumMod, "Mistletoe", 50000, ref items, ref nextSlot);
                    }

                    items[nextSlot].type = (ItemID.SliceOfCake);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ItemID.WaterBucket);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.HoneyBucket);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.LavaBucket);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.HeartLantern);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.StarinaBottle);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.WaterCandle);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.PeaceCandle);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    if (NPC.downedPlantBoss && ExternalModCache.findMod("CalamityMod", out var calamityMod) && calamityMod != null)
                    {
                        addModItemToShop(calamityMod, "TranquilityCandle", 100000, ref items, ref nextSlot);
                        addModItemToShop(calamityMod, "ChaosCandle", 150000, ref items, ref nextSlot);
                    }

                    items[nextSlot].type = (ItemID.Spike);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.DartTrap);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.GeyserTrap);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.CatBast);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.SharpeningStation);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.BewitchingTable);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.AmmoBox);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        items[nextSlot].type = (ItemID.CrystalBall);
                        items[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        items[nextSlot].type = (ModContent.ItemType<Items.UltimaCake>());
                        items[nextSlot].shopCustomPrice = 5000000;
                        nextSlot++;
                    }

                    if (NPC.downedGolemBoss)
                    {
                        items[nextSlot].type = (ItemID.WoodenSpike);
                        items[nextSlot].shopCustomPrice = 20000;
                        nextSlot++;
                        items[nextSlot].type = (ItemID.SpearTrap);
                        items[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        items[nextSlot].type = (ItemID.SpikyBallTrap);
                        items[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        items[nextSlot].type = (ItemID.SuperDartTrap);
                        items[nextSlot].shopCustomPrice = 750000;
                        nextSlot++;
                        items[nextSlot].type = (ItemID.FlameTrap);
                        items[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                    }
                }
            }
        }
    }
}
