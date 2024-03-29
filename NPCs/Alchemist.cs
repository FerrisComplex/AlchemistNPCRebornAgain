using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;
using Terraria.Localization;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Alchemist : ModNPC
    {
        public static bool baseShop = false;
        public static bool plantShop = false;
        public static bool PS = false;
        public static bool AB = false;
        public static bool LE = false;
        public static bool Tantrum = false;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Alchemist"; }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 2;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 22;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.PlantsShop"), () => "Plants shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.GetCharm"), () => "Get Charm");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.Edward"), () => "Edward");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.Severus"), () => "Severus");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.Horace"), () => "Horace");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.Tilyorn"), () => "Tilyorn");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.Nicolas"), () => "Nicolas");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.Gregg"), () => "Gregg");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.BrewElixir"), () => "Brew Life Elixer");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA1"), () => "My Healing potions will cure your deepest wounds.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA2"), () => "My Mana potions will restore your magic power.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA3"), () => "Restoration potions... I'm not sure if I trust them...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA4"), () => "There's a legendary yoyo known as the Sasscade.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA5"), () => "The Strange Brew I bought from the Skeleton Merchant smells awful, but its Mana Restoration effect is awesome!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA6"), () => "Hi, *cough*... That definitely wasn't a Teleporation potion.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA7"), () => "Have you seen any Mechanical Skulls around?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA8"), () => "Have you ever heard of Ultra Mushroom? If you find one, I do believe I got some stuff to aid you in boosting that thing.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA9"), () => "I asked ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA10"), () => " if I could buy the recipe for the Potent Extract. He said no because, and I quote, ''Even an idiot would figure it out.''");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA11"), () => "And to think, she's getting the potions and not me... but I can't argue there.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA12"), () => "What is his name? ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA13"), () => "? So... Teacher's here? Better step up my game!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA14"), () => "Thank goodness I got those pieces from Skeletron. Want to check it out?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA15"), () => "Can you please ask ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA16"), () => " to stop mocking me? I know my potions can't make you stronger, but at least they aren't as dangerous to drink.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA17"), () => "These goblins are so annoying... Thankfully, they cannot stay here for too long.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA18"), () => "You better deal with Pirates as fast, as you can. I can't wait to talk with Captain! Haven't seen him for years!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA19"), () => "I hope that you will not let them into my house, will you?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA20"), () => "Perhaps there are better things for you to do, rather than talking to me, at the moment. I don't know... maybe defend us?!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA21"), () => "...My friend, the best thing to do in this case is not bother me during this time.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA22"), () => "I have an explosive flask. You do NOT want to know what it tastes like.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA23"), () => "How can ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA24"), () => " stay calm in a time like this? I want to know, NOW.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA25"), () => "Don't let the dark one that came from the Jungle fool you with charming wisdom. Me and ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA26"), () => " were once his apprentices. I quit when his lessons turned too dark but ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Alchemist.EntryA27"), () => " interest in occult Alchemy did nothing but grow.");


            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<YoungBrewer>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection<Brewer>(AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.Alchemist"))
            });
        }

        public override void ResetEffects()
        {
            PS = false;
            AB = false;
            LE = false;
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
            AnimationType = NPCID.Clothier;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (NPC.downedBoss1 && AlchemistNPCRebornAgain.modConfiguration.AlchemistSpawn)
                return true;
            return false;
        }

        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.Edward")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.Severus")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.Horace")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.Tilyorn")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.Nicolas")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.Gregg"))
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
            randomOffset = 2f;
        }


        public override string GetChat()
        {
            //npc chat
            int Brewer = NPC.FindFirstNPC(ModContent.NPCType<Brewer>());
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            if (Main.bloodMoon && partyGirl >= 0 && Main.rand.Next(4) == 0)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA23")) + Main.npc[partyGirl].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA24"));
            }

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA20"));
                    case 1:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA21"));
                    case 2:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA22"));
                }
            }

            if (Main.invasionType == 1)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA17"));
            }

            if (Main.invasionType == 3)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA18"));
            }

            if (Main.invasionType == 4)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA19"));
            }

            if (witchDoctor >= 0 && Main.rand.NextBool(7))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA25")) + Main.npc[Brewer].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA26")) + Main.npc[Brewer].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA27"));
            }

            if (Brewer >= 0 && Main.rand.NextBool(5))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA15")) + Main.npc[Brewer].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA16"));
            }

            if (ModLoader.TryGetMod("ThoriumMod", out Mod thoriumMod) && thoriumMod != null)
            {
                int da = -1;


                if (ExternalModCache.GetOrCreateModNPCId(thoriumMod, "DesertTraveler", out da) && da >= 0 && NPC.FindFirstNPC(da) >= 0 && Main.rand.NextBool(7))
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA9")) + Main.npc[da].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA10"));
                if (Brewer >= 0 && ExternalModCache.GetOrCreateModNPCId(thoriumMod, "DesertTraveler", out da) && da >= 0 && NPC.FindFirstNPC(da) >= 0 && Main.rand.NextBool(8))
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA11"));
                if (Main.rand.NextBool(5))
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA8"));
            }

            switch (Main.rand.Next(7))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA2"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA3"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA4"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA5"));
                case 5:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA6"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.EntryA7"));
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.PlantsShop"));

            Player player = Main.player[Main.myPlayer];

            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == Mod.Find<ModItem>("LifeElixir").Type)
                    {
                        LE = true;
                    }

                    if (player.inventory[j].type == ItemID.PhilosophersStone)
                    {
                        PS = true;
                    }

                    if (player.inventory[j].type == Mod.Find<ModItem>("AlchemicalBundle").Type)
                    {
                        AB = true;
                    }
                }
            }

            if (PS && AB)
            {
                button2 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BrewElixir");
            }

            int Alchemist = NPC.FindFirstNPC(ModContent.NPCType<Alchemist>());
            if (player.name == "Gregg" && Main.npc[Alchemist].GivenName == Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.Gregg")) && NPC.downedMoonlord && !Tantrum)
            {
                button2 = "Secret";
            }

            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier1 == false && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier2 == false && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier3 == false && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier4 == false)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.GetCharm"));
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                baseShop = true;
                plantShop = false;
                shop = "Shop";
            }
            else
            {
                Player player = Main.player[Main.myPlayer];
                var source = NPC.GetSource_FromAI();
                if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier1 == false && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier2 == false && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier3 == false && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier4 == false)
                {
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Misc.AlchemistCharmTier1>());
                }

                if (!PS || !AB)
                {
                    baseShop = false;
                    plantShop = true;
                    shop = "Shop";
                }

                if (PS && AB)
                {
                    if (Main.player[Main.myPlayer].HasItem(ItemID.PhilosophersStone))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == Mod.Find<ModItem>("AlchemicalBundle").Type)
                            {
                                inventory[k].stack--;
                            }
                        }
                    }

                    player.QuickSpawnItem(source, Mod.Find<ModItem>("LifeElixir").Type);
                }

                if (player.name == "Gregg" && NPC.downedMoonlord)
                {
                    Tantrum = true;
                    player.QuickSpawnItem(source, Mod.Find<ModItem>("LastTantrum").Type);
                }
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
            if (baseShop)
            {
                items[nextSlot].type = (ItemID.LesserHealingPotion);
                items[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.HealingPotion);
                    items[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.GreaterHealingPotion);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }

                if (NPC.downedMoonlord)
                {
                    items[nextSlot].type = (ItemID.SuperHealingPotion);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }

                if (ExternalModCache.findMod("CalamityMod", out var calamityMod) && calamityMod != null)
                {
                    if ((bool)calamityMod.Call("Downed", "profaned guardians") && !(bool)calamityMod.Call("Downed", "polterghast"))
                    {
                        if (ExternalModCache.GetOrCreateModItem(calamityMod, "SupremeHealingPotion", out var currItem) && currItem != null)
                        {
                            items[nextSlot].type = (currItem.Type);
                            items[nextSlot].shopCustomPrice = 500000;
                            nextSlot++;
                        }
                    }

                    if ((bool)calamityMod.Call("Downed", "polterghast"))
                    {
                        if (ExternalModCache.GetOrCreateModItem(calamityMod, "OmegaHealingPotion", out var currItem) && currItem != null)
                        {
                            items[nextSlot].type = (currItem.Type);
                            items[nextSlot].shopCustomPrice = 1000000;
                            nextSlot++;
                        }
                    }
                }

                items[nextSlot].type = (ItemID.LesserManaPotion);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.ManaPotion);
                    items[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.GreaterManaPotion);
                    items[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                }

                if (Main.hardMode && NPC.downedMechBoss1 && (NPC.downedMechBoss2 && NPC.downedMechBoss3))
                {
                    items[nextSlot].type = (ItemID.SuperManaPotion);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }

                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.StrangeBrew);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.RecallPotion);
                nextSlot++;
                items[nextSlot].type = (ItemID.WormholePotion);
                nextSlot++;

                items[nextSlot].type = (ItemID.LuckPotionLesser);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                items[nextSlot].type = (ItemID.LuckPotion);
                items[nextSlot].shopCustomPrice = 100000;
                nextSlot++;
                items[nextSlot].type = (ItemID.LuckPotionGreater);
                items[nextSlot].shopCustomPrice = 500000;
                nextSlot++;

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.TeleportationPotion);
                    items[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                }

                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.BeachTeleporterPotion>());
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                    items[nextSlot].type = (ModContent.ItemType<Items.JungleTeleporterPotion>());
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.OceanTeleporterPotion>());
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                    items[nextSlot].type = (ModContent.ItemType<Items.DungeonTeleportationPotion>());
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.UnderworldTeleportationPotion>());
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    items[nextSlot].type = (ModContent.ItemType<Items.BeaconTeleportator>());
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }

                if (NPC.downedPlantBoss)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.TempleTeleportationPotion>());
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.Bottle);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.BottledWater);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.FallenStar);
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.Gel);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.PinkGel);
                    items[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                }

                if (ExternalModCache.findMod("ThoriumMod", out var thoriumMod) && thoriumMod != null)
                {
                    if (NPC.downedBoss2)
                    {
                        addModItemToShop(thoriumMod, "WaterChestnut", 3500, ref items, ref nextSlot);
                    }

                    if (NPC.downedBoss3)
                    {
                        addModItemToShop(thoriumMod, "Jelly", 7500, ref items, ref nextSlot);
                    }
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.PixieDust);
                    items[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.CrystalShard);
                    items[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.UnicornHorn);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.CursedFlame);
                    items[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Ichor);
                    items[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                }

                for (int k = 0; k < 255; k++)
                {
                    Player player = Main.player[k];
                    if (player.active)
                    {
                        ExternalModCache.GetOrCreateModItemId(Mod, "OtherworldlyAmulet", out var OtherworldlyAmuletItem);
                        ExternalModCache.GetOrCreateModItemId(Mod, "Autoinjector", out var AutoInjectorItem);
                        ExternalModCache.GetOrCreateModItemId(Mod, "EmagledFragmentation", out var EmagledFragmentationItem);
                        for (int j = 0; j < player.inventory.Length; j++)
                        {
                            if (OtherworldlyAmuletItem > 0 && EmagledFragmentationItem > 0 && player.inventory[j].type == OtherworldlyAmuletItem)
                            {
                                items[nextSlot].type = EmagledFragmentationItem;
                                items[nextSlot].shopCustomPrice = 100000;
                                nextSlot++;
                                break;
                            }

                            if (AutoInjectorItem > 0 && EmagledFragmentationItem > 0 && player.inventory[j].type == AutoInjectorItem)
                            {
                                items[nextSlot].type = (EmagledFragmentationItem);
                                items[nextSlot].shopCustomPrice = 100000;
                                nextSlot++;
                                break;
                            }
                        }
                    }
                }
            }

            if (plantShop)
            {
                items[nextSlot].type = (ItemID.Daybloom);
                items[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Waterleaf);
                items[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Shiverthorn);
                items[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Blinkroot);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Moonglow);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Fireblossom);
                items[nextSlot].shopCustomPrice = 2500;
                nextSlot++;
                items[nextSlot].type = (ItemID.Deathweed);
                items[nextSlot].shopCustomPrice = 2500;
                nextSlot++;
                items[nextSlot].type = (ItemID.Mushroom);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (ItemID.GlowingMushroom);
                items[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.VileMushroom);
                    items[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.ViciousMushroom);
                    items[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                }


                if (NPC.downedBoss3 && ExternalModCache.findMod("Tremor", out var tremorMod) && tremorMod != null)
                {
                    addModItemToShop(tremorMod, "Gloomstone", 100, ref items, ref nextSlot);
                    addModItemToShop(tremorMod, "UntreatedFlesh", 100, ref items, ref nextSlot);
                    addModItemToShop(tremorMod, "LightBulb", 500, ref items, ref nextSlot);
                    addModItemToShop(tremorMod, "AtisBlood", 2500, ref items, ref nextSlot);
                    addModItemToShop(tremorMod, "TearsofDeath", 2500, ref items, ref nextSlot);
                    addModItemToShop(tremorMod, "TornPapyrus", 5000, ref items, ref nextSlot);
                    addModItemToShop(tremorMod, "PhantomSoul", 5000, ref items, ref nextSlot);
                    addModItemToShop(tremorMod, "TheRib", 7500, ref items, ref nextSlot);
                }
            }
        }
    }
}
