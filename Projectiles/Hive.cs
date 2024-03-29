using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class Hive : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(261);
			Projectile.aiStyle = 14;
			AIType = 261;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(8) == 0)
			{
				for (int h = 0; h < 1; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Bees>(), Projectile.damage, 0, Main.myPlayer);
				}
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Item22, Projectile.position);
			Projectile.Kill();
			if (Projectile.ai[0] > 7f)
			{
				float num296 = 1f;
				int num297 = 265;
				for (int num298 = 0; num298 < 50; num298++)
				{
					int num299 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num297, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
					if ((num297 == 235 && Main.rand.NextBool(3)))
					{
						Main.dust[num299].noGravity = true;
						Main.dust[num299].scale *= 3f;
						Dust expr_DBEF_cp_0 = Main.dust[num299];
						expr_DBEF_cp_0.velocity.X = expr_DBEF_cp_0.velocity.X * 2f;
						Dust expr_DC0F_cp_0 = Main.dust[num299];
						expr_DC0F_cp_0.velocity.Y = expr_DC0F_cp_0.velocity.Y * 2f;
					}
					else
					{
						Main.dust[num299].scale *= 1.5f;
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
			for (int h = 0; h < 12; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				if (!Main.hardMode)
					{
						Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Bees>(), Projectile.damage, 0, Main.myPlayer);
					}
					if (Main.hardMode)
					{
						Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Bees>(), Projectile.damage, 0, Main.myPlayer);
					}
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			SoundEngine.PlaySound(SoundID.Item22, Projectile.position);
			Projectile.Kill();
			if (Projectile.ai[0] > 7f)
			{
				float num296 = 1f;
				int num297 = 265;
				for (int num298 = 0; num298 < 50; num298++)
				{
					int num299 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num297, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
					if ((num297 == 235 && Main.rand.NextBool(3)))
					{
						Main.dust[num299].noGravity = true;
						Main.dust[num299].scale *= 3f;
						Dust expr_DBEF_cp_0 = Main.dust[num299];
						expr_DBEF_cp_0.velocity.X = expr_DBEF_cp_0.velocity.X * 2f;
						Dust expr_DC0F_cp_0 = Main.dust[num299];
						expr_DC0F_cp_0.velocity.Y = expr_DC0F_cp_0.velocity.Y * 2f;
					}
					else
					{
						Main.dust[num299].scale *= 1.5f;
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
			for (int h = 0; h < 12; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					if (!Main.hardMode)
					{
						Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Bees>(), Projectile.damage, 0, Main.myPlayer);
					}
					if (Main.hardMode)
					{
						Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Bees>(), Projectile.damage, 0, Main.myPlayer);
					}
				}
		}
	}
}
