using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain
{
    public class ReversivityCoinTier6Data : CustomCurrencySingleCoin
    {
        public Color ReversivityCoinTier6TextColor = Color.Orange;
        public Mod mod;
        public ReversivityCoinTier6Data(Mod mod, int coinItemID, long currencyCap) : base(coinItemID, currencyCap)
        {
            this.mod = mod;
        }
 
        public override void GetPriceText(string[] lines, ref int currentLine, long price)
        {
            Color color = ReversivityCoinTier6TextColor * ((float)Main.mouseTextColor / 255f);
            lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
                {
                    color.R,
                    color.G,
                    color.B,
                    Language.GetTextValue("LegacyTooltip.50"),
                    price,
                    Language.GetTextValue(mod.GetLocalizationKey("Items.ReversivityCoinTier6.DisplayName"))
                });
        }
    }
}
