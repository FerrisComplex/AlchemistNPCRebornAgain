using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
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
using Terraria.GameContent.ItemDropRules;
using AlchemistNPCRebornAgain;
using AlchemistNPCRebornAgain.Extensions;
using AlchemistNPCRebornAgain.Extensions.SubMods;

namespace AlchemistNPCRebornAgain.NPCs
{
    public class ModGlobalNPC : GlobalNPC
    {
		public bool banned = false;
		public bool light = false;
		public bool chaos = false;
		public bool electrocute = false;
        public bool corrosion = false;
		public bool justitiapale = false;
		public static int kc = 0;
		public static bool ks = false;
		public static bool ksu = false;
		public static int gr = 0;
		public static bool gu = false;
		public static bool geru = false;
		public bool start = false;
        public bool rainbowdust = false;
		public bool cheat = false;
		public static bool bsu = false;
		public bool i1 = false;
		public bool i2 = false;
		public bool i3 = false;
		public int bc = 0;
		public int bc2 = 0;
		public bool intermission1 = false;
		public bool stop1 = false;
		public bool intermission2 = false;
		public bool stop2 = false;
		public bool phase2 = false;
		public bool phase3 = false;
		public bool twilight = false;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

		public void SyncPlayerVariables(Player player)
		{
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Write(modPlayer.RCT1);
			packet.Write(modPlayer.RCT2);
			packet.Write(modPlayer.RCT3);
			packet.Write(modPlayer.RCT4);
			packet.Write(modPlayer.RCT5);
			packet.Write(modPlayer.RCT6);
			packet.Write(modPlayer.BBP);
			packet.Write(modPlayer.SnatcherCounter);
			packet.Send();
		}

        public override void ResetEffects(NPC npc)
		{
			banned = false;
			light = false;
			corrosion = false;
			chaos = false;
			rainbowdust = false;
			electrocute = false;
			twilight = false;
			justitiapale = false;
			//N1 = false;
			//N2 = false;
			//N3 = false;
			//N4 = false;
			//N5 = false;
			//N6 = false;
			//N7 = false;
			//N8 = false;
			//N9 = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			/*if (chaos)
			{
				npc.lifeRegen -= 10000 + S*1500;
				if (damage < 999 + S*150)
				{
					damage = 1000 + S*150;
				}
			}
			if (light)
			{
				if (!Main.hardMode)
				{
					npc.lifeRegen -= 5 + C;
					if (damage < 1 + C)
					{
						damage = 1 + C;
					}
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
					npc.lifeRegen -= 50 + C*2;
					if (damage < 5 + C)
					{
						damage = 5 + C;
					}
				}
				if (Main.hardMode && NPC.downedMoonlord)
				{
					npc.lifeRegen -= 500 + C*4;
					if (damage < 50 + C*2)
					{
						damage = 50 + C*2;
					}
				}
			}
			if (banned)
			{
				npc.lifeRegen -= 999999;
				if (damage < 9999)
				{
					damage = 9999;
				}
			}
			if (corrosion)
			{
				npc.lifeRegen -= 500;
				if (damage < 49)
				{
					damage = 50;
				}
			}
			if (justitiapale)
			{
				npc.lifeRegen -= 2000;
				if (damage < 199)
				{
					damage = 200;
				}
			}
			if (electrocute)
			{
				npc.lifeRegen -= 1000;
				if (damage < 99)
				{
					damage = 100;
				}
			}*/
			if (twilight)
			{
				npc.lifeRegen -= 5000;
				if (damage < 499)
				{
					damage = 500;
				}
			}
		}

