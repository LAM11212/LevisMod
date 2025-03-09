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

namespace LevisMod.Content.Items.Armor.EVA_01_Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Eva_01_Breastplate : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(gold: 10000);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage<GenericDamageClass>() += 0.03f;
            player.GetCritChance<GenericDamageClass>() += 3;

        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<MechanicalComponent>(11);
        }
    }
}
