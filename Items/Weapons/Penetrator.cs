using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Penetrator : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 15;
			Item.crit = 45;
			Item.autoReuse = true;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.ammo = 0;
			Item.useAmmo = 0;
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 82;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				Item.damage = 25;
			}
			if (NPC.downedBoss1)
			{
				Item.damage = 30;
			}
			if (NPC.downedBoss2)
			{
				Item.damage = 35;
			}
			if (NPC.downedQueenBee)
			{
				Item.damage = 40;
			}
			if (NPC.downedBoss3)
			{
				Item.damage = 45;
			}
			if (Main.hardMode)
			{
				Item.damage = 55;
			}
			if (NPC.downedMechBossAny)
			{
				Item.damage = 65;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				Item.damage = 80;
			}
			if (NPC.downedPlantBoss)
			{
				Item.damage = 100;
			}
			if (NPC.downedGolemBoss)
			{
				Item.damage = 125;
			}
			if (NPC.downedFishron)
			{
				Item.damage = 175;
			}
			if (NPC.downedAncientCultist)
			{
				Item.damage = 250;
			}
			if (NPC.downedMoonlord)
			{
				Item.damage = 500;
			}
			return true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.statLife -= 3;
			if (player.statLife <= 0)
			{
				PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
				if (player.Male) damageSource = PlayerDeathReason.ByCustomReason(player.name + " drained himself to death.");
				if (!player.Male) damageSource = PlayerDeathReason.ByCustomReason(player.name + " drained herself to death.");
				player.KillMe(damageSource, 1.0, 0, false);
			}
			type = 638;
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}
