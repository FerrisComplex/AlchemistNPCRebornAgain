using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class BillSoul : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.value = 5000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<AlchemistNPCRebornPlayer>().BillIsDowned < 1;
		}

		public override bool? UseItem(Player player)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().BillIsDowned += 1;
			return true;
		}
	}
}
