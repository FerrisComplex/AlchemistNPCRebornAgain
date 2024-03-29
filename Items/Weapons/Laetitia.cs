using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Laetitia : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Musket);
			Item.damage = 35;
			Item.autoReuse = true;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().LaetitiaSet == true)
			{
			Item.damage = 35;
			Item.useTime = 15;
			Item.useAnimation = 15;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().LaetitiaSet == false)
			{
			Item.damage = 35;
			Item.useTime = 30;
			Item.useAnimation = 30;
			}
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
			Item.damage = 500;
			Item.useTime = 15;
			Item.useAnimation = 15;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, Item.shootSpeed, Item.shootSpeed, type, damage/2, Item.knockBack, player.whoAmI);
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Musket);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilMush", 10);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TheUndertaker);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilMush", 10);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}
