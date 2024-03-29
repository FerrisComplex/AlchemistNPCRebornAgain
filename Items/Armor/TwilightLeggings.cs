using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class TwilightLeggings : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = -12;
			Item.defense = 35;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.30f;
			player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 60);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "JustitiaLeggings");
			recipe.AddIngredient(null, "BigBirdLamp");
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}
