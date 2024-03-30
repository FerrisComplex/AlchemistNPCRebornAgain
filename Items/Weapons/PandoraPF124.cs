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
	public class PandoraPF124 : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 88;
			Item.DamageType = DamageClass.Ranged;
			Item.crit = 21;
			Item.width = 56;
			Item.height = 30;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = -12;
			Item.autoReuse = true;
			Item.shoot = 340;
			Item.shootSpeed = 32f;
			Item.UseSound = SoundID.Item11;
		}

		public override void HoldItem(Player player)
		{
		(player.GetModPlayer<AlchemistNPCRebornPlayer>()).PH = true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge += 4;
			if (player.altFunctionUse != 2)
			{
			type = 340;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-8, velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+8, velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
			return false;
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
				Item.SetDefaults(Mod.FindItem("PandoraPF262").Type);
			}
			return false;
		}
	}
}
