using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Microsoft.Xna.Framework;

namespace AlchemistNPCRebornAgain.Projectiles.Pets
{
	public class Snatcher : ModProjectile
	{
		public static int c1 = 0;
		public static int c2 = 0;
		public override void SetDefaults()
		{
			Main.projFrames[Projectile.type] = 8;
			Projectile.width = 56;
			Projectile.height = 58;
			Main.projPet[Projectile.type] = true;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.tileCollide = false;
		}
        
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.Snatcher>()))
			{
				modPlayer.snatcher = false;
			}
			if (modPlayer.snatcher)
			{
				Projectile.timeLeft = 2;
			}
			
			if (player.direction == 1)
			{
				Projectile.spriteDirection = 1;
				Projectile.position.X = player.position.X - 60;
				
			}
			if (player.direction == -1)
			{
				Projectile.spriteDirection = -1;
				Projectile.position.X = player.position.X + 25;
			}
			if (c1 < 75)
			{
				c1++;
				c2++;
				Projectile.position.Y = player.position.Y - 80 + c1/5;
			}
			if (c1 >= 75)
			{
				c2--;
				Projectile.position.Y = player.position.Y - 80 + c2/5;
			}
			if (c2 == 0)
			{
				c1 = 0;
				Projectile.position.Y = player.position.Y - 80;
			}
			
			if (player.velocity.Y == 0f && player.velocity.X == 0f && Projectile.frame != 0)
			{
				if (++Projectile.frameCounter > 3)
				{
					if (Projectile.frame > 0)
					{
						Projectile.frame--;
						Projectile.frameCounter = 0;
					}
				}
			}
			
			if (player.velocity.Y == 0f && player.velocity.X == 0f && Projectile.frame == 2)
			{
				Projectile.frame = 0;
			}
			
			if ((player.velocity.Y != 0f || player.velocity.X != 0f) && Projectile.frame != 7)
			{
				if (++Projectile.frameCounter > 1)
				{
					if (Projectile.frame < 7)
					{
						Projectile.frame++;
						Projectile.frameCounter = 0;
					}
				}
			}
			
			if (modPlayer.SnatcherCounter >= 15000)
			{
				Projectile.ai[0]++;
				for (int i = 0; i < 200; i++)
				{
					NPC target = Main.npc[i];

					float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
					float shootToY = target.position.Y + target.height * 0.5f - Projectile.Center.Y;
					float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

					if (distance < 500f && target.catchItem == 0 && !target.dontTakeDamage && !target.friendly && target.active)
					{
						if (Projectile.ai[0] > 60f)
						{
							int dmg = 1;
							if (player.HeldItem.damage < 50)
							{
								dmg = player.HeldItem.damage*4;
							}
							else if (player.HeldItem.damage < 100)
							{
								dmg = player.HeldItem.damage*2;
							}
							else
							{
								dmg = player.HeldItem.damage/2;
							}
							Vector2 vel = new Vector2(0, -1);
							vel *= 10f;
							SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
							for (int j = 0; j < 2; j++)
							{
								Vector2 perturbedSpeed = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed1 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed2 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed3 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed4 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Projectile.NewProjectile(((Entity) Projectile).GetSource_FromThis((string) null),target.Center.X, target.Center.Y+48, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Projectiles.ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 0f);
								Projectile.NewProjectile(((Entity) Projectile).GetSource_FromThis((string) null),target.Center.X, target.Center.Y+48, perturbedSpeed1.X, perturbedSpeed1.Y, ModContent.ProjectileType<Projectiles.ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 0f);
								Projectile.NewProjectile(((Entity) Projectile).GetSource_FromThis((string) null),target.Center.X, target.Center.Y+48, perturbedSpeed2.X, perturbedSpeed2.Y, ModContent.ProjectileType<Projectiles.ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 3f);
								Projectile.NewProjectile(((Entity) Projectile).GetSource_FromThis((string) null),target.Center.X, target.Center.Y+48, perturbedSpeed3.X, perturbedSpeed3.Y, ModContent.ProjectileType<Projectiles.ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 3f);
								Projectile.NewProjectile(((Entity) Projectile).GetSource_FromThis((string) null),target.Center.X, target.Center.Y+48, perturbedSpeed4.X, perturbedSpeed4.Y, ModContent.ProjectileType<Projectiles.ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 0f);
							}
							Projectile.ai[0] = 0f;
						}
					}
				}
			}
		}
	}
}
