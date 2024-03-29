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
	public class StormbreakerSwing : ModProjectile
	{
        public override void SetDefaults()
        {
            Projectile.width = 110;
            Projectile.height = 94;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.usesLocalNPCImmunity = true;
            
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            //-------------------------------------------------------------Sound-------------------------------------------------------
            Projectile.soundDelay--;
            if (Projectile.soundDelay <= 0)//this is the proper sound delay for this type of weapon
            {
                SoundEngine.PlaySound(SoundID.Item1);    //this is the sound when the weapon is used
                Projectile.soundDelay = 45;    //this is the proper sound delay for this type of weapon
            }
            //-----------------------------------------------How the Projectile works---------------------------------------------------------------------
            Player player = Main.player[Projectile.owner];
            if (Main.myPlayer == Projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    Projectile.Kill();
                }
            }
            Projectile.Center = player.MountedCenter;
            Projectile.position.X += player.width / 2 * player.direction;
            Projectile.spriteDirection = player.direction;
            Projectile.rotation += 0.7f * player.direction;
            if (Projectile.rotation > MathHelper.TwoPi)
            {
                Projectile.rotation -= MathHelper.TwoPi;
            }
            else if (Projectile.rotation < 0)
            {
                Projectile.rotation += MathHelper.TwoPi;
            }
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = Projectile.rotation;
        }


        public override void Kill(int timeLeft)
		{
			if (Projectile.ai[0] >= 30)
			{
			    Player player = Main.player[Projectile.owner];
			    Vector2 vector82 =  -Main.player[Main.myPlayer].Center + Main.MouseWorld;
                float ai = Main.rand.Next(100);
                Vector2 vector83 = Vector2.Normalize(vector82) * 12f;
                int n1 = Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), player.Center.X, player.Center.Y, vector83.X, vector83.Y, 580, Projectile.damage/2, .5f, player.whoAmI, vector82.ToRotation(), ai);
			    int n2 = Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), player.Center.X, player.Center.Y, vector83.X+10, vector83.Y+10, 580, Projectile.damage/2, .5f, player.whoAmI, vector82.ToRotation(), ai);
			    int n3 = Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), player.Center.X, player.Center.Y, vector83.X-10, vector83.Y-10, 580, Projectile.damage/2, .5f, player.whoAmI, vector82.ToRotation(), ai);
                Projectile.ai[0] = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 5;
			target.AddBuff(ModContent.BuffType<Buffs.Electrocute>(), 300);
		}

        public override bool PreDraw(ref Color lightColor) {
			Main.instance.LoadProjectile(Projectile.type);
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

			// Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}

			return true;
		}

        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the Projectile sprite rotate perfectaly around the player
        //{
        //    Texture2D texture = Main.ProjectileTexture[Projectile.type];
        //    spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
        //    return false;
        //}
    }
}
