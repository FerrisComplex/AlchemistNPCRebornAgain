using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.Utilities;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Hive : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[Item.type] = true;
        }

		public override void SetDefaults()
		{
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.damage = 52;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.rare = 11;
			Item.width = 40;
			Item.height = 40;
			Item.UseSound = SoundID.Item20;
			Item.useStyle = 5;
			Item.shootSpeed = 11f; 
			Item.knockBack = 4;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("Hive").Type;
		}
	}
}
