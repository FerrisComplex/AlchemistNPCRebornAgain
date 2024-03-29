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

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class BanHammer : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Muramasa);
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 88;
			Item.crit = 100;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.hammer = 666;
			Item.value = 500000;
			Item.rare = 10;
            Item.knockBack = 10;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.expert = true;
			Item.scale = 1.5f;
		}
		
		public override void ModifyHitNPC(Terraria.Player player, NPC target, ref NPC.HitModifiers modifiers) 
		{
			if (target.boss == false)
			{
				if (target.type != NPCID.TheDestroyer && target.type != NPCID.TheDestroyerBody && target.type != NPCID.TheDestroyerTail && target.type != NPCID.MourningWood && target.type != NPCID.Pumpking && target.type != NPCID.Everscream && target.type != NPCID.IceQueen && target.type != NPCID.SantaNK1 && target.type != NPCID.Mothron)
				{
					target.buffImmune[Mod.Find<ModBuff>("Banned").Type] = false;
					target.AddBuff(Mod.Find<ModBuff>("Banned").Type, 60);
				}
			}
			if (target.type == NPCID.DungeonGuardian)
			{
				target.buffImmune[Mod.Find<ModBuff>("Banned").Type] = false;
				target.AddBuff(Mod.Find<ModBuff>("Banned").Type, 60);
			}
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
		}	
	}
}
