using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class LaserCannon : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 333;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 38;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 6;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item92;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("LaserCannon").Type; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 16f;
		}
	}
}
