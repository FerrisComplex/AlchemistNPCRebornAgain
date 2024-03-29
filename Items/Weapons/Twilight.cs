using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCRebornAgain;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Twilight : ModItem
	{
		public static int counter = 0;

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 300;
			Item.width = 60;
			Item.height = 62;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 6;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void HoldItem(Player player)
		{
			counter++;
			if (counter == 60)
			{
				counter = 0;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X, player.Center.Y, 0f, 0f, Mod.Find<ModProjectile>("Returner").Type, 200, 0, player.whoAmI);
			}
		}
		
		public override void OnHitNPC(Terraria.Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("Twilight").Type, 600);
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
				{
					Item.damage = 400;
					Item.useTime = 10;
					Item.useAnimation = 10;
				}
				else
				{
					Item.damage = 300;
					Item.useTime = 12;
					Item.useAnimation = 12;
				}
			}
			if (player.altFunctionUse == 2 && !player.HasBuff(Mod.Find<ModBuff>("TwilightCD").Type))
			{
				player.AddBuff(Mod.Find<ModBuff>("TwilightBoost").Type, 120);
				player.AddBuff(Mod.Find<ModBuff>("TwilightCD").Type, 600);
				Vector2 vector = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				player.Teleport(vector, 1, 0);
			}
			if (player.altFunctionUse == 2 && player.HasBuff(Mod.Find<ModBuff>("TwilightCD").Type))
			{
				return false;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "Justitia");
			recipe.AddIngredient(null, "TheBeak");
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(null, "EmagledFragmentation", 200);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}
