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
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class Chloroshard1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;        //The recording mode
		}
		
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(207);
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			float num1 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
                float num2 = Projectile.localAI[0];
                if (num2 == 0.0)
                {
                    Projectile.localAI[0] = num1;
                    num2 = num1;
                }
                float num3 = Projectile.position.X;
                float num4 = Projectile.position.Y;
                float num5 = 300f;
                bool flag2 = false;
                int num6 = 0;
                if (Projectile.ai[1] == 0.0)
                {
                    for (int index = 0; index < 200; ++index)
                    {
                        if (Main.npc[index].CanBeChasedBy(this, false) && (Projectile.ai[1] == 0.0 || Projectile.ai[1] == (double)(index + 1)))
                        {
                            float num7 = Main.npc[index].position.X + (float)(Main.npc[index].width / 2);
                            float num8 = Main.npc[index].position.Y + (float)(Main.npc[index].height / 2);
                            float num9 = Math.Abs(Projectile.position.X + (Projectile.width / 2) - num7) + Math.Abs(Projectile.position.Y + (Projectile.height / 2) - num8);
                            if (num9 < num5 && Collision.CanHit(new Vector2(Projectile.position.X + (Projectile.width / 2), Projectile.position.Y + (Projectile.height / 2)), 1, 1, Main.npc[index].position, Main.npc[index].width, Main.npc[index].height))
                            {
                                num5 = num9;
                                num3 = num7;
                                num4 = num8;
                                flag2 = true;
                                num6 = index;
                            }
                        }
                    }
                    if (flag2)
                        Projectile.ai[1] = (float)(num6 + 1);
                    flag2 = false;
                }
                if (Projectile.ai[1] > 0.0)
                {
                    int index = (int)(Projectile.ai[1] - 1.0);
                    if (Main.npc[index].active && Main.npc[index].CanBeChasedBy(this, true) && !Main.npc[index].dontTakeDamage)
                    {
                        if ((double)(Math.Abs(Projectile.position.X + (Projectile.width / 2) - (Main.npc[index].position.X + (float)(Main.npc[index].width / 2))) + Math.Abs(Projectile.position.Y + (Projectile.height / 2) - (Main.npc[index].position.Y + (float)(Main.npc[index].height / 2)))) < 1000.0)
                        {
                            flag2 = true;
                            num3 = Main.npc[index].position.X + (float)(Main.npc[index].width / 2);
                            num4 = Main.npc[index].position.Y + (float)(Main.npc[index].height / 2);
                        }
                    }
                    else
                        Projectile.ai[1] = 0.0f;
                }
                if (!Projectile.friendly)
                    flag2 = false;
                if (flag2)
                {
                    float num7 = num2;
                    Vector2 vector2 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                    float num8 = num3 - vector2.X;
                    float num9 = num4 - vector2.Y;
                    float num10 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
                    float num11 = num7 / num10;
                    float num12 = num8 * num11;
                    float num13 = num9 * num11;
                    int num14 = 8;
                    Projectile.velocity.X = (Projectile.velocity.X * (float)(num14 - 1) + num12) / num14;
                    Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num14 - 1) + num13) / num14;
                }
		}
		
		public override bool PreDraw(ref Color lightColor) {
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
		
		//public override bool OnTileCollide(Vector2 oldVelocity)
		//{
		//	Projectile.Kill();
		//	for (int h = 0; h < 2; h++)
		//		{
		//			Vector2 vel = new Vector2(0, -1);
		//			float rand = Main.rand.NextFloat() * 6.283f;
		//			vel = vel.RotatedBy(rand);
		//			vel *= 5f;
		//			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Home"), Projectile.damage/3, 0, Main.myPlayer);
		//		}
		//	return true;
		//}
		//
		//public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		//{
		//	Projectile.Kill();
		//	for (int g = 0; g < 2; g++)
		//		{
		//			Vector2 vel = new Vector2(0, -1);
		//			float rand = Main.rand.NextFloat() * 6.283f;
		//			vel = vel.RotatedBy(rand);
		//			vel *= 5f;
		//			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Home"), Projectile.damage/3, 0, Main.myPlayer);
		//	
		//	}
		//}
	}
}
