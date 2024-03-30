using System.Linq;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class Godhead : ModItem
	{
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 30;
			Item.height = 30;
			Item.value = 100000;
			Item.rare = 8;
			Item.defense = 5;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), player.Center.X, player.Center.Y, 0f, 0f, Mod.Find<ModProjectile>("Fear2").Type, 0, 0, player.whoAmI);
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.GetDamage(DamageClass.Generic) += 0.2f;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.FindItem("SoulOfVision").Type);
			recipe.AddIngredient(Mod.FindItem("SoulOfFear").Type);
			recipe.AddIngredient(Mod.FindItem("SoulOfPower").Type);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 30);
			recipe.AddIngredient(ItemID.HallowedBar, 99);
			//recipe.AddIngredient(Mod.FindItem("MannaFromHeaven").Type);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
