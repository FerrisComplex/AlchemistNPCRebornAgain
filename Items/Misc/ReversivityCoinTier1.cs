using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Misc
{
    public class ReversivityCoinTier1 : ModItem
    {
        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = 10000;
			Item.rare = 8;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ModContent.ItemType<ReversivityCoinTier2>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
            
        }
    }
}
