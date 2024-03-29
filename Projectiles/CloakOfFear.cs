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
	public class CloakOfFear : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 96;
			Projectile.height = 96;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.hostile = false;
			Projectile.friendly = false;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center;
			Projectile.ai[0]++;
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
				if(target.active && !target.friendly && !target.townNPC && !target.boss)
				{
					if (target.Hitbox.Intersects(Projectile.Hitbox))
					{
						if (!target.HasBuff(ModContent.BuffType<Buffs.CloakOfFearDebuff>())) target.velocity *= -1;
						if (Projectile.ai[0] == 5) target.velocity += target.velocity*(-3);
						target.buffImmune[ModContent.BuffType<Buffs.CloakOfFearDebuff>()] = false;
						target.AddBuff(ModContent.BuffType<Buffs.CloakOfFearDebuff>(), 360);
					}
				}
			}
			if (Projectile.ai[0] == 6) Projectile.ai[0] = 0;
		}
	}
}
