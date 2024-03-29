using Terraria.ID;
using Terraria;
using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class LilithCharm : ModItem
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
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).BeeHeal = true;
			}
			if (hideVisual)
			{
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).LilithEmblem = false;
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).BeeHeal = false;
			}
			player.manaMagnet = true;
			player.GetDamage(DamageClass.Magic) += 0.15f;
			player.GetCritChance(DamageClass.Magic) += 15;
			player.statManaMax2 += 100;
			player.manaFlower = true;
            player.manaCost -= 0.25f;
			++player.manaRegenDelayBonus;
            player.manaRegenBonus += 50;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "LilithEmblem");
			recipe.AddIngredient(null, "ChromaticCrystal", 4);
			recipe.AddIngredient(null, "SunkroveraCrystal", 4);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 4);
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
