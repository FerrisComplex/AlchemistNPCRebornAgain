using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class CurseofArachna : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.crit = 10;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.value = 50000;
			Item.rare = 3;
            Item.knockBack = 4;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.5f;
		}
		
		public override void OnHitNPC(Terraria.Player player, NPC target, NPC.HitInfo hit, int damage)
		{
			if (target.HasBuff(Mod.Find<ModBuff>("Infested").Type))
			{
				Vector2 vel2 = new Vector2(-1, -1);
				vel2 *= 3f;
				int p1 = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X-30, target.position.Y-30, vel2.X, vel2.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p1].usesLocalNPCImmunity = true;
				Main.projectile[p1].localNPCHitCooldown = 1;
				Vector2 vel4 = new Vector2(1, -1);
				vel4 *= 3f;
				int p2 = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X+30, target.position.Y-30, vel4.X, vel4.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p2].usesLocalNPCImmunity = true;
				Main.projectile[p2].localNPCHitCooldown = 1;
				Vector2 vel6 = new Vector2(0, -1);
				vel6 *= 3f;
				int p3 = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X-15, target.position.Y-30, vel6.X, vel6.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p3].usesLocalNPCImmunity = true;
				Main.projectile[p3].localNPCHitCooldown = 1;
				Vector2 vel61 = new Vector2(0, -1);
				vel61 *= 3f;
				int p31 = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X+15, target.position.Y-30, vel61.X, vel61.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p31].usesLocalNPCImmunity = true;
				Main.projectile[p31].localNPCHitCooldown = 1;
				Vector2 vel7 = new Vector2(-1, 0);
				vel7 *= 3f;
				int p4 = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X-30, target.position.Y, vel7.X, vel7.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p4].usesLocalNPCImmunity = true;
				Main.projectile[p4].localNPCHitCooldown = 1;
				Vector2 vel8 = new Vector2(1, 0);
				vel8 *= 3f;
				int p5 = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X+30, target.position.Y, vel8.X, vel8.Y, 379 ,damage/2, 0, Main.myPlayer);
				Main.projectile[p5].usesLocalNPCImmunity = true;
				Main.projectile[p5].localNPCHitCooldown = 1;
				player.ClearBuff(BuffType<Buffs.Infested>());
			}
			else target.AddBuff(Mod.Find<ModBuff>("Infested").Type, 180);
		}
		
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.SpiderFang, 12);
            recipe.AddIngredient(Mod.Find<ModItem>("SwordofArachna").Type);
			recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}
