using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
    public class MagicBullet : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SniperRifle);
            Item.damage = 500;
            Item.autoReuse = true;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = Mod.Find<ModProjectile>("MB").Type;
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }

        public override bool CanUseItem(Player player)
        {
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
            {
                Item.damage = 600;
                Item.useTime = 10;
                Item.useAnimation = 10;
            }
            else
            {
                Item.damage = 500;
                Item.useTime = 15;
                Item.useAnimation = 15;
            }

            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SniperRifle);
            recipe.AddIngredient(ItemID.Ectoplasm, 30);
            recipe.AddIngredient(ItemID.ShroomiteBar, 15);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddTile<Tiles.WingoftheWorld>();
            recipe.Register();
        }
    }
}
