using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class EnergyCapsule : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 22;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = 10;
			Item.shoot = ModContent.ProjectileType<Projectiles.PortalGunProj>();
			Item.ammo = Item.type;
		}
	}
}
