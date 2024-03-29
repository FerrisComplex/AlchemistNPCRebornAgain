using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.QuestFishes
{
	public class MutantFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			Language.GetOrRegister(Mod.GetLocalizationKey("MutantDesc1"), () => "As I heard, sometimes sharks can't grow big enough to be counted as actual sharks. Then they should be called ''Mini Sharks''. And now you are gonna get me one of these!");
			Language.GetOrRegister(Mod.GetLocalizationKey("MutantCatch1"), () => "Caught anywhere.");
            
		}

		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 26;
			Item.height = 26;
			Item.uniqueStack = true;
			Item.rare = -11;		//The rarity of -11 gives the Item orange color
		}

		public override void UpdateInventory(Player player)
		{
		player.GetModPlayer<AlchemistNPCRebornPlayer>().DriedFish = true;
		}

		public override bool IsQuestFish() => true;

		public override bool IsAnglerQuestAvailable() => Main.hardMode;

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = Language.GetTextValue(Mod.GetLocalizationKey("MutantDesc1"));
			catchLocation = Language.GetTextValue(Mod.GetLocalizationKey("MutantCatch1"));
		}
	}
}
