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
	public class Madness : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 128;
			Projectile.height = 128;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 99999;
			Projectile.hostile = true;
			Projectile.tileCollide = false;
		}
		
		public override bool? CanHitNPC(NPC target)
		{
			if (target.townNPC || target.type == ModContent.NPCType<NPCs.BillCipher>())
			{
				return false;
			}
			return true;
		}
		
		public override void AI()
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.dead || !NPC.AnyNPCs(ModContent.NPCType<NPCs.BillCipher>()))
				{
					Projectile.Kill();
				}
				if (player.Hitbox.Intersects(Projectile.Hitbox))
				{
				player.AddBuff(BuffID.Electrified, 360);
				player.AddBuff(BuffID.OgreSpit, 360);
				}
			}
		}
	}
}
