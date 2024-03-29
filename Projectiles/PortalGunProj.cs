using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.GameContent;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class PortalGunProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording ModContente
		}
		
		public override bool PreDraw(ref Color lightColor) 
		{
			Main.instance.LoadProjectile(Projectile.type);
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int i = 0; i < Projectile.oldPos.Length; i++) {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.timeLeft = 25;
			AIType = ProjectileID.Bullet;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal1>(), Projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal2>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal3>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal4>(), Projectile.damage - Projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal5>(), Projectile.damage + Projectile.damage/2, 0, Main.myPlayer);
			break;
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.Kill();
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(((Entity) target).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal1>(), Projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(((Entity) target).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal2>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(((Entity) target).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal3>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(((Entity) target).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal4>(), Projectile.damage - Projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(((Entity) target).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal5>(), Projectile.damage + Projectile.damage/2, 0, Main.myPlayer);
			break;
			}
		}
		
		public override bool PreKill(int timeLeft)
		{
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal1>(), Projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal2>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal3>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal4>(), Projectile.damage - Projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<RickPortal5>(), Projectile.damage + Projectile.damage/2, 0, Main.myPlayer);
			break;
			}
			return true;
		}
	}
}
