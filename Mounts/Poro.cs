using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Mounts
{
	public class Poro : ModMount
	{
		public override void SetStaticDefaults()
		{
			MountData.spawnDust = 143;
			MountData.buff = ModContent.BuffType<Buffs.Poro>();
			MountData.heightBoost = 36;
			MountData.fallDamage = 0f;
			MountData.runSpeed = 15f;
			MountData.dashSpeed = 12f;
			MountData.flightTimeMax = 0;
			MountData.fatigueMax = 0;
			MountData.jumpHeight = 50;
			MountData.acceleration = 1f;
			MountData.jumpSpeed = 10f;
			MountData.blockExtraJumps = false;
			MountData.totalFrames = 6;
			MountData.constantJump = true;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 32;
			}
			MountData.playerYOffsets = array;
			MountData.xOffset = 10;
			MountData.bodyFrame = 3;
			MountData.yOffset = 16;
			MountData.playerHeadOffset = 50;
			MountData.standingFrameCount = 2;
			MountData.standingFrameDelay = 50;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 4;
			MountData.runningFrameDelay = 100;
			MountData.runningFrameStart = 2;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 4;
			MountData.inAirFrameDelay = 50;
			MountData.inAirFrameStart = 2;
			MountData.idleFrameCount = 6;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;
			if (!Main.dedServ) {
				MountData.textureWidth = MountData.backTexture.Width() + 20;
				MountData.textureHeight = MountData.backTexture.Height();
			}
		}
	}
}
