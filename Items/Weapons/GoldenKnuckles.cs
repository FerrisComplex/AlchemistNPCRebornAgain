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
using AlchemistNPCRebornAgain;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class GoldenKnuckles : ModItem
	{

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 666;
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 4;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 0.5f;
		}
		
		public override void ModifyHitNPC(Terraria.Player player, NPC target, ref NPC.HitModifiers modifiers)
		{
			modifiers.FinalDamage *= 3;
		}
		
		public override void OnHitNPC(Terraria.Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("Patience").Type, 120);
		}
	}
}
