using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class RampageComponents : ModItem
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
			player.magicQuiver = true;
			player.ammoPotion = true;
			player.GetDamage(DamageClass.Ranged) += 0.1f;
			player.GetCritChance(DamageClass.Ranged) += 10;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().XtraT = true;
		}

		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "CrystalDustBullet", 3996);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 3996);
			recipe.AddIngredient(ItemID.SniperScope);
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
