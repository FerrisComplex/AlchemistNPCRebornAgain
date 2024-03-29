using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class LastTantrum : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 22222;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 92;
			Item.height = 40;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 6;
			Item.value = 5000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 32f;
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 59;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = Mod.Find<ModProjectile>("LastTantrum").Type;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-10,10), position.Y+3+Main.rand.Next(-3,3), velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+Main.rand.Next(-10,10), position.Y-3+Main.rand.Next(-3,3), velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
			return false;
		}
	}
}
