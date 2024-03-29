using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class DarkShot : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 300;
		}

		public override void AI() {
			Projectile.velocity.Y += Projectile.ai[0];
			Projectile.rotation += 0.4f * (float)Projectile.direction;
			Projectile.scale += 0.01f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				Projectile.ai[0] += 0.1f;
				if (!Projectile.velocity.X.Equals(oldVelocity.X)) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (!Projectile.velocity.Y.Equals(oldVelocity.Y)) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
			return false;
		}

	}
}
