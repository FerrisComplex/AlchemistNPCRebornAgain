using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.ID;

namespace AlchemistNPCRebornAgain.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class somebody0214Robe : ModItem
	{
        public override void SetStaticDefaults()
        {
			ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false;
        }
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 14;
			Item.rare = -11;
			Item.value = 2500000;
			Item.vanity = true;
		}

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
		{
			robes = true;
			equipSlot = EquipLoader.GetEquipSlot(Mod, "somebody0214Robe_Legs", EquipType.Legs);
		}
	
	}
}
