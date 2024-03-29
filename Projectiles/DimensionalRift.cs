using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPCRebornAgain.NPCs;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class DimensionalRift : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(261);
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.damage = 0;
			Projectile.aiStyle = 14;
			Projectile.timeLeft = 300;
			AIType = 261;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[Projectile.owner];
			if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.BillCipher>())){
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.BillCipher>());
				BillCipher.introduction = 0;
				ModGlobalNPC.bsu = true;
			}
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.Kill();
		}
	}
}
