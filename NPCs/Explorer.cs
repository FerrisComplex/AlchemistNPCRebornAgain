using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class Explorer : ModNPC
    {
        public static bool C11 = false;
        public static bool C12 = false;
        public static bool C13 = false;
        public static bool C14 = false;
        public static bool C15 = false;
        public static bool C21 = false;
        public static bool C22 = false;
        public static bool C23 = false;
        public static bool C24 = false;
        public static bool C25 = false;
        public static bool C26 = false;
        public static bool C31 = false;
        public static bool C32 = false;
        public static bool C33 = false;
        public static bool C34 = false;
        public static bool C35 = false;
        public static bool C41 = false;
        public static bool C42 = false;
        public static bool C43 = false;
        public static bool C44 = false;
        public static bool C45 = false;
        public static bool C51 = false;
        public static bool C52 = false;
        public static bool C53 = false;
        public static bool C54 = false;
        public static bool C55 = false;
        public static bool C61 = false;
        public static bool C62 = false;
        public static bool C63 = false;
        public static bool C64 = false;
        public static bool C65 = false;
        public static bool C71 = false;
        public static bool C72 = false;
        public static bool C73 = false;
        public static bool C74 = false;
        public static bool C75 = false;
        public static bool C81 = false;
        public static bool C82 = false;
        public static bool C83 = false;
        public static bool C84 = false;

        public override string Texture
        {
            get { return "AlchemistNPCRebornAgain/NPCs/Explorer"; }
        }

        public override void ResetEffects()
        {
            C11 = false;
            C12 = false;
            C13 = false;
            C14 = false;
            C15 = false;
            C21 = false;
            C22 = false;
            C23 = false;
            C24 = false;
            C25 = false;
            C26 = false;
            C31 = false;
            C32 = false;
            C33 = false;
            C34 = false;
            C35 = false;
            C41 = false;
            C42 = false;
            C43 = false;
            C44 = false;
            C45 = false;
            C51 = false;
            C52 = false;
            C53 = false;
            C54 = false;
            C55 = false;
            C61 = false;
            C62 = false;
            C63 = false;
            C64 = false;
            C65 = false;
            C71 = false;
            C72 = false;
            C73 = false;
            C74 = false;
            C75 = false;
            C81 = false;
            C82 = false;
            C83 = false;
            C84 = false;
        }


        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;
            NPC.netUpdate = true;


            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Names.Elizabeth"), () => "Elizabeth");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Names.Dora"), () => "Dora");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create1"), () => "Create #1");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create2"), () => "Create #2");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create3"), () => "Create #3");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create4"), () => "Create #4");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create5"), () => "Create #5");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create6"), () => "Create #6");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create7"), () => "Create #7");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Create8"), () => "Create #8");

            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A1"), () => "So, were my notes of any use to you?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A2"), () => "I know about special materials which can help you.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A3"), () => "You want to try Blade with power of Determination? Just make Extractor and get some Soul Essences and Hate Vials.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A4"), () => "''There's a legendary yoyo known as the Sasscade.''... I am pretty sure you heard about that before. But I know how you can get it.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A5"), () => "If you want to take part in my researches, then grab my notes and check if you can help. All results will belong to you.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A6"), () => "Luckily, I get my Interdimensional Casket with me, so I can make potions. My inventions, of course.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A7"), () => "Celestial's Particles are pretty interesting... You can use them for crafting some special accessories and equipment or simply for making Celestial Fragments.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A8"), () => "If you've already found the Otherworldly Amulet, then you can ask ");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A9"), () => " to sell Celestial Fragments.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A10"), () => "That was the most powerful and dangerous creature in the jungle, but you killed it. Does that mean that you are now the most dangerous creature in the jungle?");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A11"), () => "Otherworldly Amulet has much more uses than you ever thought... It could help Alchemist to make Celestial's Particles, it could summon mount Poro for you and it is required for making Autoinjector or Watcher Amulet.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A12"), () => "If you managed to create Watcher Amulet, then you could buy Flask of Rainbows from Young Brewer. It is a very powerful imbuement, which can help you overcome great enemies.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A13"), () => "I once met a man that traveled on top an alicorn. He looked truly FABulous!");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A14"), () => "Can you bring me the Unicorn for examination? I am sure that your bug net is strong enough for that.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A15"), () => "Messing with the quantic shroud is no fun-time business, hero. Be careful when choosing what power to pick on.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A16"), () => "The time-space continuum is possibly the worst combination in this existance: both a delicate but mastercrafted estructure in a skillfully achieved but pathetically fragile balance and at the same time an absolute and undeniable force of nature that posseses total control of our everything and composes what we call ''reality and fiction'', volatile as you wouldn't believe.");
            Language.GetOrRegister(Mod.GetLocalizationKey("NPC.Explorer.Text.A17"), () => "Take it from someone with experience on it, friend: ''A flying giant divine cosmic worm of the heavens of who-damn-knows-what-deities is the most normal thing you'll find out there compared to what lurks in the darkness of deep space.''");
            

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers { Velocity = -1f, Direction = -1 };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetNPCAffection(NPCID.Guide, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Hate);
        }

        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Names.Elizabeth")),
            Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Names.Dora"))
        };

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Mod.GetLocalizationKey("Bestiary.Explorer"))
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
            NPC.defense = 500;
            NPC.lifeMax = 500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Mechanic;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) => false;


        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 100;
            knockback = 16f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.MoonlordBullet;
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 32f;
        }

        //public override void DrawTownAttackGun(ref float scale, ref Item item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        //{
        //	scale = 1f;
        //	closeness = 15;
        //	item = ModContent.ItemType<AlchemistNPCReborn.Items.Weapons.Nyx>();
        //}

        public override string GetChat()
        {
            //npc chat

            
            int Operator = NPC.FindFirstNPC(ModContent.NPCType<NPCs.Operator>());
            if (Operator >= 0 && Main.rand.Next(4) == 0)
            {
                return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A8")) + Main.npc[Operator].GivenName + Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A9"));
            }

            
            if (ExternalModCache.findMod("CalamityMod", out var Calamity))
            {
                if ((bool)Calamity.Call("Downed", "dog") && Main.rand.NextBool(10))
                {
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A17"));
                }
            }

            switch (Main.rand.Next(14))
            {
                case 0:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A1"));
                case 1:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A2"));
                case 2:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A3"));
                case 3:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A4"));
                case 4:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A5"));
                case 5:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A6"));
                case 6:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A7"));
                case 7:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A11"));
                case 8:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A12"));
                case 9:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A13"));
                case 10:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A14"));
                case 11:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A15"));
                case 12:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A16"));
                default:
                    return Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Text.A10"));
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                foreach (var t in player.inventory)
                {
                    if (t.type == ItemID.Terrarian)
                    {
                        C11 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C12 = true;
                    }
                    else if (t.type == ItemID.RodofDiscord)
                    {
                        C13 = true;
                    }
                    else if (t.type == ItemID.YoyoBag)
                    {
                        C14 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote1>())
                    {
                        C15 = true;
                    }
                    else if (t.type == ItemID.RainbowRod)
                    {
                        C21 = true;
                    }
                    else if (t.type == ItemID.LastPrism)
                    {
                        C22 = true;
                    }
                    else if (t.type == ItemID.AngelWings)
                    {
                        C23 = true;
                    }
                    else if (t.type == ItemID.ButterflyDust)
                    {
                        C24 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Summoning.CaughtUnicorn>())
                    {
                        C25 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote2>())
                    {
                        C26 = true;
                    }
                    else if (t.type == ItemID.ChargedBlasterCannon)
                    {
                        C31 = true;
                    }
                    else if (t.type == ItemID.HeatRay)
                    {
                        C32 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C33 = true;
                    }
                    else if (t.type == ItemID.SniperScope)
                    {
                        C34 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote3>())
                    {
                        C35 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C41 = true;
                    }
                    else if (t.type == ItemID.SkeletronTrophy)
                    {
                        C42 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.HateVial>())
                    {
                        C43 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.RainbowFlask>())
                    {
                        C44 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote4>())
                    {
                        C45 = true;
                    }
                    else if (t.type == ItemID.PiranhaGun)
                    {
                        C51 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C52 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.RainbowFlask>())
                    {
                        C53 = true;
                    }
                    else if (t.type == ItemID.MoonStone)
                    {
                        C54 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote5>())
                    {
                        C55 = true;
                    }
                    else if (t.type == ItemID.DeathSickle)
                    {
                        C61 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.HateVial>())
                    {
                        C62 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C63 = true;
                    }
                    else if (t.type == ItemID.CelestialStone)
                    {
                        C64 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote6>())
                    {
                        C65 = true;
                    }
                    else if (t.type == ItemID.PortalGun)
                    {
                        C71 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C72 = true;
                    }
                    else if (t.type == ItemID.MoonlordTurretStaff)
                    {
                        C73 = true;
                    }
                    else if (t.type == ItemID.REK)
                    {
                        C74 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote7>())
                    {
                        C75 = true;
                    }
                    else if (t.type == ItemID.PortalGun)
                    {
                        C81 = true;
                    }
                    else if (t.type == ItemID.CompanionCube)
                    {
                        C82 = true;
                    }
                    else if (t.type == ItemID.DD2FlameburstTowerT3Popper)
                    {
                        C83 = true;
                    }
                    else if (t.type == ModContent.ItemType<Items.Notes.ResearchNote8>())
                    {
                        C84 = true;
                    }
                }
            }

            if (C11 && C12 && C13 && C14 && C15)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create1"));
            }

            if (C21 && C22 && C23 && C24 && C25 && C26)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create2"));
            }

            if (C31 && C32 && C33 && C34 && C35)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create3"));
            }

            if (C41 && C42 && C43 && C44 && C45)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create4"));
            }

            if (C51 && C52 && C53 && C54 && C55)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create5"));
            }

            if (C61 && C62 && C63 && C64 && C65)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create6"));
            }

            if (C71 && C72 && C73 && C74 && C75)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create7"));
            }

            if (C81 && C82 && C83 && C84)
            {
                button2 = Language.GetTextValue(Mod.GetLocalizationKey("NPC.Explorer.Create8"));
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
            }
            else
            {
                if (C11 && C12 && C13 && C14 && C15)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.Sasscade>());
                    if (Main.player[Main.myPlayer].HasItem(ItemID.Terrarian))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ItemID.Terrarian && C11)
                            {
                                inventory[k].stack--;
                                C11 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C12)
                            {
                                inventory[k].stack--;
                                C12 = false;
                            }

                            if (inventory[k].type == ItemID.RodofDiscord && C13)
                            {
                                inventory[k].stack--;
                                C13 = false;
                            }

                            if (inventory[k].type == ItemID.YoyoBag && C14)
                            {
                                inventory[k].stack--;
                                C14 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote1>() && C15)
                            {
                                inventory[k].stack--;
                                C15 = false;
                            }
                        }
                    }
                }

                if (C21 && C22 && C23 && C24 && C25 && C26)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.MagicWand>());
                    if (Main.player[Main.myPlayer].HasItem(ItemID.RainbowRod))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ItemID.RainbowRod && C21)
                            {
                                inventory[k].stack--;
                                C21 = false;
                            }

                            if (inventory[k].type == ItemID.LastPrism && C22)
                            {
                                inventory[k].stack--;
                                C22 = false;
                            }

                            if (inventory[k].type == ItemID.AngelWings && C23)
                            {
                                inventory[k].stack--;
                                C23 = false;
                            }

                            if (inventory[k].type == ItemID.ButterflyDust && C24)
                            {
                                inventory[k].stack--;
                                C24 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Summoning.CaughtUnicorn>() && C25)
                            {
                                inventory[k].stack--;
                                C25 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote2>() && C26)
                            {
                                inventory[k].stack--;
                                C26 = false;
                            }
                        }
                    }
                }

                if (C31 && C32 && C33 && C34 && C35)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.QuantumDestabilizer>());
                    if (Main.player[Main.myPlayer].HasItem(ItemID.ChargedBlasterCannon))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ItemID.ChargedBlasterCannon && C31)
                            {
                                inventory[k].stack--;
                                C31 = false;
                            }

                            if (inventory[k].type == ItemID.HeatRay && C32)
                            {
                                inventory[k].stack--;
                                C32 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C33)
                            {
                                inventory[k].stack--;
                                C33 = false;
                            }

                            if (inventory[k].type == ItemID.SniperScope && C34)
                            {
                                inventory[k].stack--;
                                C34 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote3>() && C35)
                            {
                                inventory[k].stack--;
                                C35 = false;
                            }
                        }
                    }
                }

                if (C41 && C42 && C43 && C44 && C45)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.EyeOfJudgement>());
                    if (Main.player[Main.myPlayer].HasItem(ItemID.SkeletronTrophy))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C41)
                            {
                                inventory[k].stack--;
                                C41 = false;
                            }

                            if (inventory[k].type == ItemID.SkeletronTrophy && C42)
                            {
                                inventory[k].stack--;
                                C42 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Materials.HateVial>() && C43)
                            {
                                inventory[k].stack--;
                                C43 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.RainbowFlask>() && C44)
                            {
                                inventory[k].stack--;
                                C44 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote4>() && C45)
                            {
                                inventory[k].stack--;
                                C45 = false;
                            }
                        }
                    }
                }

                if (C51 && C52 && C53 && C54 && C55)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.PandoraPF422>());
                    if (Main.player[Main.myPlayer].HasItem(ItemID.PiranhaGun))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ItemID.PiranhaGun && C51)
                            {
                                inventory[k].stack--;
                                C51 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C52)
                            {
                                inventory[k].stack--;
                                C52 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.RainbowFlask>() && C53)
                            {
                                inventory[k].stack--;
                                C53 = false;
                            }

                            if (inventory[k].type == ItemID.MoonStone && C54)
                            {
                                inventory[k].stack--;
                                C54 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote5>() && C55)
                            {
                                inventory[k].stack--;
                                C55 = false;
                            }
                        }
                    }
                }

                if (C61 && C62 && C63 && C64 && C65)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.Akumu>());
                    if (Main.player[Main.myPlayer].HasItem(ItemID.DeathSickle))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ItemID.DeathSickle && C61)
                            {
                                inventory[k].stack--;
                                C61 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Materials.HateVial>() && C62)
                            {
                                inventory[k].stack--;
                                C62 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C63)
                            {
                                inventory[k].stack--;
                                C63 = false;
                            }

                            if (inventory[k].type == ItemID.CelestialStone && C64)
                            {
                                inventory[k].stack--;
                                C64 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote6>() && C65)
                            {
                                inventory[k].stack--;
                                C65 = false;
                            }
                        }
                    }
                }

                if (C71 && C72 && C73 && C74 && C75)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.PortalGun>());
                    if (Main.player[Main.myPlayer].HasItem( ItemID.PortalGun))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ItemID.PortalGun && C71)
                            {
                                inventory[k].stack--;
                                C71 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C72)
                            {
                                inventory[k].stack--;
                                C72 = false;
                            }

                            if (inventory[k].type == ItemID.MoonlordTurretStaff && C73)
                            {
                                inventory[k].stack--;
                                C73 = false;
                            }

                            if (inventory[k].type == ItemID.REK && C74)
                            {
                                inventory[k].stack--;
                                C74 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote7>() && C75)
                            {
                                inventory[k].stack--;
                                C75 = false;
                            }
                        }
                    }
                }

                if (C81 && C82 && C83 && C84)
                {
                    Player player = Main.player[Main.myPlayer];
                    var source = player.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Weapons.TurretStaff>());
                    if (Main.player[Main.myPlayer].HasItem(ItemID.PortalGun))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ItemID.PortalGun && C81)
                            {
                                inventory[k].stack--;
                                C81 = false;
                            }

                            if (inventory[k].type == ItemID.CompanionCube && C82)
                            {
                                inventory[k].stack--;
                                C82 = false;
                            }

                            if (inventory[k].type == ItemID.DD2FlameburstTowerT3Popper && C83)
                            {
                                inventory[k].stack--;
                                C83 = false;
                            }

                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote8>() && C84)
                            {
                                inventory[k].stack--;
                                C84 = false;
                            }
                        }
                    }
                }
            }
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            int nextSlot = 0;
            items[nextSlot].type = (ModContent.ItemType<Items.ExplorersBrew>());
            items[nextSlot].shopCustomPrice = 250000;
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.PerfectDiscordPotion>());
            items[nextSlot].shopCustomPrice = 330000;
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Misc.GlobalTeleporterUp>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Materials.ChromaticCrystal>());
            items[nextSlot].shopCustomPrice = 500000;
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Materials.NyctosythiaCrystal>());
            items[nextSlot].shopCustomPrice = 500000;
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Materials.SunkroveraCrystal>());
            items[nextSlot].shopCustomPrice = 500000;
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote1>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote2>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote3>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote4>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote5>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote6>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote7>());
            nextSlot++;
            items[nextSlot].type = (ModContent.ItemType<Items.Notes.ResearchNote8>());
            nextSlot++;
            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == Mod.FindItem("QuantumDestabilizer").Type)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.Weapons.EnergyCell>());
                        nextSlot++;
                    }

                    if (player.inventory[j].type == Mod.FindItem("Tritantrum").Type)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.Weapons.PlasmaRound>());
                        nextSlot++;
                    }

                    if (player.inventory[j].type == Mod.FindItem("ChaingunMeatGrinder").Type)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.Weapons.MGB>());
                        nextSlot++;
                    }

                    if (player.inventory[j].type == Mod.FindItem("PortalGun").Type || player.inventory[j].type == Mod.FindItem("OverloadedPortalGun").Type)
                    {
                        items[nextSlot].type = (ModContent.ItemType<Items.Weapons.EnergyCapsule>());
                        nextSlot++;
                    }
                }
            }

            items[nextSlot].type = (ModContent.ItemType<Items.Summoning.RealityPiercer>());
            nextSlot++;
        }
    }
}
