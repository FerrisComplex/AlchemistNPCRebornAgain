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
    public class OnyxGrapeSoda : ModItem
    {
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 99;
			Item.value = 0;
            Item.consumable = true;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.Teleport(player.GetModPlayer<AlchemistNPCRebornPlayer>().spawnPosition, 1);
			player.AddBuff(BuffID.ChaosState, 1800);
			player.AddBuff(ModContent.BuffType<Buffs.OnyxSoda>(),300);
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return (player.HasBuff(ModContent.BuffType<Buffs.OnyxSoda>()) == false && player.HasBuff(BuffID.ChaosState) == false);
		}
    }
}
