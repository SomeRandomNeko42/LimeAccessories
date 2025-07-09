using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Buffs
{
	public class SpiritRegen : ModBuff
	{
		public override void Update(Player player, ref int buffIndex)
		{
			player.Heal(1);
		}
	}
	public class SpiritGuard : ModBuff
	{
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.defense *= 2;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense *= 2;
		}
	}
	public class SpiritStrike : ModBuff
	{
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage<SummonDamageClass>() += 0.25f;
		}
	}
}
