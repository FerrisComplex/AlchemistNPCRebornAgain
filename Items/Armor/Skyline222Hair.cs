using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Skyline222Hair : ModItem
	{
		public override void SetStaticDefaults()
		{

			Language.GetOrRegister(Mod.GetLocalizationKey("NoireSetBonus"), () => "Increases current ranged/minion damage by 20% and adds 20% to ranged critical strike chance"
			                                                         + "\n+40 defense"
			                                                         + "\nPrices are lower");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("Skyline222Body").Type && legs.type == Mod.Find<ModItem>("Skyline222Legs").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
			string NoireSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("NoireSetBonus"));
			player.setBonus = NoireSetBonus;
			player.discountEquipped = true;
			player.discountAvailable = true;
            player.statDefense += 40;
			player.GetDamage(DamageClass.Ranged) += 0.2f;
            player.GetDamage(DamageClass.Summon) += 0.2f;
            player.GetCritChance(DamageClass.Ranged) += 20;
		}
	}
}
