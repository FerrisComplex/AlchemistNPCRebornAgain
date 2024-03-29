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
	public class IField : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 1920;
			Projectile.height = 1080;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 60;
			Projectile.tileCollide = false;
		}
        
		
		public override void AI()
		{
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(Projectile.Hitbox) && target.townNPC)
				{
					target.buffImmune[ModContent.BuffType<Buffs.IField>()] = false;
					target.AddBuff(ModContent.BuffType<Buffs.IField>(), 3600);
				}
			}
		}
	}
}
