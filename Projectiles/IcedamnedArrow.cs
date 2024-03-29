using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class IcedamnedArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.CursedArrow);
			AIType = ProjectileID.CursedArrow;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.CursedArrow;
			return true;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<Dusts.JustitiaPale>(),
						Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.velocity += Projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
				if (Main.rand.Next(4) == 0)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<Dusts.JustitiaPale>(),
						0, 0, 254, Scale: 0.3f);
					dust.velocity += Projectile.velocity * 0.5f;
					dust.velocity *= 0.5f;
				}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(39, 600);
				target.AddBuff(44, 600);
			}
		}
	}
}
