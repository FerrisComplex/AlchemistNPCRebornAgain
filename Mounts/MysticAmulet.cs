using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.Mounts
{
	public class MysticAmulet : ModMount
	{
		public override void SetStaticDefaults()
		{
			MountData.spawnDust = 226;
			MountData.spawnDustNoGravity = true;
			MountData.buff = ModContent.BuffType<Buffs.MysticAmulet>();
			MountData.heightBoost = 0;
			MountData.flightTimeMax = Int32.MaxValue;
			MountData.fatigueMax = Int32.MaxValue;
			MountData.fallDamage = 0f;
			MountData.usesHover = true;
			MountData.runSpeed = 15f;
			MountData.dashSpeed = 24f;
			MountData.acceleration = 3f;
			MountData.jumpHeight = 24;
			MountData.jumpSpeed = 16f;
			MountData.blockExtraJumps = true;
			MountData.totalFrames = 1;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 0;
			}
			MountData.playerYOffsets = new int[] { 0 };
			MountData.xOffset = 16;
			MountData.bodyFrame = 5;
			MountData.yOffset = 16;
			MountData.playerHeadOffset = 18;
			MountData.standingFrameCount = 0;
			MountData.standingFrameDelay = 0;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 0;
			MountData.runningFrameDelay = 0;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 0;
			MountData.inAirFrameDelay = 0;
			MountData.inAirFrameStart = 0;
			MountData.idleFrameCount = 0;
			MountData.idleFrameDelay = 0;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			MountData.swimFrameCount = 0;
			MountData.swimFrameDelay = 0;
			MountData.swimFrameStart = 0;
			if (!Main.dedServ) {
				MountData.textureWidth = MountData.backTexture.Width();
				MountData.textureHeight = MountData.backTexture.Height();
			}
		}
	}
}
