using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class MarcoMagicWand : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 250;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.channel = true;                            //Channel so that you can held the weapon [Important]
			Item.crit = 10;
			Item.mana = 10;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 20;   
			Item.knockBack = 2;			
			Item.shoot = Mod.Find<ModProjectile>("MagicWandM").Type;
			Item.value = Item.sellPrice(3, 0, 0, 0);
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.damage = 250;
				Item.shootSpeed = 14f;
				Item.shoot = Mod.Find<ModProjectile>("MagicWandM").Type;
				Item.channel = true;
				Item.useTime = 20;
				Item.useAnimation = 20;
			}
			if (player.altFunctionUse == 2)
			{
				Item.damage = 2000;
				Item.shootSpeed = 0f;
				Item.shoot = Mod.Find<ModProjectile>("DarkBomb").Type;
				Item.channel = false;
				Item.useTime = 10;
				Item.useAnimation = 10;
			}
			return base.CanUseItem(player);
		}
		
		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.altFunctionUse != 2)
			{
				Item.UseSound = SoundID.Item13;
				Item.damage = 250;
				Item.mana = 10;
				player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime++;
				if (player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime >= 390)
				{
					Item.damage = 550;
					Item.mana = 20;
					player.moveSpeed *= 0.8f;
				}
				else if (player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime >= 210)
				{
					Item.damage = 400;
					Item.mana = 15;
					player.moveSpeed *= 0.9f;
				}
			}
			if (player.altFunctionUse == 2)
			{
				Item.UseSound = SoundID.Item57;
			}
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				damage = 2000;
				Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				position = SPos;
				return true;
			}
			if (player.altFunctionUse != 2)
			{
				damage = 250;
				return true;
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "DarkMagicWand");
			recipe.AddIngredient(null, "EmagledFragmentation", 500);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
