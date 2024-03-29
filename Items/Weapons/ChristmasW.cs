using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class ChristmasW : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 33;
			Item.width = 78;
			Item.height = 106;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = 50000;
			Item.rare = 3;
            Item.knockBack = 6;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1f;
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				Item.damage = 150;
				Item.useTime = 20;
				Item.useAnimation = 20;
			}
			else
			{
				Item.damage = 33;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = 335;
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-75,75), position.Y+Main.rand.Next(-75,75), velocity.X, velocity.Y, type, damage, 3, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-100,100), position.Y+Main.rand.Next(-100,100), velocity.X, velocity.Y, type, damage, 3, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
			}
			else
			{
				damage /= 2;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
			}
			return true;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 56);
			}
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumBar, 5);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilBar", 5);
			recipe.AddIngredient(ItemID.BorealWood, 25);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 15);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}
