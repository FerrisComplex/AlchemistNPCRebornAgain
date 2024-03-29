using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	class LifeElixir : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.value = 5000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax >= 500 && player.GetModPlayer<AlchemistNPCRebornPlayer>().LifeElixir < 2;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			player.statLifeMax2 += 50;
			player.statLife += 50;
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(50, true);
			}
			player.GetModPlayer<AlchemistNPCRebornPlayer>().LifeElixir += 1;
			return true;
		}
	}
}
