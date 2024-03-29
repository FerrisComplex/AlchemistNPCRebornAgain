using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Notes
{
	public class ResearchNote2 : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 1;
			Item.value = 10000000;
			Item.rare = 10;
		}	
	}
}