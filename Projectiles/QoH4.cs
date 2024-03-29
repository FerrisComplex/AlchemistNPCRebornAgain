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
	public class QoH4 : ModProjectile
	{


		public override void SetDefaults()
		{
			Projectile.CloneDefaults(503);
			
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.aiStyle = 5;
			AIType = 503;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = 503;
			return true;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			modifiers.FinalDamage *= 2;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		target.immune[Projectile.owner] = 1;
		}
	}
}
