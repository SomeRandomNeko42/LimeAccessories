using LimeAccessories.Common.Config;
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
			Item.rare = ItemRarityID.Purple;
			Item.value = Item.sellPrice(0, 5, 0, 0);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 2;
			player.GetDamage<SummonDamageClass>() += 0.2f;
			player.GetKnockback<SummonDamageClass>() += 0.2f;
			player.GetModPlayer<LimePlayerHooks>().PrisionScrollEquipped = true;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (ModContent.GetInstance<LimeClientConfig>().DebugMode)
			{
				int index = tooltips.Count - 1;
				ref string text = ref tooltips[index].Text;
				text = Main.LocalPlayer.GetModPlayer<LimePlayerHooks>().PrisionScrollActiveness.ToString();
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
			recipe.AddCondition(Condition.InGraveyard);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}
