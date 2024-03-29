using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	[AutoloadEquip(EquipType.Neck)]
	public class LaetitiaGift : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 28;
			Item.value = Item.buyPrice(0, 30, 0, 0);
			Item.rare = 7;
			Item.accessory = true;
			
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().LaetitiaGift = true;
			++player.maxMinions;
			++player.maxMinions;
			++player.maxMinions;
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("LittleWitchMonster").Type] != 1)
			{
			player.lifeRegen -= 20;
			}
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("LittleWitchMonster").Type] < 1)
			{
			player.AddBuff(Mod.Find<ModBuff>("LittleWitchMonster").Type, 60);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpiderFang, 5);
			recipe.AddIngredient(ItemID.HallowedBar, 8);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}
