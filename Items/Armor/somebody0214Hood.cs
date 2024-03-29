using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class somebody0214Hood : ModItem
	{
		public override void SetStaticDefaults()
		{

			Language.GetOrRegister(Mod.GetLocalizationKey("somebody0214SetBonus"), () => "Increases current magic damage by 30% and adds 20% to magic critical strike chance"
			                                                                             + "\n+32 defense"
			                                                                             + "\n+25% damage reduction");
		}
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.rare = -11;
			Item.value = 2500000;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("somebody0214Robe").Type;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			string somebody0214SetBonus = Language.GetTextValue(Mod.GetLocalizationKey("somebody0214SetBonus"));
			player.setBonus = somebody0214SetBonus;
			player.GetDamage(DamageClass.Magic) *= 1.30f;
			player.GetCritChance(DamageClass.Magic) += 20;
			player.statDefense += 32;
			player.endurance += 0.25f;
		}
	}
}
