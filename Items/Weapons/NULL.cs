using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class NULL : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 120;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 30;
			Item.useAnimation = 50;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 1000000;
			Item.rare = 10;
			Item.noUseGraphic = true;
            Item.channel = true;
            Item.noMelee = true;
            Item.damage = 166;
            Item.knockBack = 4;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("NULL").Type;
			Item.shootSpeed = 15f;
		}
		
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.damage = 120;
				Item.shootSpeed = 14f;
				Item.shoot = Mod.Find<ModProjectile>("NULL").Type;
				Item.channel = true;
				Item.useTime = 30;
				Item.useAnimation = 50;
			}
			if (player.altFunctionUse == 2)
			{
				Item.channel = false;
				Item.useTime = 30;
				Item.useAnimation = 30;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse == 2 && !player.HasBuff(Mod.Find<ModBuff>("NULLCD").Type))
			{
				player.AddBuff(Mod.Find<ModBuff>("NULL").Type, 300);
				player.AddBuff(Mod.Find<ModBuff>("NULLCD").Type, 1800);
				return false;
			}
			if (player.altFunctionUse != 2)
			{
				int p = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, Item.shootSpeed, Item.shootSpeed, Mod.Find<ModProjectile>("NULL").Type, damage, Item.knockBack, player.whoAmI);
				return false;
			}
			return false;
        }
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Katana);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddIngredient(ItemID.FragmentVortex, 20);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
