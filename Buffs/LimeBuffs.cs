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

	// Used by forgotten earring to stun the player and make them immune for a short time
	public class Staggered : ModBuff
	{
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LimePlayerHooks>().ForgottenEarringGracePeriod += 1;
			if (player.GetModPlayer<LimePlayerHooks>().ForgottenEarringGracePeriod > 5)
			{
				player.DelBuff(buffIndex);
				// Its impossible to add custom messages as the game will refuse to load it into localization
				player.KillMe(Terraria.DataStructures.PlayerDeathReason.LegacyDefault(), player.statLifeMax, 0);
				buffIndex -= 1;
				return;
			}
			player.cursed = true;
			player.immune = true;
			player.GetDamage<GenericDamageClass>() -= 1f;
			player.moveSpeed = 0.1f;
			player.maxFallSpeed = 0.1f;
			player.blind = true;
			player.blockExtraJumps = true;
			player.GetModPlayer<LimePlayerHooks>().LastStandStaggered = true;
		}
		public override bool RightClick(int buffIndex)
		{
			return false;
		}
	}
	public class LastStand : ModBuff
	{
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LimePlayerHooks>().ForgottenEarringGracePeriod += 1;
			if (player.GetModPlayer<LimePlayerHooks>().ForgottenEarringGracePeriod > 5)
			{
				player.DelBuff(buffIndex);
				// Its impossible to add custom messages as the game will refuse to load it into localization
				player.Hurt(Terraria.DataStructures.PlayerDeathReason.LegacyDefault(), player.statLifeMax / 2, 0, dodgeable: false, armorPenetration: 100);
				buffIndex -= 1;
				return;
			}
			player.GetDamage<MeleeDamageClass>() += 0.20f;
			player.GetDamage<GenericDamageClass>() += 0.05f;
			player.statDefense += 10;
			player.GetModPlayer<LimePlayerHooks>().ForgottenEarringCharge = 0;
		}
	}
}
