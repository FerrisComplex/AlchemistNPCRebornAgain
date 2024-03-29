using Terraria.ID;
using Terraria;
using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class SupremeRampageComponents : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 30;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().Rampage = true;
			if (!hideVisual)
			{
				player.scope = true;
			}
			player.GetArmorPenetration(DamageClass.Generic) += 40;
			player.magicQuiver = true;
			player.ammoPotion = true;
			player.GetDamage(DamageClass.Ranged) += 0.15f;
			player.GetCritChance(DamageClass.Ranged) += 15;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().XtraT = true;
		}

		
		public override void AddRecipes()
		{
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "RampageComponents");
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
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
