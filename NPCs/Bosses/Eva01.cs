/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.NPCs.Bosses
{
    [AutoloadBossHead]
    public class Eva01 : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 8; // fix later, set to the amount of frames that the spritesheet has when done
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            //NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.something] // make this a specific buff immunity for the evas.

            NPCID.Sets.NPCBestiaryDrawModifiers drawMods = new()
            {
                PortraitScale = 0.6f,
                PortraitPositionYOverride = 0f
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawMods);
        }

        public override void SetDefaults()
        {
            NPC.width = 64; // fix eventually when done with sprites.
            NPC.height = 128; // fix eventually when done with sprites.

            //Damage and defence
            NPC.damage = 32;
            NPC.defense = 15;

            //Maximum Health
            NPC.lifeMax = 7500;

            //Knockback resistance
            NPC.knockBackResist = 0f;

            //hitsound
            NPC.HitSound = SoundID.NPCHit11;
            NPC.DeathSound = SoundID.NPCDeath1;

            //collision properties
            NPC.noGravity = false;
            NPC.noTileCollide = false;

            //boss settings
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f;

            // AI
            NPC.aiStyle = -1;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EvangelionBars>(), 1, 2, 5)) // drops evangelion bars for crafting weapons.
        }
    }
}
*/