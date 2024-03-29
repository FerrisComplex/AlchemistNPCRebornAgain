using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPCRebornAgain.Items
{
    public class CrimsonCherrySoda : ModItem
    {
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuperHealingPotion);
            Item.maxStack = 99;                 //this is where you set the max stack of Item
            Item.consumable = true;           //this make that the Item is consumable when used
            Item.value = 0;
            Item.rare = 6;
			Item.healLife = 175;
			Item.potion = true;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.CrimsonSoda>(),2700);
			return true;
		}
    }
}
