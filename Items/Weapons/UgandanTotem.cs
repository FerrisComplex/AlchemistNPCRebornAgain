using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class UgandanTotem : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 12345;
			Item.mana = 200;
			Item.width = 28;
			Item.height = 22;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(15, 0, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = false;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Summon;
			Item.shoot = ModContent.ProjectileType<Projectiles.Minions.UgandanWarrior>();
			Item.shootSpeed = 16f;
			Item.buffType = ModContent.BuffType<Buffs.UgandanWarrior>();
			Item.buffTime = 3600;
			
		}

		//public override void UseStyle(Player player)
		//{
		//	if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		//	{
		//		player.AddBuff(item.buffType, 3600, true);
		//	}
		//}
		
		//public override bool? UseItem(Player player)
		//{
		//	if (player.altFunctionUse == 2)
		//	{
		//		player.MinionNPCTargetAim();
		//	}
		//	return base.UseItem(player);
		//}

		//public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		//{
		//	for (int l = 0; l < Main.projectile.Length; l++)
		//	{
		//		Projectile proj = Main.projectile[l];
		//		if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
		//		{
		//			proj.active = false;
		//		}
		//	}
		//	return player.altFunctionUse != 2;
		//}
	}
}
