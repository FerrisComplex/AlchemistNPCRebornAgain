using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Tritantrum : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 92;
			Item.height = 40;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 64f;
			Item.useAmmo = Mod.FindItem("PlasmaRound").Type;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
		return Main.rand.NextFloat() >= .5;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-10,10), position.Y+3+Main.rand.Next(-3,3), velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-10,10), position.Y-3+Main.rand.Next(-3,3), velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
			return false;
		}
	}
}
