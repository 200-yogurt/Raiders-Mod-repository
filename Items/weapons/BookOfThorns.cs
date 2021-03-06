using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
 
namespace RaidersMod.Items.weapons
{
    public class BookOfThorns : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book of Thorns");
            Tooltip.SetDefault("This book shoots stings... ouch");
        }    
        public override void SetDefaults()
        {         
            item.damage = 14;                        
            item.magic = true;//this make the item do magic damage
            item.width = 24;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;        //this is how the item is holded
            item.noMelee = true;
            item.knockBack = 2;        
            item.value = 10000;
            item.rare = 2;
            item.mana = 5;             //mana use
            item.UseSound = SoundID.Item21;            //this is the sound when you use the item
            item.autoReuse = true;
            item.shoot = ProjectileType<projectiles.SpikeySpike>();   //this make the item shoot your projectile
            item.shootSpeed = 8f;    //projectile speed when shoot
        }      
    }
}
