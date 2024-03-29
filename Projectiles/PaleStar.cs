using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class PaleStar : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.SporeTrap);
			Projectile.DamageType = DamageClass.Magic;
			AIType = ProjectileID.ChlorophyteBullet;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 1;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			int multiplier = 200;
			if (target.lifeMax <= 300000)
                multiplier = 200;
			else if (target.lifeMax > 300000 && target.lifeMax < 1000000)
				multiplier = 300;
			else if (target.lifeMax >= 1000000)
				multiplier = 400;
            
			modifiers.SetMaxDamage(target.life / multiplier);
			modifiers.FlatBonusDamage += target.life;
		}
	}
}
