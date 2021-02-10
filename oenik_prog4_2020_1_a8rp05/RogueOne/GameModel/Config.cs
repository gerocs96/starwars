// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    /// <summary>
    /// The permanent values of the game.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// The width of the game field.
        /// </summary>
        public const double Width = 1280;

        /// <summary>
        /// The height of the game field.
        /// </summary>
        public const double Height = 720;

        /// <summary>
        /// The path to the Tatooine Background texture.
        /// </summary>
        public const string TatooineBackgroundPath = "RogueOne.Textures.tatooine.jpg";

        /// <summary>
        /// The path to the Hoth Background texture.
        /// </summary>
        public const string HothBackgroundPath = "RogueOne.Textures.hoth.jpg";

        /// <summary>
        /// The path to the Scarif Background texture.
        /// </summary>
        public const string ScarifBackgroundPath = "RogueOne.Textures.scarif.jpg";

        /// <summary>
        /// The path to the Mustafar Background texture.
        /// </summary>
        public const string MustafarBackgroundPath = "RogueOne.Textures.mustafar.jpg";

        /// <summary>
        /// The path to the Coruscant Background texture.
        /// </summary>
        public const string CoruscantBackgroundPath = "RogueOne.Textures.coruscant.jpg";

        /// <summary>
        /// The path to the Space Background texture.
        /// </summary>
        public const string SpaceBackgroundPath = "RogueOne.Textures.Space.jpg";

        /// <summary>
        /// The path to the XWing texture.
        /// </summary>
        public const string XWingTexturePath = "RogueOne.Textures.xwing.png";

        /// <summary>
        /// The path to the TieFighter texture.
        /// </summary>
        public const string TieFighterPath = "RogueOne.Textures.tiefighter.png";

        /// <summary>
        /// The path to the TieInterceptor texture.
        /// </summary>
        public const string FieTighterPath = "RogueOne.Textures.fietighter.png";

        /// <summary>
        /// The path to the StarDestroyer texture.
        /// </summary>
        public const string StarDestroyerPath = "RogueOne.Textures.stardestroyer.png";

        /// <summary>
        /// The path to the DeathStar texture.
        /// </summary>
        public const string DeathStarPath = "RogueOne.Textures.deathstar.png";

        /// <summary>
        /// The path to the SlaveOne texture.
        /// </summary>
        public const string SlaveOnePath = "RogueOne.Textures.slave.png";

        /// <summary>
        /// The path to the MilleniumFalcon texture.
        /// </summary>
        public const string FalconTexturePath = "RogueOne.Textures.falcon.png";

        /// <summary>
        /// The path to the JediFighter texture.
        /// </summary>
        public const string JediFighterTexturePath = "RogueOne.Textures.jedifighter.png";

        /// <summary>
        /// The path to the NabooFighter texture.
        /// </summary>
        public const string NabooFighterTexturePath = "RogueOne.Textures.naboofighter.png";

        /// <summary>
        /// The path to the T47 texture.
        /// </summary>
        public const string T47TexturePath = "RogueOne.Textures.t47.png";

        /// <summary>
        /// The health of the XWing.
        /// </summary>
        public const int XWingHealth = 200;

        /// <summary>
        /// The damage of the XWing.
        /// </summary>
        public const int XWingDamage = 50;

        /// <summary>
        /// The armor of the XWing.
        /// </summary>
        public const int XWingArmor = 1;

        /// <summary>
        /// The speed of the XWing.
        /// </summary>
        public const int XWingSpeed = 15;

        /// <summary>
        /// The health of the MilleniumFalcon.
        /// </summary>
        public const int FalconHealth = 250;

        /// <summary>
        /// The damage of the MilleniumFalcon.
        /// </summary>
        public const int FalconDamage = 40;

        /// <summary>
        /// The armor of the MilleniumFalcon.
        /// </summary>
        public const int FalconArmor = 2;

        /// <summary>
        /// The speed of the MilleniumFalcon.
        /// </summary>
        public const int FalconSpeed = 20;

        /// <summary>
        /// The health of the JediFighter.
        /// </summary>
        public const int JediFighterHealth = 150;

        /// <summary>
        /// The damage of the JediFighter.
        /// </summary>
        public const int JediFighterDamage = 30;

        /// <summary>
        /// The armor of the JediFighter.
        /// </summary>
        public const int JediFighterArmor = 1;

        /// <summary>
        /// The speed of the JediFighter.
        /// </summary>
        public const int JediFighterSpeed = 20;

        /// <summary>
        /// The health of the NabooFighter.
        /// </summary>
        public const int NabooFighterHealth = 100;

        /// <summary>
        /// The damage of the NabooFighter.
        /// </summary>
        public const int NabooFighterDamage = 20;

        /// <summary>
        /// The armor of the NabooFighter.
        /// </summary>
        public const int NabooFighterArmor = 0;

        /// <summary>
        /// The speed of the NabooFighter.
        /// </summary>
        public const int NabooFighterSpeed = 22;

        /// <summary>
        /// The health of the T47.
        /// </summary>
        public const int T47Health = 150;

        /// <summary>
        /// The damage of the T47.
        /// </summary>
        public const int T47Damage = 25;

        /// <summary>
        /// The armor of the T47.
        /// </summary>
        public const int T47Armor = 1;

        /// <summary>
        /// The speed of the T47.
        /// </summary>
        public const int T47Speed = 10;

        /// <summary>
        /// The speed of the TieFighter on the X-axis.
        /// </summary>
        public const int TieFighterDX = -10;

        /// <summary>
        /// The speed of the TieFighter on the Y-axis.
        /// </summary>
        public const int TieFighterDY = 0;

        /// <summary>
        /// The health of the TieFighter.
        /// </summary>
        public const int TieFighterHealth = 100;

        /// <summary>
        /// The damage of the TieFighter.
        /// </summary>
        public const int TieFighterDamage = 10;

        /// <summary>
        /// Determines whether the fire is targeting on the TieFighter.
        /// </summary>
        public const bool TieFighterTarget = false;

        /// <summary>
        /// The amount of score given after a TeiFighter dies.
        /// </summary>
        public const int TieFighterWorth = 20;

        /// <summary>
        /// The amount of charge required to fire for the TieFighter.
        /// </summary>
        public const int TieFighterCharge = 100;

        /// <summary>
        /// The speed of the FieTighter on the X-axis.
        /// </summary>
        public const int FieTighterDX = -10;

        /// <summary>
        /// The speed of the FieTighter on the Y-axis.
        /// </summary>
        public const int FieTighterDY = 0;

        /// <summary>
        /// The health of the FieTighter.
        /// </summary>
        public const int FieTighterHealth = 150;

        /// <summary>
        /// The damage of the FieTighter.
        /// </summary>
        public const int FieTighterDamage = 20;

        /// <summary>
        /// Determines whether the fire is targeting on the FieTighter.
        /// </summary>
        public const bool FieTighterTarget = true;

        /// <summary>
        /// The amount of score given after a FieTighter dies.
        /// </summary>
        public const int FieTighterWorth = 40;

        /// <summary>
        /// The amount of charge required to fire for the FieTighter.
        /// </summary>
        public const int FieTighterCharge = 150;

        /// <summary>
        /// The speed of the StarDestroyer on the X-axis.
        /// </summary>
        public const int StarDestroyerDX = -4;

        /// <summary>
        /// The speed of the StarDestroyer on the Y-axis.
        /// </summary>
        public const int StarDestroyerDY = 0;

        /// <summary>
        /// The health of the StarDestroyer.
        /// </summary>
        public const int StarDestroyerHealth = 2000;

        /// <summary>
        /// The damage of the StarDestroyer.
        /// </summary>
        public const int StarDestroyerDamage = 70;

        /// <summary>
        /// Determines whether the fire is targeting on the StarDestroyer.
        /// </summary>
        public const bool StarDestroyerTarget = true;

        /// <summary>
        /// The amount of score given after a StarDestroyer dies.
        /// </summary>
        public const int StarDestroyerWorth = 1000;

        /// <summary>
        /// The amount of charge required to fire for the StarDestroyer.
        /// </summary>
        public const int StarDestroyerCharge = 140;

        /// <summary>
        /// The speed of the DeathStar on the X-axis.
        /// </summary>
        public const int DeathStarDX = -2;

        /// <summary>
        /// The speed of the DeathStar on the Y-axis.
        /// </summary>
        public const int DeathStarDY = 0;

        /// <summary>
        /// The health of the DeathStar.
        /// </summary>
        public const int DeathStarHealth = 5000;

        /// <summary>
        /// The damage of the DeathStar.
        /// </summary>
        public const int DeathStarDamage = 100;

        /// <summary>
        /// Determines whether the fire is targeting on the DeathStar.
        /// </summary>
        public const bool DeathStarTarget = true;

        /// <summary>
        /// The amount of score given after a DeathStar dies.
        /// </summary>
        public const int DeathStarWorth = 3000;

        /// <summary>
        /// The amount of charge required to fire for the DeathStar.
        /// </summary>
        public const int DeathStarCharge = 70;

        /// <summary>
        /// The speed of the SlaveOne on the X-axis.
        /// </summary>
        public const int SlaveOneDX = -3;

        /// <summary>
        /// The speed of the SlaveOne on the Y-axis.
        /// </summary>
        public const int SlaveOneDY = 4;

        /// <summary>
        /// The health of the SlaveOne.
        /// </summary>
        public const int SlaveOneHealth = 600;

        /// <summary>
        /// The damage of the SlaveOne.
        /// </summary>
        public const int SlaveOneDamage = 50;

        /// <summary>
        /// Determines whether the fire is targeting on the SlaveOne.
        /// </summary>
        public const bool SlaveOneTarget = false;

        /// <summary>
        /// The amount of score given after a SlaveOne dies.
        /// </summary>
        public const int SlaveOneWorth = 300;

        /// <summary>
        /// The amount of charge required to fire for the SlaveOne.
        /// </summary>
        public const int SlaveOneCharge = 70;

        /// <summary>
        /// The speed of the player's bullet on the X-axis.
        /// </summary>
        public const int ShipBulletDX = 40;

        /// <summary>
        /// The speed of the player's bullet on the Y-axis.
        /// </summary>
        public const int ShipBulletDY = 0;

        /// <summary>
        /// The width of the player's bullet.
        /// </summary>
        public const int ShipBulletWidth = 20;

        /// <summary>
        /// The height of the player's bullet.
        /// </summary>
        public const int ShipBulletHeight = 5;

        /// <summary>
        /// The speed of the enemy's bullet on the X-axis.
        /// </summary>
        public const int EnemyBulletDX = -30;

        /// <summary>
        /// The speed of the enemy's bullet on the Y-axis.
        /// </summary>
        public const int EnemyBulletDY = 0;

        /// <summary>
        /// The width of the enemy's bullet.
        /// </summary>
        public const int EnemyBulletWidth = 20;

        /// <summary>
        /// The height of the enemy's bullet.
        /// </summary>
        public const int EnemyBulletHeight = 5;
    }
}
