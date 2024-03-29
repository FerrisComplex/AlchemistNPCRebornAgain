using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.Utilities;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class TomeOfOrder : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.UseSound = SoundID.Item9;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.autoReuse = true;
			Item.useTime = 12;
			Item.useAnimation = 36;
			Item.shoot = Mod.Find<ModProjectile>("Bolt").Type;
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 83;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				Item.damage = 31;
			}
			if (NPC.downedBoss1)
			{
				Item.damage = 32;
			}
			if (NPC.downedBoss2)
			{
				Item.damage = 35;
			}
			if (NPC.downedQueenBee)
			{
				Item.damage = 38;
			}
			if (NPC.downedBoss3)
			{
				Item.damage = 41;
			}
			if (Main.hardMode)
			{
				Item.damage = 49;
				Item.useTime = 10;
				Item.useAnimation = 30;
			}
			if (NPC.downedMechBossAny)
			{
				Item.damage = 56;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				Item.damage = 62;
				Item.useTime = 8;
				Item.useAnimation = 24;
			}
			if (NPC.downedPlantBoss)
			{
				Item.damage = 72;
			}
			if (NPC.downedGolemBoss)
			{
				Item.damage = 80;
				Item.useTime = 7;
				Item.useAnimation = 21;
			}
			if (NPC.downedFishron)
			{
				Item.damage = 90;
			}
			if (NPC.downedAncientCultist)
			{
				Item.damage = 100;
			}
			if (NPC.downedMoonlord)
			{
				Item.damage = 110;
			}
			if (player.altFunctionUse == 2)
			{
				for(int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].type == Mod.Find<ModProjectile>("Bolt").Type)
					{
						Main.projectile[i].damage *= 2;
						Main.projectile[i].Kill();
					}
				}
				return false;
			}
			return true;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
	}
}
