using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPCRebornAgain.Buffs;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class Globe199 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Projectile.light = 0.5f;
			Main.projFrames[Projectile.type] = 12;
		}

		public override void SetDefaults()
		{
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 3600;
			Projectile.tileCollide = false;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.extraUpdates = 0;
		}
		
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center;
			Projectile.position.Y = player.Center.Y-116;
			if (++Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 12)
                {
                    Projectile.frame = 0;
                }
            }
			if (ProjCounter.counter == 0)
			{
				for (int i = 0; i < 25; i++)
				{
					int dustType = 193;
					int dustIndex = Dust.NewDust(Projectile.position, 96, 96, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-10, 10) * 0.5f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-10, 10) * 0.5f;
					dust.scale *= 0.98f;
					dust.noGravity = true;
				}
			}
			if (player.dead || !player.HasBuff(Mod.Find<ModBuff>("ProjCounter").Type))
			{
				Projectile.Kill();
			}
		}
	}
}
