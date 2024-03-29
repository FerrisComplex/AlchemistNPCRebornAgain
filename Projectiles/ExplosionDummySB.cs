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
	public class ExplosionDummySB : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Projectile.timeLeft = 150;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			Projectile.DamageType = DamageClass.Summon;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = 40;
			Projectile.timeLeft = 40;
			Projectile.tileCollide = false;
			AIType = ProjectileID.LaserMachinegunLaser;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 2;
			if (Projectile.timeLeft <= 20)
			{
				Projectile.friendly = false;
			}
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
		}
	
	}
}
