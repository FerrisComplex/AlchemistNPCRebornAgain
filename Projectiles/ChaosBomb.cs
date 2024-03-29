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
	public class ChaosBomb : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(261);
			Projectile.width = 40;
			Projectile.height = 62;
			
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.aiStyle = 14;
			Projectile.timeLeft = 360;
			AIType = 261;
		}
		
		public override void AI()
		{
			if (Projectile.timeLeft > 350) Projectile.tileCollide = false;
			else Projectile.tileCollide = true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[Projectile.owner];
			
			for (int index1 = 0; index1 < 30; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index2].velocity *= 1.4f;
			}
			for (int index1 = 0; index1 < 20; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 3.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 7f;
				int index3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index3].velocity *= 3f;
			}
			
            if (Projectile.owner == Main.myPlayer)
            {
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				float num75 = 10f;
				float num82 = (float)Projectile.Center.X - vector2.X;
				float num83 = (float)Projectile.Center.Y - vector2.Y;
				float num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
				float num85 = num84;
				if ((float.IsNaN(num82) && float.IsNaN(num83)) || (num82 == 0f && num83 == 0f))
				{
					num82 = (float)Projectile.direction;
					num83 = 0f;
					num84 = 11f;
				}
				else
				{
					num84 = 11f / num84;
				}
				num82 *= num84;
				num83 *= num84;
				int num117 = 5;
				for (int num118 = 0; num118 < num117; num118++)
				{
					vector2 = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(201) * -(float)player.direction) + ((float)Projectile.Center.X - player.position.X), Projectile.Center.Y - 600f);
					vector2.X = (vector2.X + player.Center.X) / 2f + (float)Main.rand.Next(-350, 351);
					vector2.Y -= (float)(100 * num118);
					num82 = (float)Projectile.Center.X - vector2.X;
					num83 = (float)Projectile.Center.Y - vector2.Y;
					float ai2 = num83 + vector2.Y;
					if (num83 < 0f)
					{
						num83 *= -1f;
					}
					if (num83 < 20f)
					{
						num83 = 20f;
					}
					num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
					num84 = num75 / num84;
					num82 *= num84;
					num83 *= num84;
					Vector2 vector11 = new Vector2(num82, num83) / 2f;
					switch (Main.rand.Next(4))
					{
						case 0:
							SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
							Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<CB1>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
						case 1:
							SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
							Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<CB2>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
						case 2:
							SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
							Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<CB3>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
						case 3:
							SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
							Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<CB4>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
					}
				}
			}
		}
		
					
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.type == ModContent.NPCType<NPCs.BillCipher>())
				modifiers.FinalDamage /= 250;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 1;
			Projectile.Kill();
		}
	}
}
