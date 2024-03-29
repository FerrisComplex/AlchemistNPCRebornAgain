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
	public class Sasscade : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(3389);
			Item.damage = 125;
			Item.shoot = ModContent.ProjectileType<Projectiles.SasscadeYoyo>();
			Item.knockBack = 4;
			Item.value = 5000000;
			Item.rare = 11;
			Item.shootSpeed = 12f;
			Item.useTime = 10;
			Item.useAnimation = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.counterWeight = 556 + Main.rand.Next(6);
        	player.yoyoGlove = true;
        	player.yoyoString = true;
		}
		
		public override void UpdateInventory(Player player)
		{
			player.counterWeight = 556 + Main.rand.Next(6);
        	player.yoyoGlove = true;
        	player.yoyoString = true;
		}
		
		public override void HoldItem(Player player)
		{
			player.counterWeight = 556 + Main.rand.Next(6);
        	player.yoyoGlove = true;
        	player.yoyoString = true;
		}
	}
}
