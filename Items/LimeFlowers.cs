using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Items
{
	[AutoloadEquip(EquipType.Face)]
	public class SearedFlower : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(30, 42);
			Item.hasVanityEffects = true;
			Item.maxStack = 1;
			Item.rare = ItemRarityID.LightPurple;
			Item.value = Item.sellPrice(0, 16, 0, 0);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.ArcaneFlower);
			recipe.AddIngredient(ItemID.ObsidianRose);
			recipe.AddIngredient(ItemID.MagmaStone);
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddIngredient(ItemID.CursedFlame, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaFlower = true;
			player.aggro -= 400;
			player.manaCost -= 0.1f;
			player.buffImmune[BuffID.OnFire3] = true;
			player.buffImmune[BuffID.OnFire] = true;
			player.lavaRose = true;
			player.fireWalk = true;
			player.GetDamage<MagicDamageClass>() += 0.1f;
			player.GetModPlayer<LimePlayerHooks>().SearedFlowerEquipped = true;
		}
	}
}