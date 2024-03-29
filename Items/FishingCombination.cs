using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPCRebornAgain.Items
{
     public class FishingCombination : ModItem
    {
       
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item44;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.FishingComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient(ItemID.FishingPotion, 1);
			recipe.AddIngredient(ItemID.SonarPotion, 1);
			recipe.AddIngredient(ItemID.CratePotion, 1);
			recipe.AddIngredient(ItemID.RestorationPotion, 1);
			recipe.AddIngredient(ItemID.IronskinPotion, 1);
			recipe.AddIngredient(ItemID.ThornsPotion, 1);
			recipe.AddIngredient(ItemID.InfernoPotion, 1);
			recipe.AddIngredient(ItemID.CalmingPotion, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.Register();
		}
    }
}