         public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            Player player = Main.LocalPlayer;
            if (player.active && player == Main.player[Main.myPlayer])
            {
                if (npc.type == ModContent.NPCType<Tinkerer>())
                {
                    foreach (Item item in items) 
					{
						if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= 2;
                    }
                }
                if (npc.type == ModContent.NPCType<Brewer>() ||
                    npc.type == ModContent.NPCType<Alchemist>() ||
                    npc.type == ModContent.NPCType<YoungBrewer>())
                {
                    foreach (Item item in items)
                    {
						if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= AlchemistNPCRebornAgain.modConfiguration.PotsPriceMulti;
                        if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
                        {
                            if (AlchemistNPCRebornAgain.modConfiguration.RevPrices && CalamityModRevengeance)
                            {
                                item.shopCustomPrice += item.shopCustomPrice;
                            }
                        }
                        if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier4)
                        {
                            item.shopCustomPrice -= item.shopCustomPrice / 2;
                        }
                        else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier3)
                        {
                            item.shopCustomPrice -= ((item.shopCustomPrice / 20) * 7);
                        }
                        else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier2)
                        {
                            item.shopCustomPrice -= item.shopCustomPrice / 4;
                        }
                        else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier1)
                        {
                            item.shopCustomPrice -= item.shopCustomPrice / 10;
                        }
                    }
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("Tremor") != null)
            {
                if (type == ModLoader.GetMod("Tremor").NPCType("Lady Moon"))
                {
                    addModItemToShop(Tremor, "DarkMass", 7500, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "CarbonSteel", 10000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "Doomstone", 25000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "NightmareBar", 25000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "VoidBar", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "AngryShard", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "Phantaplasm", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "ClusterShard", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "DragonCapsule", 50000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "HuskofDusk", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "NightCore", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "GoldenClaw", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "StoneDice", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "ConcentratedEther", 100000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "Squorb", 250000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "ToothofAbraxas", 250000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "CosmicFuel", 1000000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "EyeofOblivion", 3000000, ref shop, ref nextSlot);
                }
            }
			*/
        }
         
        public override void SetDefaults(NPC npc)
        {

	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.UgandanKnucklesChat1"), () => "I have a question to ask from you...");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat4"), () => "WHAT? You again? I was already defeated with your help! What else do you want from me?");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat5"), () => "You dared summon me? This is going to be fun!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat6"), () => "Hey catch this!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat7"), () => "Do you really think that you would be able to defeat me? That's hilarious!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat8"), () => "Hey you! Yes, you! I am asking the one who is controlling this 'puppet'!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat9"), () => "Enough playing around, now you are gonna die!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat10"), () => "Madness is unleashed!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat11"), () => "You are starting to annoy me, worm!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat12"), () => "Don't start thinking you're safe behind that screen...");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat13"), () => "I will come to your dreams and will turn them into the horrible nightmare!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat14"), () => "I will not get defeated again!");
	        Language.GetOrRegister(Mod.GetLocalizationKey("GlobalNPC.Chat.BillCipherChat15"), () => "Prepare to suffer!");

            if (npc.type == NPCID.DungeonGuardian)
                NPCID.Sets.MPAllowedEnemies[NPCID.DungeonGuardian] = true;
            if (NPC.downedMoonlord && (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus))
				npc.lifeMax = 500;
            if (NPC.downedMoonlord && (npc.type == ModContent.NPCType<Alchemist>() || npc.type == ModContent.NPCType<Brewer>() || npc.type == ModContent.NPCType<YoungBrewer>() || npc.type == ModContent.NPCType<Jeweler>() || npc.type == ModContent.NPCType<Architect>() || npc.type == ModContent.NPCType<Musician>() || npc.type == ModContent.NPCType<Tinkerer>()|| npc.type == ModContent.NPCType<Explorer>()))
				npc.lifeMax = 500;
            
            if (npc.type == NPCID.Unicorn)
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)ModContent.ItemType<Items.Summoning.CaughtUnicorn>();
			}
            if (npc.type == ModContent.NPCType<Alchemist>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.AlchemistHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Brewer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.BrewerHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Architect>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.ArchitectHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Jeweler>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.JewelerHorcrux>();
            }
			if (npc.type == ModContent.NPCType<Explorer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.RealityPiercer>();
            }
            if (npc.type == ModContent.NPCType<Operator>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.APMC>();
            }
            if (npc.type == ModContent.NPCType<Musician>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.MusicianHorcrux>();
            }
			if (npc.type == ModContent.NPCType<OtherworldlyPortal>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.NotesBook>();
            }
            if (npc.type == ModContent.NPCType<Tinkerer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.TinkererHorcrux>();
            }
        }
		
		public override void ModifyHitNPC(NPC npc, NPC target, ref NPC.HitModifiers modifiers)
		{
			if (npc.type == ModContent.NPCType<Knuckles>())
			{
				var pl = Player.FindClosest(npc.position, npc.width, npc.height);
				if (pl <= 0) return;
				
				Player player = Main.player[pl];
				if (player.HeldItem.type == ItemID.SlapHand)
				{
					modifiers.Defense *= 0;
					npc.life = 1;
				}
				return;
			}
		}
		
		public override void AI(NPC npc)
		{
			Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			if (npc.type == ModContent.NPCType<Knuckles>())
			{
				if (!start)
				{
					npc.position.Y = player.position.Y - 350;
					npc.position.X = player.position.X;
					start = true;
				}
				if (ks == false)
				{
					kc++;
				}
				if (kc == 2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.UgandanKnucklesChat1"), 255, 255, 255);
				}
				if (kc < 180)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					npc.dontTakeDamage = true;
				}
				if (kc == 180)
				{
					Main.NewText("DEW U NO DE WEI?", 255, 0, 0);
					ks = true;
					npc.dontTakeDamage = false;
					kc++;
				}
			}

			if (npc.type == ModContent.NPCType<GameError>())
			{
				if (!start)
				{
					npc.position.Y = player.position.Y - 350;
					npc.position.X = player.position.X;
					start = true;
				}
				if (gu == false)
				{
					gr++;
				}
				if (gr == 2)
				{
					Main.NewText("*$%7#74213!#34%$@", 255, 255, 255);
				}
				if (gr < 180)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					npc.dontTakeDamage = true;
				}
				if (gr == 180)
				{
					Main.NewText(":JLSJFOWEP:FJDS:M;vkf,o[irgt]", 255, 0, 0);
					gu = true;
					npc.dontTakeDamage = false;
					gr++;
				}
			}
			
			if (npc.type == ModContent.NPCType<NPCs.BillCipher>())
			{
				if (npc.life == npc.lifeMax && !start && player.name != "Bill")
				{
					npc.position.Y = player.position.Y - 300;
					npc.position.X = player.position.X;
					if (player.name == "Dipper" || player.name == "Mabel" || player.name == "Stanford" || player.name == "Stanlee" || player.name == "Stan")
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat4"), 10, 255, 10);	
					}
					else
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat5"), 10, 255, 10);
					}
					start = true;
				}
				var source = npc.GetSource_FromAI();
				if (npc.life <= npc.lifeMax*0.6f && !i1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat6"), 10, 255, 10);
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("VoodooDoll").Type);
					i1 = true;
				}
				if (npc.life <= npc.lifeMax*0.4f && !i2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat6"), 10, 255, 10);
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("ScreamingHead").Type);
					i2 = true;
				}
				if (npc.life <= npc.lifeMax*0.2f && !i3)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat6"), 10, 255, 10);
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("CursedMirror").Type);
					i3 = true;
				}
				if (npc.life <= (npc.lifeMax - npc.lifeMax/4) && !intermission1 && !stop1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat7"), 30, 255, 30);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat8"), 30, 255, 30);
					npc.dontTakeDamage = true;
					intermission1 = true;
				}
				if (intermission1 && !stop1)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					bc++;
					if (bc >= 300)
					{
						npc.life += 50000;
						npc.HealEffect(50000, true);
						npc.dontTakeDamage = false;
						stop1 = true;
						intermission1 = false;
					}
				}
				if (npc.life <= npc.lifeMax/2 && !phase2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat9"), 150, 100, 30);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat10"), 150, 100, 30);
					phase2 = true;
					for (int index1 = 0; index1 < 30; ++index1)
					{
					float X = npc.Center.X + Main.rand.Next(-2500, 2500);
					float Y = npc.Center.Y + Main.rand.Next(-2500, 2500);
					Projectile.NewProjectile(((Entity) npc).GetSource_FromThis((string) null),X, Y, 0f, 0f, Mod.Find<ModProjectile>("Madness").Type, 200, 0, Main.myPlayer);
					}
				}
				if (npc.life <= npc.lifeMax/4 && !intermission2 && !stop2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat11"), 210, 50, 20);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat12"), 210, 50, 20);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat13"), 210, 50, 10);
					npc.dontTakeDamage = true;
					intermission2 = true;
				}
				if (intermission2 && !stop2)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					bc2++;
					if (bc2 >= 300)
					{
						npc.life += 50000;
						npc.HealEffect(50000, true);
						npc.dontTakeDamage = false;
						stop2 = true;
						intermission2 = false;
					}
				}
				if (npc.life <= npc.lifeMax*0.15f && !phase3)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat14"), 255, 0, 0);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BillCipherChat15"), 255, 0, 0);
					phase3 = true;
				}
			}
			
		}

        public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
        {
            if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
            {
                if (Main.hardMode && !NPC.downedMoonlord)
                {
                    damage += 20;
                }
                if (NPC.downedMoonlord)
                {
                    damage = 100;
                }
            }
        }

        public override void TownNPCAttackCooldown(NPC npc, ref int cooldown, ref int randExtraCooldown)
        {
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 4;
                    randExtraCooldown = 4;
                }
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 3;
                    randExtraCooldown = 3;
                }
            }
            if (npc.type == NPCID.Guide)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 3;
                }
            }
        }

        public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
        {
            if (npc.type == NPCID.ArmsDealer)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 4;
                    projType = ProjectileID.MoonlordBullet;
                }
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 3;
                    projType = ProjectileID.MoonlordBullet;
                }
            }
            if (npc.type == NPCID.Cyborg)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 3;
                    projType = ProjectileID.RocketSnowmanI;
                }
            }
            if (npc.type == NPCID.Wizard)
            {
                if (NPC.downedMoonlord)
                {
                    projType = ProjectileID.CursedFlameFriendly;
                }
            }
            if (npc.type == NPCID.Guide)
            {
                if (NPC.downedMoonlord)
                {
                    projType = ProjectileID.MoonlordArrow;
                }
            }
        }
        
        
        public override void DrawTownAttackGun(NPC npc, ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)/* tModPorter Note: closeness is now horizontalHoldoutOffset, use 'horizontalHoldoutOffset = Main.DrawPlayerItemPos(1f, itemtype) - originalClosenessValue' to adjust to the change. See docs for how to use hook with an item type. */
        {
	        if (npc.type == NPCID.ArmsDealer)
	        {
		        if (NPC.downedMoonlord)
		        {
			        item = TextureAssets.Item[ItemID.Megashark].Value;
		        }
	        }
	        if (npc.type == NPCID.Steampunker)
	        {
		        if (NPC.downedMoonlord)
		        {
			        scale = 1f;
			        horizontalHoldoutOffset = 4;
			        item = TextureAssets.Item[ItemID.SDMG].Value;
		        }
	        }
        }

        public override void BuffTownNPC(ref float damageMult, ref int defense)
        {
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                defense += 30;
            }
            if (NPC.downedMoonlord)
            {
                defense += 80;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active && player.HasBuff(ModContent.BuffType<Buffs.GreaterDangersense>()))
                {
                    if (npc.type == 112)
                    {
                        npc.color = new Color(255, 255, 0, 100);
                        Lighting.AddLight(npc.position, 1f, 1f, 0f);
                    }
                }

				if (twilight)
				{
					if (Main.rand.Next(4) < 2)
					{
						int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Dusts.JustitiaPale>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
						Main.dust[dust].noGravity = true;
						Main.dust[dust].velocity *= 1.8f;
						Main.dust[dust].velocity.Y -= 0.5f;
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[dust].noGravity = false;
							Main.dust[dust].scale *= 0.5f;
						}
					}
				}
            }
        }
        public override void OnKill(NPC npc)
        {
			var source = npc.GetSource_FromAI();
			Player player = Main.player[Main.myPlayer];

			if (AlchemistNPCRebornWorld.foundAntiBuffMode)
			{
				if (npc.type == NPCID.KingSlime)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.KingSlimeBooster>(), 1);
				}
				if (npc.type == NPCID.EyeofCthulhu)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.EyeOfCthulhuBooster>(), 1);
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BrokenBooster1>(), 1);
				}
				if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.EaterOfWorldsBooster>(), 1);
				}
				if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.EaterOfWorldsBooster>(), 1);
				}
				if (npc.type == NPCID.BrainofCthulhu)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BrainOfCthulhuBooster>(), 1);
				}
				if (npc.type == NPCID.QueenBee)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.QueenBeeBooster>(), 1);
				}
				if (npc.type == NPCID.SkeletronHead)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.SkeletronBooster>(), 1);
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BrokenBooster2>(), 1);
				}
				if (npc.type == NPCID.WallofFlesh)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.WoFBooster>(), 1);
				}
				if (npc.type == NPCID.SkeletronPrime)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.PrimeBooster>(), 1);
				}
				if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.TwinsBooster>(), 1);
				}
				if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism))
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.TwinsBooster>(), 1);
				}
				if (npc.type == NPCID.TheDestroyer)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.DestroyerBooster>(), 1);
				}
				if (npc.type == NPCID.Plantera)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.PlanteraBooster>(), 1);
				}
				if (npc.type == NPCID.Golem)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.GolemBooster>(), 1);
				}
				if (npc.type == NPCID.DukeFishron)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.FishronBooster>(), 1);
				}
				if (npc.type == NPCID.CultistBoss)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.CultistBooster>(), 1);
				}
				if (npc.type == NPCID.MoonLordCore)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.MoonLordBooster>(), 1);
				}
				if (npc.type == NPCID.DD2DarkMageT1 || npc.type == NPCID.DD2DarkMageT3)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.DarkMageBooster>(), 1);
				}
				if (npc.type == NPCID.DD2OgreT2 || npc.type == NPCID.DD2OgreT3)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.OgreBooster>(), 1);
				}
				if (npc.type == NPCID.DD2Betsy)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.BetsyBooster>(), 1);
				}
				if (npc.type == NPCID.GoblinSummoner)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.GSummonerBooster>(), 1);
				}
				if (npc.type == NPCID.IceGolem)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.IceGolemBooster>(), 1);
				}
				if (npc.type == NPCID.PigronCorruption || npc.type == NPCID.PigronCrimson || npc.type == NPCID.PigronHallow)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.PigronBooster>(), 1);
				}
				if (npc.type == NPCID.MartianSaucerCore)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Boosters.MartianSaucerBooster>(), 1);
				}
				for (int k = 0; k < 255; k++)
				{
					if (player.active)
					{
						AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
						if (modPlayer.CultistBooster == 1)
						{
							if ((npc.type == NPCID.StardustWormHead || npc.type == NPCID.StardustCellBig || npc.type == NPCID.StardustJellyfishBig || npc.type == NPCID.StardustSpiderBig || npc.type == NPCID.StardustSoldier) && Main.rand.NextBool(5))
							{
								source = npc.GetSource_FromAI();
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentStardust, 1, 1);
							}
							if ((npc.type == NPCID.SolarCrawltipedeHead || npc.type == NPCID.SolarDrakomire || npc.type == NPCID.SolarDrakomireRider || npc.type == NPCID.SolarSroller || npc.type == NPCID.SolarCorite || npc.type == NPCID.SolarSolenian) && Main.rand.NextBool(5))
							{
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentSolar, 1, 1);
							}
							if ((npc.type == NPCID.NebulaBrain || npc.type == NPCID.NebulaHeadcrab || npc.type == NPCID.NebulaBeast || npc.type == NPCID.NebulaSoldier) && Main.rand.NextBool(5))
							{
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentNebula, 1, 1);
							}
							if ((npc.type == NPCID.VortexRifleman || npc.type == NPCID.VortexHornetQueen || npc.type == NPCID.VortexHornet || npc.type == NPCID.VortexSoldier) && Main.rand.NextBool(5))
							{
								Item.NewItem(source, npc.width, npc.height, ItemID.FragmentVortex, 1, 1);
							}
						}
					}
				}
			}

			if (npc.type == NPCID.Plantera)
			{
				if (Main.rand.Next(20) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("Hive").Type, 1, false, 83);
				}
			}
			if (npc.type == NPCID.Golem)
			{
				if (Main.rand.Next(10) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("Fuaran").Type);
				}
			}

			
			if (player.HeldItem.type == Mod.FindItem("ChristmasW").Type && Main.rand.NextBool(33))
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present);
			}
			if (player.HasBuff(Mod.Find<ModBuff>("Snatcher").Type) && !npc.friendly && npc.type != 14 && npc.type != 135 && !npc.SpawnedFromStatue && npc.type != 1 && npc.type != 535)
			{
				if (ModLoader.GetMod("Redemption") != null)
				{
					if (npc.type != ModLoader.GetMod("Redemption").Find<ModNPC>("OozeBlob").Type) 
					{
						player.GetModPlayer<AlchemistNPCRebornPlayer>().SnatcherCounter++;
						if (Main.netMode == 2)
						SyncPlayerVariables(player);
					}
				}
				if (ModLoader.GetMod("Redemption") == null)
				{
					player.GetModPlayer<AlchemistNPCRebornPlayer>().SnatcherCounter++;
					if (Main.netMode == 2)
					SyncPlayerVariables(player);
				}
			}

			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).Extractor && npc.boss == true && npc.lifeMax >= 50000 && (Main.rand.Next(3) == 0))
			{
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("SoulEssence").Type);
			}
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).Extractor && npc.boss == true && npc.lifeMax >= 55000 && (Main.rand.Next(10) == 0))
			{
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("HateVial").Type);
			}
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).TimeTwist && npc.boss == false && Main.rand.NextBool(4))
			{
				npc.NPCLoot();
			}

			if (WorldGen.crimson)
			{
				if ((npc.type == 239 || npc.type == 240) && Main.rand.NextBool(10))
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("SpiderFangarang").Type);
				}
			}
			if (!WorldGen.crimson)
			{
				if ((npc.type == 164 || npc.type == 165) && Main.rand.NextBool(10))
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("SpiderFangarang").Type);
				}
			}
			if ((npc.type == 236 || npc.type == 237) && Main.rand.NextBool(20))
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("FangBallista").Type);
			}
			if ((npc.type == 164 || npc.type == 165) && Main.rand.NextBool(20))
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("SwordofArachna").Type);
			}
			if (npc.lifeMax >= 25000 && npc.boss && Main.rand.Next(20) == 0)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("PerfectionToken").Type);
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(200) == 0)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("Devilsknife").Type);
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("WailOfBanshee").Type);
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("ExecutionersEyes").Type);
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("SymbolOfPain").Type);
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("MeteorSwarm").Type);
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("CloakOfFear").Type);
			}
			if (npc.type == NPCID.WallofFlesh)
			{
				source = npc.GetSource_FromAI();
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("LuckCharm").Type);
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("PHD").Type);
				Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("BrokenDimensionalCasket").Type);
				if (NPC.downedDeerclops)
                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<References.CodexUmbra>());
                }
			}
			if (!npc.SpawnedFromStatue)
			{
				if (Main.rand.Next(25000) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("HolyAvenger").Type, 1, false, 81);
				}
				if (Main.rand.Next(25000) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("Penetrator").Type, 1, false, 82);
				}
				if (Main.rand.Next(25000) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("TomeOfOrder").Type, 1, false, 83);
				}
				if (Main.rand.Next(25000) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("FlaskoftheAlchemist").Type, 1, false, 82);
				}
				if (Main.rand.Next(25000) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("CounterMatter").Type, 1, false);
				}
				if (Main.rand.Next(33333) == 0)
				{
					source = npc.GetSource_FromAI();
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("CrackedCrown").Type, 1, false);
				}
			}
			
			if (npc.type == NPCID.DungeonGuardian)
			{
				source = npc.GetSource_FromAI();
				if (!Main.expertMode)
				{
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("EmagledFragmentation").Type, Main.rand.Next(20, 30));
					if (Main.rand.Next(10) == 0)
					{
						Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("OtherworldlyAmulet").Type);
					}
				}
				else
				{
					Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("EmagledFragmentation").Type, Main.rand.Next(40, 50));
					if (Main.rand.Next(5) == 0)
					{
						Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("OtherworldlyAmulet").Type);
					}
				}
			}

            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                if ((bool)Calamity.Call("Downed", "dog") && npc.type == 327)
                {
                    if (!AlchemistNPCRebornWorld.downedDOGPumpking)
                    {
                        AlchemistNPCRebornWorld.downedDOGPumpking = true;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                        }
                    }
                }

                if ((bool)Calamity.Call("Downed", "dog") && npc.type == 345)
                {
                    if (!AlchemistNPCRebornWorld.downedDOGIceQueen)
                    {
                        AlchemistNPCRebornWorld.downedDOGIceQueen = true;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                        }
                    }
                }
            }

			if (npc.type == NPCID.MoonLordCore)
			{
				if (NPC.downedMoonlord && Main.bloodMoon)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("TheSecretVR").Type, 1);
				}
				if (AlchemistNPCRebornAgain.modConfiguration.TinkererSpawn)
				{
					Item.NewItem(source,(int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.FindItem("PaperTube3").Type, 3);
				}
			}

            if (npc.type == NPCID.SandElemental)
            {
                if (!AlchemistNPCRebornWorld.downedSandElemental)
                {
                    AlchemistNPCRebornWorld.downedSandElemental = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData);
                    }
                }
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npc, npcLoot);

			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			ModLoader.TryGetMod("ThoriumMod", out Mod Thorium);
			ModLoader.TryGetMod("SpiritMod", out Mod Spirit);

        	if (npc.type == NPCID.EyeofCthulhu)
        	{
        		if (!NPC.downedBoss1)
        		{
				    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.AlchemistCharmTier1>(), 1));
        		}
        	}

			if (npc.boss && AlchemistNPCRebornAgain.modConfiguration.TinkererSpawn)
			{
				if (npc.type == NPCID.KingSlime)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type));
				}
				if (npc.type == NPCID.EyeofCthulhu)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
				}
				if (npc.type == NPCID.BrainofCthulhu)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
				}
				if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail))
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
				}
				if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
				}
				if (npc.type == NPCID.QueenBee)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
				}
				if (npc.type == NPCID.SkeletronHead)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
				}
				if (npc.type == NPCID.WallofFlesh)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 2));
				}
				if (npc.type == NPCID.SkeletronPrime)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
				}
				if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer))
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
				}
				if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism))
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
				}
				if (npc.type == NPCID.TheDestroyer)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
				}
				if (npc.type == NPCID.Plantera)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube3").Type, 1));
				}
				if (npc.type == NPCID.Golem)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube3").Type, 2));
				}
				if (npc.type == NPCID.DukeFishron)
				{
					npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube3").Type, 2));
				}
				if (Calamity != null)
				{
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("DesertScourgeHead").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Crabulon").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("HiveMind").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PerforatorHive").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SlimeGodCore").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Cryogen").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("BrimstoneElemental").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AquaticScourgeHead").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SoulSeeker").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Leviathan").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AstrumAureus").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube3").Type, 2));
					if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PlaguebringerGoliath").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube3").Type, 2));
				}
				
				if (Thorium != null)
				{
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("TheGrandThunderBirdv2").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("QueenJelly").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("Viscount").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("GraniteEnergyStorm").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("TheBuriedWarrior").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("ThePrimeScouter").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("BoreanStriderPopped").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 2));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("FallenDeathBeholder2").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 2));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("LichHeadless").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("AbyssionReleased").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube3").Type, 2));
				}
				//if (ModLoader.GetMod("Redemption") != null)
				//{
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("KingChicken").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube")));
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("Thorn").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube")));
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("TheKeeper").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube"), 2));
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("XenomiteCrystalPhase2").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube"), 3));
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("InfectedEye").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube2"), 2));
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("KSCharge").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube2"), 3));
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("VlitchCleaver").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube2"), 4));
				//	if (npc.type == (ModLoader.GetMod("Redemption").Find<ModNPC>("VlitchWormHead").Type)) npcLoot.Add(ItemDropRule.Common(mod.ItemType("PaperTube3"), 2));
				//}
				if (Spirit != null)
				{
					if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Scarabeus").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type));
					if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("ReachBoss").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 2));
					if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("AncientFlyer").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
					if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("SteamRaiderHead").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube").Type, 3));
					if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Dusking").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("SpiritCore").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("IlluminantMaster").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube2").Type, 3));
					if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Atlas").Type)) npcLoot.Add(ItemDropRule.Common(Mod.FindItem("PaperTube3").Type, 2));
				}
			}
			
			if (npc.type == NPCID.EyeofCthulhu && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote1>(), 1));
			}
			if (npc.type == NPCID.Creeper && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote2Piece>(), 1));
			}
			if (npc.type == NPCID.EaterofWorldsBody && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote2Piece>(), 1));
			}
			if (npc.type == NPCID.SkeletronHead && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote3>(), 1));
			}
			if (npc.type == NPCID.SkeletronPrime && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote4>(), 1));
			}
			if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer) && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote5>(), 1));
			}
			if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism) && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote5>(), 1));
			}
			if (npc.type == NPCID.TheDestroyer && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote6>(), 1));
			}
			if (npc.type == NPCID.Plantera && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote7>(), 1));
			}
			if (npc.type == NPCID.Golem && AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote8>(), 1));
			}


			if (npc.type == NPCID.KingSlime)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(1,3)));
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(3,6)));
			}
			if (npc.type == NPCID.Deerclops)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(5,8)));
			}
			if (npc.type == NPCID.QueenBee)
			{
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(9,12)));
			}
			if (npc.type == NPCID.SkeletronHead)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(12,15)));
			}
			if (npc.type == NPCID.WallofFlesh)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(4,6)));
			}
			if (npc.type == NPCID.QueenSlimeBoss)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(6,8)));
			}
			if (npc.type == NPCID.SkeletronPrime)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(2,3)));
			}
			if (npc.type == NPCID.TheDestroyer)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(2,3)));
			}
			if (npc.type == NPCID.Spazmatism)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(1,2)));
			}
			if (npc.type == NPCID.Retinazer)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(1,2)));
			}		
			if (npc.type == NPCID.Plantera)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(5,6)));
			}
			if (npc.type == NPCID.Golem)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(2,3)));
			}
			if (npc.type == NPCID.HallowBoss)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(5,10)));
			}
			if (npc.type == NPCID.DukeFishron)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));
			}
			if (npc.type == NPCID.CultistBoss)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));
			}

			if (Calamity != null)
			{
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("DesertScourgeHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(1,3)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Crabulon").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("HiveMind").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PerforatorHive").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SlimeGodCore").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Cryogen").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("BrimstoneElemental").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AquaticScourgeHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SoulSeeker").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Leviathan").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(12,15)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AstrumAureus").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(9,12)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("PlaguebringerGoliath").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("RavagerBody").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("AstrumDeusHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(5,7)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("ProfanedGuardianCommander").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("ProfanedGuardianDefender").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("ProfanedGuardianHealer").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Providence").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), Main.rand.Next(12,15)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("CeaselessVoid").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 1));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("StormWeaverHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 1));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Signus").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 1));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Polterghast").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(4,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("OldDuke").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(5,7)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("DevourerofGodsHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Bumblefuck").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("Yharon").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), Main.rand.Next(12,15)));}
				if (npc.type == (ModLoader.GetMod("CalamityMod").Find<ModNPC>("SupremeCalamitas").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 66));}
			}

			if (Thorium != null)
			{
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("TheGrandThunderBirdv2").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(1,2)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("QueenJelly").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("Viscount").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(5,7)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("GraniteEnergyStorm").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("TheBuriedWarrior").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("ThePrimeScouter").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(9,12)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("BoreanStriderPopped").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("FallenDeathBeholder2").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("LichHeadless").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("AbyssionReleased").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("ThoriumMod").Find<ModNPC>("RealityBreaker").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), 33));}
			}

			if (Spirit != null)
			{
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Scarabeus").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(2,3)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("ReachBoss").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("AncientFlyer").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), Main.rand.Next(9,12)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("SteamRaiderHead").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), Main.rand.Next(3,6)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Dusking").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("SpiritCore").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(3,6)));}
				//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("IlluminantMaster").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), Main.rand.Next(6,9)));}
				if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Atlas").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), Main.rand.Next(6,9)));}
				//if (npc.type == (ModLoader.GetMod("SpiritMod").Find<ModNPC>("Overseer").Type)) {npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), 33));}
			}

            if (npc.type == NPCID.MoonLordCore)
			{
				if (AlchemistNPCRebornAgain.modConfiguration.TornNotesDrop)
				{
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Notes.TornNote9>(), 1));
				}
			}
			
                
        
            //if (npc.type == ModContent.NPCType<Operator>())
            //{
            //    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Summoning.APMC>(), 1));
            //}
			
			

        }

		public bool CalamityModRevengeance
		{            
            get {
				ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if(Calamity != null) {
                    return (bool)Calamity.Call("GetDifficultyActive", "revengeance");
                }
                return false;
            }
        }
		
		// private readonly ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
	}
}
