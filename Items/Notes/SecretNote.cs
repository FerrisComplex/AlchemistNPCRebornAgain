using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Notes
{
	public class SecretNote : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 99;
			Item.value = 1000000;
			Item.rare = 5;
		}	
	}
}
