using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class LilithEmblem : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (!hideVisual)
			{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).LilithEmblem = true;
			}
			if (hideVisual)
			{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).LilithEmblem = false;
			}
			player.manaMagnet = true;
			player.GetDamage(DamageClass.Magic) += 0.1f;
			player.GetCritChance(DamageClass.Magic) += 10;
			player.statManaMax2 += 50;
			player.manaFlower = true;
            player.manaCost -= 0.15f;
			++player.manaRegenDelayBonus;
            player.manaRegenBonus += 25;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CelestialEmblem);
			recipe.AddIngredient(ItemID.EyeoftheGolem);
			recipe.AddIngredient(ItemID.ManaFlower);
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.BeeGun);
			recipe.AddIngredient(ItemID.WaspGun);
            recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
