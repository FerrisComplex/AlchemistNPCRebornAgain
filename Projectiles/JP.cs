using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPCRebornAgain.Projectiles
{
    public class JP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Arkhalis);
            Projectile.width = 50;
            Projectile.height = 46;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Main.projFrames[ModContent.ProjectileType<JP>()] = 28;
            Projectile.aiStyle = 75;
            AIType = 595;
        }
        public override void AI()
        {
			if (Main.myPlayer == Projectile.owner)
            {
                //Do net updatey thing. Syncs this Projectile.
				if (Main.rand.Next(3) == 0)
                {
                 int num30 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 2f);
                    Main.dust[num30].noGravity = true;
                    Main.dust[num30].position -= Projectile.velocity;
                 }
                Projectile.netUpdate = true;
                Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                if (Main.player[Projectile.owner].Center.Y < mouse.Y)
                {
                    float Xdis = Main.player[Main.myPlayer].Center.X - mouse.X;  // change myplayer to nearest player in full version
                    float Ydis = Main.player[Main.myPlayer].Center.Y - mouse.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    float DistXT = (float)(Math.Sin(Angle) * 29);
                    float DistYT = (float)(Math.Cos(Angle) * 29);
                    Projectile.position.X = (Main.player[Projectile.owner].Center.X + DistXT) - 30;
                    Projectile.position.Y = (Main.player[Projectile.owner].Center.Y + DistYT) - 30;
                }
                if (Main.player[Projectile.owner].Center.Y >= mouse.Y)
                {
                    float Xdis = Main.player[Main.myPlayer].Center.X - mouse.X;  // change myplayer to nearest player in full version
                    float Ydis = Main.player[Main.myPlayer].Center.Y - mouse.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    float DistXT = (float)(Math.Sin(Angle) * 29);
                    float DistYT = (float)(Math.Cos(Angle) * 29);
                    Projectile.position.X = (Main.player[Projectile.owner].Center.X + (0 - DistXT)) - 30;
                    Projectile.position.Y = (Main.player[Projectile.owner].Center.Y + (0 - DistYT)) - 30;
                }
            }
			
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Buffs.JustitiaPale>(), 600);
			target.immune[Projectile.owner] = 3;
		}

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            projHitbox.X -= projHitbox.Width / 2;
            projHitbox.Y -= projHitbox.Height / 2;
            projHitbox.Width *= 2;
            projHitbox.Height *= 2;
            return projHitbox.Intersects(targetHitbox);
        }
    }
}
