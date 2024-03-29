using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class FangBallista : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 99;
			Item.DamageType = DamageClass.Ranged;
			Item.crit = 21;
			Item.width = 32;
			Item.height = 46;
			Item.useTime = 90;
			Item.useAnimation = 90;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = Mod.Find<ModProjectile>("SpiderFang").Type;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position, velocity, type, damage, Item.knockBack, player.whoAmI);
			return false;
		}
	}
}
