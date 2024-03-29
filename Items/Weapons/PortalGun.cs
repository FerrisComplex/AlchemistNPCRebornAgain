using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class PortalGun : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 75;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item114;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.PortalGunProj>();
			Item.shootSpeed = 16f;
			Item.useAmmo = ModContent.ItemType<EnergyCapsule>();
		}
	}
}
