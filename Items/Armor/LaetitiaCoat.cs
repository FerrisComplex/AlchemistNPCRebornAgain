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
	[AutoloadEquip(EquipType.Body)]
	public class LaetitiaCoat : ModItem
	{
		public int ad = 5;

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
			player.GetDamage(DamageClass.Summon) += 0.2f;
			Item.defense = ad;
			ad = 5;
			if (NPC.downedQueenBee)
			{
				ad = 6;
			}
			if (NPC.downedBoss3)
			{
				ad = 7;
			}
			if (Main.hardMode)
			{
				ad = 10;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 12;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 14;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 16;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 18;
			}
			if (NPC.downedFishron)
			{
				ad = 20;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 21;
			}
			if (NPC.downedMoonlord)
			{
				ad = 24;
			}
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			Item.defense = ad;
			ad = 5;
			if (NPC.downedQueenBee)
			{
				ad = 6;
			}
			if (NPC.downedBoss3)
			{
				ad = 7;
			}
			if (Main.hardMode)
			{
				ad = 10;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 12;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 14;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 16;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 18;
			}
			if (NPC.downedFishron)
			{
				ad = 20;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 21;
			}
			if (NPC.downedMoonlord)
			{
				ad = 24;
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
			recipe.AddIngredient(ItemID.Silk, 25);
			recipe.AddIngredient(ItemID.Cobweb, 50);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 20);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilMush", 12);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}
