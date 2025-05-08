using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace LevisMod.NPCs.TownNPCs
{
    public class Loona : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 80;
            NPC.lifeMax = 30000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCHit1;
            NPC.knockBackResist = 0.3f;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 2;
            NPCID.Sets.AttackTime[NPC.type] = 25;
            AnimationType = 633;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) // spawn condition.
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.WoodenArrow)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Loona",
                "Loona",
                "Loona"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Talk";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            int x = Main.rand.Next(4);
            if (firstButton)
            {
                shopName = "LoonaShop";
            }
            else if (!firstButton && x == 0)
            {
                Main.npcChatText = "Ugh, im so hungover right now...";
            }
            else if (!firstButton && x == 1)
            {
                Main.npcChatText = "Fuck, I did my makeup shitty today...";
            }
            else if (!firstButton && x == 2)
            {
                Main.npcChatText = "Oh, yeah. I wish I had friends. Haha, heh...I mean, I don't have any friends."
;
            }
            else if (!firstButton && x == 3)
            {
                Main.npcChatText = "You wanna go smoke a joint?";
            }
        }

        public override void AddShops()
        {
            NPCShop shop = new NPCShop(Type, "LoonaShop");
            shop.Add(ItemID.GreaterHealingPotion);
            shop.Add(ItemID.GreaterManaPotion);
            shop.Add(ItemID.LesserHealingPotion);
            shop.Add(ItemID.LesserManaPotion);
            shop.Add(ItemID.FeatherfallPotion);
            shop.Add(ItemID.BuilderPotion);
            shop.Add(ItemID.CalmingPotion);
            shop.Add(ItemID.GenderChangePotion);
            shop.Add(ItemID.BattlePotion);
            shop.Add(ItemID.LovePotion);
            shop.Add(ItemID.LuckPotion);
            shop.Add(ItemID.StinkPotion);
            shop.Add(ItemID.NightOwlPotion);
            shop.Add(ItemID.ShinePotion);
            shop.Add(ItemID.SpelunkerPotion);
            shop.Register();
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Zoologist>());
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "Whaddya want punk?";
                case 1:
                    return "God you're so annoying, what now?";
                case 2:
                    return "Sup man how can I help?";
                case 3:
                    return "UGHHHHHH WHAT???";
                default:
                    return "Haiiiiii";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 50;
            knockback = 8f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 6;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.WoodenArrowFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.WrathPotion);
        }
    }
}
