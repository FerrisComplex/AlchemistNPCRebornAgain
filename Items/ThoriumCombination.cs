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
    public class ThoriumCombination : ModItem
    {
		public override bool IsLoadingEnabled(Mod mod)
		 {
			 ModLoader.TryGetMod("ThoriumMod", out Mod Thorium);
			 return Thorium != null;
		}
		
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}    

		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.ThoriumComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AssassinPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("BloodPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("FrenzyPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("CreativityPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("EarwormPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InspirationReachPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GlowingPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("HolyPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("HydrationPotion")), 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.Register();
		}
		*/
    }
}
