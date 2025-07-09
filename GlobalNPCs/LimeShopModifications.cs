using LimeAccessories.Items;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.GlobalNPCs
{
	public class LimeTravellingMerchant: GlobalNPC
	{
		public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
		{
			return entity.type == NPCID.TravellingMerchant;
		}

		public override void SetupTravelShop(int[] shop, ref int nextSlot)
		{
			int omamori = ModContent.ItemType<AncientOmamori>();
			if (!shop.Contains(omamori) && Main._rand.NextBool(1, 10))
			{
				shop[nextSlot] = omamori;
				nextSlot++;
			}
		}
	}
	public class LimeSkeletonMerchant: GlobalNPC
	{
		public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
		{
			return entity.type == NPCID.SkeletonMerchant;
		}
		public override void ModifyShop(NPCShop shop)
		{
			shop.Add(ModContent.ItemType<AncientOmamori>(), [Condition.Hardmode, Condition.MoonPhasesEven]);
		}
	}
}
