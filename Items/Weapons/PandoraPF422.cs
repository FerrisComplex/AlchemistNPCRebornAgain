using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class PandoraPF422 : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PiranhaGun);
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 88;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.rare = 11;
			Item.knockBack = 8;
			Item.shoot = ModContent.ProjectileType<Projectiles.PF422>();
		}
		
		//public override bool Shoot(Player player, EntitySource_ItemUse source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		//{
		//	type = mod.ProjectileType("PF422");
		//	return true;
		//}
	}
}
