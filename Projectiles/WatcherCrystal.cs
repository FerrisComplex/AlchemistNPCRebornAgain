using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Projectiles

{
	public class WatcherCrystal : ModProjectile
    {
 
        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 40;  
            Projectile.hostile = false;  
            Projectile.friendly = false;
            Projectile.ignoreWater = true; 
            Main.projFrames[Projectile.type] = 9;
            Projectile.timeLeft = 18000;
            Projectile.penetrate = -1; 
            Projectile.tileCollide = false; 
            Projectile.sentry = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }
        
	
        public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.WatcherCrystal>()))
			{
				modPlayer.watchercrystal = false;
			}
			if (modPlayer.watchercrystal)
			{
				Projectile.timeLeft = 2;
			}
			
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - Projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 520f && target.catchItem == 0 && !target.friendly && target.active && target.type != 488)
                {
                    if (Projectile.ai[0] > 60f) // Time in (60 = 1 second) 
                    {
                        distance = 1.6f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, shootToX, shootToY, 617, Projectile.damage, 0, Main.myPlayer, 0f, 0f);
                        Projectile.ai[0] = 0f;
                    }
                }
            }
            Projectile.ai[0] += 1f;
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 20)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 8)
			{ Projectile.frame = 0; }
		}
	}
}
