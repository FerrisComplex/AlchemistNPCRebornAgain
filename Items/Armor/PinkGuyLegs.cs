using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PinkGuyLegs : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 16;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}
