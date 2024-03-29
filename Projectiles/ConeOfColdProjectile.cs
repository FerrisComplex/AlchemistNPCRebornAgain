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
	public class ConeOfColdProjectile : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(118);
			
			Projectile.DamageType = DamageClass.Magic;
			Projectile.aiStyle = 28;
			AIType = 118;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!target.boss && Main.rand.Next(10) == 0)
			{
			target.buffImmune[ModContent.BuffType<Buffs.Slowness>()] = false;
			target.AddBuff(ModContent.BuffType<Buffs.Slowness>(), 120);
			}
			if (!target.boss && Main.rand.Next(30) == 0)
			{
			target.buffImmune[ModContent.BuffType<Buffs.Patience>()] = false;
			target.AddBuff(ModContent.BuffType<Buffs.Patience>(), 120);
			}
		}
	}
}
