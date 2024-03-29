using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class MagicWand : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 135;
			Item.DamageType = DamageClass.Magic;
			Item.channel = true;                            //Channel so that you can held the weapon [Important]
			Item.mana = 15;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 20;   
			Item.knockBack = 1;			
			Item.shoot = ModContent.ProjectileType<Projectiles.MagicWand>();
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}
	}
}
