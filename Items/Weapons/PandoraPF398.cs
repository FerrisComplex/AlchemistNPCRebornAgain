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
	public class PandoraPF398 : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 250;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.channel = true;
			Item.rare = -12;
			Item.width = 18;
			Item.height = 14;
			Item.useTime = 40;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 40;   
			Item.knockBack = 10;			
			Item.shoot = Mod.Find<ModProjectile>("PF398").Type;
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}

		public override void HoldItem(Player player)
		{
		player.GetModPlayer<AlchemistNPCRebornPlayer>().PH = true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().DisasterGauge += 10;
			if (player.altFunctionUse != 2)
			{
			return true;
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
			if (player.altFunctionUse == 2 && player.GetModPlayer<AlchemistNPCRebornPlayer>().DisasterGauge < 500)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && player.GetModPlayer<AlchemistNPCRebornPlayer>().DisasterGauge >= 500)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().DisasterGauge = 0;
				Item.SetDefaults(Mod.FindItem("PandoraPF594").Type);
			}
			return false;
		}
	}
}
