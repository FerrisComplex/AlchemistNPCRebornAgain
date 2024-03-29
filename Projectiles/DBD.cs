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
	public class DBD : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 60;
			Projectile.height = 34;
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.HellfireArrow;
			return true;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.lifeMax > 6666)
			{
				modifiers.FlatBonusDamage += 999999;
				modifiers.SetMaxDamage(150); // force to always be 150
			}
			if (target.lifeMax <= 6666)
			{
				modifiers.FlatBonusDamage += 999999;
				modifiers.SetMaxDamage(6666); // force to always be 6666
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			AlchemistNPCRebornAgain.DTH++;
		}
	}
}
