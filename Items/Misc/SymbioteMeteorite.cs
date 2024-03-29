using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Misc
{
    public class SymbioteMeteorite : ModItem
    {
        public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 36;
			Item.maxStack = 1;
			Item.value = 1000000;
			Item.rare = -12;
		}
    }
}
