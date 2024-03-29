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
	[AutoloadEquip(EquipType.Legs)]
	public class LaetitiaLeggings : ModItem
	{
		public int ad = 4;

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 7;
			Item.defense = ad;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.1f;
			Item.defense = ad;
			ad = 4;
			if (NPC.downedQueenBee)
			{
				ad = 5;
			}
			if (NPC.downedBoss3)
			{
				ad = 6;
			}
			if (Main.hardMode)
			{
				ad = 9;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 11;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 13;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 15;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 17;
			}
			if (NPC.downedFishron)
			{
				ad = 19;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 20;
			}
			if (NPC.downedMoonlord)
			{
				ad = 23;
			}
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			Item.defense = ad;
			ad = 4;
			if (NPC.downedQueenBee)
			{
				ad = 5;
			}
			if (NPC.downedBoss3)
			{
				ad = 6;
			}
			if (Main.hardMode)
			{
				ad = 9;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 11;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 13;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 15;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 17;
			}
			if (NPC.downedFishron)
			{
				ad = 19;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 20;
			}
			if (NPC.downedMoonlord)
			{
				ad = 23;
			}
			string text1 = ad + " defense";
			TooltipLine line = new TooltipLine(Mod, "text1", text1);
			line.OverrideColor = Color.White;
			tooltips.RemoveAt(2);
			tooltips.Insert(2,line);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.Cobweb, 40);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilMush", 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}
