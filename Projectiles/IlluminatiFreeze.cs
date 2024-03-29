using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPCRebornAgain.Items.Weapons;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class IlluminatiFreeze : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 3200;
			Projectile.height = 3200;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 1;
			Projectile.tileCollide = false;
		}
        
		public override void AI()
		{
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(Projectile.Hitbox) && !target.townNPC && !target.friendly && !target.boss)
				{
						target.buffImmune[ModContent.BuffType<Buffs.Patience>()] = false;
						target.AddBuff(ModContent.BuffType<Buffs.Patience>(), 600);
				}
			}
		}
	}
}
