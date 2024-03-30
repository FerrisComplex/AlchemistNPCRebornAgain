using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using AlchemistNPCRebornAgain.Extensions;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Pandora : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PiranhaGun);
			
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 125;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.rare = -12;
			Item.knockBack = 8;
			Item.shoot = Mod.Find<ModProjectile>("PF422").Type;
		}

		public override void HoldItem(Player player)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).PH = true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge += 33;
			if (player.altFunctionUse != 2)
			{
				type = Mod.Find<ModProjectile>("PF422").Type;
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				return true;
			}
			if (player.altFunctionUse == 2 && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge < 500)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && (player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge >= 500)
			{
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge = 0;		
				Item.SetDefaults(Mod.FindItem("PandoraPF013").Type);
			}
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "PandoraPF422");
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
