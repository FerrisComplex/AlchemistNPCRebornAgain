using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.QuestFishes
{
	public class MosesFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			Language.GetOrRegister(Mod.GetLocalizationKey("MosesDesc1"), () => "You heard about Moses, don't you? Then hear what I found in one old fairy tale book. There said that Moses still returning to our world even after his life. And he is prefering Desert pools. Long story short, I want you to get me this fish! It could be a really hard catch, but the reward can be great too!");
			Language.GetOrRegister(Mod.GetLocalizationKey("MosesCatch1"), () => "Caught in Desert.");
            
		}

		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 42;
			Item.height = 42;
			Item.uniqueStack = true;
			Item.rare = -11;		//The rarity of -11 gives the Item orange color
		}

		public override void UpdateInventory(Player player)
		{
		player.GetModPlayer<AlchemistNPCRebornPlayer>().Manna = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                return true;
			
			return false;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = Language.GetTextValue(Mod.GetLocalizationKey("MosesDesc1"));
			catchLocation = Language.GetTextValue(Mod.GetLocalizationKey("MosesCatch1"));
		}
	}
}
