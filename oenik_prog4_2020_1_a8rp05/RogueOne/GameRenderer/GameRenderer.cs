// <copyright file="GameRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameRenderer
{
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GameModel;

    /// <summary>
    /// The necessary methods to render the game.
    /// </summary>
    public class GameRenderer
    {
        private IGameModel model;

        private RectangleGeometry backGround;
        private FormattedText formattedScore;
        private FormattedText formattedShield;
        private FormattedText formattedArmor;
        private FormattedText formattedRemainingHealth;
        private Typeface font = new Typeface("Arial");
        private Point scoreLocation = new Point(10, 10);
        private Point shieldLocation = new Point(10, Config.Height - 30);
        private Point armorLocation = new Point(100, Config.Height - 30);
        private Point remaininghealthLocation = new Point(0, 0);
        private Brush bgtexture;

        private int oldScore = -1;
        private int oldShield = -1;
        private int oldArmor = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRenderer"/> class.
        /// </summary>
        /// <param name="model">The model which the renderer draws.</param>
        public GameRenderer(IGameModel model)
        {
            this.model = model;
            this.backGround = new RectangleGeometry(new Rect(0, 0, Config.Width, Config.Height));

            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = Assembly.GetEntryAssembly().GetManifestResourceStream(model.Map);
            bmp.EndInit();
            ImageBrush ib = new ImageBrush(bmp);
            this.bgtexture = ib;
        }

        /// <summary>
        /// Draws the necessary object from the model.
        /// </summary>
        /// <param name="ctx">The datacontext to use.</param>
        public void BuildDisplay(DrawingContext ctx)
        {
            this.DrawBackground(ctx);
            this.DrawPlayer(ctx);
            this.DrawEnemies(ctx);
            this.DrawBullets(ctx);
            this.DrawText(ctx);
        }

        private void DrawBackground(DrawingContext ctx)
        {
            ctx.DrawGeometry(this.bgtexture, null, this.backGround);
        }

        private void DrawEnemies(DrawingContext ctx)
        {
            foreach (Enemy enemy in this.model.Enemies)
            {
                ctx.DrawGeometry(enemy.Texture, null, enemy.GetTransformedArea(enemy.Width / 2, enemy.Height / 2));
            }
        }

        private void DrawPlayer(DrawingContext ctx)
        {
            ctx.DrawGeometry(this.model.Player.Texture, null, this.model.Player.GetTransformedArea(this.model.Player.Width / 2, this.model.Player.Height / 2));
        }

        private void DrawBullets(DrawingContext ctx)
        {
            foreach (Bullet bullet in this.model.Bullets)
            {
                ctx.DrawGeometry(bullet.Color, null, bullet.GetTransformedArea(bullet.Width / 2, bullet.Height / 2));
            }
        }

        private void DrawText(DrawingContext ctx)
        {
            if (this.oldScore != this.model.Score)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                this.formattedScore = new FormattedText(
                    "Score: " + this.model.Score.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    16,
                    Brushes.White);
#pragma warning restore CS0618 // Type or member is obsolete
                this.oldScore = this.model.Score;
            }

            if (this.oldShield != this.model.Player.Health)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                this.formattedShield = new FormattedText(
                    "Shield: " + this.model.Player.Health.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    16,
                    Brushes.White);
#pragma warning restore CS0618 // Type or member is obsolete
                this.oldShield = this.model.Player.Health;
            }

            if (this.oldArmor != this.model.Player.Armor)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                this.formattedArmor = new FormattedText(
                    "Armor: " + this.model.Player.Armor.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    16,
                    Brushes.White);
#pragma warning restore CS0618 // Type or member is obsolete
                this.oldArmor = this.model.Player.Armor;
            }

            foreach (Enemy enemy in this.model.Enemies)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                this.formattedRemainingHealth = new FormattedText(
                    enemy.Health.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    14,
                    Brushes.White);
#pragma warning restore CS0618 // Type or member is obsolete
                if (enemy.CenterY + (enemy.Height / 2) + 20 >= Config.Height)
                {
                    this.remaininghealthLocation.Y = enemy.CenterY - (enemy.Height / 2) - 20;
                }
                else
                {
                    this.remaininghealthLocation.Y = enemy.CenterY + (enemy.Height / 2) + 10;
                }

                this.remaininghealthLocation.X = enemy.CenterX - (this.formattedRemainingHealth.Width / 2);
                ctx.DrawText(this.formattedRemainingHealth, this.remaininghealthLocation);
            }

            ctx.DrawText(this.formattedScore, this.scoreLocation);
            ctx.DrawText(this.formattedShield, this.shieldLocation);
            ctx.DrawText(this.formattedArmor, this.armorLocation);
        }
    }
}
