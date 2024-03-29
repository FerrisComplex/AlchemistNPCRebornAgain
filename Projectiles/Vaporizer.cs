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
	public class Vaporizer : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(302);
			Projectile.width = 6;
			Projectile.tileCollide = false;
			Projectile.aiStyle = 1;
			AIType = 302;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.friendly)
			{
				modifiers.FinalDamage /= 30;
			}
		}
		
		public override void ModifyHitPlayer(Terraria.Player target, ref Terraria.Player.HurtModifiers modifiers)
		{
			target.AddBuff(BuffID.Stoned, 10);
		}
	}
}
