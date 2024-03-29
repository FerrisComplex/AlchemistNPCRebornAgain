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
using AlchemistNPCRebornAgain.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Chat;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Operator : ModNPC
    {
        public static bool OA = false;
        public static bool Meteor = false;
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool egoShop = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public static bool Shop5 = false;
        public static bool Shop6 = false;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Operator"; }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -6;


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Names.Angela"), () => "Angela");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Names.Carmen"), () => "Carmen");


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop1"), () => "Boss Drops & Materials Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop2"), () => "EGO Equipment Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop3"), () => "Modded Boss Drops & Materials Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop4"), () => "Vanilla Treasure Bags Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop5"), () => "Modded Treasure Bags Shop");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop6"), () => "Modded Treasure Bags Shop #2");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop7"), () => "Modded Treasure Bags Shop #3");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Actions.ShopChanger"), () => "Shop Changer");


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E1"), () => "How is your day, Manager? Can I help you?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E2"), () => "That 'The Great Thunder Bird' doesn't seems so dangerous. I am only hoping that it isn't a part of Apocalypse Bird...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E3"), () => "Hello, Manager! Isn't this day silent, is it?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E4"), () => "Do you want anything special, Manager?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E5"), () => "Eater of Worlds is an Abnormality with risk class TETH. And now it is contained. Do you need something from it?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E6"), () => "If you manage to supress Ragnarok, then you could do everything imaginable.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E7"), () => "Eye of Cthulhu is a pretty strange creature. It seems like it is just a small part of something really dangerous. It would be better for us if it never escapes.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E8"), () => "Brain of Cthulhu may look horrifying, but without its minions it can't do anything.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E9"), () => "Something changed in this world, Manager. Evil is spreading even wider, but at the same time, my sensor system caught the birth of new biome, called Hallow.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E10"), () => "All these Mechanical Bosses... They definitely could have Trauma origin. What classification numbers will they get? I think they would be started as T-05-...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E11"), () => "Goblins... Such a pathetic creatures. And the only useful things from them are just Spiky Balls and Harpoons.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E12"), () => "Pretty strange Abnormal event... They all look as living creatures, but their 'Flying Dutchman' is definetly a ghost with HE risk class.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E13"), () => "Martians came again. Last time they were here, several big towns were destroyed. But we could say as an excuse that we weren't as ready, as we were now.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E14"), () => "Blood Moon? Shouldn't it happen once in 666 years?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E15"), () => "All these strange cratures just keep coming and coming to this 'Beacon'... Hope we all will survive until Dawn.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E16"), () => "Anyway, there are some reasons for optimism. Blood Moon attracts some creatures, which cannot be seen in normal conditions.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E17"), () => "I read a few manuscripts about creature, named Slime God. They say that he is one of the first creatures in this world.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E18"), () => "Yharim... I am pretty sure I heard that name before. But my memory data is corrupted. Try asking Calamitas about him...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E19"), () => "This carnivorous plant was really dangerous... Looks like it was at least HE Risk Class. Glad to see you again in one piece after all.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E20"), () => "This ancient machine was holding celestial powers inside. With its death, world can change forever...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E21"), () => "An insect the size of the Queen Bee defies current methods of classification. I propose insects of this size be given a new classification MI-XX. It is a wonder that nobody has used them for their own means, let us be the first.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E22"), () => "It appears I was wrong about the queen bees. Their memory storage contains the ramblings of a scientist who was blinded by ambition and cruelly introduced the plague to them. Let us classify them as MP-0X.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E23"), () => "According to my notes, this Coznix you speak of was a lesser Void Observer, classified as OB-V-01. There are greater threats waiting beyond the veil of reality.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E24"), () => "This flying scouter..... curious. From the memory banks stored in the wreckage, this looks to have been a scouting ship for the Martians, to determine how hospitable Terraria is. I fear the pilot's last moments have been transmitted to the main Martian command centre.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E25"), () => "Turning a mages' power in on himself and trapping him within it is no easy task, but to observe cruelty of such magnitude..... Permafrost, former lord of the Ice Castle, may you see peace.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E26"), () => "The Starplate raider is a Genius Stardust Centipede, or a G-S-C3, popular with the Martian elite as lifelong companions and raiding partners. It must have wandered far from home, judging from the transmitter memory banks I recovered.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E27"), () => "I took the time to analyze the remains of this incredible creature. Every time it attacked, the entire planet seemed to resonate against its will. I can do nothing but to worry about the consequences of its death. At least, you saved Terraria of certain doom..........again.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E28"), () => "Such an ancient presence is worth documenting - the material of its plates can withstand temperatures equal to the core of the Terrarian Sun! This will revolutionize containment procedures for ARS-0N prisoners if we can make materials half as resistant to heat!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E29"), () => "Whoever made the Ravager deserves to be put in HI-MAX containment. All those tortured souls....... Well, at least you put them out of their misery.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E30"), () => "Interesting... those Bumblebirbs were actually meant to be clones of Yharon. I’m glad that experiment was a failure!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E31"), () => "You were lucky that thing got complacent and didn't open a portal to the Sun on our heads. The sheer strength and intelligence it exhibited means I need to make a whole new category for the classification of Worms.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E32"), () => "I have my theories about the origin of this being, frightening more than his soul (if he even has one)... Irradiates negative energy, experimentation shown how in darkness this ''oblivion energy'', irradiated light but in light places irradiated shadow. I don't know where he came from but I know that whatever it is, it must be contained at any cost!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E33"), () => "Supreme Calamitas has been defeated but she speaks of a being even stronger than herself. We must hope that he hasn't taken notice of us yet.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E34"), () => "I’m honestly not sure why giant spinning skulls are the key to everything, but somehow they seem to contain the power of celestial beings within them...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E35"), () => "Yeah, I know that we are the ones capturing and farming horrifying eldritch entities. But who the hell thought It was a good idea to put loot bags inside a giant monster?!?!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Operator.Text.E36"), () => "Кemember Manager, Treasure Bags are valuable but not everything comes inside them. That mutant man can help you get a boss's most elusive drops.");

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
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
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.Operator"))
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

        public override void ResetEffects()
        {
            OA = false;
            Meteor = false;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (NPC.downedBoss2 && AlchemistNPCRebornAgain.modConfiguration.OperatorSpawn)
                return true;
            return false;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            int score = 0;
            for (int x = left; x <= right; x++)
            {
                for (int y = top; y <= bottom; y++)
                {
                    int type = Main.tile[x, y].TileType;
                    if (type == Mod.Find<ModTile>("WingoftheWorld").Type)
                    {
                        score++;
                    }
                }
            }

            return score > 0;
        }

        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Names.Angela")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Names.Carmen"))
        };

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
                projType = Mod.Find<ModProjectile>("BB").Type;
            }

            if (Main.hardMode && !NPC.downedMoonlord)
            {
                projType = Mod.Find<ModProjectile>("FDB").Type;
            }

            if (NPC.downedMoonlord)
            {
                projType = Mod.Find<ModProjectile>("MB").Type;
            }
        }

        public override void DrawTownAttackGun(ref Texture2D itemTex, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            //closeness = 20;
            int item = -1;

            if (!Main.hardMode)
            {
                item = Mod.Find<ModItem>("TheBeak").Type;
            }

            if (Main.hardMode && !NPC.downedMoonlord)
            {
                item = Mod.Find<ModItem>("FuneralofDeadButterflies").Type;
            }

            if (NPC.downedMoonlord)
            {
                item = Mod.Find<ModItem>("MagicBullet").Type;
            }

            if (item != -1)
            {
                Main.GetItemDrawFrame(item, out Texture2D itemTexture2, out Rectangle itemRectangle2);
                itemTex = itemTexture2;
                itemFrame = itemRectangle2;
                scale = 1;
                horizontalHoldoutOffset = 0;
                return;
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
        }


        public override string GetChat()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E14"));
                    case 1:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E15"));
                    case 2:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E16"));
                }
            }

            if (Main.invasionType == 1)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E11"));
            }

            if (Main.invasionType == 3)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E12"));
            }

            if (Main.invasionType == 4)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E13"));
            }

            if (Main.rand.NextBool(5))
            {
                if (!WorldGen.crimson)
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E5"));
                }

                if (WorldGen.crimson)
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E8"));
                }
            }

            if (Calamity != null && NPC.downedBoss3)
            {
                if (Main.rand.NextBool(7))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E17"));
                }
            }

            if (NPC.downedPlantBoss)
            {
                if (Main.rand.NextBool(7))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E19"));
                }
            }

            if (NPC.downedGolemBoss)
            {
                if (Main.rand.NextBool(7))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E20"));
                }
            }

            if (Calamity != null && NPC.downedMoonlord)
            {
                if (Main.rand.NextBool(7))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E18"));
                }
            }

            ModLoader.TryGetMod("ThoriumMod", out Mod Thorium);
            if (Thorium != null)
            {
                if (Main.rand.NextBool(6))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E2"));
                }

                if (Main.hardMode && Main.rand.NextBool(6))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E6"));
                }
            }

            if (Main.rand.NextBool(5) && Main.hardMode)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E9"));
                    case 1:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E10"));
                }
            }

            if (Main.rand.NextBool(5) && NPC.downedQueenBee)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E21"));
            }

            if (Calamity != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "plaguebringer goliath"))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E22"));
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "cryogen"))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E25"));
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "providence"))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E28"));
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "ravager"))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E29"));
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "bumblebirb"))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E30"));
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "dog"))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E31"));
                }

                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "supreme calamitas"))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E33"));
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED

            try
            {
                if (!erroredThorium && ModLoader.GetMod("ThoriumMod") != null && Main.hardMode)
                {
                    if (Main.rand.NextBool(5) && ThoriumModDownedFallenBeholder)
                    {
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E23"));
                    }

                    if (Main.rand.NextBool(5) && ThoriumModDownedStarScout)
                    {
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E24"));
                    }
                }
            }
            catch (Exception)
            {
                if (!erroredThorium)
                {
                    erroredThorium = true;
                    ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] It Appears Thorium is Semi-Incompatable with this Version!"), Color.Red, Main.myPlayer);
                    ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Please report this to Ferris on Steam or Discord!"), Color.Red, Main.myPlayer);
                }
            }

            /*
            if (ModLoader.GetMod("SacredTools") != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && SacredToolsDownedAbbadon)
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E32"));
                }
            }

            if (ModLoader.GetMod("SpiritMod") != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && SpiritModDownedStarplateRaider)
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E26"));
                }
                if (Main.rand.NextBool(5) && SpiritModDownedOverseer)
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E27"));
                }
            }
            */
            switch (Main.rand.Next(6))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E3"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E4"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E34"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E35"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Text.E7"));
            }
        }

        private static bool erroredThorium = false;
        private static bool calamityErrored = false;

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop1"));

            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == Mod.Find<ModItem>("SymbioteMeteorite").Type)
                    {
                        Meteor = true;
                    }
                }
            }

            if (!Main.expertMode)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop3"));
            }

            if (Main.expertMode)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.ShopChanger"));
            }

            if (Shop1)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop1"));
            }

            if (Shop2)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop3"));
            }

            if (egoShop)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop2"));
            }

            if (Shop3)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop4"));
            }

            if (Shop4)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop5"));
            }

            if (Shop5)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop6"));
            }

            if (Shop6)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Operator.Actions.Shop7"));
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                if (Meteor)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = NPC.GetSource_FromAI();
                    player.QuickSpawnItem(source, Mod.Find<ModItem>("Symbiote").Type);
                    if (Main.player[Main.myPlayer].HasItem(Mod.Find<ModItem>("SymbioteMeteorite").Type) && Meteor)
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == Mod.Find<ModItem>("SymbioteMeteorite").Type && Meteor)
                            {
                                inventory[k].stack--;
                                Meteor = false;
                            }
                        }
                    }
                }

                if (!Main.expertMode)
                {
                    Shop1 = true;
                    Shop2 = false;
                    Shop3 = false;
                    Shop4 = false;
                    Shop5 = false;
                    Shop6 = false;
                    shop = "Shop";
                }

                if (Main.expertMode)
                {
                    shop = "Shop";
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
                    shop = "Shop";
                }

                if (Main.expertMode)
                {
                    if (!ShopChangeUIO.visible) ShopChangeUIO.timeStart = Main.GameUpdateCount;
                    ShopChangeUIO.visible = true;
                }
            }
        }

        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedGTBird
        {
            get { return ThoriumMod.ThoriumWorld.downedTheGrandThunderBird; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedQueenJelly
        {
            get { return ThoriumMod.ThoriumWorld.downedQueenJellyfish; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedViscount
        {
            get { return ThoriumMod.ThoriumWorld.downedViscount; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedStorm
        {
            get { return ThoriumMod.ThoriumWorld.downedGraniteEnergyStorm; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedChampion
        {
            get { return ThoriumMod.ThoriumWorld.downedBuriedChampion; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedStarScout
        {
            get { return ThoriumMod.ThoriumWorld.downedStarScouter; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedBoreanStrider
        {
            get { return ThoriumMod.ThoriumWorld.downedBoreanStrider; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedFallenBeholder
        {
            get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedLich
        {
            get { return ThoriumMod.ThoriumWorld.downedLich; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedAbyssion
        {
            get { return ThoriumMod.ThoriumWorld.downedForgottenOne; }
        }
        [JITWhenModsEnabled("ThoriumMod")]
        public bool ThoriumModDownedRagnarok
        {
            get { return ThoriumMod.ThoriumWorld.downedThePrimordials; }
        }

        /*

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

        public bool ReDownedChicken
        {
            get { return Redemption.RedeWorld.downedKingChicken; }
        }
        public bool ReDownedThorn
        {
            get { return Redemption.RedeWorld.downedThorn; }
        }
        public bool ReDownedKeeper
        {
            get { return Redemption.RedeWorld.downedTheKeeper; }
        }
        public bool ReDownedCrystal
        {
            get { return Redemption.RedeWorld.downedXenomiteCrystal; }
        }
        public bool ReDownedIEye
        {
            get { return Redemption.RedeWorld.downedInfectedEye; }
        }
        public bool ReDownedKingSlayer
        {
            get { return Redemption.RedeWorld.downedSlayer; }
        }
        public bool ReDownedVCleaver
        {
            get { return Redemption.RedeWorld.downedVlitch1; }
        }
        public bool ReDownedVGigipede
        {
            get { return Redemption.RedeWorld.downedVlitch2; }
        }
        public bool ReDownedObliterator
        {
            get { return Redemption.RedeWorld.downedVlitch3; }
        }
        public bool ReDownedPZero
        {
            get { return Redemption.RedeWorld.downedPatientZero; }
        }
        public bool ReDownedThornRe
        {
            get { return Redemption.RedeWorld.downedThornPZ; }
        }
        public bool ReDownedGolemRe
        {
            get { return Redemption.RedeWorld.downedEaglecrestGolemPZ; }
        }
        public bool ReDownedNebuleus
        {
            get { return Redemption.RedeWorld.downedNebuleus; }
        }
        */
        // Possibly redundant with ModGlobalNPC
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npcLoot);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Summoning.APMC>(), 1));
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

        private void addModItemToCShop(Mod mod, String itemName, int price, ref Item[] items, ref int nextSlot, int customCurrency)
        {
            if (ExternalModCache.GetOrCreateModItem(mod, itemName, out var item) && item != null)
            {
                items[nextSlot].type = (item.Type);
                items[nextSlot].shopCustomPrice = price;
                items[nextSlot].shopSpecialCurrency = customCurrency;
                nextSlot += 1;
            }
        }

        private void addModItemToT1CShop(Mod mod, String itemName, int price, ref Item[] items, ref int nextSlot)
        {
            addModItemToCShop(mod, itemName, price, ref items, ref nextSlot, AlchemistNPCRebornAgain.ReversivityCoinTier1ID);
        }

        private void addModItemToT2CShop(Mod mod, String itemName, int price, ref Item[] items, ref int nextSlot)
        {
            addModItemToCShop(mod, itemName, price, ref items, ref nextSlot, AlchemistNPCRebornAgain.ReversivityCoinTier2ID);
        }

        private void addModItemToT3CShop(Mod mod, String itemName, int price, ref Item[] items, ref int nextSlot)
        {
            addModItemToCShop(mod, itemName, price, ref items, ref nextSlot, AlchemistNPCRebornAgain.ReversivityCoinTier3ID);
        }

        private void addModItemToT4CShop(Mod mod, String itemName, int price, ref Item[] items, ref int nextSlot)
        {
            addModItemToCShop(mod, itemName, price, ref items, ref nextSlot, AlchemistNPCRebornAgain.ReversivityCoinTier4ID);
        }

        private void addModItemToT5CShop(Mod mod, String itemName, int price, ref Item[] items, ref int nextSlot)
        {
            addModItemToCShop(mod, itemName, price, ref items, ref nextSlot, AlchemistNPCRebornAgain.ReversivityCoinTier5ID);
        }

        private void addModItemToT6CShop(Mod mod, String itemName, int price, ref Item[] items, ref int nextSlot)
        {
            addModItemToCShop(mod, itemName, price, ref items, ref nextSlot, AlchemistNPCRebornAgain.ReversivityCoinTier6ID);
        }


        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            int nextSlot = 0;
            bool T1 = false;
            bool T2 = false;
            bool T3 = false;
            bool T4 = false;
            bool T5 = false;
            bool T6 = false;
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active && player == Main.LocalPlayer)
                {
                    for (int index1 = 0; index1 < 40; ++index1)
                    {
                        if (player.bank3.item[index1].stack == 0 && !T1)
                        {
                            player.bank3.item[index1].type = (Mod.Find<ModItem>("ReversivityCoinTier1").Type);
                            player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCRebornPlayer>().RCT1;
                            T1 = true;
                            continue;
                        }

                        if (player.bank3.item[index1].stack == 0 && !T2)
                        {
                            player.bank3.item[index1].type = (Mod.Find<ModItem>("ReversivityCoinTier2").Type);
                            player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCRebornPlayer>().RCT2;
                            T2 = true;
                            continue;
                        }

                        if (player.bank3.item[index1].stack == 0 && !T3)
                        {
                            player.bank3.item[index1].type = (Mod.Find<ModItem>("ReversivityCoinTier3").Type);
                            player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCRebornPlayer>().RCT3;
                            T3 = true;
                            continue;
                        }

                        if (player.bank3.item[index1].stack == 0 && !T4)
                        {
                            player.bank3.item[index1].type = (Mod.Find<ModItem>("ReversivityCoinTier4").Type);
                            player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCRebornPlayer>().RCT4;
                            T4 = true;
                            continue;
                        }

                        if (player.bank3.item[index1].stack == 0 && !T5)
                        {
                            player.bank3.item[index1].type = (Mod.Find<ModItem>("ReversivityCoinTier5").Type);
                            player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCRebornPlayer>().RCT5;
                            T5 = true;
                            continue;
                        }

                        if (player.bank3.item[index1].stack == 0 && !T6)
                        {
                            player.bank3.item[index1].type = (Mod.Find<ModItem>("ReversivityCoinTier6").Type);
                            player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCRebornPlayer>().RCT6;
                            T6 = true;
                            break;
                        }
                    }
                }
            }

            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Shop1)
            {
                items[nextSlot].type = (ItemID.Lens);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.DemoniteOre);
                items[nextSlot].shopCustomPrice = 1500;
                nextSlot++;
                items[nextSlot].type = (ItemID.ShadowScale);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.RottenChunk);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.CrimtaneOre);
                items[nextSlot].shopCustomPrice = 1500;
                nextSlot++;
                items[nextSlot].type = (ItemID.TissueSample);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Vertebrae);
                items[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    items[nextSlot].type = (ItemID.BeeWax);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Stinger);
                    items[nextSlot].shopCustomPrice = 75000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.JungleSpores);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Vine);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ItemID.Feather);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Bone);
                    items[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }

                if (AlchemistNPCRebornWorld.downedSandElemental)
                {
                    items[nextSlot].type = (3783);
                    items[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                }

                if (NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (ItemID.SoulofLight);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.SoulofNight);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.SoulofFlight);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }

                if (NPC.downedMechBoss3)
                {
                    items[nextSlot].type = (ItemID.SoulofFright);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                if (NPC.downedMechBoss1)
                {
                    items[nextSlot].type = (ItemID.SoulofMight);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }

                if (NPC.downedMechBoss2)
                {
                    items[nextSlot].type = (ItemID.SoulofSight);
                    items[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.BlackLens);
                    items[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                }

                if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && NPC.downedMechBoss3)
                {
                    items[nextSlot].type = (ItemID.HallowedBar);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }

                if (NPC.downedPlantBoss)
                {
                    items[nextSlot].type = (ItemID.Ectoplasm);
                    items[nextSlot].shopCustomPrice = 35000;
                    nextSlot++;
                }

                if (NPC.downedMoonlord)
                {
                    items[nextSlot].type = (ItemID.FragmentSolar);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FragmentNebula);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FragmentVortex);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FragmentStardust);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }
            }

            if (Shop2)
            {
                if (ExternalModCache.findMod("ThoriumMod", out var thoriumMod))
                {
                    addModItemToShop(thoriumMod, "Petal", 10000, ref items, ref nextSlot);
                    if (NPC.downedMoonlord)
                    {
                        addModItemToShop(thoriumMod, "WhiteDwarfFragment", 100000, ref items, ref nextSlot);
                        addModItemToShop(thoriumMod, "CometFragment", 100000, ref items, ref nextSlot);
                        addModItemToShop(thoriumMod, "CelestialFragment", 100000, ref items, ref nextSlot);
                    }

                    if (NPC.downedGolemBoss)
                    {
                        addModItemToShop(thoriumMod, "BrokenHeroFragment", 250000, ref items, ref nextSlot);
                    }
                }

                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("SpiritMod") != null)
                {
                    if (NPC.downedGolemBoss)
                    {
                        addModItemToShop(SpiritMod, "BrokenParts", 500000, ref items, ref nextSlot);
                        addModItemToShop(SpiritMod, "BrokenStaff", 500000, ref items, ref nextSlot);
                    }
                }
                if (ModLoader.GetMod("LithosArmory") != null)
                {
                    if (NPC.downedGolemBoss)
                    {
                        addModItemToShop(LithosArmory, "BrokenHeroFlail", 500000, ref items, ref nextSlot);
                        addModItemToShop(LithosArmory, "BrokenHeroGreatbow", 500000, ref items, ref nextSlot);
                        addModItemToShop(LithosArmory, "BrokenHeroShotgun", 500000, ref items, ref nextSlot);
                        addModItemToShop(LithosArmory, "BrokenHeroSling", 500000, ref items, ref nextSlot);
                        addModItemToShop(LithosArmory, "BrokenHeroSpear", 500000, ref items, ref nextSlot);
                        addModItemToShop(LithosArmory, "BrokenHeroWand", 500000, ref items, ref nextSlot);
                    }
                }
                */
                if (NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("DivineLava").Type);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("CursedIce").Type);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }

                try
                {
                    if (Calamity != null)
                    {
                        if ((bool)Calamity.Call("Downed", "hive mind"))
                        {
                            addModItemToShop(Calamity, "TrueShadowScale", 20000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "perforators"))
                        {
                            addModItemToShop(Calamity, "BloodSample", 20000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "slime god"))
                        {
                            addModItemToShop(Calamity, "EbonianGel", 25000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "PurifiedGel", 30000, ref items, ref nextSlot);
                        }

                        /*if (NPC.downedMechBoss2)
                        {
                            addModItemToShop(Calamity, "BlightedLens", 150000, ref items, ref nextSlot);
                        }*/
                        if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
                        {
                            addModItemToShop(Calamity, "UnholyCore", 100000, ref items, ref nextSlot);
                        }

                        if (NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "cryogen"))
                        {
                            addModItemToShop(Calamity, "EssenceofEleum", 25000, ref items, ref nextSlot);
                        }

                        if (NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "aquatic scourge"))
                        {
                            addModItemToShop(Calamity, "EssenceofCinder", 25000, ref items, ref nextSlot);
                        }

                        if (NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "brimstone elemental"))
                        {
                            addModItemToShop(Calamity, "EssenceofChaos", 25000, ref items, ref nextSlot);
                        }

                        if (NPC.downedPlantBoss)
                        {
                            addModItemToShop(Calamity, "Tenebris", 30000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "Lumenite", 50000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "DepthCells", 30000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "astrum aureus"))
                        {
                            addModItemToShop(Calamity, "AstralJelly", 50000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "Stardust", 10000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "leviathan"))
                        {
                            addModItemToShop(Calamity, "LivingShard", 30000, ref items, ref nextSlot);
                        }

                        if (NPC.downedPlantBoss)
                        {
                            addModItemToShop(Calamity, "SolarVeil", 50000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "ravager"))
                        {
                            addModItemToShop(Calamity, "BarofLife", 100000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "astrum deus"))
                        {
                            addModItemToShop(Calamity, "MeldBlob", 10000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "profaned guardians"))
                        {
                            addModItemToShop(Calamity, "UnholyEssence", 50000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "polterghast"))
                        {
                            addModItemToShop(Calamity, "BloodOrb", 50000, ref items, ref nextSlot);
                            addModItemToShop(Calamity, "Phantoplasm", 100000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "dog") && AlchemistNPCRebornWorld.downedDOGPumpking)
                        {
                            addModItemToShop(Calamity, "NightmareFuel", 120000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "dog") && AlchemistNPCRebornWorld.downedDOGIceQueen)
                        {
                            addModItemToShop(Calamity, "EndothermicEnergy", 120000, ref items, ref nextSlot);
                        }

                        if ((bool)Calamity.Call("Downed", "buffed mothron"))
                        {
                            addModItemToShop(Calamity, "DarksunFragment", 150000, ref items, ref nextSlot);
                        }
                    }
                }
                catch (Exception)
                {
                    if (!calamityErrored)
                    {
                        calamityErrored = true;
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] It Appears Calamity is Semi-Incompatable with this Version!"), Color.Red, Main.myPlayer);
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Please report this to Ferris on Steam or Discord!"), Color.Red, Main.myPlayer);
                    }
                }
            }

            if (egoShop)
            {
                if (AlchemistNPCRebornAgain.modConfiguration.CoinsDrop && Main.hardMode)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("WorldControlUnit").Type);
                    items[nextSlot].shopCustomPrice = new int?(30);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier3ID;
                    nextSlot++;
                }

                if (!AlchemistNPCRebornAgain.modConfiguration.CoinsDrop && NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("WorldControlUnit").Type);
                    items[nextSlot].shopCustomPrice = 2000000;
                    nextSlot++;
                }

                if (NPC.downedMoonlord)
                {
                    if (AlchemistNPCRebornAgain.modConfiguration.CoinsDrop)
                    {
                        items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("TerrainReformer").Type);
                        items[nextSlot].shopCustomPrice = new int?(30);
                        items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier4ID;
                        nextSlot++;
                    }

                    if (!AlchemistNPCRebornAgain.modConfiguration.CoinsDrop)
                    {
                        items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("TerrainReformer").Type);
                        items[nextSlot].shopCustomPrice = 5000000;
                        nextSlot++;
                    }
                }

                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorSnow").Type);
                items[nextSlot].shopCustomPrice = 250000;
                nextSlot++;
                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorDesert").Type);
                items[nextSlot].shopCustomPrice = 250000;
                nextSlot++;
                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorJungle").Type);
                items[nextSlot].shopCustomPrice = 250000;
                nextSlot++;
                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorCorruption").Type);
                items[nextSlot].shopCustomPrice = 250000;
                nextSlot++;
                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorCrimson").Type);
                items[nextSlot].shopCustomPrice = 250000;
                nextSlot++;
                items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorSpace").Type);
                items[nextSlot].shopCustomPrice = 250000;
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorDungeon").Type);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("HoloprojectorHallowed").Type);
                    items[nextSlot].shopCustomPrice = 330000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("GlobalTeleporter").Type);
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("TheBeak").Type);
                    items[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("LaetitiaRibbon").Type);
                    items[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("LaetitiaCoat").Type);
                    items[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("LaetitiaLeggings").Type);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("Laetitia").Type);
                    items[nextSlot].shopCustomPrice = 350000;
                    nextSlot++;
                }

                if (NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("FuneralofDeadButterflies").Type);
                    items[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                }

                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("LaetitiaGift").Type);
                    items[nextSlot].shopCustomPrice = 300000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("ReverberationHead").Type);
                    items[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("ReverberationBody").Type);
                    items[nextSlot].shopCustomPrice = 350000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("ReverberationLegs").Type);
                    items[nextSlot].shopCustomPrice = 300000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("Reverberation").Type);
                    items[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                }

                if (NPC.downedPlantBoss)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("BigBirdLamp").Type);
                    items[nextSlot].shopCustomPrice = 750000;
                    nextSlot++;
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("GrinderMK4").Type);
                    items[nextSlot].shopCustomPrice = 750000;
                    nextSlot++;
                }

                if (NPC.downedGolemBoss)
                {
                    items[nextSlot].type = (ModLoader.GetMod("AlchemistNPCRebornAgain").Find<ModItem>("Spore").Type);
                    items[nextSlot].shopCustomPrice = 1000000;
                    nextSlot++;
                }
            }

            if (Shop3)
            {
                if (!NPC.downedBoss3)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.Notes.InformatingNote>());
                    nextSlot++;
                }

                if (NPC.downedBoss3 && Main.expertMode)
                {
                    if (NPC.downedSlimeKing)
                    {
                        items[nextSlot].type = (ItemID.KingSlimeBossBag);
                        //items[nextSlot].shopCustomPrice = 250000;
                        items[nextSlot].shopCustomPrice = new int?(4);
                        items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier1ID;
                        nextSlot++;
                    }

                    if (NPC.downedBoss1)
                    {
                        items[nextSlot].type = (ItemID.EyeOfCthulhuBossBag);
                        //items[nextSlot].shopCustomPrice = 350000;
                        items[nextSlot].shopCustomPrice = new int?(9);
                        items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier1ID;
                        nextSlot++;
                    }

                    if (NPC.downedDeerclops)
                    {
                        items[nextSlot].type = (ItemID.DeerclopsBossBag);
                        //items[nextSlot].shopCustomPrice = 2500000;
                        items[nextSlot].shopCustomPrice = new int?(9);
                        items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier1ID;
                        nextSlot++;
                    }

                    if (NPC.downedBoss2)
                    {
                        items[nextSlot].type = (ItemID.EaterOfWorldsBossBag);
                        //items[nextSlot].shopCustomPrice = 500000;
                        items[nextSlot].shopCustomPrice = new int?(14);
                        items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier1ID;
                        nextSlot++;
                        items[nextSlot].type = (ItemID.BrainOfCthulhuBossBag);
                        items[nextSlot].shopCustomPrice = new int?(14);
                        items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier1ID;
                        //items[nextSlot].shopCustomPrice = 500000;
                        nextSlot++;
                    }

                    if (NPC.downedQueenBee)
                    {
                        items[nextSlot].type = (ItemID.QueenBeeBossBag);
                        //items[nextSlot].shopCustomPrice = 750000;
                        items[nextSlot].shopCustomPrice = new int?(16);
                        items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier1ID;
                        nextSlot++;
                    }

                    items[nextSlot].type = (ItemID.SkeletronBossBag);
                    //items[nextSlot].shopCustomPrice = 1000000;
                    items[nextSlot].shopCustomPrice = new int?(5);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier2ID;
                    nextSlot++;
                }

                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                ExternalModCache.findMod("ThoriumMod", out var thoriumMod);
                if (thoriumMod != null && DD2Event.DownedInvasionT1)
                    addModItemToShop(thoriumMod, "DarkMageBag", 1000000, ref items, ref nextSlot);


                if (Main.hardMode && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.WallOfFleshBossBag);
                    //items[nextSlot].shopCustomPrice = 1500000;
                    items[nextSlot].shopCustomPrice = new int?(8);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier2ID;
                    nextSlot++;
                }

                if (NPC.downedQueenSlime && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.QueenSlimeBossBag);
                    //items[nextSlot].shopCustomPrice = 1500000;
                    items[nextSlot].shopCustomPrice = new int?(10);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier2ID;
                    nextSlot++;
                }

                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.DestroyerBossBag);
                    //items[nextSlot].shopCustomPrice = 2000000;
                    items[nextSlot].shopCustomPrice = new int?(5);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier3ID;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.TwinsBossBag);
                    //items[nextSlot].shopCustomPrice = 2000000;
                    items[nextSlot].shopCustomPrice = new int?(5);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier3ID;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.SkeletronPrimeBossBag);
                    //items[nextSlot].shopCustomPrice = 2000000;
                    items[nextSlot].shopCustomPrice = new int?(5);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier3ID;
                    nextSlot++;
                }

                if (thoriumMod != null && NPC.downedMechBossAny)
                    addModItemToShop(thoriumMod, "OgreBag", 2500000, ref items, ref nextSlot);

                if (NPC.downedPlantBoss && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.PlanteraBossBag);
                    //items[nextSlot].shopCustomPrice = 2500000;
                    items[nextSlot].shopCustomPrice = new int?(8);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier3ID;
                    nextSlot++;
                }

                if (NPC.downedGolemBoss && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.GolemBossBag);
                    //items[nextSlot].shopCustomPrice = 3000000;
                    items[nextSlot].shopCustomPrice = new int?(5);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier4ID;
                    nextSlot++;
                }

                if (DD2Event.DownedInvasionT3 && NPC.downedGolemBoss)
                {
                    items[nextSlot].type = (ItemID.BossBagBetsy);
                    //items[nextSlot].shopCustomPrice = 3500000;
                    items[nextSlot].shopCustomPrice = new int?(8);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier4ID;
                    nextSlot++;
                }

                if (NPC.downedFishron && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.FishronBossBag);
                    //items[nextSlot].shopCustomPrice = 3500000;
                    items[nextSlot].shopCustomPrice = new int?(11);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier4ID;
                    nextSlot++;
                }

                if (NPC.downedEmpressOfLight && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.FairyQueenBossBag);
                    //items[nextSlot].shopCustomPrice = 2500000;
                    items[nextSlot].shopCustomPrice = new int?(13);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier4ID;
                    nextSlot++;
                }

                if (NPC.downedMoonlord && Main.expertMode)
                {
                    items[nextSlot].type = (ItemID.MoonLordBossBag);
                    //items[nextSlot].shopCustomPrice = 4000000;
                    items[nextSlot].shopCustomPrice = new int?(26);
                    items[nextSlot].shopSpecialCurrency = AlchemistNPCRebornAgain.ReversivityCoinTier4ID;
                    nextSlot++;
                }
            }

            if (Shop4)
            {
                try
                {
                    if (Calamity != null)
                    {
                        if (NPC.downedBoss3 && Main.expertMode)
                        {
                            if ((bool)Calamity.Call("Downed", "desert scourge"))
                            {
                                addModItemToT1CShop(Calamity, "DesertScourgeBag", 6, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "crabulon"))
                            {
                                addModItemToT1CShop(Calamity, "CrabulonBag", 9, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "hive mind") || (bool)Calamity.Call("Downed", "perforators"))
                            {
                                addModItemToT1CShop(Calamity, "HiveMindBag", 16, ref items, ref nextSlot);
                                addModItemToT1CShop(Calamity, "PerforatorBag", 16, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "slime god"))
                            {
                                addModItemToT2CShop(Calamity, "SlimeGodBag", 6, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "cryogen"))
                            {
                                addModItemToT2CShop(Calamity, "CryogenBag", 10, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "brimstone elemental"))
                            {
                                if (!(bool)Calamity.Call("Downed", "providence"))
                                    addModItemToT3CShop(Calamity, "BrimstoneWaifuBag", 14, ref items, ref nextSlot);
                                else
                                    addModItemToT4CShop(Calamity, "BrimstoneWaifuBag", 12, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "aquatic scourge"))
                            {
                                addModItemToT3CShop(Calamity, "AquaticScourgeBag", 14, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
                            {
                                if (!(bool)Calamity.Call("Downed", "providence"))
                                    addModItemToT3CShop(Calamity, "CalamitasBag", 20, ref items, ref nextSlot);
                                else
                                    addModItemToT4CShop(Calamity, "CalamitasBag", 20, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "leviathan"))
                            {
                                addModItemToT3CShop(Calamity, "LeviathanBag", 23, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "astrum aureus"))
                            {
                                if (!(bool)Calamity.Call("Downed", "providence"))
                                    addModItemToT3CShop(Calamity, "AstrageldonBag", 30, ref items, ref nextSlot);
                                else
                                    addModItemToT4CShop(Calamity, "AstrageldonBag", 30, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "astrum deus"))
                            {
                                addModItemToT4CShop(Calamity, "AstrumDeusBag", 10, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "plaguebringer goliath"))
                            {
                                addModItemToT4CShop(Calamity, "PlaguebringerGoliathBag", 15, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "ravager"))
                            {
                                addModItemToT4CShop(Calamity, "RavagerBag", 20, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "bumblebirb"))
                            {
                                addModItemToT5CShop(Calamity, "BumblebirbBag", 10, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "providence"))
                            {
                                addModItemToT5CShop(Calamity, "ProvidenceBag", 14, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "stormweaver"))
                            {
                                addModItemToT6CShop(Calamity, "StormWeaverBag", 3, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "ceaselessvoid"))
                            {
                                addModItemToT6CShop(Calamity, "CeaselessVoidBag", 3, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "signus"))
                            {
                                addModItemToT6CShop(Calamity, "SignusBag", 3, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "polterghast"))
                            {
                                addModItemToT6CShop(Calamity, "PolterghastBag", 10, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "old duke"))
                            {
                                addModItemToT6CShop(Calamity, "OldDukeBag", 17, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "dog"))
                            {
                                addModItemToT6CShop(Calamity, "DevourerofGodsBag", 26, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "yharon"))
                            {
                                addModItemToT6CShop(Calamity, "YharonBag", 30, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "exomechs"))
                            {
                                addModItemToT6CShop(Calamity, "DraedonTreasureBag", 37, ref items, ref nextSlot);
                            }

                            if ((bool)Calamity.Call("Downed", "supremecalamitas"))
                            {
                                addModItemToT6CShop(Calamity, "SCalBag", 45, ref items, ref nextSlot);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    if (!calamityErrored)
                    {
                        calamityErrored = true;
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] It Appears Calamity is Semi-Incompatable with this Version!"), Color.Red, Main.myPlayer);
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Please report this to Ferris on Steam or Discord!"), Color.Red, Main.myPlayer);
                    }
                }
                // IMPLEMENT WHEN WEAKREFERENCES FIXED

                try
                {
                    if (ExternalModCache.findMod("ThoriumMod", out var thoriumMod))
                    {
                        if (NPC.downedBoss3)
                        {
                            if (ThoriumModDownedGTBird)
                            {
                                addModItemToShop(thoriumMod, "ThunderBirdBag", 500000, ref items, ref nextSlot);
                            }

                            if (ThoriumModDownedQueenJelly)
                            {
                                addModItemToShop(thoriumMod, "JellyFishBag", 750000, ref items, ref nextSlot);
                            }

                            if (ThoriumModDownedViscount)
                            {
                                addModItemToShop(thoriumMod, "CountBag", 850000, ref items, ref nextSlot);
                            }

                            if (ThoriumModDownedStorm)
                            {
                                addModItemToShop(thoriumMod, "GraniteBag", 1000000, ref items, ref nextSlot);
                            }

                            if (ThoriumModDownedChampion)
                            {
                                addModItemToShop(thoriumMod, "HeroBag", 1000000, ref items, ref nextSlot);
                            }

                            if (ThoriumModDownedStarScout)
                            {
                                addModItemToShop(thoriumMod, "ScouterBag", 1250000, ref items, ref nextSlot);
                            }

                            if (Main.hardMode)
                            {
                                if (ThoriumModDownedBoreanStrider)
                                {
                                    addModItemToShop(thoriumMod, "BoreanBag", 1500000, ref items, ref nextSlot);
                                }

                                if (ThoriumModDownedFallenBeholder)
                                {
                                    addModItemToShop(thoriumMod, "BeholderBag", 2000000, ref items, ref nextSlot);
                                }

                                if (ThoriumModDownedLich)
                                {
                                    addModItemToShop(thoriumMod, "LichBag", 3000000, ref items, ref nextSlot);
                                }

                                if (ThoriumModDownedAbyssion)
                                {
                                    addModItemToShop(thoriumMod, "AbyssionBag", 3500000, ref items, ref nextSlot);
                                }
                            }

                            if (NPC.downedMoonlord)
                            {
                                if (ThoriumModDownedRagnarok)
                                {
                                    addModItemToShop(thoriumMod, "RagBag", 5000000, ref items, ref nextSlot);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    if (!erroredThorium)
                    {
                        erroredThorium = true;
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] It Appears Thorium is Semi-Incompatable with this Version!"), Color.Red, Main.myPlayer);
                        ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Please report this to Ferris on Steam or Discord!"), Color.Red, Main.myPlayer);
                    }
                }
                /*
                if (ModLoader.GetMod("SacredTools") != null)
                {
                    if (NPC.downedBoss3)
                    {
                        if (SacredToolsDownedDecree)
                        {
                            addModItemToShop(SacredTools, "DecreeBag", 330000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedPumpkin)
                        {
                            addModItemToShop(SacredTools, "PumpkinBag", 500000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedHarpyPreHM)
                        {
                            addModItemToShop(SacredTools, "HarpyBag", 1000000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedAraneas)
                        {
                            addModItemToShop(SacredTools, "AraneasBag", 1500000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedHarpyHM)
                        {
                            addModItemToShop(SacredTools, "HarpyBag2", 2000000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedPrimordia)
                        {
                            addModItemToShop(SacredTools, "PrimordiaBag", 3000000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedAbbadon)
                        {
                            addModItemToShop(SacredTools, "OblivionBag", 5000000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedAraghur)
                        {
                            addModItemToShop(SacredTools, "SerpentBag", 7500000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedLunarians)
                        {
                            addModItemToShop(SacredTools, "LunarBag", 10000000, ref items, ref nextSlot);
                        }
                        if (SacredToolsDownedChallenger)
                        {
                            addModItemToShop(SacredTools, "ChallengerBag", 15000000, ref items, ref nextSlot);
                        }
                    }
                }
                */
            }

            if (Shop5)
            {
                if (!NPC.downedBoss3)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.Notes.InformatingNote>());
                    nextSlot++;
                }

                if (NPC.downedBoss3 && Main.expertMode)
                {
                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
                    /*
                    if (ModLoader.GetMod("AAMod") != null)
                    {
                        if (AAModDownedMonarch)
                        {
                            addModItemToShop(AAMod, "MonarchBag", 150000, ref items, ref nextSlot);
                        }
                        if (AAModDownedGrips)
                        {
                            addModItemToShop(AAMod, "GripsBag", 300000, ref items, ref nextSlot);
                        }
                        if (AAModDownedTruffleToad)
                        {
                            addModItemToShop(AAMod, "TruffleBag", 350000, ref items, ref nextSlot);
                        }
                        if (AAModDownedBrood)
                        {
                            addModItemToShop(AAMod, "BroodBag", 500000, ref items, ref nextSlot);
                        }
                        if (AAModDownedHydra)
                        {
                            addModItemToShop(AAMod, "HydraBag", 750000, ref items, ref nextSlot);
                        }
                        if (AAModDownedSerpent)
                        {
                            addModItemToShop(AAMod, "SerpentBag", 1000000, ref items, ref nextSlot);
                        }
                        if (AAModDownedDjinn)
                        {
                            addModItemToShop(AAMod, "DjinnBag", 1000000, ref items, ref nextSlot);
                        }
                        if (AAModDownedEquinox)
                        {
                            addModItemToShop(AAMod, "DBBag", 2500000, ref items, ref nextSlot);
                            addModItemToShop(AAMod, "NCBag", 2500000, ref items, ref nextSlot);
                        }
                        if (AAModDownedSisters)
                        {
                            addModItemToShop(AAMod, "AHBag", 5000000, ref items, ref nextSlot);
                        }
                        if (AAModDownedYamata)
                        {
                            addModItemToShop(AAMod, "YamataBag", 5000000, ref items, ref nextSlot);
                        }
                        if (AAModDownedAkuma)
                        {
                            addModItemToShop(AAMod, "AkumaBag", 5000000, ref items, ref nextSlot);
                        }
                        if (AAModDownedZero)
                        {
                            addModItemToShop(AAMod, "ZeroBag", 10000000, ref items, ref nextSlot);
                        }
                        if (AAModDownedShen)
                        {
                            addModItemToShop(AAMod, "ShenCache", 15000000, ref items, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("SpiritMod") != null)
                    {
                        if (SpiritModDownedScarabeus)
                        {
                            addModItemToShop(SpiritMod, "BagOScarabs", 300000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedBane)
                        {
                            addModItemToShop(SpiritMod, "ReachBossBag", 500000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedFlier)
                        {
                            addModItemToShop(SpiritMod, "FlyerBag", 750000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedStarplateRaider)
                        {
                            addModItemToShop(SpiritMod, "SteamRaiderBag", 1000000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedInfernon)
                        {
                            addModItemToShop(SpiritMod, "InfernonBag", 2000000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedDusking)
                        {
                            addModItemToShop(SpiritMod, "DuskingBag", 2500000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedEtherialUmbra)
                        {
                            addModItemToShop(SpiritMod, "SpiritCoreBag", 2500000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedIlluminantMaster)
                        {
                            addModItemToShop(SpiritMod, "IlluminantBag", 3000000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedAtlas)
                        {
                            addModItemToShop(SpiritMod, "AtlasBag", 4000000, ref items, ref nextSlot);
                        }
                        if (SpiritModDownedOverseer)
                        {
                            addModItemToShop(SpiritMod, "OverseerBag", 8000000, ref items, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("Laugicality") != null)
                    {
                        if (EnigmaDownedSharkron)
                        {
                            addModItemToShop(Laugicality, "DuneSharkronTreasureBag", 300000, ref items, ref nextSlot);
                        }
                        if (EnigmaDownedHypothema)
                        {
                            addModItemToShop(Laugicality, "HypothemaTreasureBag", 500000, ref items, ref nextSlot);
                        }
                        if (EnigmaDownedRagnar)
                        {
                            addModItemToShop(Laugicality, "RagnarTreasureBag", 750000, ref items, ref nextSlot);
                        }
                        if (EnigmaDownedAnDio)
                        {
                            addModItemToShop(Laugicality, "AnDioTreasureBag", 1000000, ref items, ref nextSlot);
                        }
                        if (EnigmaDownedAnnihilator)
                        {
                            addModItemToShop(Laugicality, "AnnihilatorTreasureBag", 2000000, ref items, ref nextSlot);
                        }
                        if (EnigmaDownedSlybertron)
                        {
                            addModItemToShop(Laugicality, "SlybertronTreasureBag", 2000000, ref items, ref nextSlot);
                        }
                        if (EnigmaDownedSteamTrain)
                        {
                            addModItemToShop(Laugicality, "SteamTrainTreasureBag", 2000000, ref items, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("pinkymod") != null)
                    {
                        if (PinkymodDownedST)
                        {
                            addModItemToShop(pinkymod, "STBag", 500000, ref items, ref nextSlot);
                        }
                        if (PinkymodDownedMS)
                        {
                            addModItemToShop(pinkymod, "HOTCTreasureBag", 750000, ref items, ref nextSlot);
                            addModItemToShop(pinkymod, "MythrilBag", 1000000, ref items, ref nextSlot);
                        }
                        if (PinkymodDownedVD)
                        {
                            addModItemToShop(pinkymod, "Valdabag", 1500000, ref items, ref nextSlot);
                        }
                        if (PinkymodDownedAD)
                        {
                            addModItemToShop(pinkymod, "GatekeeperTreasureBag", 2500000, ref items, ref nextSlot);
                        }
                    }
                    */
                }
            }

            if (Shop6)
            {
                if (!NPC.downedBoss3)
                {
                    items[nextSlot].type = (ModContent.ItemType<Items.Notes.InformatingNote>());
                    nextSlot++;
                }

                if (NPC.downedBoss3 && Main.expertMode)
                {
                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
                    /*
                    if (ModLoader.GetMod("ElementsAwoken") != null)
                    {
                        if (EADownedWasteland)
                        {
                            addModItemToShop(ElementsAwoken, "WastelandBag", 300000, ref items, ref nextSlot);
                        }
                        if (EADownedInfernace)
                        {
                            addModItemToShop(ElementsAwoken, "InfernaceBag", 500000, ref items, ref nextSlot);
                        }
                        if (EADownedScourgeFighter)
                        {
                            addModItemToShop(ElementsAwoken, "ScourgeFighterBag", 1500000, ref items, ref nextSlot);
                        }
                        if (EADownedRegaroth)
                        {
                            addModItemToShop(ElementsAwoken, "RegarothBag", 1750000, ref items, ref nextSlot);
                        }
                        if (EADownedPermafrost)
                        {
                            addModItemToShop(ElementsAwoken, "PermafrostBag", 2250000, ref items, ref nextSlot);
                        }
                        if (EADownedObsidious)
                        {
                            addModItemToShop(ElementsAwoken, "ObsidiousBag", 2250000, ref items, ref nextSlot);
                        }
                        if (EADownedAqueous)
                        {
                            addModItemToShop(ElementsAwoken, "AqueousBag", 2500000, ref items, ref nextSlot);
                        }
                        if (EADownedWyrm)
                        {
                            addModItemToShop(ElementsAwoken, "TempleKeepersBag", 2750000, ref items, ref nextSlot);
                        }
                        if (EADownedGuardian)
                        {
                            addModItemToShop(ElementsAwoken, "GuardianBag", 3000000, ref items, ref nextSlot);
                        }
                        if (EADownedVolcanox)
                        {
                            addModItemToShop(ElementsAwoken, "VolcanoxBag", 5000000, ref items, ref nextSlot);
                        }
                        if (EADownedVoidLevi)
                        {
                            addModItemToShop(ElementsAwoken, "VoidLeviathanBag", 6000000, ref items, ref nextSlot);
                        }
                        if (EADownedAzana)
                        {
                            addModItemToShop(ElementsAwoken, "AzanaBag", 8000000, ref items, ref nextSlot);
                        }
                        if (EADownedAncients)
                        {
                            addModItemToShop(ElementsAwoken, "AncientsBag", 10000000, ref items, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("Redemption") != null)
                    {
                        if (ReDownedChicken)
                        {
                            addModItemToShop(Redemption, "KingChickenBag", 150000, ref items, ref nextSlot);
                        }
                        if (ReDownedThorn)
                        {
                            addModItemToShop(Redemption, "ThornBag", 250000, ref items, ref nextSlot);
                        }
                        if (ReDownedKeeper)
                        {
                            addModItemToShop(Redemption, "TheKeeperBag", 350000, ref items, ref nextSlot);
                        }
                        if (ReDownedCrystal)
                        {
                            addModItemToShop(Redemption, "XenomiteCrystalBag", 500000, ref items, ref nextSlot);
                        }
                        if (ReDownedIEye)
                        {
                            addModItemToShop(Redemption, "InfectedEyeBag", 1000000, ref items, ref nextSlot);
                        }
                        if (ReDownedKingSlayer)
                        {
                            addModItemToShop(Redemption, "SlayerBag", 1500000, ref items, ref nextSlot);
                        }
                        if (ReDownedVCleaver)
                        {
                            addModItemToShop(Redemption, "VlitchCleaverBag", 2000000, ref items, ref nextSlot);
                        }
                        if (ReDownedVGigipede)
                        {
                            addModItemToShop(Redemption, "VlitchGigipedeBag", 3000000, ref items, ref nextSlot);
                        }
                        if (ReDownedObliterator)
                        {
                            addModItemToShop(Redemption, "OmegaOblitBag", 5000000, ref items, ref nextSlot);
                        }
                        if (ReDownedPZero)
                        {
                            addModItemToShop(Redemption, "PZBag", 6000000, ref items, ref nextSlot);
                        }
                        if (ReDownedThornRe && ReDownedGolemRe)
                        {
                            addModItemToShop(Redemption, "ThornPZBag", 7000000, ref items, ref nextSlot);
                        }
                        if (ReDownedNebuleus)
                        {
                            addModItemToShop(Redemption, "NebBag", 10000000, ref items, ref nextSlot);
                        }
                    }
                    */
                }
            }
        }
    }
}
