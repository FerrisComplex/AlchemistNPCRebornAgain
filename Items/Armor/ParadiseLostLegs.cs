using System.Collections.Generic;
using System.Linq;
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
	public class ParadiseLostLegs : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 40;
		}

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 60);
			player.moveSpeed += 0.66f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "TwilightLeggings");
			recipe.AddIngredient(null, "ChromaticCrystal", 8);
			recipe.AddIngredient(null, "SunkroveraCrystal", 8);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 8);
			recipe.AddIngredient(null, "EmagledFragmentation", 200);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
