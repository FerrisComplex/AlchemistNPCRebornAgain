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
	public class Barrage : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 10;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().Barrage = true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:Tier3Bar", 15);
			recipe.AddIngredient(Mod.Find<ModItem>("DivineLava").Type, 99);
			recipe.AddIngredient(2882);
			recipe.AddIngredient(ItemID.Nanites, 99);
			recipe.AddTile(Mod.Find<ModTile>("MateriaTransmutator").Type);
			recipe.Register();
		}
	}
}
