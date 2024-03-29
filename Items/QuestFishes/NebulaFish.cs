using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.QuestFishes
{
	public class NebulaFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			Language.GetOrRegister(Mod.GetLocalizationKey("NebulaDesc1"), () => "There's this unearthly looking fish... probably looks that way because it's from celestial bodies of water. Probably tastes heavenly too, so go get it for me!");
			Language.GetOrRegister(Mod.GetLocalizationKey("NebulaCatch1"), () => "Caught nearby Nebula Pillar.");
			
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
		player.GetModPlayer<AlchemistNPCRebornPlayer>().NebulaFish = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			if (Main.hardMode && NPC.downedAncientCultist)
			{
				return true;
			}
			return false;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = Language.GetTextValue(Mod.GetLocalizationKey("NebulaDesc1"));
			catchLocation = Language.GetTextValue(Mod.GetLocalizationKey("NebulaCatch1"));
		}
	}
}
