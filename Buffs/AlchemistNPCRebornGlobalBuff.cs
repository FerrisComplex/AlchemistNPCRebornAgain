using Microsoft.Xna.Framework;
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
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Buffs
{
	public class AlchemistNPCRebornGlobalBuffs : GlobalBuff
	{
		public override void Update(int type, Player player, ref int buffIndex)
		{
			if (type == 165)
			{
				Main.buffNoTimeDisplay[type] = false;
			}

			if (AlchemistNPCRebornWorld.foundAntiBuffMode)
			{
				if (!Main.lightPet[type] && !Main.vanityPet[type] && !Main.buffNoTimeDisplay[type] && player.buffTime[buffIndex] > 1801 && !Main.debuff[type] && type != 21 && type != 94)
				{
					player.DelBuff(buffIndex);
				}
			}

			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().BuffsKeep == true)
			{
				if (type != 71 && type != 73 && type != 74 && type != 75 && type != 76 && type != 77 && type != 78 && type != 79 && type != ModContent.BuffType<RainbowFlaskBuff>())
				{
					if (Main.debuff[type] == false)
					{
					Main.persistentBuff[type] = true;
					}
				}
			}

			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().BuffsKeep == false && NPC.downedMoonlord)
			{
				if (type != 71 && type != 73 && type != 74 && type != 75 && type != 76 && type != 77 && type != 78 && type != 79 && type != ModContent.BuffType<RainbowFlaskBuff>())
				{
					if (Main.debuff[type] == false)
					{
					Main.persistentBuff[type] = false;
					}
				}
			}
		}
	}
}
