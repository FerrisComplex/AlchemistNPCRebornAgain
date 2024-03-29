using System;
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
    public class YoungBrewer : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/YoungBrewer"; }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 2;


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Harold"), () => "Harold");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Charles"), () => "Charles");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Monty"), () => "Monty");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Lucas"), () => "Lucas");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Porky"), () => "Porky");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Leeland"), () => "Leeland");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Atreus"), () => "Atreus");


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E1"), () => "I'm trading potions which were made by my parents.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E2"), () => "I have some potions I can sell to you.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E3"), () => "Although, the Battle Combination was my idea.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E4"), () => "There's a legendary yoyo known as the Sasscade.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E5"), () => "Strange Brew from Skeleton Merchant smells really terrible, but Mana Restoration effect is awesome.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E6"), () => "Hi, *cough*.. That definetly wasn't a lemonade.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E7"), () => "Have you seen a Mechanical Worm around?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E8"), () => "My mom, ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E9"), () => ", is the coolest brewer ever, isn't she? She can brew the hardest potions with ease.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E10"), () => "Certain combinations can only be brewed if certain types of magic are present in the world.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E11"), () => "You might be wondering how do i put actual rainbows in a flask... Well, with the power of maaagic...... and eternal sufferings.");


            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<DesertBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<Brewer>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection<Alchemist>(AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.YoungBrewer"))
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
            AnimationType = NPCID.Angler;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (Main.hardMode && AlchemistNPCRebornAgain.modConfiguration.YoungBrewerSpawn)
            {
                if (NPC.AnyNPCs(ModContent.NPCType<Brewer>()))
                {
                    if (NPC.AnyNPCs(ModContent.NPCType<Alchemist>()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Harold")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Charles")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Monty")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Lucas")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Porky")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Leeland")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Names.Atreus"))
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
                projType = Mod.Find<ModProjectile>("CorrosiveFlask").Type;
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
            randomOffset = 2f;
        }


        public override string GetChat()
        {
            int Brewer = NPC.FindFirstNPC(ModContent.NPCType<Brewer>());
            if (Brewer >= 0 && Main.rand.Next(4) == 0)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E8")) + Main.npc[Brewer].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E9"));
            }

            if (NPC.downedMoonlord && Main.rand.NextBool(10))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E8")) + Main.npc[Brewer].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E9"));
            }

            switch (Main.rand.Next(8))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E2"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E3"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E4"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E5"));
                case 5:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E6"));
                case 6:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E10"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.YoungBrewer.Chat.E7"));
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Combinations";
            button2 = "Flasks";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                Shop1 = true;
                Shop2 = false;
                shop = "Shop";
            }
            else
            {
                Shop2 = true;
                Shop1 = false;
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
            if (Shop1)
            {
                items[nextSlot].type = (ModContent.ItemType<Items.VanTankCombination>());
                items[nextSlot].shopCustomPrice = 90000;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.TankCombination>());
                    items[nextSlot].shopCustomPrice = 160000;
                    nextSlot++;
                }

                items[nextSlot].type = (ModContent.ItemType<Items.BattleCombination>());
                items[nextSlot].shopCustomPrice = 120000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.RangerCombination>());
                items[nextSlot].shopCustomPrice = 75000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.MageCombination>());
                items[nextSlot].shopCustomPrice = 90000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.BuilderCombination>());
                items[nextSlot].shopCustomPrice = 35000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.ExplorerCombination>());
                items[nextSlot].shopCustomPrice = 80000;
                nextSlot++;
                items[nextSlot].type = (ModContent.ItemType<Items.SummonerCombination>());
                items[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.FishingCombination>());
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }
                
                ExternalModCache.findMod("ThoriumMod", out var thoriumMod);
                ExternalModCache.findMod("CalamityMod", out var calamityMod);


                if (thoriumMod != null && NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.ThoriumCombination>());
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }


                if (calamityMod != null && NPC.downedGolemBoss)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.CalamityCombination>());
                    items[nextSlot].shopCustomPrice = 350000;
                    nextSlot++;
                }

                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("MorePotions") != null)
                {
                    if (Main.hardMode)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.MorePotionsCombination>());
                        items[nextSlot].shopCustomPrice = 500000;
                        nextSlot++;
                    }
                }
                if (ModLoader.GetMod("SpiritMod") != null)
                {
                    if (NPC.downedMechBossAny)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.SpiritCombination>());
                        items[nextSlot].shopCustomPrice = 250000;
                        nextSlot++;
                    }
                }
                */
                if (NPC.downedMoonlord)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.UniversalCombination>());
                    items[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                }

                // IMPLEMENT WHEN WEAKREFERENCES FIXED

                if (thoriumMod != null)
                {
                }

                if (NPC.downedBoss3)
                {
                    addModItemToShop(thoriumMod, "FrostCoatingItem", 5000, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "ExplosiveCoatingItem", 5000, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "GorganCoatingItem", 5000, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "SporeCoatingItem", 2500, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "ToxicCoatingItem", 2500, ref items, ref nextSlot);
                }

                if (Main.hardMode)
                {
                    addModItemToShop(thoriumMod, "GasContainer", 250, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "CorrosionBeaker", 250, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "CombustionFlask", 250, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "NitrogenVial", 250, ref items, ref nextSlot);
                    addModItemToShop(thoriumMod, "AphrodisiacVial", 250, ref items, ref nextSlot);

                    if (NPC.downedPlantBoss)
                    {
                        addModItemToShop(thoriumMod, "PlasmaVial", 350, ref items, ref nextSlot);
                    }
                }
            }

            if (Shop2)
            {
                if (NPC.downedQueenBee)
                {
                    items[nextSlot].type = (ItemID.FlaskofPoison);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FlaskofFire);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FlaskofParty);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.FlaskofGold);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FlaskofIchor);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FlaskofCursedFlames);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }

                if (NPC.downedPlantBoss)
                {
                    items[nextSlot].type = (ItemID.FlaskofVenom);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FlaskofNanites);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                bool done = false;
                for (int k = 0; k < 255; k++)
                {
                    if (done) break;
                    Player player = Main.player[k];
                    if (player.active)
                    {
                        for (int j = 0; j < player.inventory.Length; j++)
                        {
                            if (player.inventory[j].type == Mod.Find<ModItem>("WatcherAmulet").Type)
                            {
                                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPC").Find<ModItem>("RainbowFlask").Type);
                                items[nextSlot].shopCustomPrice = 1000000;
                                nextSlot++;
                                done = true;
                                break;
                            }

                            if (player.inventory[j].type == Mod.Find<ModItem>("Autoinjector").Type)
                            {
                                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPC").Find<ModItem>("RainbowFlask").Type);
                                items[nextSlot].shopCustomPrice = 1000000;
                                done = true;
                                break;
                            }
                        }
                    }
                }
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("AAMod") != null)
                {
                    if (Main.hardMode)
                    {
                        addModItemToShop(AAMod, "DragonfireFlask", 20000, ref shop, ref nextSlot);
                        addModItemToShop(AAMod, "HydratoxinFlask", 20000, ref shop, ref nextSlot);
                    }
                }
                if (ModLoader.GetMod("SpiritMod") != null)
                {
                    if (Main.hardMode)
                    {
                        addModItemToShop(SpiritMod, "AcidVial", 30000, ref shop, ref nextSlot);
                    }
                }
                */


                if (ExternalModCache.findMod("CalamityMod", out var calamityMod) && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    addModItemToShop(calamityMod, "CalamitasBrew", 50000, ref items, ref nextSlot);
                }
            }
        }
    }
}
