using System;
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
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Buffs
{
	public class ExplorerComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
			player.nightVision = true;
			player.detectCreature = true;
			player.pickSpeed -= 0.25f;
			player.dangerSense = true;
			player.gills = true;
			player.waterWalk = true;
			player.ignoreWater = true;
            player.accFlipper = true;
			player.buffImmune[4] = true;
			player.buffImmune[15] = true;
			player.buffImmune[109] = true;
			player.buffImmune[9] = true;
			player.buffImmune[11] = true;
			player.buffImmune[12] = true;
			player.buffImmune[17] = true;
			player.buffImmune[104] = true;
			player.buffImmune[111] = true;
			BuffLoader.Update(BuffID.Gills, player, ref buffIndex);
			BuffLoader.Update(BuffID.Flipper, player, ref buffIndex);
			BuffLoader.Update(BuffID.Shine, player, ref buffIndex);
		}
	}
}
