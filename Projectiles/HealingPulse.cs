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
	public class HealingPulse : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 1920;
			Projectile.height = 1080;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 1;
			Projectile.tileCollide = false;
		}
        
		
		public override void AI()
		{
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(Projectile.Hitbox) && target.friendly && target.life != target.lifeMax)
				{
						for (int i = 0; i < 10; i++)
						{
							int dustType = Main.rand.Next(74, 75);
							int dustIndex = Dust.NewDust(target.position, target.width, target.height, dustType);
							Dust dust = Main.dust[dustIndex];
							dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.1f;
							dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.1f;
							dust.scale *= 0.9f;
							dust.noGravity = true;
						}
						target.life += 10;
						target.HealEffect(10, true);
						if (target.life > target.lifeMax)
						{
							target.life = target.lifeMax;
						}
				}
			}
		}
	}
}
