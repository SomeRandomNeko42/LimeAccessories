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
		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense *= 2;
		}
	}
}
