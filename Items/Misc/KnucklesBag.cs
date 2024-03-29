using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class KnucklesBag : ModItem
	{
        
		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = 9;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			itemLoot.Add(ItemDropRule.Common(ItemType<Weapons.EdgeOfChaos>()));
			itemLoot.Add(ItemDropRule.Common(ItemType<Weapons.LastTantrum>()));
			itemLoot.Add(ItemDropRule.Common(ItemType<Weapons.BreathOfTheVoid>()));
			itemLoot.Add(ItemDropRule.Common(ItemType<Weapons.ChaosBomb>()));
			itemLoot.Add(ItemDropRule.Common(ItemType<Weapons.UgandanTotem>()));
			itemLoot.Add(ItemDropRule.Common(ItemType<Equippable.AutoinjectorMK2>()));
			
			itemLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 25));
		}
	}
}
