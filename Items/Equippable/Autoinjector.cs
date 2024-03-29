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
    public class Autoinjector : ModItem
    {

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.stack = 1;
            Item.width = 26;
            Item.height = 26;
            Item.value = 1000000;
            Item.rare = 11;
            Item.accessory = true;
            Item.defense = 4;
            Item.lifeRegen = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.1f;
            player.GetCritChance(DamageClass.Generic) += 8;
            player.GetCritChance(DamageClass.Ranged) += 8;
            player.GetCritChance(DamageClass.Magic) += 8;
            player.GetCritChance(DamageClass.Throwing) += 8;
            player.pStone = true;
            player.longInvince = true;
            player.AddBuff(Mod.Find<ModBuff>("UniversalComb").Type, 2);
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 8);
            }
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<AlchemistNPCRebornPlayer>().KeepBuffs < 1;
        }

        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<AlchemistNPCRebornPlayer>().KeepBuffs += 1;
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "AlchemistNecklace", 1);
            recipe.AddIngredient(null, "TankCombination", 30);
            recipe.AddIngredient(null, "RangerCombination", 30);
            recipe.AddIngredient(null, "MageCombination", 30);
            recipe.AddIngredient(null, "SummonerCombination", 30);
            recipe.AddRecipeGroup("AlchemistNPCRebornAgain:Tier3Bar", 25);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.AddIngredient(ItemID.ShroomiteBar, 25);
            recipe.AddIngredient(ItemID.SpectreBar, 25);
            recipe.AddIngredient(null, "AlchemicalBundle", 1);
            recipe.AddIngredient(ItemID.HerculesBeetle, 1);
            recipe.AddIngredient(ItemID.DestroyerEmblem, 1);
            recipe.AddIngredient(null, "MasksBundle", 1);
            recipe.AddTile(null, "MateriaTransmutator");
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(null, "WatcherAmulet", 1);
            recipe.AddRecipeGroup("AlchemistNPCRebornAgain:Tier3Bar", 25);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.AddIngredient(ItemID.ShroomiteBar, 25);
            recipe.AddIngredient(ItemID.SpectreBar, 25);
            recipe.AddIngredient(ItemID.HerculesBeetle, 1);
            recipe.AddIngredient(ItemID.DestroyerEmblem, 1);
            recipe.AddIngredient(null, "TankCombination", 30);
            recipe.AddIngredient(null, "RangerCombination", 30);
            recipe.AddIngredient(null, "MageCombination", 30);
            recipe.AddIngredient(null, "SummonerCombination", 30);
            recipe.AddIngredient(null, "MasksBundle", 1);
            recipe.AddTile(null, "MateriaTransmutator");
            recipe.Register();
        }
    }
}
