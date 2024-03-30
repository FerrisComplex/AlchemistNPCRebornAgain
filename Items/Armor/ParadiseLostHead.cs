using System.Collections.Generic;
using System.Linq;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain.Items.PaleDamageClass;

namespace AlchemistNPCRebornAgain.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ParadiseLostHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Language.GetOrRegister(Mod.GetLocalizationKey("ParadiseLostSetBonus"), () => "Increases all damage by 35% and adds 25% to critical strike chance"
                                                                                         + "\nIncreases damage dealt by EGO weapons"
                                                                                         + "\nChanges would be seen after first usage of weapons"
                                                                                         + "\nIf hit taken deals less than 100 damage, then it will be nullified.");

            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1000000;
            Item.rare = 11;
            Item.defense = 35;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 100;
            player.GetAttackSpeed(DamageClass.Melee) += 0.33f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.FindItem("ParadiseLostBody").Type && legs.type == Mod.FindItem("ParadiseLostLegs").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            string ParadiseLostSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("ParadiseLostSetBonus"));
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost = true;
            player.setBonus = ParadiseLostSetBonus;
            player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 60);
            player.GetDamage(DamageClass.Generic) += 0.35f;
            player.GetCritChance(DamageClass.Generic) += 25;
            player.GetCritChance(DamageClass.Magic) += 25;
            player.GetCritChance(DamageClass.Ranged) += 25;
            player.GetCritChance(DamageClass.Throwing) += 25;
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 25);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "TwilightCrown");
            recipe.AddIngredient(null, "ChromaticCrystal", 5);
            recipe.AddIngredient(null, "SunkroveraCrystal", 5);
            recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
            recipe.AddIngredient(null, "EmagledFragmentation", 100);
            recipe.AddTile(null, "MateriaTransmutator");
            recipe.Register();
        }
    }
}
