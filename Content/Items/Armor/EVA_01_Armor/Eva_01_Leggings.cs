using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Transactions;
using LevisMod.Content.Items.Materials;
using System.Diagnostics.Contracts;

namespace LevisMod.Content.Items.Armor.EVA_01_Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Eva_01_Leggings : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(gold: 10000);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.12f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<MechanicalComponent>(7).
                AddTile(TileID.Anvils);
        }
    }
}
