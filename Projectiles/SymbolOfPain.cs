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
	public class SymbolOfPain : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 3200;
			Projectile.height = 3200;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
		}
        
		
		public override void AI()
		{
			
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(Projectile.Hitbox) && !target.friendly)
				{
						for (int i = 0; i < 10; i++)
						{
							int dustIndex = Dust.NewDust(target.position, target.width, target.height, ModContent.DustType<Dusts.RainbowDust>());
							Dust dust = Main.dust[dustIndex];
							dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.1f;
							dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.1f;
							dust.scale *= 0.9f;
							dust.noGravity = true;
						}
						target.buffImmune[ModContent.BuffType<Buffs.SymbolOfPain>()] = false;
						target.AddBuff(ModContent.BuffType<Buffs.SymbolOfPain>(), 3600);
				}
			}
		}
	}
}
