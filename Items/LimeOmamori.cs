using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Items
{
    public class AncientOmamori : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory(32, 32);
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 10, 0, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 90;
        }
        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (//incomingItem.type == ModContent.ItemType<AncientOmamori>()
                incomingItem.type == ModContent.ItemType<EarthOmamori>()
                || incomingItem.type == ModContent.ItemType<WaterOmamori>()
                || incomingItem.type == ModContent.ItemType<FlameOmamori>()
                || incomingItem.type == ModContent.ItemType<AirOmamori>()
                )
            {
                return false;
            }
            return true;
        }
        public override void AddRecipes()
        {
            Recipe ToLavaCharm = Recipe.Create(ItemID.LavaCharm, 1);
            ToLavaCharm.AddIngredient<AncientOmamori>();
            ToLavaCharm.AddIngredient(ItemID.HellstoneBar, 10);
            ToLavaCharm.AddIngredient(ItemID.Bone, 20);
            ToLavaCharm.AddTile(TileID.Hellforge);
            ToLavaCharm.Register();
        }
    }
    public class FlameOmamori : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory(32, 32);
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = ItemRarityID.Yellow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient<AncientOmamori>();
            recipe.AddIngredient(ItemID.ObsidianRose);
            recipe.AddIngredient(ItemID.LavaCharm);
            recipe.AddIngredient(ItemID.CursedFlame, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
            Recipe recipeAlt = CreateRecipe(1);
            recipeAlt.AddIngredient<AncientOmamori>();
            recipeAlt.AddIngredient(ItemID.MoltenSkullRose);
            recipeAlt.AddIngredient(ItemID.CursedFlame, 10);
            recipeAlt.AddIngredient(ItemID.SoulofFright, 10);
            recipeAlt.AddTile(TileID.Hellforge);
            recipeAlt.Register();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Increasing damage
            float HPPercent = player.statLife / 100 * player.statLifeMax2;
            float Modifier = 50 - (HPPercent / 100) - (MathF.Pow(HPPercent, 0.75f) * 2);
            if (Modifier > 0) player.GetDamage(DamageClass.Generic) += Modifier / 100;
            // Other stuff
            player.fireWalk = true;
            player.lavaMax += 420;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.OnFire3] = true;
            // player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 90;
        }
        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
                || incomingItem.type == ModContent.ItemType<EarthOmamori>()
                || incomingItem.type == ModContent.ItemType<WaterOmamori>()
                //|| incomingItem.type == ModContent.ItemType<FlameOmamori>()
                || incomingItem.type == ModContent.ItemType<AirOmamori>()
                )
            {
                return false;
            }
            return true;
        }
    }
    public class EarthOmamori : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory(32, 32);
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = ItemRarityID.Yellow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient<AncientOmamori>();
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.LihzahrdAltar);
            recipe.Register();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 6;
            if (player.statLife < player.statLifeMax2 / 4 * 3) { player.statDefense += 2; }
            if (player.statLife < player.statLifeMax2 / 2) { player.statDefense += 2; }
            if (player.statLife < player.statLifeMax2 / 4) { player.statDefense += 2; }
            player.noKnockback = true;
            player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 50;
        }
        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
                //|| incomingItem.type == ModContent.ItemType<EarthOmamori>()
                || incomingItem.type == ModContent.ItemType<WaterOmamori>()
                || incomingItem.type == ModContent.ItemType<FlameOmamori>()
                || incomingItem.type == ModContent.ItemType<AirOmamori>()
                )
            {
                return false;
            }
            return true;
        }
    }
    public class WaterOmamori : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory(32, 32);
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = ItemRarityID.Yellow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient<AncientOmamori>();
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddIngredient(ItemID.CrossNecklace);
            recipe.AddIngredient(ItemID.Ichor, 100);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 5; // 2.5 per second
            if (player.statLife < player.statLifeMax2 / 2) { player.lifeRegen += 5; }
            if (player.statLife < player.statLifeMax2 / 4) { player.lifeRegen += 5; }
            player.pStone = true;
            player.panic = true;
            player.longInvince = true;
            player.statLifeMax2 += 100;
            player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 80;
        }
        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
                || incomingItem.type == ModContent.ItemType<EarthOmamori>()
                //|| incomingItem.type == ModContent.ItemType<WaterOmamori>()
                || incomingItem.type == ModContent.ItemType<FlameOmamori>()
                || incomingItem.type == ModContent.ItemType<AirOmamori>()
                )
            {
                return false;
            }
            return true;
        }
    }
    public class AirOmamori : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory(32, 32);
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = ItemRarityID.Yellow;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.15f;
            player.noFallDmg = true;
            player.jumpBoost = true;
            player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 80;
            player.GetModPlayer<LimePlayerHooks>().AirOmamoriEquipped = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient<AncientOmamori>();
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddIngredient(ItemID.Feather, 100);
            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddTile(TileID.SkyMill);
            recipe.Register();
        }
        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
                || incomingItem.type == ModContent.ItemType<EarthOmamori>()
                || incomingItem.type == ModContent.ItemType<WaterOmamori>()
                || incomingItem.type == ModContent.ItemType<FlameOmamori>()
                //|| incomingItem.type == ModContent.ItemType<AirOmamori>()
                )
            {
                return false;
            }
            return true;
        }
    }
}
