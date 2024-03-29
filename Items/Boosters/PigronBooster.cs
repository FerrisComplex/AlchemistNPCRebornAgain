using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Boosters
{
	class PigronBooster : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().PigronBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().PigronBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().PigronBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().PigronBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
