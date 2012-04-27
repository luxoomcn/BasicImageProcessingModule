
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace BaicImageProcessModule
{
    // ColorSliderType enumeration
    public enum ColorSliderType
    {
        Gradient,
        InnerGradient,
        OuterGradient,
        Threshold
    }

    /// <summary>
    /// ColorSlider control
    /// </summary>
    public class ColorSlider : System.Windows.Forms.Control
    {
        private Pen blackPen = new Pen( Color.Black, 1 );
        private Color color1 = Color.Black;
        private Color color2 = Color.White;
        private Color color3 = Color.Black;
        private ColorSliderType type = ColorSliderType.Gradient;
        private bool doubleArrow = true;
        private Bitmap arrow;
        private int min = 0, max = 255;
        private int width = 256, height = 10;
        private int trackMode = 0;
        private int dx;

        // values changed event
        public event EventHandler ValuesChanged;

        // Color1 property
        [DefaultValue( typeof( Color ), "Black" )]
        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                Invalidate( );
            }
        }
        // Color2 property
        [DefaultValue( typeof( Color ), "White" )]
        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                Invalidate( );
            }
        }
        // Color3 property
        [DefaultValue( typeof( Color ), "Black" )]
        public Color Color3
        {
            get { return color3; }
            set
            {
                color3 = value;
                Invalidate( );
            }
        }
        // Type property
        [DefaultValue( ColorSliderType.Gradient )]
        public ColorSliderType Type
        {
            get { return type; }
            set
            {
                type = value;
                if ( ( type != ColorSliderType.Gradient ) && ( type != ColorSliderType.Threshold ) )
                    DoubleArrow = true;
                Invalidate( );
            }
        }
        // Min property
        [DefaultValue( 0 )]
        public int Min
        {
            get { return min; }
            set
            {
                min = value;
                Invalidate( );
            }
        }
        // Max property
        [DefaultValue( 255 )]
        public int Max
        {
            get { return max; }
            set
            {
                max = value;
                Invalidate( );
            }
        }
        // DoubleArrow property
        [DefaultValue( true )]
        public bool DoubleArrow
        {
            get { return doubleArrow; }
            set
            {
                doubleArrow = value;
                if ( ( !doubleArrow ) && ( type != ColorSliderType.Threshold ) )
                {
                    Type = ColorSliderType.Gradient;
                }
                Invalidate( );
            }
        }

        // Dispose
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                blackPen.Dispose( );
                arrow.Dispose( );
            }
            base.Dispose( disposing );
        }

        // Init component
        private void InitializeComponent( )
        {
            // 
            // ColorSlider
            // 
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.ColorSlider_MouseUp );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.ColorSlider_MouseMove );
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.ColorSlider_MouseDown );

        }
    // On mouse down
        private void ColorSlider_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            int x = ( ClientRectangle.Right - width ) / 2 - 4;
            int y = 3 + height;

            // check Y coordinate
            if ( ( e.Y >= y ) && ( e.Y < y + 6 ) )
            {
                // check X coordinate
                if ( ( e.X >= x + min ) && ( e.X < x + min + 9 ) )
                {
                    // left arrow
                    trackMode = 1;
                    dx = e.X - min;
                }
                if ( ( doubleArrow ) && ( e.X >= x + max ) && ( e.X < x + max + 9 ) )
                {
                    // right arrow
                    trackMode = 2;
                    dx = e.X - max;
                }

                if ( trackMode != 0 )
                    this.Capture = true;
            }
        }

        // On mouse up
        private void ColorSlider_MouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( trackMode != 0 )
            {
                // release capture
                this.Capture = false;
                trackMode = 0;

                // notify client
                if ( ValuesChanged != null )
                    ValuesChanged( this, new EventArgs( ) );
            }
        }

        // On mouse move
        private void ColorSlider_MouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( trackMode != 0 )
            {
                if ( trackMode == 1 )
                {
                    // left arrow tracking
                    min = e.X - dx;
                    min = Math.Max( min, 0 );
                    min = Math.Min( min, max );
                }
                if ( trackMode == 2 )
                {
                    // right arrow tracking
                    max = e.X - dx;
                    max = Math.Max( max, min );
                    max = Math.Min( max, 255 );
                }

                // repaint control
                Invalidate( );
            }
        }
    }
}
