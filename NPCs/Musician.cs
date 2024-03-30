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
using AlchemistNPCRebornAgain.ExternalHelpers;
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
		public static bool S4 = false;
		public static bool S5 = false;

		public static string Sh1 = "Sh1";
		public static string Sh2 = "Sh2";
		public static string Sh3 = "Sh3";
		public static string Sh4 = "Sh4";
		public static string Sh5 = "Sh5";

		public override string Texture
		{
			get { return "AlchemistNPCRebornAgain/NPCs/Musician"; }
		}
		//Probably removed
		// public override bool Autoload(ref string name)
		// {
		// 	name = "Musician";
		// 	return true;
		// }

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 500;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 45;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = -2;

			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = -1f,
				Direction = -1
			};
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
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,
				new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCRebornAgain.Bestiary.Musician")
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

		public override bool CanTownNPCSpawn(int numTownNPCs) /* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
		{
			if (NPC.downedBoss3 && AlchemistNPCRebornAgain.modConfiguration.MusicianSpawn)
			{
				return true;
			}

			return false;
		}



		public override List<string> SetNPCNameList()
		{
			//NPC names
			string Beethoven = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Beethoven");
			string Bach = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Bach");
			string Johan = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Johan");
			string Edison = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Edison");
			string Scott = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Scott");
			string Lloyd = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Lloyd");
			string Gamma = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Gamma");

			return new List<string>()
			{
				Beethoven,
				Bach,
				Johan,
				Edison,
				Scott,
				Lloyd,
				Gamma
			};
		}

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
			string EntryM1 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM1");
			string EntryM2 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM2");
			string EntryM3 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM3");
			string EntryM4 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM4");
			string EntryM5 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM5");
			string EntryM6 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM6");
			string EntryM7 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM7");
			string EntryM8 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM8");
			string EntryM9 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM9");
			string EntryM10 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM10");
			string EntryM11 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM11");
			string EntryM12 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM12");
			string EntryM13 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM13");
			string EntryM14 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM14");
			string EntryM15 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM15");
			string EntryM16 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM16");
			string EntryM17 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM17");
			string EntryM18 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM18");
			string EntryM19 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM19");
			string EntryM20 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM20");
			string EntryM21 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM21");
			string EntryM22 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EntryM22");
			string Gamma = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Gamma");
			int Cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
			int Mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
			int Clothier = NPC.FindFirstNPC(NPCID.Clothier);
			int Wizard = NPC.FindFirstNPC(NPCID.Wizard);
			int Musician = NPC.FindFirstNPC(ModContent.NPCType<Musician>());
			if (Main.musicVolume == 0)
			{
				return EntryM19;
			}

			if (Main.musicVolume == 100)
			{
				return EntryM22;
			}

			if (Main.bloodMoon)
			{
				return EntryM20;
			}

			if (Cyborg >= 0 && Main.npc[Cyborg].GivenName == "Gamma" && Main.npc[Musician].GivenName == Gamma && Main.rand.Next(15) == 0)
			{
				return EntryM3;
			}

			if (Mechanic >= 0 && Main.rand.NextBool(20))
			{
				return EntryM8 + Main.npc[Mechanic].GivenName + EntryM9;
			}

			if (Wizard >= 0 && Main.rand.NextBool(20))
			{
				return EntryM10 + Main.npc[Wizard].GivenName + EntryM11;
			}

			if (Clothier >= 0 && Main.rand.NextBool(20))
			{
				return EntryM12 + Main.npc[Clothier].GivenName + EntryM13;
			}

			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (Main.rand.Next(15) == 0)
				{
				    return EntryM18;
				}
			}
			*/
			if (ModLoader.TryGetMod("CalamityModMusic", out Mod CalamityMusic))
			{
				if (Main.rand.Next(15) == 0)
				{
					return EntryM17;
				}
			}

			switch (Main.rand.Next(9))
			{
				case 0:
					return EntryM1;
				case 1:
					return EntryM2;
				case 2:
					return EntryM4;
				case 3:
					return EntryM5;
				case 4:
					return EntryM6;
				case 5:
					return EntryM14;
				case 6:
					return EntryM15;
				case 7:
					return EntryM16;
				case 8:
					return EntryM21;
				default:
					return EntryM1;
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			string Shop2 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Shop2");
			string Shop3 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Shop3");
			string Shop4 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Shop4");
			string Shop5 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Shop5");
			string ShopChanger = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ShopChanger");
			if (S1)
			{
				button = Language.GetTextValue("LegacyInterface.28");
			}

			if (S2)
			{
				button = Shop2;
			}

			if (S3)
			{
				button = Shop3;
			}

			if (S4)
			{
				button = Shop4;
			}

			if (S5)
			{
				button = Shop5;
			}

			button2 = ShopChanger;
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shopName)
		{
			if (firstButton)
			{
				shopName = ShopChangeUIM.Shop;
				ShopChangeUIM.visible = false;
			}
			else
			{
				if (!ShopChangeUIM.visible) ShopChangeUIM.timeStart = Main.GameUpdateCount;
				ShopChangeUIM.visible = true;
			}
		}

		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public bool ThoriumModDownedGTBird
		{
		    get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
		}
		public bool ThoriumModDownedViscount
		{
		    get { return ThoriumMod.ThoriumWorld.downedBat; }
		}
		public bool ThoriumModDownedBoreanStrider
		{
		    get { return ThoriumMod.ThoriumWorld.downedStrider; }
		}
		public bool ThoriumModDownedFallenBeholder
		{
		    get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
		}
		public bool ThoriumModDownedAbyssion
		{
		    get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
		}
		*/

		public override void AddShops()
		{
			var shop = new NPCShop(Type, Sh1)
				.Add(new Item(576), new Condition("", () => !NPC.downedMechBossAny))
				.Add(new Item(562) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1600) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(564) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1601) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1596) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1602) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1603) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1604) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4077) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4079) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1597) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(566) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1964) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1610) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(568) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(569) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(570) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1598) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(2742) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(571) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(573) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(3237) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1605) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1608) { shopCustomPrice = 100000 }, Condition.DownedPlantera)
				.Add(new Item(567) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(572) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(574) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1599) { shopCustomPrice = 100000 }, Condition.DownedGolem)
				.Add(new Item(1607) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5112) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4979) { shopCustomPrice = 100000 }, Condition.DownedQueenSlime)
				.Add(new Item(1606) { shopCustomPrice = 100000 }, Condition.DownedPlantera)
				.Add(new Item(4985) { shopCustomPrice = 100000 }, Condition.DownedEmpressOfLight)
				.Add(new Item(4990) { shopCustomPrice = 100000 }, Condition.DownedDukeFishron)
				.Add(new Item(563) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1609) { shopCustomPrice = 100000 }, Condition.DownedMechBossAny);
			shop.Register();
			shop = new NPCShop(Type, Sh2)
				.Add(new Item(3371) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(3236) { shopCustomPrice = 100000 }, Condition.DownedPirates)
				.Add(new Item(1963) { shopCustomPrice = 100000 }, Condition.DownedPumpking)
				.Add(new Item(1965) { shopCustomPrice = 100000 }, Condition.DownedIceQueen)
				.Add(new Item(3235) { shopCustomPrice = 100000 }, Condition.DownedMartians)
				.Add(new Item(3370) { shopCustomPrice = 100000 }, Condition.DownedCultist)
				.Add(new Item(3044) { shopCustomPrice = 100000 }, Condition.DownedMoonLord)
				.Add(new Item(3796) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(3869) { shopCustomPrice = 100000 }, Condition.DownedOldOnesArmyT1)
				.Add(new Item(4078) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4080) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4081) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4082) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4237) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4356) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4357) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4358) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4421) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4606) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4991) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(565) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4992) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5006) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5362) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5044) { shopCustomPrice = 100000 }, Condition.DownedPlantera);
			shop.Register();
			shop = new NPCShop(Type, Sh3)
				.Add(new Item(5015) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5016) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5014) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5017) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5018) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5019) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5020) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5021) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5016) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5017) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5018) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5019) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5020) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5021) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5022) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5023) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5024) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5025) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5026) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5027) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5028) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5038) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5040) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5029) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5030) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5031) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5033) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5032) { shopCustomPrice = 100000 }, Condition.DownedMechBossAny)
				.Add(new Item(5034) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5039) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5037) { shopCustomPrice = 100000 }, Condition.DownedPlantera)
				.Add(new Item(5035) { shopCustomPrice = 100000 }, Condition.DownedCultist)
				.Add(new Item(5036) { shopCustomPrice = 100000 }, Condition.DownedMoonLord)
				.Add(new Item(5037) { shopCustomPrice = 100000 }, Condition.Hardmode);
			shop.Register();

			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			ModLoader.TryGetMod("CalamityModMusic", out Mod CalamityMM);
			ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);

			shop = new NPCShop(Type, Sh4)
				.AddModItemToShop(CalamityMM, "CalamityTitleMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AbyssLayer1MusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AbyssLayer2MusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AbyssLayer3MusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AbyssLayer4MusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AcidRainTier1MusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AcidRainTier3MusicBox", 100000, Condition.DownedMoonLord)
				.AddModItemToShop(CalamityMM, "AnahitasLureMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AnahitaMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AquaticScourgeMusicBox", 100000, () => (bool)Calamity.Call("Downed", "aquatic scourge"))
				.AddModItemToShop(CalamityMM, "AstralInfectionMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AstralInfectionUndergroundMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "AstrumAureusMusicBox", 100000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
				.AddModItemToShop(CalamityMM, "AstrumDeusMusicBox", 100000, () => (bool)Calamity.Call("Downed", "astrum deus"))
				.AddModItemToShop(CalamityMM, "BioLabMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "BossRushTier1MusicBox", 100000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "BossRushTier2MusicBox", 100000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "BossRushTier3MusicBox", 100000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "BrimstoneCragsMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "BrimstoneElementalMusicBox", 100000, () => (bool)Calamity.Call("Downed", "brimstone elemental"))
				.AddModItemToShop(CalamityMM, "CalamitasCloneMusicBox", 100000, () => (bool)Calamity.Call("Downed", "calamitas doppelganger"))
				.AddModItemToShop(CalamityMM, "CalamitasPhase1MusicBox", 250000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "CalamitasPhase2MusicBox", 250000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "CalamitasPhase3MusicBox", 250000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "CalamitasDefeatMusicBox", 250000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "CeaselessVoidMusicBox", 100000, () => (bool)Calamity.Call("Downed", "ceaselessvoid"))
				.AddModItemToShop(CalamityMM, "CrabulonMusicBox", 100000, () => (bool)Calamity.Call("Downed", "crabulon"))
				.AddModItemToShop(CalamityMM, "CryogenMusicBox", 100000, () => (bool)Calamity.Call("Downed", "cryogen"))
				.AddModItemToShop(CalamityMM, "DevourerofGodsPhase1MusicBox", 500000, () => (bool)Calamity.Call("Downed", "dog"))
				.AddModItemToShop(CalamityMM, "DevourerofGodsPhase2MusicBox", 500000, () => (bool)Calamity.Call("Downed", "dog"))
				.AddModItemToShop(CalamityMM, "DragonfollyMusicBox", 100000, () => (bool)Calamity.Call("Downed", "dragonfolly"))
				.AddModItemToShop(CalamityMM, "ExoMechsMusicBox", 500000, () => (bool)Calamity.Call("Downed", "exomechs"))
				.AddModItemToShop(CalamityMM, "HiveMindMusicBox", 100000, () => (bool)Calamity.Call("Downed", "hive mind"))
				.AddModItemToShop(CalamityMM, "LeviathanMusicBox", 100000, () => (bool)Calamity.Call("Downed", "leviathan"))
				.AddModItemToShop(CalamityMM, "OldDukeMusicBox", 100000, () => (bool)Calamity.Call("Downed", "old duke"))
				.AddModItemToShop(CalamityMM, "PerforatorsMusicBox", 100000, () => (bool)Calamity.Call("Downed", "perforators"))
				.AddModItemToShop(CalamityMM, "PlaguebringerGoliathMusicBox", 100000, () => (bool)Calamity.Call("Downed", "plaguebringer goliath"))
				.AddModItemToShop(CalamityMM, "PlanetoidMusicBox", 100000, Condition.Hardmode);
			shop.Register();

			shop = new NPCShop(Type, Sh5)
				.AddModItemToShop(CalamityMM, "PolterghastMusicBox", 100000, () => (bool)Calamity.Call("Downed", "polterghast"))
				.AddModItemToShop(CalamityMM, "PrimordialWyrmMusicBox", 500000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
				.AddModItemToShop(CalamityMM, "ProfanedGuardiansMusicBox", 100000, () => (bool)Calamity.Call("Downed", "providence"))
				.AddModItemToShop(CalamityMM, "ProvidenceMusicBox", 100000, () => (bool)Calamity.Call("Downed", "providence"))
				.AddModItemToShop(CalamityMM, "RavagerMusicBox", 100000, () => (bool)Calamity.Call("Downed", "ravager"))
				.AddModItemToShop(CalamityMM, "SignusMusicBox", 100000, () => (bool)Calamity.Call("Downed", "signus"))
				.AddModItemToShop(CalamityMM, "SlimeGodMusicBox", 100000, () => (bool)Calamity.Call("Downed", "slime god"))
				.AddModItemToShop(CalamityMM, "StormWeaverMusicBox", 100000, () => (bool)Calamity.Call("Downed", "stormweaver"))
				.AddModItemToShop(CalamityMM, "SulphurousSeaDayMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "SulphurousSeaNightMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "SunkenSeaMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(CalamityMM, "YharonLegacyMusicBox", 330000, () => (bool)Calamity.Call("Downed", "yharon"))
				.AddModItemToShop(CalamityMM, "YharonPhase1MusicBox", 330000, () => (bool)Calamity.Call("Downed", "yharon"))
				.AddModItemToShop(CalamityMM, "YharonPhase2MusicBox", 330000, () => (bool)Calamity.Call("Downed", "yharon"))
				.AddModItemToShop(ThoriumMod, "AquaticDepthsMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(ThoriumMod, "MiniBossMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(ThoriumMod, "SunkenPalaceMusicBox", 100000, Condition.Hardmode)
				.AddModItemToShop(ThoriumMod, "BoreanStriderMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "BoreanStrider"))
				.AddModItemToShop(ThoriumMod, "BuriedChampionMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "BuriedChampion"))
				.AddModItemToShop(ThoriumMod, "FallenBeholderMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "FallenBeholder"))
				.AddModItemToShop(ThoriumMod, "ForgottenOneMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "ForgottenOne"))
				.AddModItemToShop(ThoriumMod, "GraniteEnergyStormMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "GraniteEnergyStorm"))
				.AddModItemToShop(ThoriumMod, "LichMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "Lich"))
				.AddModItemToShop(ThoriumMod, "QueenJellyfishMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "QueenJellyfish"))
				.AddModItemToShop(ThoriumMod, "StarScouterMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "StarScouter"))
				.AddModItemToShop(ThoriumMod, "TheGrandThunderBirdMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "TheGrandThunderBird"))
				.AddModItemToShop(ThoriumMod, "ThePrimordialsMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "ThePrimordials"))
				.AddModItemToShop(ThoriumMod, "ViscountMusicBox", 330000, () => (bool)ThoriumMod.Call("GetDownedBoss", "Viscount"));
			shop.Register();
		}
	}
}
