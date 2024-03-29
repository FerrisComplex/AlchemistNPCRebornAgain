using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class AlchemistCharmTier2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 2000000;
			Item.rare = 8;
		}
		
        public override void UpdateInventory(Player player)
        {
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier2 = true;
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).DistantPotionsUse = true;
        }
		
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient(null, "AlchemistCharmTier1");
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilBar", 15);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
