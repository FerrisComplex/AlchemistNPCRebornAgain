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
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Justitia : ModItem
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
			Item.rare = -12;
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
			Item.shoot = Mod.Find<ModProjectile>("JP").Type;
			Item.shootSpeed = 15f;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int p = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, Item.shootSpeed, Item.shootSpeed, Mod.Find<ModProjectile>("JP").Type, damage, Item.knockBack, player.whoAmI);
			Main.projectile[p].scale = 1.5f;
            return false;
        }
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				Item.damage = 225;
			}
			else
			{
				Item.damage = 120;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}
