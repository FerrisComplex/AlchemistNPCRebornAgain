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
	public class Void : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Magic;
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
			if (Projectile.timeLeft > 75)
			{
				Projectile.timeLeft = 75;
			}
			if (Projectile.ai[0] > 4f)
			{
				float num302 = 1f;
				if (Projectile.ai[0] == 8f)
				{
					num302 = 0.25f;
				}
				else if (Projectile.ai[0] == 9f)
				{
					num302 = 0.5f;
				}
				else if (Projectile.ai[0] == 10f)
				{
					num302 = 0.75f;
				}
				Projectile.ai[0] += 1f;
				int num303 = 86;
				if (Main.rand.Next(2) == 0)
				{
					int num3;
					for (int num304 = 0; num304 < 1; num304 = num3 + 1)
					{
						int num305 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num303, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
						Dust dust;
						if (Main.rand.Next(3) != 0 || (Main.rand.Next(3) == 0))
						{
							Main.dust[num305].noGravity = true;
							dust = Main.dust[num305];
							dust.scale *= 2.5f;
							Dust var_2_E189_cp_0_cp_0 = Main.dust[num305];
							var_2_E189_cp_0_cp_0.velocity.X = var_2_E189_cp_0_cp_0.velocity.X * 2f;
							Dust var_2_E1AA_cp_0_cp_0 = Main.dust[num305];
							var_2_E1AA_cp_0_cp_0.velocity.Y = var_2_E1AA_cp_0_cp_0.velocity.Y * 2f;
						}
						if (Projectile.type == 188)
						{
							dust = Main.dust[num305];
							dust.scale *= 1.25f;
						}
						else
						{
							dust = Main.dust[num305];
							dust.scale *= 1.5f;
						}
						Dust var_2_E21E_cp_0_cp_0 = Main.dust[num305];
						var_2_E21E_cp_0_cp_0.velocity.X = var_2_E21E_cp_0_cp_0.velocity.X * 1.2f;
						Dust var_2_E23F_cp_0_cp_0 = Main.dust[num305];
						var_2_E23F_cp_0_cp_0.velocity.Y = var_2_E23F_cp_0_cp_0.velocity.Y * 1.2f;
						dust = Main.dust[num305];
						dust.scale *= num302;
						if (num303 == 86)
						{
							dust = Main.dust[num305];
							dust.velocity += Projectile.velocity;
							if (!Main.dust[num305].noGravity)
							{
								dust = Main.dust[num305];
								dust.velocity *= 0.5f;
							}
						}
						num3 = num304;
					}
				}
			}
			else
			{
				Projectile.ai[0] += 1f;
			}
			Projectile.rotation += 0.3f * (float)Projectile.direction;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.type == ModContent.NPCType<NPCs.BillCipher>())
				modifiers.FinalDamage /= 200;
			
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
			target.immune[Projectile.owner] = 1;
			if (Main.rand.NextBool(15))
			{
				target.buffImmune[ModContent.BuffType<Buffs.Patience>()] = false;
				target.AddBuff(ModContent.BuffType<Buffs.Patience>(), 10);
			}
		}
	}
}
