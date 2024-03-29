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
	public class AkumuSphere : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Projectile.light = 0.5f;
			Main.projFrames[Projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(533);
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 66;
			AIType = 533;
			Projectile.tileCollide = false;
		}
			
		public override void AI()
		{
			Projectile.tileCollide = false;
			Player player = Main.player[Projectile.owner]; 
			if (player.statLife < player.statLifeMax2*0.35f || player.dead || !player.HasBuff(ModContent.BuffType<Buffs.TrueAkumuAttack>()))
			{
				Projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 3;
		}
	}
}
