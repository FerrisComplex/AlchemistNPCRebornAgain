using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Placeable
{
    public class ImmortalityFieldProjector : ModItem
    {
		
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 7;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = Mod.Find<ModTile>("ImmortalityFieldProjector").Type;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
            recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(ItemID.Wire, 200);
			recipe.AddIngredient(Mod.FindItem("ChromaticCrystal").Type, 5);
			recipe.AddIngredient(Mod.FindItem("SunkroveraCrystal").Type, 5);
			recipe.AddIngredient(Mod.FindItem("NyctosythiaCrystal").Type, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
