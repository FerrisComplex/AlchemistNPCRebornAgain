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
	public class UltimateSephirothicFruit : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().SF = true;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().SFU = true;
            player.GetDamage(DamageClass.Summon) += 0.15f;
			++player.maxMinions;
			++player.maxMinions;
			++player.maxMinions;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "SephirothicFruit");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			if (Calamity == null)
			{
				recipe.AddTile(null, "MateriaTransmutator");
			}
			if (Calamity != null)
			{
				recipe.AddTile(null, "MateriaTransmutatorMK2");
			}
			recipe.Register();
		}
	}
}
