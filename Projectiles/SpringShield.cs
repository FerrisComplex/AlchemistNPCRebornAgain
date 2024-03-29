using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPCRebornAgain.Items.Weapons;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class SpringShield : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Projectile.light = 0.1f;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			Main.projFrames[Projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.penetrate = 200;
			Projectile.timeLeft = 99999;
			Projectile.tileCollide = false;
			Projectile.friendly = false;
			
			AIType = ProjectileID.LaserMachinegunLaser;
			Projectile.extraUpdates = 1;
			Projectile.scale = 1.5f;
			Projectile.alpha = 50;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			Projectile.position.X = player.position.X-15;
			Projectile.position.Y = player.position.Y;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(0f);
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation -= MathHelper.ToRadians(180f);
			}
			if (Projectile.frameCounter < 20)
				Projectile.frame = 0;
			else if (Projectile.frameCounter >= 20 && Projectile.frameCounter < 40)
				Projectile.frame = 1;
			else if (Projectile.frameCounter >= 40 && Projectile.frameCounter < 60)
				Projectile.frame = 2;
			else if (Projectile.frameCounter >= 60 && Projectile.frameCounter < 80)
				Projectile.frame = 3;
			else if (Projectile.frameCounter >= 80 && Projectile.frameCounter < 100)
				Projectile.frame = 4;
			else if (Projectile.frameCounter >= 100 && Projectile.frameCounter < 120)
				Projectile.frame = 5;
			else
				Projectile.frameCounter = 0;
			Projectile.frameCounter++;
			
			if (player.dead || modPlayer.RevSet == false)
			{
				Projectile.Kill();
			}
		}
	}
}
