using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Enums;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class MagicWandM : ModProjectile
	{
		private const int MAX_CHARGE = 30;
		private const float MOVE_DISTANCE = 60f;
		public int supercharge = 0;
		public int hypercharge = 0;

		public float Distance
		{
			get { return Projectile.ai[0]; }
			set { Projectile.ai[0] = value; }
		}

		public float Charge
		{
			get { return Projectile.localAI[0]; }
			set { Projectile.localAI[0] = value; }
		}

		public override void SetDefaults()
		{
			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.hide = true;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			if (Charge == MAX_CHARGE)
			{
				Vector2 unit = Projectile.velocity;
				DrawLaser(Main.spriteBatch, TextureAssets.Projectile[Projectile.type].Value, 
					Main.player[Projectile.owner].Center, unit, 10, Projectile.damage, 
					-1.57f, 1f, 1000f, Color.White, (int)MOVE_DISTANCE);
			}
			return false;

		}

		/// <summary>
		/// The core function of drawing a laser
		/// </summary>
		public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default(Color), int transDist = 50)
		{
			
			Vector2 origin = start;
			float r = unit.ToRotation() + rotation;
			
			if (Charge == MAX_CHARGE && supercharge < 180)
			{
				texture = Request<Texture2D>("AlchemistNPCRebornAgain/Projectiles/MagicWandC", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
				#region Draw laser body
				for (float i = transDist; i <= Distance; i += step)
				{
					Color c = Color.White;
					origin = start + i * unit;
					Main.spriteBatch.Draw(texture, origin - Main.screenPosition,
						new Rectangle(0, 26, 28, 26), i < transDist ? Color.Transparent : c, r,
						new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				}
				#endregion

				#region Draw laser tail
				Main.spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
					new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				#endregion

				#region Draw laser head
				Main.spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition,
					new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				#endregion
			}
			if (Charge == MAX_CHARGE && supercharge >= 180 && hypercharge < 180)
			{
				texture = Request<Texture2D>("AlchemistNPCRebornAgain/Projectiles/MagicWandB", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
				#region Draw laser body
				for (float i = transDist; i <= Distance; i += step)
				{
					Color c = Color.White;
					origin = start + i * unit;
					Main.spriteBatch.Draw(texture, origin - Main.screenPosition,
						new Rectangle(0, 26, 28, 26), i < transDist ? Color.Transparent : c, r,
						new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				}
				#endregion

				#region Draw laser tail
				Main.spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
					new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				#endregion

				#region Draw laser head
				Main.spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition,
					new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				#endregion
			}
			if (Charge == MAX_CHARGE && supercharge >= 180 && hypercharge >= 180)
			{
				texture = Request<Texture2D>("AlchemistNPCRebornAgain/Projectiles/MagicWandA", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
				#region Draw laser body
				for (float i = transDist; i <= Distance; i += step)
				{
					Color c = Color.White;
					origin = start + i * unit;
					Main.spriteBatch.Draw(texture, origin - Main.screenPosition,
						new Rectangle(0, 26, 28, 26), i < transDist ? Color.Transparent : c, r,
						new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				}
				#endregion

				#region Draw laser tail
				Main.spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
					new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				#endregion

				#region Draw laser head
				Main.spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition,
					new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(28 / 2, 26 / 2), 1.5f, 0, 0);
				#endregion
			}
		}

		/// <summary>
		/// Change the way of collision check of the projectile
		/// </summary>
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (Charge == MAX_CHARGE)
			{
				Player p = Main.player[Projectile.owner];
				Vector2 unit = Projectile.velocity;
				float point = 0f;
				if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), p.Center, p.Center + unit * Distance, 22, ref point))
				{
					return true;
				}
			}
			return false;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			Player player = Main.player[Projectile.owner];
			modifiers.FinalDamage *= 3;
			modifiers.SetMaxDamage(10000);
			if (player.HasBuff(BuffID.ManaSickness))
				modifiers.FinalDamage /= 2;
			
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.Next(2) == 0)
			{
				Projectile.damage += 1;
			}
			target.immune[Projectile.owner] = 4;
		}

		/// <summary>
		/// The AI of the projectile
		/// </summary>
		public override void AI()
		{

			Vector2 mousePos = Main.MouseWorld;
			Player player = Main.player[Projectile.owner];

			#region Set projectile position
			if (Projectile.owner == Main.myPlayer) // Multiplayer support
			{
				Vector2 diff = mousePos - player.Center;
				diff.Normalize();
				Projectile.velocity = diff;
				Projectile.direction = Main.MouseWorld.X > player.position.X ? 1 : -1;
				Projectile.netUpdate = true;
			}
			Projectile.position = player.Center + Projectile.velocity * MOVE_DISTANCE;
			Projectile.timeLeft = 2;
			int dir = Projectile.direction;
			player.ChangeDir(dir);
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(Projectile.velocity.Y * dir,
				Projectile.velocity.X * dir);
			#endregion

			#region Charging process
			// Kill the projectile if the player stops channeling
			if (!player.channel)
			{
				Projectile.Kill();
				player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime = 0;
			}
			else
			{
				if (Main.time % 10 < 1 && !player.CheckMana(player.inventory[player.selectedItem].mana, true))
				{
					Projectile.Kill();
					player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime = 0;
				}
				Vector2 offset = Projectile.velocity;
				offset *= MOVE_DISTANCE - 20;
				Vector2 pos = player.Center + offset - new Vector2(10, 10);
				if (Charge < MAX_CHARGE)
				{
					Charge++;
				}
				int chargeFact = (int)(Charge / 20f);
				Vector2 dustVelocity = Vector2.UnitX * 18f;
				dustVelocity = dustVelocity.RotatedBy(Projectile.rotation - 1.57f, default(Vector2));
				Vector2 spawnPos = Projectile.Center + dustVelocity;
				for (int k = 0; k < chargeFact + 1; k++)
				{
					Vector2 spawn = spawnPos + ((float)Main.rand.NextDouble() * 6.28f).ToRotationVector2() * (12f - (chargeFact * 2));
					Dust dust = Main.dust[Dust.NewDust(pos, 20, 20, 57, Projectile.velocity.X / 2f,
						Projectile.velocity.Y / 2f, 0, default(Color), 1f)];
					dust.velocity = Vector2.Normalize(spawnPos - spawn) * 1.5f * (10f - chargeFact * 2f) / 10f;
					dust.noGravity = true;
					dust.scale = Main.rand.Next(10, 20) * 0.05f;
				}
			}
			#endregion


			#region Set laser tail position and dusts
			if (Charge < MAX_CHARGE) return;
			Vector2 start = player.Center;
			Vector2 unit = Projectile.velocity;
			unit *= -1;
			for (Distance = MOVE_DISTANCE; Distance <= 2200f; Distance += 5f)
			{
				start = player.Center + Projectile.velocity * Distance;
				if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1))
				{
					Distance -= 5f;
					break;
				}
			}

			Vector2 dustPos = player.Center + Projectile.velocity * Distance;
			//Imported dust code from source because I'm lazy
			for (int i = 0; i < 2; ++i)
			{
				float num1 = Projectile.velocity.ToRotation() + (Main.rand.Next(2) == 1 ? -1.0f : 1.0f) * 1.57f;
				float num2 = (float)(Main.rand.NextDouble() * 0.8f + 1.0f);
				Vector2 dustVel = new Vector2((float)Math.Cos(num1) * num2, (float)Math.Sin(num1) * num2);
				Dust dust = Main.dust[Dust.NewDust(dustPos, 0, 0, 57, dustVel.X, dustVel.Y, 0, new Color(), 1f)];
				dust.noGravity = true;
				dust.scale = 1.2f;
				// At this part, I was messing with the dusts going across the laser beam very fast, but only really works properly horizontally now
				dust = Main.dust[Dust.NewDust(Main.player[Projectile.owner].Center + unit * 5f, 0, 0, 57, unit.X, unit.Y, 0, new Color(), 1f)];
				dust.fadeIn = 0f;
				dust.noGravity = true;
				dust.scale = 0.88f;
			}
			if (Main.rand.Next(5) == 0)
			{
				Vector2 offset = Projectile.velocity.RotatedBy(1.57f, new Vector2()) * ((float)Main.rand.NextDouble() - 0.5f) * Projectile.width;
				Dust dust = Main.dust[Dust.NewDust(dustPos + offset - Vector2.One * 4f, 8, 8, 57, 0.0f, 0.0f, 100, new Color(), 1.5f)];
				dust.velocity = dust.velocity * 0.5f;
				dust.velocity.Y = -Math.Abs(dust.velocity.Y);

				unit = dustPos - Main.player[Projectile.owner].Center;
				unit.Normalize();
				dust = Main.dust[Dust.NewDust(Main.player[Projectile.owner].Center + 55 * unit, 8, 8, 57, 0.0f, 0.0f, 100, new Color(), 1.5f)];
				dust.velocity = dust.velocity * 0.5f;
				dust.velocity.Y = -Math.Abs(dust.velocity.Y);
			}
			#endregion

			//Add lights
			//DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
			//Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * (Distance - MOVE_DISTANCE), 26, new Utils.PerLinePoint(DelegateMethods.CastLight));
			
			if (MAX_CHARGE >= 30)
			{
				supercharge++;
				if (supercharge >= 180)		
				{
					hypercharge++;
				}					
			}
		}

		public override bool ShouldUpdatePosition()
		{
			return false;
		}

		//public override void CutTiles()
		//{
		//	DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
		//	Vector2 unit = Projectile.velocity;
		//	Utils.PlotTileLine(Projectile.Center, Projectile.Center + unit * Distance, (Projectile.width + 16) * Projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
		//}
	}
}
