using Microsoft.Build.Graph;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LevisMod.Content.Projectiles
{
    public class Gravity : ModProjectile
    {
        private int frameTimer;
        public override void SetDefaults()
        {
            Projectile.height = 10;
            Projectile.width = 10;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            AIType = ProjectileID.Bullet;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 1000;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Main.projFrames[Projectile.type] = 12;

        }

        public override void AI()
        {
            frameTimer++;
            if (frameTimer >= 13)
            {
                frameTimer = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            if (Main.rand.NextBool(5))
            {
                int choice = Main.rand.Next(3);
                if (choice == 0)
                {
                    choice = 15;
                }
                else if (choice == 1)
                {
                    choice = 57;
                }
                else
                {
                    choice = 58;
                }
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, choice, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default, 0.7f);
            }

            Microsoft.Xna.Framework.Vector2 targetPos = new Microsoft.Xna.Framework.Vector2(Projectile.ai[0], Projectile.ai[1]);
            Microsoft.Xna.Framework.Vector2 toTarget = targetPos - Projectile.Center;

            float stopDist = 4f;

            if(toTarget.Length() > stopDist)
            {
                toTarget.Normalize();
                float speed = 10f;
                Projectile.velocity = toTarget * speed;
            } 
            else
            {
                Projectile.Center = targetPos;
                Projectile.velocity = Microsoft.Xna.Framework.Vector2.Zero;
            }

            Projectile.rotation += 0.4f * (float)Projectile.direction;

        }
    }
    }
