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
	public class ParadiseLost : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			Main.projFrames[Projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 60;
			Projectile.height = 46;
			Projectile.penetrate = 200;
			Projectile.timeLeft = 70;
			Projectile.tileCollide = false;
			AIType = ProjectileID.LaserMachinegunLaser;
			Projectile.extraUpdates = 1;
			Projectile.scale = 2f;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner]; 
			Projectile.position.X = player.position.X;
			Projectile.position.Y = player.position.Y-10;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(0f);
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation -= MathHelper.ToRadians(180f);
			}
			if (Projectile.frameCounter < 10)
				Projectile.frame = 0;
			else if (Projectile.frameCounter >= 10 && Projectile.frameCounter < 20)
				Projectile.frame = 1;
			else if (Projectile.frameCounter >= 20 && Projectile.frameCounter < 30)
				Projectile.frame = 2;
			else if (Projectile.frameCounter >= 30 && Projectile.frameCounter < 40)
				Projectile.frame = 3;
			else if (Projectile.frameCounter >= 40 && Projectile.frameCounter < 50)
				Projectile.frame = 4;
			else if (Projectile.frameCounter >= 50 && Projectile.frameCounter < 60)
				Projectile.frame = 5;
			else if (Projectile.frameCounter >= 60 && Projectile.frameCounter < 70)
				Projectile.frame = 6;
			else
				Projectile.frameCounter = 0;
			Projectile.frameCounter++;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Twilight>(), 600);
			target.immune[Projectile.owner] = 2;
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			if (Main.rand.Next(6) == 0)
			{
				for (int h = 0; h < 1; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<PaleStar>(), Projectile.damage, 0, Main.myPlayer);
				}
			}
		}
	
	}
}
