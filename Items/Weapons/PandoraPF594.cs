using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class PandoraPF594 : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SnowmanCannon);
			Item.noUseGraphic = true;
			
			Item.damage = 3333;
			Item.crit = 100;
			Item.width = 56;
			Item.height = 30;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = -12;
			Item.autoReuse = false;
			Item.shootSpeed = 32f;
			Item.shoot = ProjectileID.VortexBeaterRocket;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.useAmmo = 0;
		}
		
		public override void HoldItem(Player player)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).PH = true;
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge = 500;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse != 2)
			{
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X+30, player.position.Y+30, vel1.X, vel1.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X-30, player.position.Y-30, vel2.X, vel2.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X-30, player.position.Y+30, vel3.X, vel3.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X+30, player.position.Y-30, vel4.X, vel4.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X, player.position.Y+30, vel5.X, vel5.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X, player.position.Y-30, vel6.X, vel6.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X-30, player.position.Y, vel7.X, vel7.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 8f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X+30, player.position.Y, vel8.X, vel8.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).DisasterGauge = 0;
			Item.SetDefaults(Mod.FindItem("Pandora").Type);
			}
			if (player.altFunctionUse == 2)
			{
			return false;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				Item.SetDefaults(Mod.FindItem("PandoraPF666").Type);
				return true;
			}
			return false;
		}
	}
}
