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
    public class CloakOfFear : ModItem
    {
		
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item123;
            Item.useStyle = 2;
            Item.useTurn = true;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 18;
            Item.height = 28;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 11;
			Item.mana = 200;
        }
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.CloakOfFear>(),10800);
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.Exhausted>()) && !player.HasBuff(ModContent.BuffType<Buffs.ExecutionersEyes>()) && !player.HasBuff(ModContent.BuffType<Buffs.CloakOfFear>()))
			{
				return true;
			}
			return false;
		}
    }
}
