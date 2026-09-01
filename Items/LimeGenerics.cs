using LimeAccessories.Buffs;
using LimeAccessories.Common.Config;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Items
{
	public class PrisonScroll : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(0, 5, 0, 0);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 2;
			player.GetDamage<SummonDamageClass>() += 0.2f;
			player.GetKnockback<SummonDamageClass>() += 0.2f;
			player.GetModPlayer<LimePlayerHooks>().PrisonScrollEquipped = true;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (ModContent.GetInstance<LimeClientConfig>().DebugMode)
			{
				int index = tooltips.Count - 1;
				ref string text = ref tooltips[index].Text;
				text = Main.LocalPlayer.GetModPlayer<LimePlayerHooks>().PrisonScrollActiveness.ToString();
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.PapyrusScarab);
			recipe.AddIngredient<Fetters>();
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.Ectoplasm, 50);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (incomingItem.type == ModContent.ItemType<UnsealedScroll>()) { return false; }
			return true;
		}
	}
	public class UnsealedScroll : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(42, 42);
			Item.rare = ItemRarityID.Purple;
			Item.value = Item.sellPrice(0, 15, 0, 0);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 3;
			player.maxTurrets += 1;
			player.GetDamage<SummonDamageClass>() += 0.3f;
			player.GetKnockback<SummonDamageClass>() += 0.2f;
			player.GetModPlayer<LimePlayerHooks>().PrisonScrollEquipped = true;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (ModContent.GetInstance<LimeClientConfig>().DebugMode)
			{
				int index = tooltips.Count - 1;
				ref string text = ref tooltips[index].Text;
				text = Main.LocalPlayer.GetModPlayer<LimePlayerHooks>().PrisonScrollActiveness.ToString();
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient<PrisonScroll>();
			recipe.AddIngredient(ItemID.PygmyNecklace);
			recipe.AddIngredient(ItemID.Ectoplasm, 50);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddIngredient(ItemID.ApprenticeScarf, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (incomingItem.type == ModContent.ItemType<PrisonScroll>()) { return false; }
			return true;
		}
	}

	public class ForgottenEarring : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 36);
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<LimePlayerHooks>().ForgottenEarringEquipped = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int index = tooltips.Count - 2;
			ref string text = ref tooltips[index].Text;
			text = tooltips[index].Text.Replace("0", MathF.Round(Main.LocalPlayer.GetModPlayer<LimePlayerHooks>().ForgottenEarringCharge, 1).ToString());
			index = tooltips.Count - 3;
			if (!(Main.LocalPlayer.HasBuff<Staggered>() || Main.LocalPlayer.HasBuff<LastStand>()))
			{
				tooltips[index].Hide();
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddCondition(Condition.InGraveyard);
			recipe.AddIngredient<Fetters>();
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
