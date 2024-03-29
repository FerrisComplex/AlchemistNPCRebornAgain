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
    public class CalamityCombination : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			return Calamity != null;
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
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 10;
            Item.buffType = Item.buffType = ModContent.BuffType<Buffs.CalamityComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
        
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);;
            recipe.AddTile(TileID.AlchemyTable);
            string[][] modComponents = new string[][]{
                new string[] {"CalamityMod", "YharimsStimulants"},
                new string[] {"CalamityMod", "FabsolsVodka"},
                new string[] {"CalamityMod", "CadancePotion"},
                new string[] {"CalamityMod", "TitanScalePotion"},
                new string[] {"CalamityMod", "SoaringPotion"},
                new string[] {"CalamityMod", "BoundingPotion"}
            };
            foreach (string[] arr in modComponents) {
                if (ModContent.TryFind<ModItem>(arr[0], arr[1], out ModItem currItem)) {
			        recipe.AddIngredient(currItem, 1);
                }
            }
            recipe.Register();
		}
    }
}
