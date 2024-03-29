using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Microsoft.Xna.Framework;
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
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCRebornAgain;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Buffs
{
	public class UniversalComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			modPlayer.AllDamage10 = true;
			modPlayer.AllCrit10 = true;
			modPlayer.Defense8 = true;
			modPlayer.DR10 = true;
			modPlayer.Regeneration = true;
			modPlayer.Lifeforce = true;
			modPlayer.MS = true;
			modPlayer.Bewitched = true;
			modPlayer.Clairvoyance = true;
			player.GetDamage(DamageClass.Magic) += 0.2f;
			player.manaRegenBuff = true;
			player.archery = true;
			player.ammoPotion = true;
			player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
			player.buffImmune[29] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[110] = true;
			player.buffImmune[112] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
			player.buffImmune[150] = true;
			player.buffImmune[ModContent.BuffType<Buffs.BattleComb>()] = true;
			player.buffImmune[ModContent.BuffType<Buffs.TankComb>()] = true;
			player.buffImmune[ModContent.BuffType<Buffs.VanTankComb>()] = true;
			player.buffImmune[ModContent.BuffType<Buffs.RangerComb>()] = true;
			player.buffImmune[ModContent.BuffType<Buffs.MageComb>()] = true;
			player.buffImmune[ModContent.BuffType<Buffs.SummonerComb>()] = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[6] = true;
			player.buffImmune[7] = true;
			player.buffImmune[14] = true;
			++player.maxMinions;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			if (ModLoader.GetMod("MorePotions") != null)
			{
				if (player.HasBuff(ModContent.BuffType<Buffs.MorePotionsComb>()) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("SoulbindingElixerPotionBuff")))
				{
					--player.maxMinions;
				}
				if (player.HasBuff(ModContent.BuffType<Buffs.MorePotionsComb>()) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("DiamondSkinPotionBuff")))
				{
					player.statDefense -= 8;
				}
			}
			*/
			if (player.thorns < 1.0)
			{
				player.thorns = 0.3333333f;
			}
			BuffLoader.Update(BuffID.ObsidianSkin, player, ref buffIndex);
		}
	}
}
