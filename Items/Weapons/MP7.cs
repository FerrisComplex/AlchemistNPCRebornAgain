using AlchemistNPCRebornAgain.Extensions;
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
	public class MP7 : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = 5;
			Item.autoReuse = true;
			Item.useAnimation = 2;
			Item.useTime = 2;
			Item.width = 72;
			Item.height = 34;
			Item.shoot = 10;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.damage = 10;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.rare = 11;
			Item.knockBack = 3;
			Item.DamageType = DamageClass.Ranged;
		}
		
		public override void UpdateInventory(Player player)
		{
			if (!AlchemistNPCRebornWorld.foundMP7)
			{
				AlchemistNPCRebornWorld.foundMP7 = true;
				if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			}
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return Mod.FindPrefixId("Shining");
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .88;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 vector = player.MountedCenter;
			int numberProjectiles = 1 + Main.rand.Next(3); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(3));
				float scale = 1f - (Main.rand.NextFloat() * .4f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, Item.knockBack, player.whoAmI);
			}
			return false;
		}
	}
}
