using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class TrueSasscade : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(3389);
			Item.damage = 200;
			Item.shoot = Mod.Find<ModProjectile>("TrueSasscadeYoyo").Type;
			Item.knockBack = 4;
			Item.value = 5000000;
			Item.rare = 11;
			Item.shootSpeed = 12f;
			Item.useTime = 10;
			Item.useAnimation = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.counterWeight = 556 + Main.rand.Next(6);
			player.yoyoGlove = true;
			player.yoyoString = true;
		}
		
		public override void UpdateInventory(Player player)
		{
			player.counterWeight = 556 + Main.rand.Next(6);
			player.yoyoGlove = true;
			player.yoyoString = true;
		}
		
		public override void HoldItem(Player player)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).TS = true;
			player.counterWeight = 556 + Main.rand.Next(6);
			player.yoyoGlove = true;
			player.yoyoString = true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "Sasscade");
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
