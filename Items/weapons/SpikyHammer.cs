using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RaidersMod.Items.weapons
{
    class SpikyHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiky Hammer");
            Tooltip.SetDefault("Spiky Boi");
        }
        public override void SetDefaults()
        {
            item.noMelee = true;
            item.noUseGraphic = true;
            item.width = item.height = 16;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.shoot = ProjectileType<projectiles.SpikyHammerProj>();
            item.shootSpeed = 16;
            item.channel = true;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.damage = 35;
            item.knockBack = 2f;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ProjectileType<projectiles.SpikyHammerProj>()] < 1;
        }
    }
}
