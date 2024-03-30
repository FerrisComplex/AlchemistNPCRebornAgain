using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;
using AlchemistNPCRebornAgain.Extensions;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class MoneyVacuum : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
			for (int number = 0; number < 400; ++number)
			{
				if (Main.item[number].active && Main.item[number].type == ItemID.CopperCoin)
				{
					player.QuickSpawnItem(player.GetSource_FromThis(),Main.item[number]);
					if (Main.netMode == NetmodeID.MultiplayerClient)
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					
				}
				else if (Main.item[number].active && Main.item[number].type == ItemID.SilverCoin)
				{
					player.QuickSpawnItem(player.GetSource_FromThis(),Main.item[number]);
					if (Main.netMode == NetmodeID.MultiplayerClient)
						NetMessage.SendData(MessageID.SyncItem,  -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
				}
				else if (Main.item[number].active && Main.item[number].type == ItemID.GoldCoin)
				{
					player.QuickSpawnItem(player.GetSource_FromThis(),Main.item[number]);
					if (Main.netMode == NetmodeID.MultiplayerClient)
						NetMessage.SendData(MessageID.SyncItem,  -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
				}
				else if (Main.item[number].active && Main.item[number].type == ItemID.PlatinumCoin)
				{
					player.QuickSpawnItem(player.GetSource_FromThis(),Main.item[number]);
					if (Main.netMode == NetmodeID.MultiplayerClient)
						NetMessage.SendData(MessageID.SyncItem,  -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}
		
		public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimsonHeart);
			recipe.AddIngredient(ItemID.GoldRing);
			recipe.AddIngredient(Mod.FindItem("BrokenDimensionalCasket").Type);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(Mod.FindItem("DivineLava").Type, 15);
			recipe.Register();
			
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShadowOrb);
			recipe.AddIngredient(ItemID.GoldRing);
			recipe.AddIngredient(Mod.FindItem("BrokenDimensionalCasket").Type);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(Mod.FindItem("DivineLava").Type, 15);
			recipe.Register();
        }
	}
}
