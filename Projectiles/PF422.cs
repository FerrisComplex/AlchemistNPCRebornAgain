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
	public class PF422 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(190);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.aiStyle = 39;
			AIType = 190;
		}
		
		public override void AI()
		{
			Projectile.velocity *= 1.2f;
			Projectile.velocity *= 1.02f;
			if (Projectile.rotation >= 10f)
			{
				Projectile.rotation = 1f;
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		target.immune[Projectile.owner] = 2;
		Projectile.rotation++;
		}
	}
}
