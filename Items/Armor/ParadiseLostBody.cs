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
	[AutoloadEquip(EquipType.Body)]
	public class ParadiseLostBody: ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 45;
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 200;
			player.endurance += 0.25f;
			player.buffImmune[46] = true;
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[33] = true;
            player.buffImmune[36] = true;
            player.buffImmune[30] = true;
            player.buffImmune[20] = true;
            player.buffImmune[32] = true;
            player.buffImmune[31] = true;
            player.buffImmune[35] = true;
            player.buffImmune[23] = true;
            player.buffImmune[22] = true;
			player.buffImmune[24] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "TwilightSuit");
			recipe.AddIngredient(null, "ChromaticCrystal", 10);
			recipe.AddIngredient(null, "SunkroveraCrystal", 10);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 10);
			recipe.AddIngredient(null, "EmagledFragmentation", 300);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
