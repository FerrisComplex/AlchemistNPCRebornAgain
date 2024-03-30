using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCRebornAgain;
using AlchemistNPCRebornAgain.Extensions;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Stormbreaker : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MonkStaffT3);
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 110;
			Item.crit = 21;
			Item.width = 50;
			Item.height = 40;
			Item.hammer = 600;
			Item.axe = 120;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 10;
			Item.expert = true;
			Item.scale = 1.5f;
			Item.shoot = Mod.Find<ModProjectile>("StormbreakerSwing").Type;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.shoot = Mod.Find<ModProjectile>("StormbreakerSwing").Type;
			}
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.damage = 150;
				Item.shootSpeed = 24f;
				Item.shoot = Mod.Find<ModProjectile>("Stormbreaker").Type;
				Item.noMelee = true;
				Item.noUseGraphic = true;
			}
			
			return base.CanUseItem(player);
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
			Item.consumable = true;
            Item.NewItem(((Entity) player).GetSource_FromThis((string) null),(int)player.position.X, (int)player.position.Y, player.width, player.height, Mod.FindItem("StormbreakerThrown").Type, 1, false, 82);
        }
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.NimbusRod);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:AnyLunarHamaxe");
			recipe.AddIngredient(ItemID.MoltenHamaxe);
			recipe.AddIngredient(ItemID.MeteorHamaxe);
			recipe.AddIngredient(ItemID.LivingWoodWand);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
