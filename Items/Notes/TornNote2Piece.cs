using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Notes
{
	public class TornNote2Piece : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 15;
			Item.height = 11;
			Item.maxStack = 99;
			Item.value = 150000;
			Item.rare = 5;
		}
	}
}
