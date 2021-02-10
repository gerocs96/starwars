// <copyright file="GameItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    using System.Reflection;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// The base class of an item in the game.
    /// </summary>
    public abstract class GameItem
    {
        /// <summary>
        /// Gets or sets the center point of the GameItem on the X-axis.
        /// </summary>
        public double CenterX { get; set; }

        /// <summary>
        /// Gets or sets the center point of the GameItem on the Y-axis.
        /// </summary>
        public double CenterY { get; set; }

        /// <summary>
        /// Gets or sets the degree of which the GameItem has to be rotated.
        /// </summary>
        public double RotDegree { get; set; }

        /// <summary>
        /// Gets or sets the color of the GameItem.
        /// </summary>
        public Brush Color { get; set; }

        /// <summary>
        /// Gets or sets the geometry of the GameItem.
        /// </summary>
        public Geometry Area { get; set; }

        /// <summary>
        /// Gets or sets a filling texture brush of the GameItem.
        /// </summary>
        public Brush Texture { get; set; }

        /// <summary>
        /// Gets or sets the path of the GameItem's texture.
        /// </summary>
        public string TexturePath { get; set; }

        /// <summary>
        /// Check whether the GameItem collides with an other GameItem.
        /// </summary>
        /// <param name="other">The other GameItem.</param>
        /// <param name="myoffsetx">The calling GameItem's offset on the X-axis.</param>
        /// <param name="myoffsety">The calling GameItem's offset on the Y-axis.</param>
        /// <param name="otheroffsetx">The other GameItem's offset on the X-axis.</param>
        /// <param name="otheroffsety">The other GameItem's offset on the Y-axis.</param>
        /// <returns>Returns true if the two GameItem collides.</returns>
        public bool IsCollision(GameItem other, double myoffsetx, double myoffsety, double otheroffsetx, double otheroffsety)
        {
            return Geometry.Combine(this.GetTransformedArea(myoffsetx, myoffsety), other.GetTransformedArea(otheroffsetx, otheroffsety), GeometryCombineMode.Intersect, null).GetArea() > 0;
        }

        /// <summary>
        /// Returns the actual area and location of the GameItem's area after transformations.
        /// </summary>
        /// <param name="offsetx">The GameItem's offset on the X-axis.</param>
        /// <param name="offsety">The GameItem's offset on the Y-axis.</param>
        /// <returns>Returns the transformed Geometry of the GameItem.</returns>
        public Geometry GetTransformedArea(double offsetx, double offsety)
        {
            TransformGroup tg = new TransformGroup();
            if (this.Area is EllipseGeometry)
            {
                tg.Children.Add(new TranslateTransform(this.CenterX, this.CenterY));
            }
            else if (this.Area is RectangleGeometry)
            {
                tg.Children.Add(new TranslateTransform(this.CenterX - offsetx, this.CenterY - offsety));
            }

            tg.Children.Add(new RotateTransform(this.RotDegree, this.CenterX, this.CenterY));
            this.Area.Transform = tg;
            return this.Area.GetFlattenedPathGeometry();
        }

        /// <summary>
        /// Loads the texture brush of the GameItem.
        /// </summary>
        /// <param name="path">The path of the texture to be loaded.</param>
        public void TextureLoad(string path)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = Assembly.GetEntryAssembly().GetManifestResourceStream(path);
            bmp.EndInit();
            ImageBrush ib = new ImageBrush(bmp);
            this.Texture = ib;
        }
    }
}
