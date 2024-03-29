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
	public class DarkBomb : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(261);
			Projectile.width = 30;
			Projectile.height = 28;
			Projectile.aiStyle = 14;
			AIType = 261;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[Projectile.owner];
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 1;
			Projectile.Kill();
		}
	}
}
