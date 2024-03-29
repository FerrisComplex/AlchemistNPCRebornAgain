using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Projectiles.Pets
{
	public class YuiS : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(492);
			Projectile.width = 72;
			Projectile.height = 64;
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 90;
			AIType = 492;
			Main.projFrames[Projectile.type] = 8;
			ProjectileID.Sets.LightPet[Projectile.type] = true;
			Projectile.scale = 0.5f;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.bunny = false;
			return true;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 61, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default(Color), 1f);
			}
			Player player = Main.player[Projectile.owner];
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.YuiS>()))
			{
				modPlayer.YuiS = false;
			}
			if (modPlayer.YuiS)
			{
				Projectile.timeLeft = 2;
			}
			Lighting.AddLight(Projectile.position, 3.0f, 3.0f, 3.0f);
		}
	}
}
