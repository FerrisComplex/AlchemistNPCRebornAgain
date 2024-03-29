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
	public class Counter : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
			
			Projectile.width = 200;
			Projectile.height = 200;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 15;
			Projectile.tileCollide = false;
			Projectile.friendly = false;
			AIType = ProjectileID.BulletHighVelocity;
		}
		
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center;
			for(int i = 0; i < 1000; ++i)
			{
				if(Main.projectile[i].active && i != Projectile.whoAmI )
				{
					if(Main.projectile[i].Hitbox.Intersects(Projectile.Hitbox) && Main.projectile[i].active && !Main.projectile[i].friendly && Main.projectile[i].hostile)
					{
					DestroyProjectile(Main.projectile[i]);
					}
				}
			}
		}
		
		public void DestroyProjectile(Projectile proj)
		{
			proj.Kill();
		}
	}
}
