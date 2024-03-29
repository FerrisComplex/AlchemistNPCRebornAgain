using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class ElementalWasps3 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(189);
			Projectile.netImportant = true;
			Projectile.netUpdate = true;
			Projectile.DamageType = DamageClass.Ranged;
			
			Projectile.aiStyle = 36;
			AIType = 189;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
				if (player.armor[index1].type == ItemID.HiveBackpack)
				{
					Projectile.scale = 1.5f;
					return;
				}
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			Player player = Main.player[Projectile.owner];
			for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
				if (player.armor[index1].type == ItemID.HiveBackpack)
				{
					modifiers.FinalDamage /= 2;
					return;
				}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (!Projectile.velocity.X.Equals(oldVelocity.X))
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (!Projectile.velocity.Y.Equals(oldVelocity.Y))
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 1;
			target.buffImmune[BuffID.CursedInferno] = false;
			target.AddBuff(BuffID.CursedInferno, 600);
			Projectile.penetrate = 1;
		}
	}
}
