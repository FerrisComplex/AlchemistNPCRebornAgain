﻿using Microsoft.Xna.Framework;
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
	public class PlasmaBurst : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 3;
			Projectile.timeLeft = 120;
		}
        
		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.25f) / 255f, ((255 - Projectile.alpha) * 0.05f) / 255f, ((255 - Projectile.alpha) * 0.05f) / 255f);
			if (Projectile.timeLeft > 90)
			{
				Projectile.timeLeft = 90;
			}
			if (Projectile.ai[0] > 7f)
			{
				float num296 = 1f;
				if (Projectile.ai[0] == 8f)
				{
					num296 = 0.1f;
				}
				else if (Projectile.ai[0] == 9f)
				{
					num296 = 0.2f;
				}
				else if (Projectile.ai[0] == 10f)
				{
					num296 = 0.3f;
				}
				Projectile.ai[0] += 1f;
				int num297 = 74;
				if (Main.rand.NextBool(2))
				{
					for (int num298 = 0; num298 < 1; num298++)
					{
						int num299 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num297, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
						if ((num297 == 235 && Main.rand.NextBool(3)))
						{
							Main.dust[num299].noGravity = true;
							Main.dust[num299].scale *= 0.99f;
							Dust expr_DBEF_cp_0 = Main.dust[num299];
							expr_DBEF_cp_0.velocity.X = expr_DBEF_cp_0.velocity.X * 2f;
							Dust expr_DC0F_cp_0 = Main.dust[num299];
							expr_DC0F_cp_0.velocity.Y = expr_DC0F_cp_0.velocity.Y * 2f;
						}
						else
						{
							Main.dust[num299].scale *= 0.95f;
						}
						Dust expr_DC74_cp_0 = Main.dust[num299];
						expr_DC74_cp_0.velocity.X = expr_DC74_cp_0.velocity.X * 1.2f;
						Dust expr_DC94_cp_0 = Main.dust[num299];
						expr_DC94_cp_0.velocity.Y = expr_DC94_cp_0.velocity.Y * 1.2f;
						Main.dust[num299].scale *= num296;
						if (num297 == 75)
						{
							Main.dust[num299].velocity += Projectile.velocity;
							if (!Main.dust[num299].noGravity)
							{
								Main.dust[num299].velocity *= 0.5f;
							}
						}
					}
				}
			}
			else
			{
				Projectile.ai[0] += 1f;
			}
			Projectile.rotation += 0.3f * Projectile.direction;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (!Projectile.velocity.X.Equals(oldVelocity.X))
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (!Projectile.velocity.Y.Equals(oldVelocity.Y))
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
			}
			return false;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 3;
			target.AddBuff(BuffID.OnFire, 300);
		}
	}
}
