using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	class Fuaran : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.value = 5000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statManaMax >= 200 && player.GetModPlayer<AlchemistNPCRebornPlayer>().Fuaran < 1;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			player.statManaMax2 += 100;
			player.statMana += 100;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().Fuaran += 1;
			return true;
		}
	}
}
