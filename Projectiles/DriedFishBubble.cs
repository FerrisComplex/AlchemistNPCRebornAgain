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
	public class DriedFishBubble : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(405);
			Projectile.tileCollide = false;
			Projectile.aiStyle = 70;
			AIType = 405;           //Act exactly like default Bullet
		}
	}
}
