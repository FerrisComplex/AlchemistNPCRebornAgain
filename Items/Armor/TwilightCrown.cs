using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
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
	public class TwilightCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			Language.GetOrRegister(Mod.GetLocalizationKey("TwilightSetBonus"), () => "Increases current melee/magic damage by 30% and adds 15% to melee/magic critical strike chance"
			                                                                         + "\nIncludes all bonuses from Big Bird Lamp");
			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = -12;
			Item.defense = 30;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.30f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.FindItem("TwilightSuit").Type && legs.type == Mod.FindItem("TwilightLeggings").Type;
		}
	

		public override void UpdateArmorSet(Player player)
		{
			string TwilightSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("TwilightSetBonus"));
			player.setBonus = TwilightSetBonus;
			player.GetDamage(DamageClass.Melee) += 0.35f;
			player.GetDamage(DamageClass.Magic) += 0.35f;
			player.GetCritChance(DamageClass.Generic) += 20;
			player.GetCritChance(DamageClass.Magic) += 20;
			player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 300);
			player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetDamage(DamageClass.Summon) += 0.05f;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "JustitiaCrown");
			recipe.AddIngredient(null, "MasksBundle");
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}
