using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.PaleDamageClass
{
	// This class handles everything for our custom damage class
	// Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
	public abstract class PaleDamageItem : ModItem
	{
		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
		}

		// By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
		// We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			// all vanilla damage types must be false for custom damage types to work
			//NOT FIXED Item.DamageType = DamageClass.Melee;
			//NOT FIXED Item.DamageType = DamageClass.Ranged;
			//NOT FIXED Item.DamageType = DamageClass.Magic;
			//NOT FIXED Item.DamageType = DamageClass.Summon;
		}

		// Pls fix it ///As a modder, you could also opt to make these overrides also sealed. Up to the modder
		//public override void ModifyWeaponDamage(Player player, ref StatModifier damage) {
		//	add += PaleDamagePlayer.ModPlayer(player).paleDamageAdd;
		//	mult *= PaleDamagePlayer.ModPlayer(player).paleDamageMult;
		//}

		public override void ModifyWeaponKnockback(Player player, ref StatModifier knockback)
		{
			// Adds knockback bonuses
			knockback = knockback + PaleDamagePlayer.ModPlayer(player).paleKnockback;
		}

		public override void ModifyWeaponCrit(Player player, ref float crit)
		{
			// Adds crit bonuses
			crit = crit + PaleDamagePlayer.ModPlayer(player).paleCrit;
		}

		// Because we want the damage tooltip to show our custom damage, we need to modify it
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			// Get the vanilla damage tooltip
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
			if (tt != null)
			{
				// We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what langauge the player is using)
				// So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
				string[] splitText = tt.Text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
                // Change the tooltip text
				tt.Text = damageValue + " [c/00FFFF:pale] " + damageWord;
			}
		}
	}
}
