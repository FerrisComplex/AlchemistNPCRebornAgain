using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
    public class MemerRiposte : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.value = 1000000;
            Item.rare = 11;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.15f;
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AutoinjectorMK2 == false)
            {
                player.GetCritChance(DamageClass.Generic) -= 25;
                player.GetCritChance(DamageClass.Magic) -= 25;
                player.GetCritChance(DamageClass.Ranged) -= 25;
                player.GetCritChance(DamageClass.Throwing) -= 25;
            }
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AutoinjectorMK2)
            {
                player.GetCritChance(DamageClass.Generic) -= 15;
                player.GetCritChance(DamageClass.Magic) -= 15;
                player.GetCritChance(DamageClass.Ranged) -= 15;
                player.GetCritChance(DamageClass.Throwing) -= 15;
            }
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).MemersRiposte = true;
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, -25);
                if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AutoinjectorMK2) Calamity.Call("AddRogueCrit", player, 10);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "KnucklesUgandaDoll", 1);
            recipe.AddIngredient(null, "BanHammer", 1);
            recipe.AddIngredient(null, "PinkGuyHead", 1);
            recipe.AddIngredient(null, "PinkGuyBody", 1);
            recipe.AddIngredient(null, "PinkGuyLegs", 1);
            recipe.AddTile(null, "MateriaTransmutator");
            recipe.Register();
        }
    }
}
