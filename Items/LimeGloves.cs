using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Items
{
	[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
	public class Fetters : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(36, 36);
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.handOffSlot = 3;
			Item.handOnSlot = 8;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.Shackle, 2);
			recipe.AddIngredient(ItemID.Chain, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe ToMagicCuffs = Recipe.Create(ItemID.MagicCuffs, 1);
			ToMagicCuffs.AddIngredient<Fetters>();
			ToMagicCuffs.AddIngredient(ItemID.ManaRegenerationBand, 1);
			ToMagicCuffs.AddTile(TileID.TinkerersWorkbench);
			ToMagicCuffs.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 3;
		}
	}
}