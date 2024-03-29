using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class SymbolOfPain : ModItem
	{

		public override void SetDefaults()
		{
			Item.consumable = true;
			Item.maxStack = 99;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = 2;
			Item.noMelee = true;
			Item.rare = 11;
			Item.mana = 300;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("SymbolOfPain").Type;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.UseSound = SoundID.NPCDeath59;
			Item.mana = 200;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 vel1 = new Vector2(-0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X, player.position.Y, vel1.X, vel1.Y, Mod.Find<ModProjectile>("SymbolOfPainVision").Type, Item.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X, player.position.Y, vel1.X, vel1.Y, Mod.Find<ModProjectile>("SymbolOfPain").Type, Item.damage, 0, Main.myPlayer);
			player.AddBuff(Mod.Find<ModBuff>("Exhausted").Type, 3600); 
			return false;
		}
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(Mod.Find<ModBuff>("Exhausted").Type) && !player.HasBuff(Mod.Find<ModBuff>("ExecutionersEyes").Type) && !player.HasBuff(Mod.Find<ModBuff>("CloakOfFear").Type))
			{
				return true;
			}
			return false;
		}
	}
}
