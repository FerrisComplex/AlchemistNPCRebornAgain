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
	public class TP : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.NebulaBlaze1);
			Main.projFrames[Projectile.type] = 4;
			AIType = ProjectileID.NebulaBlaze1;
			Projectile.tileCollide = false;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 450;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.NebulaBlaze1;
			return true;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.lifeMax <= 10000)
			{
				modifiers.SetMaxDamage(10000);
				modifiers.FlatBonusDamage += 99999999999;
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Twilight>(), 600);
			target.immune[Projectile.owner] = 1;
		}
	}
}
