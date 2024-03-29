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

namespace AlchemistNPCRebornAgain.Projectiles.Minions
{
	public class UgandanWarrior : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(533);
			Projectile.width = 96;
			Projectile.height = 76;
			Projectile.aiStyle = 66;
			Projectile.minionSlots = 1;
			AIType = 533;
			Projectile.tileCollide = false;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			Player player = Main.player[Projectile.owner];
			modifiers.FinalDamage *= Math.Max(1, player.maxMinions / 10);
			if (target.type == ModContent.NPCType<NPCs.BillCipher>())
                modifiers.FinalDamage /= 100;
		}
		
		public override void AI()
		{
			Projectile.tileCollide = false;
			Player player = Main.player[Projectile.owner]; 
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.UgandanWarrior>()))
			{
				Projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 1;
		}
	}
}
