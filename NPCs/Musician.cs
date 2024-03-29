using System.Linq;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using AlchemistNPCRebornAgain.Interface;
using Microsoft.Xna.Framework;
using Terraria.Chat;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Musician : ModNPC
    {
        public static bool S1 = true;
        public static bool S2 = false;
        public static bool S3 = false;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Musician"; }
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

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Names.Beethoven"), () => "Beethoven");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Names.Bach"), () => "Bach");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Names.Johan"), () => "Johan");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Names.Edison"), () => "Edison");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Names.Scott"), () => "Scott");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Names.Lloyd"), () => "Lloyd");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Names.Gamma"), () => "Gamma");


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Actions.Shop2"), () => "1st Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Actions.Shop3"), () => "2nd Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Actions.ShopChanger"), () => "Shop Changer");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E1"), () => "I would wear headphones, but I'm not sure if Terrarians even have ears...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E2"), () => "I have to wonder why Boss 1 and Boss 2 didn't get better names in the OST. Those names are soooo bland.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E3"), () => "Look, the Cyborg may have my name, but I've still got the better job here.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E4"), () => "Shhhhh! You'll ruin my recording!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E5"), () => "I swear, if one more person asks me to sell them a ''Megalovania'' music box....");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E6"), () => "Look, your enthusiasm is awesome, but could you maybe record the next boss track yourself? I don't really want to risk my life for some tunes.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E7"), () => "Ah, I see you were able to save the Explorer! Well done! Perhaps my next song is going to be about your triumph.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E8"), () => "You know, ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E9"), () => " has been really helpful while I've been setting up this sound system. Wires are key!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E10"), () => "If you run into ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E11"), () => ", let him know he still owes me for those music boxes I sold him.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E12"), () => "I'll be honest, I'm not sure if I trust ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E13"), () => ". He claims to not be possessed, and yet he still is using skulls to fight... I'm getting mixed messages here.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E14"), () => "Man, my mixtape is so much better than this, but I can't sell you that due to copyright.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E15"), () => "No, I don't have an ''All Star'' music box. Code it in yourself.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E16"), () => "Wait, NPC? I thought I was the protagonist!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E17"), () => "Never thought I'd be selling a music box with lyrics... DM DOKURO, you're a madman and I love it!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E18"), () => "A whole music based class? That sounds amazing! Too bad I don't have any gear for that, huh?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E19"), () => "This is your fault. GET. OUT.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E20"), () => "Ah, this takes me back! I remember when this song used to play in the dungeon and the underworld... good times!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E21"), () => "Is there a name for the fear of being spied by a cake?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Musician.Text.E22"), () => "You are hurting my ears! Turn it down!");


            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<HallowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Wizard, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.Musician"))
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
            if (NPC.downedBoss3 && AlchemistNPCRebornAgain.modConfiguration.MusicianSpawn)
                return true;

            return false;
        }


        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Beethoven")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Bach")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Johan")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Edison")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Scott")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Lloyd")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Gamma"))
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
            cooldown = 5;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            attackDelay = 3;
            switch (Main.rand.Next(3))
            {
                case 0:
                    projType = 76;
                    break;
                case 1:
                    projType = 77;
                    break;
                case 2:
                    projType = 78;
                    break;
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 6f;
            randomOffset = 0f;
        }


        public override string GetChat()
        {
            int Cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            int Mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            int Clothier = NPC.FindFirstNPC(NPCID.Clothier);
            int Wizard = NPC.FindFirstNPC(NPCID.Wizard);
            int Musician = NPC.FindFirstNPC(ModContent.NPCType<Musician>());
            if (Main.musicVolume <= 1)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E19"));
            }

            if (Main.musicVolume >= 99)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E22"));
            }

            if (Main.bloodMoon)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E20"));
            }

            if (Cyborg >= 0 && Main.npc[Cyborg].GivenName == "Gamma" && Main.npc[Musician].GivenName == Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Names.Gamma")) && Main.rand.NextBool(15))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E3"));
            }

            if (Mechanic >= 0 && Main.rand.NextBool(20))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E8")) + Main.npc[Mechanic].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E9"));
            }

            if (Wizard >= 0 && Main.rand.NextBool(20))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E10")) + Main.npc[Wizard].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E11"));
            }

            if (Clothier >= 0 && Main.rand.NextBool(20))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E12")) + Main.npc[Clothier].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E13"));
            }

            if (ExternalModCache.findMod("ThoriumMod", out var thoriumMod) && thoriumMod != null && Main.rand.NextBool(15))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E18"));
            }

            if (ExternalModCache.findMod("CalamityModMusic", out var calamityMusic) && calamityMusic != null && Main.rand.NextBool(15))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E17"));
            }

            switch (Main.rand.Next(9))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E2"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E4"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E5"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E6"));
                case 5:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E14"));
                case 6:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E15"));
                case 7:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E16"));
                case 8:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E21"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Text.E1"));
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (S1)
            {
                button = Language.GetTextValue("LegacyInterface.28");
            }

            if (S2)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Actions.Shop2"));
            }

            if (S3)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Actions.Shop3"));
            }

            button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Musician.Actions.ShopChanger"));
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
                ShopChangeUIM.visible = false;
            }
            else
            {
                if (!ShopChangeUIM.visible) ShopChangeUIM.timeStart = Main.GameUpdateCount;
                ShopChangeUIM.visible = true;
            }
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            int nextSlot = 0;
            if (S1)
            {
                if (!NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (576);
                    nextSlot++;
                }

                if (NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (562);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (563);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (564);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (565);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (566);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (568);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (569);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (570);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (571);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (573);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1596);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1597);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1598);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1600);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1601);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1602);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1603);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1604);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1605);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1608);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1610);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (1964);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (2742);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (3237);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (3796);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    if (NPC.downedPlantBoss)
                    {
                        items[nextSlot].type = (567);
                        items[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        items[nextSlot].type = (572);
                        items[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        items[nextSlot].type = (574);
                        items[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedQueenBee)
                        {
                            items[nextSlot].type = (1599);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        if (NPC.downedGolemBoss)
                        {
                            items[nextSlot].type = (1607);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        items[nextSlot].type = (1606);
                        items[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedMoonlord)
                        {
                            items[nextSlot].type = (3044);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        if (NPC.downedGoblins)
                        {
                            items[nextSlot].type = (3371);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        if (NPC.downedPirates)
                        {
                            items[nextSlot].type = (3236);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        if (DD2Event.DownedInvasionT1)
                        {
                            items[nextSlot].type = (3869);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        items[nextSlot].type = (1609);
                        items[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedHalloweenKing)
                        {
                            items[nextSlot].type = (1963);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        if (NPC.downedChristmasIceQueen)
                        {
                            items[nextSlot].type = (1965);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        if (NPC.downedMartians)
                        {
                            items[nextSlot].type = (3235);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }

                        if (NPC.downedMoonlord)
                        {
                            items[nextSlot].type = (3370);
                            items[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                    }
                }
            }

            if (S2)
            {
                if (ExternalModCache.findMod("CalamityMod", out var calamityMod) && calamityMod != null && ExternalModCache.findMod("CalamityModMusic", out var calamityMusicMod) && calamityMusicMod != null)
                {
                    if ((bool)calamityMod.Call("Downed", "desert scourge"))
                    {
                        addModItemToShop(calamityMusicMod, "DesertScourgeMusicbox", 150000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "SunkenSeaMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "crabulon"))
                    {
                        addModItemToShop(calamityMusicMod, "CrabulonMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "hive mind"))
                    {
                        addModItemToShop(calamityMusicMod, "HiveMindMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "perforators"))
                    {
                        addModItemToShop(calamityMusicMod, "PerforatorMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "slime god"))
                    {
                        addModItemToShop(calamityMusicMod, "SlimeGodMusicbox", 150000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "CragMusicbox", 150000, ref items, ref nextSlot);
                    }

                    addModItemToShop(calamityMusicMod, "SirenIdleMusicbox", 150000, ref items, ref nextSlot);
                    addModItemToShop(calamityMusicMod, "SulphurousMusicbox", 150000, ref items, ref nextSlot);
                    addModItemToShop(calamityMusicMod, "HigherAbyssMusicbox", 150000, ref items, ref nextSlot);
                    addModItemToShop(calamityMusicMod, "AbyssLowerMusicbox", 150000, ref items, ref nextSlot);
                    addModItemToShop(calamityMusicMod, "VoidMusicbox", 150000, ref items, ref nextSlot);
                    if ((bool)calamityMod.Call("Downed", "cryogen"))
                    {
                        addModItemToShop(calamityMusicMod, "CryogenMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "aquatic scourge"))
                    {
                        addModItemToShop(calamityMusicMod, "AquaticScourgeMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "brimstone elemental"))
                    {
                        addModItemToShop(calamityMusicMod, "BrimmyMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "calamitas doppelganger"))
                    {
                        addModItemToShop(calamityMusicMod, "CalamitasMusicbox", 150000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "CalamityMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "leviathan"))
                    {
                        addModItemToShop(calamityMusicMod, "SirenMusicbox", 150000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "LeviathanMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "astrum aureus"))
                    {
                        addModItemToShop(calamityMusicMod, "AstralMusicbox", 150000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "AstrageldonMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "astrum deus"))
                    {
                        addModItemToShop(calamityMusicMod, "AstrumDeusMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "plaguebringer goliath"))
                    {
                        addModItemToShop(calamityMusicMod, "PlaguebringerMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "ravager"))
                    {
                        addModItemToShop(calamityMusicMod, "RavagerMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "profaned guardians"))
                    {
                        addModItemToShop(calamityMusicMod, "ProfanedGuardianMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "providence"))
                    {
                        addModItemToShop(calamityMusicMod, "ProvidenceMusicbox", 250000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "stormweaver"))
                    {
                        addModItemToShop(calamityMusicMod, "StormWeaverMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "ceaselessvoid"))
                    {
                        addModItemToShop(calamityMusicMod, "CeaselessVoidMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "signus"))
                    {
                        addModItemToShop(calamityMusicMod, "SignusMusicbox", 150000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "polterghast"))
                    {
                        addModItemToShop(calamityMusicMod, "PolterghastMusicbox", 300000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "dog"))
                    {
                        addModItemToShop(calamityMusicMod, "DoGMusicbox", 500000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "DoGP2Musicbox", 500000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "yharon"))
                    {
                        addModItemToShop(calamityMusicMod, "Yharon1Musicbox", 500000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "Yharon2Musicbox", 500000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "Yharon3Musicbox", 500000, ref items, ref nextSlot);
                    }

                    if ((bool)calamityMod.Call("Downed", "supreme calamitas"))
                    {
                        addModItemToShop(calamityMusicMod, "SCalGMusicbox", 500000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "SCalLMusicbox", 500000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "SCalEMusicbox", 500000, ref items, ref nextSlot);
                        addModItemToShop(calamityMusicMod, "SCalAMusicbox", 500000, ref items, ref nextSlot);
                    }
                }
            }

            if (S3)
            {
                items[nextSlot].type = (ModContent.ItemType<Items.Misc.BoomBox>());
                items[nextSlot].shopCustomPrice = 250000;
                nextSlot++;

                if (!errored && ExternalModCache.findMod("ThoriumMod", out var thoriumMod))
                {
                    try
                    {
                        if (ThoriumModDownedGTBird)
                        {
                            addModItemToShop(thoriumMod, "ThunderBirdMusicBox", 150000, ref items, ref nextSlot);
                        }

                        if (ThoriumModDownedViscount)
                        {
                            addModItemToShop(thoriumMod, "ViscountMusicBox", 150000, ref items, ref nextSlot);
                        }

                        if (ThoriumModDownedBoreanStrider)
                        {
                            addModItemToShop(thoriumMod, "BoreanStriderMusicBox", 150000, ref items, ref nextSlot);
                        }

                        if (ThoriumModDownedFallenBeholder)
                        {
                            addModItemToShop(thoriumMod, "FallenBeholderMusicBox", 150000, ref items, ref nextSlot);
                        }

                        if (ThoriumModDownedAbyssion)
                        {
                            addModItemToShop(thoriumMod, "DepthsMusicBox", 150000, ref items, ref nextSlot);
                        }
                    }
                    catch (Exception)
                    {
                        errored = true;
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] It Appears Thorium is Semi-Incompatable with this Version!"), Color.Red, Main.myPlayer);
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Please report this to Ferris on Steam or Discord!"), Color.Red, Main.myPlayer);
                    }
                }
            }
        }

        private static bool errored = false;

        [JITWhenModsEnabled("ThoriumMod")]
        public static bool ThoriumModDownedGTBird
        {
            get { return !errored && ThoriumMod.ThoriumWorld.downedTheGrandThunderBird; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public static bool ThoriumModDownedViscount
        {
            get { return !errored && ThoriumMod.ThoriumWorld.downedViscount; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public static bool ThoriumModDownedBoreanStrider
        {
            get { return !errored && ThoriumMod.ThoriumWorld.downedBoreanStrider; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public static bool ThoriumModDownedFallenBeholder
        {
            get { return !errored && ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public static bool ThoriumModDownedAbyssion
        {
            get { return !errored && ThoriumMod.ThoriumWorld.downedForgottenOne; }
        }
    }
}
