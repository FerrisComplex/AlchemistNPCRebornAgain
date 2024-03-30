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

namespace AlchemistNPCRebornAgain.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ReverberationHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Language.GetOrRegister(Mod.GetLocalizationKey("ReverberationSetBonus"), () => "Forms shield around weilder. Shield reduces all incoming damage by 15%\nSpeeds up all arrows\nImproves ''Reverberation'' repeater:\nLowers manacost for additional projectiles\nMakes repeater shoot multiple projectiles\nBoosts Druidic type damage and critical strike chance by 20%");
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 100000;
            Item.rare = 9;
            Item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.2f;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.FindItem("ReverberationBody").Type && legs.type == Mod.FindItem("ReverberationLegs").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            string ReverberationSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("ReverberationSetBonus"));
            player.setBonus = ReverberationSetBonus;
            player.magicQuiver = true;
            player.AddBuff(Mod.Find<ModBuff>("ShieldofSpring").Type, 300);
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).RevSet = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.DynastyWood, 100);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(null, "WingoftheWorld");
            recipe.Register();
        }
    }
}
