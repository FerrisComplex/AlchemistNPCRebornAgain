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
	public class BlueFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(514);
			
			Projectile.DamageType = DamageClass.Magic;
			Projectile.aiStyle = 93;
			AIType = 514;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Projectile.type = 514;
			
			Projectile.DamageType = DamageClass.Magic;
			return true;
		}
		
		public override void AI()
		{
			if (++Projectile.frameCounter >= 10)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
			if (Projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref Projectile.velocity);
				Projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 300f;
			bool target = false;
			for (int k = 0; k < 100; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - Projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				Projectile.velocity = (10 * Projectile.velocity + move) / 4f;
				AdjustMagnitude(ref Projectile.velocity);
			}
		}
		
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 7f / magnitude;
			}
		}
		
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return true;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			
			Projectile.DamageType = DamageClass.Magic;
			target.immune[Projectile.owner] = 1;
			Projectile.Kill();
		}
	}
}
