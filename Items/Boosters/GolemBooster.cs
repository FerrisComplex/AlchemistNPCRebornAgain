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
	class GolemBooster : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool CanUseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().GolemBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().GolemBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().GolemBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().GolemBooster = 0;
				return true;
			}
			return false;
		}
	}
}
