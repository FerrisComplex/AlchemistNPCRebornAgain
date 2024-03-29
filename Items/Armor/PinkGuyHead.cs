using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PinkGuyHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			Language.GetOrRegister(Mod.GetLocalizationKey("PGSetBonus"), () => "Increases current ranged/melee damage by 15% and adds 15% to ranged/melee critical strike chance"
			                                                                   + "\n+56 defense"
			                                                                   + "\nIncreases movement speed greatly"
			                                                                   + "\nPlayer is under permanent effect of Tank Combination"
			                                                                   + "\nNational Ugandan Treasure can now be dropped from Moon Lord");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("PinkGuyBody").Type && legs.type == Mod.Find<ModItem>("PinkGuyLegs").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
            modPlayer.PGSWear = true;
            string PGSetBonus = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.PGSetBonus");
			player.setBonus = PGSetBonus;
            player.statDefense += 56;
			player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Ranged) += 15;
			player.GetCritChance(DamageClass.Generic) += 15;
			player.moveSpeed += 0.50f;
			player.AddBuff(Mod.Find<ModBuff>("TankComb").Type, 2);
		}
	}
}
