using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
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
    public class BreathOfTheVoid : ModProjectile
    {
		public int counter = 0;

        public override void SetDefaults()
        {
            Projectile.width = 118;
            Projectile.height = 118;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			
			float num = 1.57079637f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			Projectile.ai[0] += 1f;
			int num2 = 0;
			if (Projectile.ai[0] >= 30f)
			{
				num2++;
			}
			if (Projectile.ai[0] >= 60f)
			{
				num2++;
			}
			if (Projectile.ai[0] >= 90f)
			{
				num2++;
			}
			int num3 = 24;
			int num4 = 6;
			Projectile.ai[1] += 1f;
			bool flag = false;
			if (Projectile.ai[1] >= (float)(num3 - num4 * num2))
			{
				Projectile.ai[1] = 0f;
				flag = true;
			}
			if (Projectile.ai[1] == 1f && Projectile.ai[0] != 1f)
			{
				Vector2 vector2 = Vector2.UnitX * 24f;
				vector2 = vector2.RotatedBy((double)(Projectile.rotation - 1.57079637f), default(Vector2));
				Vector2 value = Projectile.Center + vector2;
			}
			if (flag && Main.myPlayer == Projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					float scaleFactor = player.inventory[player.selectedItem].shootSpeed * Projectile.scale;
					Vector2 vector3 = vector;
					Vector2 value2 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector3;
					if (player.gravDir == -1f)
					{
						value2.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector3.Y;
					}
					Vector2 vector4 = Vector2.Normalize(value2);
					if (float.IsNaN(vector4.X) || float.IsNaN(vector4.Y))
					{
						vector4 = -Vector2.UnitY;
					}
					vector4 *= scaleFactor;
					if (vector4.X != Projectile.velocity.X || vector4.Y != Projectile.velocity.Y)
					{
						
					}
					Projectile.velocity = vector4;
					float scaleFactor2 = 14f;
					int num7 = 7;
				
					vector3 = Projectile.Center + new Vector2((float)Main.rand.Next(-num7, num7 + 1), (float)Main.rand.Next(-num7, num7 + 1));
					Vector2 vector5 = Vector2.Normalize(Projectile.velocity) * scaleFactor2;
					vector5 = vector5.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
					if (float.IsNaN(vector5.X) || float.IsNaN(vector5.Y))
					{
						vector5 = -Vector2.UnitY;
					}
				}
			}
			Projectile.netUpdate = true;
			if (player.direction == 1)
			{
				Projectile.spriteDirection = 1;
				Projectile.position.X = player.position.X - 160;
				
			}
			if (player.direction == -1)
			{
				Projectile.spriteDirection = -1;
				Projectile.position.X = player.position.X + 90;
			}
			
			Projectile.position.Y = player.position.Y - 120;
			Projectile.rotation = Projectile.velocity.ToRotation() + num;
			Projectile.spriteDirection = Projectile.direction;
			Projectile.timeLeft = 2;
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2((double)(Projectile.velocity.Y * (float)Projectile.direction), (double)(Projectile.velocity.X * (float)Projectile.direction));
            if (!player.channel)
			{
				Projectile.Kill();
			}
			counter++;
			if (Projectile.owner == Main.myPlayer && counter == 5)
            {
				counter = 0;
				float num10 = 12f;
				Vector2 vector8 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
				float f1 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
				float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
				if ((double)player.gravDir == -1.0)
					f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector8.Y;
				float num8 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
				float num9;
				if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
				{
					f1 = (float)player.direction;
					f2 = 0.0f;
					num9 = num10;
				}
				else
					num9 = num10 / num8;
				float SpeedX = f1 * num9;
				float SpeedY = f2 * num9;
				SoundEngine.PlaySound(SoundID.Item34, Projectile.position);
				int numberProjectiles = 3;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(SpeedX, SpeedY).RotatedByRandom(MathHelper.ToRadians(5));
					Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),vector8.X, vector8.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Void>(), Projectile.damage, Projectile.knockBack, player.whoAmI);
				}
				int numberProjectiles1 = 6;
				for (int i = 0; i < numberProjectiles1; i++)
				{
					Vector2 perturbedSpeed1 = new Vector2(SpeedX, SpeedY).RotatedByRandom(MathHelper.ToRadians(5));
					Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),vector8.X, vector8.Y, perturbedSpeed1.X, perturbedSpeed1.Y, ModContent.ProjectileType<VoidDummy>(), Projectile.damage, Projectile.knockBack, player.whoAmI);
				}
			}
        }
    }
}
