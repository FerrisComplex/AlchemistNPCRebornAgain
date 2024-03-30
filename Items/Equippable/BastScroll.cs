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
using AlchemistNPCRebornAgain.Extensions;
using Terraria.DataStructures;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class BastScroll : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 100000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(Mod.Find<ModBuff>("BastScroll").Type, 60);
			player.GetModPlayer<AlchemistNPCRebornPlayer>().Scroll = true;
			player.endurance += 0.1f;
			player.statDefense += 5;
			player.GetDamage(DamageClass.Throwing) += 0.15f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
			player.GetCritChance(DamageClass.Generic) += 15;
            player.GetCritChance(DamageClass.Throwing) += 15;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
			player.jumpBoost = true;
			player.noFallDmg = true;
			if (!hideVisual)
			{
				// https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#extra-jump-api needs to be updated to this
				player.GetJumpState<CloudInABottleJump>().Available = true;
				player.GetJumpState<BlizzardInABottleJump>().Available = true;
				//player.hasJumpOption_Cloud = true;
				//player.hasJumpOption_Blizzard = true;
			}
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, 15);
			}
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.BlackInk, 10);
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.SpectreBar, 20);
			recipe.AddIngredient(ItemID.Nanites, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 30);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(Mod.FindItem("EmagledFragmentation").Type, 250);
			recipe.AddTile(Mod.Find<ModTile>("MateriaTransmutator").Type);
			recipe.Register();
		}
	}
}
