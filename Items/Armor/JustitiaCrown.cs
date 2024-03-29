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
	public class JustitiaCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			Language.GetOrRegister(Mod.GetLocalizationKey("JustitiaSetBonus"), () => "Increases current melee damage by 30% and adds 15% to melee critical strike chance");
			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = -12;
			Item.defense = 25;
		}
	
		public override void UpdateEquip(Player player)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.20f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("JustitiaSuit").Type && legs.type == Mod.Find<ModItem>("JustitiaLeggings").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
			string JustitiaSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("JustitiaSetBonus"));
			player.setBonus = JustitiaSetBonus;
			player.GetDamage(DamageClass.Melee) += 0.30f;
			player.GetCritChance(DamageClass.Generic) += 15;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Blindfold);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(ItemID.FragmentNebula, 8);
            recipe.AddIngredient(ItemID.FragmentSolar, 8);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}
