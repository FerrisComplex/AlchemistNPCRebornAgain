using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class SoulOfVision : ModItem
	{
		public override void SetStaticDefaults()
		{
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 15));
        }
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 30;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofSight, 99);
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
