using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
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
	public class TheBeak : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.useAnimation = 20;
			Item.useTime = 10;
			Item.reuseDelay = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage/2, Item.knockBack, player.whoAmI);
			type = Mod.Find<ModProjectile>("BB").Type;
			return true;
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .25;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 4);
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 150;
					Item.useAnimation = 12;
					Item.useTime = 6;
					Item.reuseDelay = 6;
					}
					else
					{
					Item.damage = 12;
					Item.useAnimation = 20;
					Item.useTime = 10;
					Item.reuseDelay = 20;
					}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilBar", 12);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 10);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilMush", 5);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}
