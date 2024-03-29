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
using AlchemistNPCRebornAgain.NPCs;

namespace AlchemistNPCRebornAgain.Items.Summoning
{
    public class KnucklesUgandaDoll : ModItem
    {
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 99;
            Item.consumable = false;
			Item.scale = 0.5f;
			Item.UseSound = SoundID.Item37;
            //return;
        }

		public override bool CanUseItem(Player player){
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Knuckles>());
		}
		
		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Knuckles>());
			ModGlobalNPC.ksu = true;
			ModGlobalNPC.kc = 0;
			ModGlobalNPC.ks = false;
			return true;
		}
    }
}
