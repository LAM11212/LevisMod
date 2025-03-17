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
    [AutoloadEquip(EquipType.Head)]
    public class Eva_01_Helmet : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(gold: 10000);
            Item.defense = 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Eva_01_Breastplate>() && legs.type == ModContent.ItemType<Eva_01_Leggings>();
        }
   

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Enemies take damage when they attack you.";
            player.thorns = 1f;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage<RangedDamageClass>() += 0.1f;
            player.GetCritChance<RangedDamageClass>() += 5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<MechanicalComponent>(5).
                AddTile(TileID.Anvils).Register();
        }
    }
}
