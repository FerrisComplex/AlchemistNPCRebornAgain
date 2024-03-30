using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain.Interface;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class DimensionalCasket : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 5000000;
			Item.rare = 10;
			Item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = false;
			Item.expert = true;
		}
		
		public override bool? UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
			{
				//DimensionalCasketUI.visible = true;
		
			}
			return true;
		}
		
		public override bool ConsumeItem(Player player)
		{
			return false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
			if (Main.myPlayer == player.whoAmI)
			{
				//DimensionalCasketUI.visible = true;
			
			}
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.FindItem("BrokenDimensionalCasket").Type);
			recipe.AddIngredient(Mod.FindItem("DivineLava").Type, 15);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:Tier3Bar", 10);
			recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
