using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class QuantumDestabilizer : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 600;
			Item.DamageType = DamageClass.Ranged;
			Item.channel = true;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 20;   
			Item.knockBack = 10;			
			Item.shoot = ModContent.ProjectileType<Projectiles.QuantumDestabilizer>();
			Item.useAmmo = ModContent.ItemType<EnergyCell>();
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, 1);
		}
	}
}
