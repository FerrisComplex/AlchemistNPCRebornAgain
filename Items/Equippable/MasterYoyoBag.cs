using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class MasterYoyoBag : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 100000;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().MasterYoyoBag = true;
			player.counterWeight = 556 + Main.rand.Next(6);
			player.yoyoGlove = true;
			player.yoyoString = true;
            player.GetDamage(DamageClass.Melee) += 0.15f;
			if (player.HeldItem.channel) player.GetAttackSpeed(DamageClass.Melee) += 1.15f;
			else player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
			player.kbGlove = true;
			player.magmaStone = true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.YoyoBag);
			recipe.AddIngredient(ItemID.FireGauntlet);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
