using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent;
using AlchemistNPCRebornAgain.NPCs;
using ReLogic.Content;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using AlchemistNPCRebornAgain.Interface;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Architect : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public static bool Shop5 = false;
        public static bool Shop6 = false;
        public static bool Shop7 = false;
        public static bool Shop8 = false;
        public static bool Shop9 = false;
        public static bool Shop10 = false;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Architect"; }
        }
        // Possibly removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Architect";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = 3;
            NPCID.Sets.AttackTime[NPC.type] = 35;
            NPCID.Sets.AttackAverageChance[NPC.type] = 50;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.Joe"), () => "Joe");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.Mark"), () => "Mark");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.Walter"), () => "Walter");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.Archer"), () => "Archer");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.Frido"), () => "Frido");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.Li"), () => "Li");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A1"), () => "If this dastardly ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A2"), () => " isn't going to shut up, I'm letting ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A3"), () => " bite her.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A4"), () => "KILL THE ZOMBIES! KILL THE BUNNIES! IN THE NAME OF THE BLOO- oh sorry I didn't notice you here.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A5"), () => "Why hello there I'm just getting some blood buckets for a lake I'm making please dont ask any more questions");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A6"), () => "I like it when there is a gigantic horde of zombies behind our doors. But I HATE WHEN THEY BREAK MY DOORS!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A7"), () => "Ah, the feeling that I'm not safe, the paranoia is embraced the moment the bloodmoon rises up in the sky.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A8"), () => "Are you interested in my religion? It invloves sacrifices to the bloody moon.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A9"), () => "Do you know why I hate these goblins? They are mildly annoying.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A10"), () => "Hooray to pirates! They supply me with my golden furniture!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A11"), () => "Ah! Finally some proper plating to have my roof done!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A12"), () => "No explosives please, ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A13"), () => " is already annoying me enough.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A13"), () => "BUILDER POTIONS FREE FOR EVERYONE but you.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A14"), () => "What? Where I got my architect degree? There's an architect degree?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A15"), () => "Did'ja know that wood somehow doesn't burn? Though under certain circumstances it does. Weird...");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A16"), () => "No, I am not the guy. I'm the dude.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A17"), () => "Well, the one you recently made was ALMOST impressive. (not really)");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A18"), () => "So, you say that chests are furniture too. I reply: Screw you.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A19"), () => "I saw your buildings but I am still not impressed");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A20"), () => "Have you heard 'bout that FuryForged guy? I taught him all he knows!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.A21"), () => "I was once hired by a certain company to build a supermassive hi-tech, hi-security installation. Lemme tell ya its my magnum opus in terms of security and containment.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS1"), () => "1st shop (Filler Blocks)       ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS2"), () => "2nd shop (Building Blocks)     ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS3"), () => "3rd shop (Basic Furniture)     ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS4"), () => "4th shop (Advanced Furniture)  ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS5"), () => "5th shop (Torches)             ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS6"), () => "6th shop (Candles)             ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS7"), () => "7th shop (Lamps)               ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS8"), () => "8th shop (Lanterns)            ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS9"), () => "9th shop (Chandeliers)         ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.AS10"), () => "10th shop (Candelabras)        ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Architect.ShopsChanger"), () => "Shops Changer");

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Painter, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCRebornAgain.Bestiary.Architect")
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
            AnimationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (numTownNPCs >= 3 && AlchemistNPCRebornAgain.modConfiguration.ArchitectSpawn)
                return true;

            return false;
        }


        public override List<string> SetNPCNameList() =>
            new List<string>()
            {
                Language.GetTextValue(Mod.GetLocalizationKey("NPC.Architect.Joe")),
                Language.GetTextValue(Mod.GetLocalizationKey("NPC.Architect.Mark")),
                Language.GetTextValue(Mod.GetLocalizationKey("NPC.Architect.Walter")),
                Language.GetTextValue(Mod.GetLocalizationKey("NPC.Architect.Archer")),
                Language.GetTextValue(Mod.GetLocalizationKey("NPC.Architect.Frido")),
                Language.GetTextValue(Mod.GetLocalizationKey("NPC.Architect.Li"))
            };


        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 10;
            knockback = 8f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 10;
        }

        public override void DrawTownAttackSwing(  ref Texture2D item, ref Rectangle itemFrame, ref int itemSize, ref float scale, ref Vector2 offset) //Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). ItemType is the Texture2D instance of the item to be drawn (use Main.PopupTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 1f;
            item = TextureAssets.Item[ItemID.IronHammer].Value; //this defines the item that this npc will use
            itemSize = 40;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 50;
            itemHeight = 50;
        }

        public override string GetChat()
        {
            int goblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
            int Operator = NPC.FindFirstNPC(ModContent.NPCType<Operator>());
            if (Main.bloodMoon && partyGirl >= 0 && goblinTinkerer >= 0 && Main.rand.NextBool(4))
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A1")) + Main.npc[partyGirl].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A2")) + Main.npc[goblinTinkerer].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A3"));
            }

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A4"));
                    case 1:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A5"));
                    case 2:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A6"));
                    case 3:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A7"));
                    case 4:
                        return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A8"));
                }
            }

            if (Main.invasionType == 1)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A9"));
            }

            if (Main.invasionType == 3)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A10"));
            }

            if (Main.invasionType == 4)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A11"));
            }

            if (demolitionist >= 0 && Main.rand.Next(5) == 0)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A12")) + Main.npc[demolitionist].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A13"));
            }

            if (Operator >= 0 && Main.rand.Next(7) == 0)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A21"));
            }

            switch (Main.rand.Next(8))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A14"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A15"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A16"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A17"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A18"));
                case 5:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A19"));
                case 6:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A21"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.A20"));
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (Shop1)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS1"));
            }
            else if (Shop2)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS2"));
            }
            else if (Shop3)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS3"));
            }
            else if (Shop4)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS4"));
            }
            else if (Shop5)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS5"));
            }
            else if (Shop6)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS6"));
            }
            else if (Shop7)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS7"));
            }
            else if (Shop8)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS8"));
            }
            else if (Shop9)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS9"));
            }
            else if (Shop10)
            {
                button = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.AS10"));
            }

            button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Alchemist.ShopsChanger"));
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Shop";
                ShopChangeUIA.visible = false;
            }
            else
            {
                if (!ShopChangeUIA.visible) ShopChangeUIA.timeStart = Main.GameUpdateCount;
                ShopChangeUIA.visible = true;
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
                items[nextSlot].type = (ItemID.DirtBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.ClayBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.StoneBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.EbonstoneBlock);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.CrimstoneBlock);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    items[nextSlot].type = (ItemID.Hive);
                    items[nextSlot].shopCustomPrice = 10;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.SandBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.EbonsandBlock);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.CrimsandBlock);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.Sandstone);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.HardenedSand);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.MudBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    items[nextSlot].type = (ItemID.DesertFossil);
                    nextSlot++;
                    items[nextSlot].type = (ItemID.Obsidian);
                    items[nextSlot].shopCustomPrice = 2500;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.AshBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.SiltBlock);
                nextSlot++;
                items[nextSlot].type = (ItemID.SlushBlock);
                nextSlot++;
                items[nextSlot].type = (ItemID.SnowBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.IceBlock);
                items[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                items[nextSlot].type = (ItemID.Marble);
                items[nextSlot].shopCustomPrice = 50;
                nextSlot++;
                items[nextSlot].type = (ItemID.Granite);
                items[nextSlot].shopCustomPrice = 50;
                nextSlot++;
                items[nextSlot].type = (ItemID.Cloud);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.RainCloud);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.PearlstoneBlock);
                    items[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.PearlsandBlock);
                    items[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                }
            }

            if (Shop2)
            {
                items[nextSlot].type = (ItemID.RedBrick);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.Wood);
                items[nextSlot].shopCustomPrice = 5;
                nextSlot++;
                items[nextSlot].type = (ItemID.Ebonwood);
                items[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                items[nextSlot].type = (ItemID.Shadewood);
                items[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                items[nextSlot].type = (ItemID.BorealWood);
                items[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                items[nextSlot].type = (ItemID.PalmWood);
                items[nextSlot].shopCustomPrice = 15;
                nextSlot++;
                items[nextSlot].type = (ItemID.RichMahogany);
                items[nextSlot].shopCustomPrice = 15;
                nextSlot++;
                if (NPC.downedGoblins && ExternalModCache.findMod("ThoriumMod", out var thoriumMod) && thoriumMod != null)
                    addModItemToShop(thoriumMod, "YewWood", 500, ref items, ref nextSlot);
                    
                
                
                items[nextSlot].type = (ItemID.DynastyWood);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.RedDynastyShingles);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.BlueDynastyShingles);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.Pearlwood);
                    items[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.GrayBrick);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.Glass);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.MeteoriteBrick);
                items[nextSlot].shopCustomPrice = 4;
                nextSlot++;
                items[nextSlot].type = (ItemID.ObsidianBrick);
                items[nextSlot].shopCustomPrice = 5;
                nextSlot++;
                items[nextSlot].type = (ItemID.IridescentBrick);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.SnowBrick);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.SandstoneBrick);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.EbonstoneBrick);
                items[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                items[nextSlot].type = (ItemID.IceBrick);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.FleshBlock);
                items[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                items[nextSlot].type = (ItemID.StoneSlab);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.SandstoneSlab);
                items[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                items[nextSlot].type = (ItemID.MarbleBlock);
                items[nextSlot].shopCustomPrice = 75;
                nextSlot++;
                items[nextSlot].type = (ItemID.GraniteBlock);
                items[nextSlot].shopCustomPrice = 75;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    items[nextSlot].type = (ItemID.HoneyBlock);
                    items[nextSlot].shopCustomPrice = 5;
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.CrystalBlock);
                    items[nextSlot].shopCustomPrice = 100;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.SunplateBlock);
                items[nextSlot].shopCustomPrice = 25;
                nextSlot++;
                items[nextSlot].type = (ItemID.Pumpkin);
                items[nextSlot].shopCustomPrice = 125;
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ItemID.PinkBrick);
                    items[nextSlot].shopCustomPrice = 50;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.GreenBrick);
                    items[nextSlot].shopCustomPrice = 50;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.BlueBrick);
                    items[nextSlot].shopCustomPrice = 50;
                    nextSlot++;
                }

                if (NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (ItemID.AsphaltBlock);
                    items[nextSlot].shopCustomPrice = 2;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.FleshBlock);
                    items[nextSlot].shopCustomPrice = 10;
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.PearlstoneBrick);
                    items[nextSlot].shopCustomPrice = 10;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.RainbowBrick);
                    items[nextSlot].shopCustomPrice = 100;
                    nextSlot++;
                }

                if (NPC.downedGolemBoss)
                {
                    items[nextSlot].type = (ItemID.LihzahrdBrick);
                    items[nextSlot].shopCustomPrice = 100;
                    nextSlot++;
                }

                if (NPC.downedMartians)
                {
                    items[nextSlot].type = (ItemID.MartianConduitPlating);
                    items[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                }
            }

            if (Shop3)
            {
                items[nextSlot].type = (ItemID.Candle);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.GoldChandelier);
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (ItemID.ChainLantern);
                items[nextSlot].shopCustomPrice = 200;
                nextSlot++;
                items[nextSlot].type = (ItemID.Mannequin);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.Womannquin);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.Cobweb);
                items[nextSlot].shopCustomPrice = 20;
                nextSlot++;
                items[nextSlot].type = (ItemID.WorkBench);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                items[nextSlot].type = (ItemID.WoodenTable);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                items[nextSlot].type = (ItemID.WoodenChair);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                items[nextSlot].type = (ItemID.WoodenDoor);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                items[nextSlot].type = (ItemID.WoodenBeam);
                items[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                items[nextSlot].type = (ItemID.Book);
                items[nextSlot].shopCustomPrice = 250;
                nextSlot++;
                items[nextSlot].type = (ItemID.Fireplace);
                items[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Chimney);
                items[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Furnace);
                items[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                items[nextSlot].type = (ItemID.BanquetTable);
                items[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                items[nextSlot].type = (ItemID.HeavyWorkBench);
                items[nextSlot].shopCustomPrice = 3000;
                nextSlot++;

                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.BrickLayer);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.PortableCementMixer);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.PaintSprayer);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.ExtendoGrip);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    items[nextSlot].type = (3624);
                    items[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ItemID.Ruler);
                    items[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.EngineeringHelmet);
                    items[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }
            }

            if (Shop4)
            {
                items[nextSlot].type = (ItemID.LivingLoom);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    items[nextSlot].type = (ItemID.AlchemyTable);
                    items[nextSlot].shopCustomPrice = 33000;
                    nextSlot++;
                    items[nextSlot].type = (ItemID.BoneWelder);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.GlassKiln);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                items[nextSlot].type = (ItemID.SkyMill);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                items[nextSlot].type = (ItemID.IceMachine);
                items[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    items[nextSlot].type = (ItemID.HoneyDispenser);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }

                items[nextSlot].type = (ItemID.Sawmill);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                items[nextSlot].type = (ItemID.Loom);
                items[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (ItemID.MeatGrinder);
                    items[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                }

                if (NPC.downedMechBossAny)
                {
                    items[nextSlot].type = (ItemID.FleshCloningVaat);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }

                if (NPC.downedPlantBoss)
                {
                    items[nextSlot].type = (ItemID.LihzahrdFurnace);
                    items[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }
            }

            if (Shop5)
            {
                items[nextSlot].type = (ItemID.Torch);
                items[nextSlot].shopCustomPrice = 50;
                nextSlot++;
                items[nextSlot].type = (ItemID.TikiTorch);
                items[nextSlot].shopCustomPrice = 250;
                nextSlot++;
                items[nextSlot].type = (974);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (427);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (428);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (1245);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (429);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (430);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (431);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (432);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (433);
                items[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                items[nextSlot].type = (523);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1333);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2274);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3004);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3045);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3114);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
            }

            if (Shop6)
            {
                items[nextSlot].type = (105);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (713);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1405);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1406);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1407);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2045);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2046);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2047);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2048);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2049);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2050);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (2051);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }

                items[nextSlot].type = (2052);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2153);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2154);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2155);
                items[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                items[nextSlot].type = (2236);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2523);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2542);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2556);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2571);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2648);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2649);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2650);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2651);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    items[nextSlot].type = (2818);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }

                items[nextSlot].type = (3171);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3172);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3173);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (3890);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }

            if (Shop7)
            {
                items[nextSlot].type = (341);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2082);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2083);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2084);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2085);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2086);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2087);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (2088);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }

                items[nextSlot].type = (2089);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2090);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2091);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2129);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2130);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2131);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2132);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2133);
                items[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                items[nextSlot].type = (2134);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2225);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2533);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2547);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2563);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2578);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2643);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2644);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2645);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2646);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2647);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    items[nextSlot].type = (2819);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                    items[nextSlot].type = (2820);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }

                items[nextSlot].type = (3135);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3136);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3137);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (3892);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }

            if (Shop8)
            {
                items[nextSlot].type = (136);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (344);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (347);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1390);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1391);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1392);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1393);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1394);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (1808);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2032);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2033);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2034);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2035);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2036);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2037);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2038);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (2039);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }

                items[nextSlot].type = (2040);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2041);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2042);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2043);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2145);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2146);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2147);
                items[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                items[nextSlot].type = (2148);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2226);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2530);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2546);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2564);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2579);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2641);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2642);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2820);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3138);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3139);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3140);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (3891);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }

            if (Shop9)
            {
                items[nextSlot].type = (106);
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (107);
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (108);
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (710);
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (711);
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (712);
                items[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                items[nextSlot].type = (2055);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2056);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2057);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2058);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2059);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2060);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (2061);
                    items[nextSlot].shopCustomPrice = 1200;
                    nextSlot++;
                }

                items[nextSlot].type = (2062);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2063);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2064);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2065);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2141);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2142);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2143);
                items[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                items[nextSlot].type = (2144);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2224);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2525);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2543);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2558);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2573);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2652);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2653);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2654);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2655);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2656);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (2657);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    items[nextSlot].type = (2813);
                    items[nextSlot].shopCustomPrice = 1200;
                    nextSlot++;
                }

                items[nextSlot].type = (3177);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (3178);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                items[nextSlot].type = (3179);
                items[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (3894);
                    items[nextSlot].shopCustomPrice = 1200;
                    nextSlot++;
                }
            }

            if (Shop10)
            {
                items[nextSlot].type = (349);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (714);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2092);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2093);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2094);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2095);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2096);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2097);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2098);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (2099);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }

                items[nextSlot].type = (2100);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2101);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2102);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2103);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2149);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2150);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2151);
                items[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                items[nextSlot].type = (2152);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2227);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2522);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2541);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2555);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2570);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2664);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2665);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2666);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2667);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (2668);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    items[nextSlot].type = (2825);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }

                items[nextSlot].type = (3168);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3169);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                items[nextSlot].type = (3170);
                items[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    items[nextSlot].type = (3893);
                    items[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }
        }
    }
}
