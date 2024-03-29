using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	class MannafromHeaven : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.width = 26;
			Item.height = 14;
			Item.value = 25000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<AlchemistNPCRebornPlayer>().WellFed < 1;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().WellFed += 1;
			return true;
		}
	}
}
