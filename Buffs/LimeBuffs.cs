using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;

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

				// Setup the death messages
				int deathMessage = Main.rand.Next(5);
				string key = "Mods.LimeAccessories.DeathMessages.RemovedEarRing_" + deathMessage.ToString();
				NetworkText subject = NetworkText.FromLiteral(player.name);

				PlayerDeathReason RemovedEarRingReason = PlayerDeathReason.ByCustomReason(NetworkText.FromKey(key, subject));

				player.KillMe(RemovedEarRingReason, player.statLifeMax2, 0);
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

				// Setup the death messages
				int deathMessage = Main.rand.Next(7);
				string key = "Mods.LimeAccessories.DeathMessages.RemovedEarRing_" + deathMessage.ToString();
				NetworkText subject = NetworkText.FromLiteral(player.name);

				PlayerDeathReason RemovedEarRingReason = PlayerDeathReason.ByCustomReason(NetworkText.FromKey(key, subject));

				player.Hurt(RemovedEarRingReason, (player.statLifeMax2 / 4) * 3, 0, dodgeable: false, armorPenetration: 1000, knockback: 0);
				return;
			}
			player.GetDamage<MeleeDamageClass>() += 0.20f;
			player.GetDamage<GenericDamageClass>() += 0.05f;
			player.statDefense += 10;
			player.GetModPlayer<LimePlayerHooks>().ForgottenEarringCharge = 0;
		}
		public override bool RightClick(int buffIndex)
		{
			return false;
		}
	}
}
