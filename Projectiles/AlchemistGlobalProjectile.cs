using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPCRebornAgain.Projectiles;
using System.IO;
using AlchemistNPCRebornAgain.NPCs;
using Terraria.ModLoader.IO;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class AlchemistGlobalProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity => true;
		
		public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					if (player.HasBuff(ModContent.BuffType<Buffs.GreaterDangersense>()))
					{
						if (projectile.hostile && !projectile.friendly)
						{
							Lighting.AddLight(projectile.Center, 1f, 1f, 0f);
							return Color.Yellow;
						}
					}
				}
			}
			return base.GetAlpha(projectile, lightColor);
        }
		
		public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
		{
			Player player = Main.player[projectile.owner];
			if ((projectile.type == ProjectileID.PoisonDart) && player.GetModPlayer<AlchemistNPCRebornPlayer>().Traps)
			{
				if (Main.expertMode)
				{
					modifiers.FlatBonusDamage += 40;
				}
				else
				{
					modifiers.FlatBonusDamage += 20;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == ProjectileID.PoisonDartTrap) && player.GetModPlayer<AlchemistNPCRebornPlayer>().Traps)
			{
				if (Main.expertMode)
				{
					modifiers.FlatBonusDamage += 40;
				}
				else
				{
					modifiers.FlatBonusDamage += 20;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == ProjectileID.SpikyBallTrap) && player.GetModPlayer<AlchemistNPCRebornPlayer>().Traps)
			{
				if (Main.expertMode)
				{
					modifiers.FlatBonusDamage += 40;
				}
				else
				{
					modifiers.FlatBonusDamage += 20;
				}
				target.immune[projectile.owner] = 3;
			}
			if ((projectile.type == ProjectileID.SpearTrap) && player.GetModPlayer<AlchemistNPCRebornPlayer>().Traps)
			{
				if (Main.expertMode)
				{
					modifiers.FlatBonusDamage += 20;
				}
				else
				{
					modifiers.FlatBonusDamage += 10;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == ProjectileID.FlamethrowerTrap) && player.GetModPlayer<AlchemistNPCRebornPlayer>().Traps)
			{
				if (Main.expertMode)
				{
					modifiers.FlatBonusDamage += 40;
				}
				else
				{
					modifiers.FlatBonusDamage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
			
			
			if ((projectile.type == ProjectileID.FlamesTrap) && player.GetModPlayer<AlchemistNPCRebornPlayer>().Traps)
			{
				if (Main.expertMode)
				{
					modifiers.FlatBonusDamage += 40;
				}
				else
				{
					modifiers.FlatBonusDamage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == ProjectileID.GeyserTrap) && player.GetModPlayer<AlchemistNPCRebornPlayer>().Traps)
			{
				if (Main.expertMode)
				{
					modifiers.FlatBonusDamage += 40;
				}
				else
				{
					modifiers.FlatBonusDamage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
		}
	}
}
