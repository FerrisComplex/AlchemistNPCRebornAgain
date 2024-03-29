using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Projectiles.Minions
{
	public class Devilsknife : ModProjectile
    {
        public override void SetDefaults()
        {
			Projectile.CloneDefaults(533);
			Projectile.aiStyle = 66;
			AIType = 533;
            Projectile.width = 78;
            Projectile.height = 86;  
            Projectile.ignoreWater = true; 
            Projectile.timeLeft = 36000;
            Projectile.penetrate = -1; 
            Projectile.tileCollide = false; 
            Projectile.DamageType = DamageClass.Summon;
			Projectile.minionSlots = 1;
        }

		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}
		
		public override void AI()
		{
			Projectile.tileCollide = false;
			Player player = Main.player[Projectile.owner];
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.Devilsknife>()))
			{
				modPlayer.devilsknife = false;
			}
			if (modPlayer.devilsknife)
			{
				Projectile.timeLeft = 2;
			}
			if (player.direction == 1)
			{
				Projectile.spriteDirection = -1;
			}
			if (player.direction == -1)
			{
				Projectile.spriteDirection = 1;
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 6;
		}
	}
}
