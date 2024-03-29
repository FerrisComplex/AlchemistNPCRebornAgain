using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class PlasmaRound : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = 10;
			Item.shoot = Mod.Find<ModProjectile>("PlasmaRound").Type;
			Item.shootSpeed = 32f; 
			Item.ammo = Item.type; //
		}
	}
}
