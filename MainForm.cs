

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace ImageFilters
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MenuItem fileItem;
        private System.Windows.Forms.MenuItem openFileItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem exitFilrItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem sizeItem;
        private System.Windows.Forms.MenuItem normalSizeItem;
        private System.Windows.Forms.MenuItem stretchedSizeItem;
        private System.Windows.Forms.MenuItem centeredSizeItem;
        private System.Windows.Forms.MenuItem filtersItem;
        private System.Windows.Forms.MenuItem noneFiltersItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem sepiaFiltersItem;
        private System.Windows.Forms.MenuItem invertFiltersItem;
        private System.Windows.Forms.MenuItem rotateChannelFiltersItem;
        private System.Windows.Forms.MenuItem grayscaleFiltersItem;
        private System.Windows.Forms.MenuItem colorFiltersItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem hueModifierFiltersItem;
        private System.Windows.Forms.MenuItem saturationAdjustingFiltersItem;
        private System.Windows.Forms.MenuItem brightnessAdjustingFiltersItem;
        private System.Windows.Forms.MenuItem contrastAdjustingFiltersItem;
        private System.Windows.Forms.MenuItem hslFiltersItem;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem yCbCrLinearFiltersItem;
        private System.Windows.Forms.MenuItem yCbCrFiltersItem;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem thresholdFiltersItem;
        private System.Windows.Forms.MenuItem floydFiltersItem;
        private System.Windows.Forms.MenuItem orderedDitheringFiltersItem;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem convolutionFiltersItem;
        private System.Windows.Forms.MenuItem sharpenFiltersItem;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem differenceEdgesFiltersItem;
        private System.Windows.Forms.MenuItem homogenityEdgesFiltersItem;
        private System.Windows.Forms.MenuItem sobelEdgesFiltersItem;
        private System.Windows.Forms.MenuItem rgbLinearFiltersItem;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem jitterFiltersItem;
        private System.Windows.Forms.MenuItem oilFiltersItem;
        private MenuItem gaussianFiltersItem;
        private MenuItem textureFiltersItem;
        private IContainer components;

        private System.Drawing.Bitmap sourceImage;
        private MenuItem menuItem9;
        private MenuItem BinaryDilatationFiltersItem;
        private MenuItem BinaryErosionFiltersItem;
        private MenuItem testFilterItem;
        private MenuItem menuItem10;
        private MenuItem menuItem11;
        private MenuItem menuItemErode;
        private MenuItem menuItemDilate;
        private System.Drawing.Bitmap filteredImage;

        // Constructor
        public MainForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            // set default size mode of picture box
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
                {
                    components.Dispose( );
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileItem = new System.Windows.Forms.MenuItem();
            this.openFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.exitFilrItem = new System.Windows.Forms.MenuItem();
            this.filtersItem = new System.Windows.Forms.MenuItem();
            this.noneFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.grayscaleFiltersItem = new System.Windows.Forms.MenuItem();
            this.sepiaFiltersItem = new System.Windows.Forms.MenuItem();
            this.invertFiltersItem = new System.Windows.Forms.MenuItem();
            this.rotateChannelFiltersItem = new System.Windows.Forms.MenuItem();
            this.colorFiltersItem = new System.Windows.Forms.MenuItem();
            this.rgbLinearFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.hueModifierFiltersItem = new System.Windows.Forms.MenuItem();
            this.saturationAdjustingFiltersItem = new System.Windows.Forms.MenuItem();
            this.brightnessAdjustingFiltersItem = new System.Windows.Forms.MenuItem();
            this.contrastAdjustingFiltersItem = new System.Windows.Forms.MenuItem();
            this.hslFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.yCbCrLinearFiltersItem = new System.Windows.Forms.MenuItem();
            this.yCbCrFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.thresholdFiltersItem = new System.Windows.Forms.MenuItem();
            this.floydFiltersItem = new System.Windows.Forms.MenuItem();
            this.orderedDitheringFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.convolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.sharpenFiltersItem = new System.Windows.Forms.MenuItem();
            this.gaussianFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.differenceEdgesFiltersItem = new System.Windows.Forms.MenuItem();
            this.homogenityEdgesFiltersItem = new System.Windows.Forms.MenuItem();
            this.sobelEdgesFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.jitterFiltersItem = new System.Windows.Forms.MenuItem();
            this.oilFiltersItem = new System.Windows.Forms.MenuItem();
            this.textureFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.BinaryDilatationFiltersItem = new System.Windows.Forms.MenuItem();
            this.BinaryErosionFiltersItem = new System.Windows.Forms.MenuItem();
            this.testFilterItem = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.sizeItem = new System.Windows.Forms.MenuItem();
            this.normalSizeItem = new System.Windows.Forms.MenuItem();
            this.stretchedSizeItem = new System.Windows.Forms.MenuItem();
            this.centeredSizeItem = new System.Windows.Forms.MenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItemErode = new System.Windows.Forms.MenuItem();
            this.menuItemDilate = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileItem,
            this.filtersItem,
            this.sizeItem,
            this.menuItem11});
            // 
            // fileItem
            // 
            this.fileItem.Index = 0;
            this.fileItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.openFileItem,
            this.menuItem3,
            this.exitFilrItem});
            this.fileItem.Text = "&File";
            // 
            // openFileItem
            // 
            this.openFileItem.Index = 0;
            this.openFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.openFileItem.Text = "&Open";
            this.openFileItem.Click += new System.EventHandler(this.openFileItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // exitFilrItem
            // 
            this.exitFilrItem.Index = 2;
            this.exitFilrItem.Text = "E&xit";
            this.exitFilrItem.Click += new System.EventHandler(this.exitFilrItem_Click);
            // 
            // filtersItem
            // 
            this.filtersItem.Index = 1;
            this.filtersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.noneFiltersItem,
            this.menuItem1,
            this.grayscaleFiltersItem,
            this.sepiaFiltersItem,
            this.invertFiltersItem,
            this.rotateChannelFiltersItem,
            this.colorFiltersItem,
            this.rgbLinearFiltersItem,
            this.menuItem2,
            this.hueModifierFiltersItem,
            this.saturationAdjustingFiltersItem,
            this.brightnessAdjustingFiltersItem,
            this.contrastAdjustingFiltersItem,
            this.hslFiltersItem,
            this.menuItem4,
            this.yCbCrLinearFiltersItem,
            this.yCbCrFiltersItem,
            this.menuItem5,
            this.thresholdFiltersItem,
            this.floydFiltersItem,
            this.orderedDitheringFiltersItem,
            this.menuItem6,
            this.convolutionFiltersItem,
            this.sharpenFiltersItem,
            this.gaussianFiltersItem,
            this.menuItem7,
            this.differenceEdgesFiltersItem,
            this.homogenityEdgesFiltersItem,
            this.sobelEdgesFiltersItem,
            this.menuItem8,
            this.jitterFiltersItem,
            this.oilFiltersItem,
            this.textureFiltersItem,
            this.menuItem9,
            this.BinaryDilatationFiltersItem,
            this.BinaryErosionFiltersItem,
            this.testFilterItem,
            this.menuItem10});
            this.filtersItem.Text = "Fi&lters";
            // 
            // noneFiltersItem
            // 
            this.noneFiltersItem.Index = 0;
            this.noneFiltersItem.Text = "&None";
            this.noneFiltersItem.Click += new System.EventHandler(this.noneFiltersItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // grayscaleFiltersItem
            // 
            this.grayscaleFiltersItem.Index = 2;
            this.grayscaleFiltersItem.Text = "&Grayscale";
            this.grayscaleFiltersItem.Click += new System.EventHandler(this.grayscaleFiltersItem_Click);
            // 
            // sepiaFiltersItem
            // 
            this.sepiaFiltersItem.Index = 3;
            this.sepiaFiltersItem.Text = "&Sepia";
            this.sepiaFiltersItem.Click += new System.EventHandler(this.sepiaFiltersItem_Click);
            // 
            // invertFiltersItem
            // 
            this.invertFiltersItem.Index = 4;
            this.invertFiltersItem.Text = "&Invert";
            this.invertFiltersItem.Click += new System.EventHandler(this.invertFiltersItem_Click);
            // 
            // rotateChannelFiltersItem
            // 
            this.rotateChannelFiltersItem.Index = 5;
            this.rotateChannelFiltersItem.Text = "&Rotate channel";
            this.rotateChannelFiltersItem.Click += new System.EventHandler(this.rotateChannelFiltersItem_Click);
            // 
            // colorFiltersItem
            // 
            this.colorFiltersItem.Index = 6;
            this.colorFiltersItem.Text = "Color filtering";
            this.colorFiltersItem.Click += new System.EventHandler(this.colorFiltersItem_Click);
            // 
            // rgbLinearFiltersItem
            // 
            this.rgbLinearFiltersItem.Index = 7;
            this.rgbLinearFiltersItem.Text = "Levels linear correction";
            this.rgbLinearFiltersItem.Click += new System.EventHandler(this.rgbLinearFiltersItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 8;
            this.menuItem2.Text = "-";
            // 
            // hueModifierFiltersItem
            // 
            this.hueModifierFiltersItem.Index = 9;
            this.hueModifierFiltersItem.Text = "Hue modifier";
            this.hueModifierFiltersItem.Click += new System.EventHandler(this.hueModifierFiltersItem_Click);
            // 
            // saturationAdjustingFiltersItem
            // 
            this.saturationAdjustingFiltersItem.Index = 10;
            this.saturationAdjustingFiltersItem.Text = "Saturation adjusting";
            this.saturationAdjustingFiltersItem.Click += new System.EventHandler(this.saturationAdjustingFiltersItem_Click);
            // 
            // brightnessAdjustingFiltersItem
            // 
            this.brightnessAdjustingFiltersItem.Index = 11;
            this.brightnessAdjustingFiltersItem.Text = "Brightness adjusting";
            this.brightnessAdjustingFiltersItem.Click += new System.EventHandler(this.brightnessAdjustingFiltersItem_Click);
            // 
            // contrastAdjustingFiltersItem
            // 
            this.contrastAdjustingFiltersItem.Index = 12;
            this.contrastAdjustingFiltersItem.Text = "Contrast adjusting";
            this.contrastAdjustingFiltersItem.Click += new System.EventHandler(this.contrastAdjustingFiltersItem_Click);
            // 
            // hslFiltersItem
            // 
            this.hslFiltersItem.Index = 13;
            this.hslFiltersItem.Text = "HSL filtering";
            this.hslFiltersItem.Click += new System.EventHandler(this.hslFiltersItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 14;
            this.menuItem4.Text = "-";
            // 
            // yCbCrLinearFiltersItem
            // 
            this.yCbCrLinearFiltersItem.Index = 15;
            this.yCbCrLinearFiltersItem.Text = "YCbCr linear correction";
            this.yCbCrLinearFiltersItem.Click += new System.EventHandler(this.yCbCrLinearFiltersItem_Click);
            // 
            // yCbCrFiltersItem
            // 
            this.yCbCrFiltersItem.Index = 16;
            this.yCbCrFiltersItem.Text = "YCbCr filtering";
            this.yCbCrFiltersItem.Click += new System.EventHandler(this.yCbCrFiltersItem_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 17;
            this.menuItem5.Text = "-";
            // 
            // thresholdFiltersItem
            // 
            this.thresholdFiltersItem.Index = 18;
            this.thresholdFiltersItem.Text = "Threshold &binarization";
            this.thresholdFiltersItem.Click += new System.EventHandler(this.thresholdFiltersItem_Click);
            // 
            // floydFiltersItem
            // 
            this.floydFiltersItem.Index = 19;
            this.floydFiltersItem.Text = "Floyd-Steinberg dithering";
            this.floydFiltersItem.Click += new System.EventHandler(this.floydFiltersItem_Click);
            // 
            // orderedDitheringFiltersItem
            // 
            this.orderedDitheringFiltersItem.Index = 20;
            this.orderedDitheringFiltersItem.Text = "Ordered dithering";
            this.orderedDitheringFiltersItem.Click += new System.EventHandler(this.orderedDitheringFiltersItem_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 21;
            this.menuItem6.Text = "-";
            // 
            // convolutionFiltersItem
            // 
            this.convolutionFiltersItem.Index = 22;
            this.convolutionFiltersItem.Text = "Convolution";
            this.convolutionFiltersItem.Click += new System.EventHandler(this.convolutionFiltersItem_Click);
            // 
            // sharpenFiltersItem
            // 
            this.sharpenFiltersItem.Index = 23;
            this.sharpenFiltersItem.Text = "Sharpen";
            this.sharpenFiltersItem.Click += new System.EventHandler(this.sharpenFiltersItem_Click);
            // 
            // gaussianFiltersItem
            // 
            this.gaussianFiltersItem.Index = 24;
            this.gaussianFiltersItem.Text = "Gaussian blur";
            this.gaussianFiltersItem.Click += new System.EventHandler(this.gaussianFiltersItem_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 25;
            this.menuItem7.Text = "-";
            // 
            // differenceEdgesFiltersItem
            // 
            this.differenceEdgesFiltersItem.Index = 26;
            this.differenceEdgesFiltersItem.Text = "Difference edge detector";
            this.differenceEdgesFiltersItem.Click += new System.EventHandler(this.differenceEdgesFiltersItem_Click);
            // 
            // homogenityEdgesFiltersItem
            // 
            this.homogenityEdgesFiltersItem.Index = 27;
            this.homogenityEdgesFiltersItem.Text = "Homogenity edge detector";
            this.homogenityEdgesFiltersItem.Click += new System.EventHandler(this.homogenityEdgesFiltersItem_Click);
            // 
            // sobelEdgesFiltersItem
            // 
            this.sobelEdgesFiltersItem.Index = 28;
            this.sobelEdgesFiltersItem.Text = "Sobel edge detector";
            this.sobelEdgesFiltersItem.Click += new System.EventHandler(this.sobelEdgesFiltersItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 29;
            this.menuItem8.Text = "-";
            // 
            // jitterFiltersItem
            // 
            this.jitterFiltersItem.Index = 30;
            this.jitterFiltersItem.Text = "Jitter";
            this.jitterFiltersItem.Click += new System.EventHandler(this.jitterFiltersItem_Click);
            // 
            // oilFiltersItem
            // 
            this.oilFiltersItem.Index = 31;
            this.oilFiltersItem.Text = "Oil Painting";
            this.oilFiltersItem.Click += new System.EventHandler(this.oilFiltersItem_Click);
            // 
            // textureFiltersItem
            // 
            this.textureFiltersItem.Index = 32;
            this.textureFiltersItem.Text = "Texture";
            this.textureFiltersItem.Click += new System.EventHandler(this.textureFiltersItem_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 33;
            this.menuItem9.Text = "-";
            // 
            // BinaryDilatationFiltersItem
            // 
            this.BinaryDilatationFiltersItem.Index = 34;
            this.BinaryDilatationFiltersItem.Text = "BinaryDilatation";
            this.BinaryDilatationFiltersItem.Click += new System.EventHandler(this.BinaryDilatationFiltersItem_Click);
            // 
            // BinaryErosionFiltersItem
            // 
            this.BinaryErosionFiltersItem.Index = 35;
            this.BinaryErosionFiltersItem.Text = "BinaryErosion";
            this.BinaryErosionFiltersItem.Click += new System.EventHandler(this.BinaryErosionFiltersItem_Click);
            // 
            // testFilterItem
            // 
            this.testFilterItem.Index = 36;
            this.testFilterItem.Text = "MosaicFilter";
            this.testFilterItem.Click += new System.EventHandler(this.testFilterItem_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 37;
            this.menuItem10.Text = "GaussSmooth";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // sizeItem
            // 
            this.sizeItem.Index = 2;
            this.sizeItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.normalSizeItem,
            this.stretchedSizeItem,
            this.centeredSizeItem});
            this.sizeItem.Text = "&Size mode";
            this.sizeItem.Popup += new System.EventHandler(this.sizeItem_Popup);
            // 
            // normalSizeItem
            // 
            this.normalSizeItem.Index = 0;
            this.normalSizeItem.Text = "&Normal";
            this.normalSizeItem.Click += new System.EventHandler(this.normalSizeItem_Click);
            // 
            // stretchedSizeItem
            // 
            this.stretchedSizeItem.Index = 1;
            this.stretchedSizeItem.Text = "&Stretched";
            this.stretchedSizeItem.Click += new System.EventHandler(this.stretchedSizeItem_Click);
            // 
            // centeredSizeItem
            // 
            this.centeredSizeItem.Index = 2;
            this.centeredSizeItem.Text = "&Centered";
            this.centeredSizeItem.Click += new System.EventHandler(this.centeredSizeItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
    "es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
    "p)|*.bmp|GIF files (*.gif)|*.gif";
            this.openFileDialog.Title = "Open image";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(6, -4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(475, 305);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 3;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemErode,
            this.menuItemDilate});
            this.menuItem11.Text = "&Morphology";
            // 
            // menuItemErode
            // 
            this.menuItemErode.Index = 0;
            this.menuItemErode.Text = "Erode";
            this.menuItemErode.Click += new System.EventHandler(this.menuItemErode_Click);
            // 
            // menuItemDilate
            // 
            this.menuItemDilate.Index = 1;
            this.menuItemDilate.Text = "Dilate";
            this.menuItemDilate.Click += new System.EventHandler(this.menuItemDilate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(493, 313);
            this.Controls.Add(this.pictureBox);
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(384, 258);
            this.Name = "MainForm";
            this.Text = "Image Processing filters ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            Application.Run( new MainForm( ) );
        }

        // On File->Exit menu item
        private void exitFilrItem_Click( object sender, System.EventArgs e )
        {
            Application.Exit( );
        }

        // On File->Open menu item
        private void openFileItem_Click( object sender, System.EventArgs e )
        {
            try
            {
                // show file open dialog
                if ( openFileDialog.ShowDialog( ) == DialogResult.OK )
                {
                    // load image
                    sourceImage = (Bitmap) Bitmap.FromFile( openFileDialog.FileName );

                    // check pixel format
                    if ( ( sourceImage.PixelFormat == PixelFormat.Format16bppGrayScale ) ||
                         ( Bitmap.GetPixelFormatSize( sourceImage.PixelFormat ) > 32 ) )
                    {
                        MessageBox.Show( "The demo application supports only color images.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        // free image
                        sourceImage.Dispose( );
                        sourceImage = null;
                    }
                    else
                    {
                        // make sure the image has 24 bpp format
                        if ( sourceImage.PixelFormat != PixelFormat.Format24bppRgb )
                        {
                            Bitmap temp = AForge.Imaging.Image.Clone( sourceImage, PixelFormat.Format24bppRgb );
                            sourceImage.Dispose( );
                            sourceImage = temp;
                        }
                    }

                    ClearCurrentImage( );

                    // display image
                    pictureBox.Image = sourceImage;
                    noneFiltersItem.Checked = true;

                    // enable filters menu
                    filtersItem.Enabled = ( sourceImage != null );
                }
            }
            catch
            {
                MessageBox.Show( "Failed loading the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        // On Size mode->Normal menu item
        private void normalSizeItem_Click( object sender, System.EventArgs e )
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        // On Size mode->Stretched menu item
        private void stretchedSizeItem_Click( object sender, System.EventArgs e )
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // On Size mode->Centered size menu item
        private void centeredSizeItem_Click( object sender, System.EventArgs e )
        {
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        // On Size menu item popup
        private void sizeItem_Popup( object sender, System.EventArgs e )
        {
            normalSizeItem.Checked = ( pictureBox.SizeMode == PictureBoxSizeMode.Normal );
            stretchedSizeItem.Checked = ( pictureBox.SizeMode == PictureBoxSizeMode.StretchImage );
            centeredSizeItem.Checked = ( pictureBox.SizeMode == PictureBoxSizeMode.CenterImage );
        }

        // Clear current image in picture box
        private void ClearCurrentImage( )
        {
            // clear current image from picture box
            pictureBox.Image = null;
            // free current image
            if ( ( noneFiltersItem.Checked == false ) && ( filteredImage != null ) )
            {
                filteredImage.Dispose( );
                filteredImage = null;
            }
            // uncheck all menu items
            foreach ( MenuItem item in filtersItem.MenuItems )
                item.Checked = false;
        }

        // Apply filter to the source image and show the filtered image
        private void ApplyFilter( IFilter filter )
        {
            ClearCurrentImage( );
            // apply filter
            filteredImage = filter.Apply( sourceImage );
            // display filtered image
            pictureBox.Image = filteredImage;
        }

        // On Filters->None item
        private void noneFiltersItem_Click( object sender, System.EventArgs e )
        {
            ClearCurrentImage( );
            // display source image
            pictureBox.Image = sourceImage;
            noneFiltersItem.Checked = true;
        }

        // On Filters->Grayscale item
        private void grayscaleFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( Grayscale.CommonAlgorithms.BT709 );
            BradleyLocalThresholding filter = new BradleyLocalThresholding();
            // apply the filter
            filter.ApplyInPlace(filteredImage);
            grayscaleFiltersItem.Checked = true;
        }

        // On Filters->Sepia item
        private void sepiaFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sepia( ) );
            sepiaFiltersItem.Checked = true;
        }

        // On Filters->Invert item
        private void invertFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Invert( ) );
            invertFiltersItem.Checked = true;
        }

        // On Filters->Rotate Channels item
        private void rotateChannelFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new RotateChannels( ) );
            rotateChannelFiltersItem.Checked = true;
        }

        // On Filters->Color filtering
        private void colorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ColorFiltering( new IntRange( 25, 230 ), new IntRange( 25, 230 ), new IntRange( 25, 230 ) ) );
            colorFiltersItem.Checked = true;
        }

        // On Filters->Hue modifier
        private void hueModifierFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new HueModifier( 50 ) );
            hueModifierFiltersItem.Checked = true;
        }

        // On Filters->Saturation adjusting
        private void saturationAdjustingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SaturationCorrection( 0.15f ) );
            saturationAdjustingFiltersItem.Checked = true;
        }

        // On Filters->Brightness adjusting
        private void brightnessAdjustingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new BrightnessCorrection( ) );
            brightnessAdjustingFiltersItem.Checked = true;
        }

        // On Filters->Contrast adjusting
        private void contrastAdjustingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ContrastCorrection( ) );
            contrastAdjustingFiltersItem.Checked = true;
        }

        // On Filters->HSL filtering
        private void hslFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new HSLFiltering( new IntRange( 330, 30 ), new Range( 0, 1 ), new Range( 0, 1 ) ) );
            hslFiltersItem.Checked = true;
        }

        // On Filters->YCbCr filtering
        private void yCbCrLinearFiltersItem_Click( object sender, System.EventArgs e )
        {
            YCbCrLinear filter = new YCbCrLinear( );

            filter.InCb = new Range( -0.3f, 0.3f );

            ApplyFilter( filter );
            yCbCrLinearFiltersItem.Checked = true;
        }

        // On Filters->YCbCr filtering
        private void yCbCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrFiltering( new Range( 0.2f, 0.9f ), new Range( -0.3f, 0.3f ), new Range( -0.3f, 0.3f ) ) );
            yCbCrFiltersItem.Checked = true;
        }

        // On Filters->Threshold binarization
        private void thresholdFiltersItem_Click( object sender, System.EventArgs e )
        {
            // save original image
            Bitmap originalImage = sourceImage;
            // get grayscale image
            sourceImage = Grayscale.CommonAlgorithms.RMY.Apply( sourceImage );
            // apply threshold filter
            ApplyFilter( new Threshold( ) );
            // delete grayscale image and restore original
            sourceImage.Dispose( );
            sourceImage = originalImage;

            thresholdFiltersItem.Checked = true;
        }

        // On Filters->Floyd-Steinberg dithering
        private void floydFiltersItem_Click( object sender, System.EventArgs e )
        {
            // save original image
            Bitmap originalImage = sourceImage;
            // get grayscale image
            sourceImage = Grayscale.CommonAlgorithms.RMY.Apply( sourceImage );
            // apply threshold filter
            ApplyFilter( new FloydSteinbergDithering( ) );
            // delete grayscale image and restore original
            sourceImage.Dispose( );
            sourceImage = originalImage;

            floydFiltersItem.Checked = true;
        }

        // On Filters->Ordered dithering
        private void orderedDitheringFiltersItem_Click( object sender, System.EventArgs e )
        {
            // save original image
            Bitmap originalImage = sourceImage;
            // get grayscale image
            sourceImage = Grayscale.CommonAlgorithms.RMY.Apply( sourceImage );
            // apply threshold filter
            ApplyFilter( new OrderedDithering( ) );
            // delete grayscale image and restore original
            sourceImage.Dispose( );
            sourceImage = originalImage;

            orderedDitheringFiltersItem.Checked = true;
        }

        // On Filters->Correlation
        private void convolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Convolution( new int[,] {
								{ 1, 2, 3, 2, 1 },
								{ 2, 4, 5, 4, 2 },
								{ 3, 5, 6, 5, 3 },
								{ 2, 4, 5, 4, 2 },
								{ 1, 2, 3, 2, 1 } } ) );
            convolutionFiltersItem.Checked = true;
        }

        // On Filters->Sharpen
        private void sharpenFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sharpen( ) );
            sharpenFiltersItem.Checked = true;
        }

        // On Filters->Difference edge detector
        private void differenceEdgesFiltersItem_Click( object sender, System.EventArgs e )
        {
            // save original image
            Bitmap originalImage = sourceImage;
            // get grayscale image
            sourceImage = Grayscale.CommonAlgorithms.RMY.Apply( sourceImage );
            // apply edge filter
            ApplyFilter( new DifferenceEdgeDetector( ) );
            // delete grayscale image and restore original
            sourceImage.Dispose( );
            sourceImage = originalImage;

            differenceEdgesFiltersItem.Checked = true;
        }

        // On Filters->Homogenity edge detector
        private void homogenityEdgesFiltersItem_Click( object sender, System.EventArgs e )
        {
            // save original image
            Bitmap originalImage = sourceImage;
            // get grayscale image
            sourceImage = Grayscale.CommonAlgorithms.RMY.Apply( sourceImage );
            // apply edge filter
            ApplyFilter( new HomogenityEdgeDetector( ) );
            // delete grayscale image and restore original
            sourceImage.Dispose( );
            sourceImage = originalImage;

            homogenityEdgesFiltersItem.Checked = true;
        }

        // On Filters->Sobel edge detector
        private void sobelEdgesFiltersItem_Click( object sender, System.EventArgs e )
        {
            // save original image
            Bitmap originalImage = sourceImage;
            // get grayscale image
            sourceImage = Grayscale.CommonAlgorithms.RMY.Apply( sourceImage );
            // apply edge filter
            ApplyFilter( new SobelEdgeDetector( ) );
            // delete grayscale image and restore original
            sourceImage.Dispose( );
            sourceImage = originalImage;

            sobelEdgesFiltersItem.Checked = true;
        }

        // On Filters->Levels Linear Correction
        private void rgbLinearFiltersItem_Click( object sender, System.EventArgs e )
        {
            LevelsLinear filter = new LevelsLinear( );

            filter.InRed = new IntRange( 30, 230 );
            filter.InGreen = new IntRange( 50, 240 );
            filter.InBlue = new IntRange( 10, 210 );

            ApplyFilter( filter );
            rgbLinearFiltersItem.Checked = true;
        }

        // On Filters->Jitter
        private void jitterFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Jitter( ) );
            jitterFiltersItem.Checked = true;
        }

        // On Filters->Oil Painting
        private void oilFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new OilPainting( ) );
            oilFiltersItem.Checked = true;
        }

        // On Filters->Gaussin blur
        private void gaussianFiltersItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new GaussianBlur( 2.0, 7 ) );
            gaussianFiltersItem.Checked = true;
        }

        // On Filters->Texture
        private void textureFiltersItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new Texturer( new TextileTexture( ), 1.0, 0.8 ) );
            textureFiltersItem.Checked = true;
        }

        // On Filters->BinaryDilatation3x3
        private void BinaryDilatationFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(Grayscale.CommonAlgorithms.BT709);
            // ApplyFilter(new SobelEdgeDetector());
            BinaryDilatation3x3 filter = new BinaryDilatation3x3();
            // apply the filter
            filter.ApplyInPlace(filteredImage);
            BinaryDilatationFiltersItem.Checked= true;
        }
        
        // On Filters->BinaryErosion3x3
        private void BinaryErosionFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(Grayscale.CommonAlgorithms.BT709);
            // ApplyFilter(new SobelEdgeDetector());
            BinaryErosion3x3 filter = new BinaryErosion3x3();
            // apply the filter
            filter.ApplyInPlace(filteredImage);
            BinaryErosionFiltersItem.Checked = true;
        }

        private void testFilterItem_Click(object sender, EventArgs e)
        {
            MosaicFilter mosaic = new MosaicFilter();
            pictureBox.Image = mosaic.ProcessBitmap(sourceImage, 8);
            testFilterItem.Checked = true; 

        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            // define mean filter kernel
            int[,] kernel = {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 } };
            // create filter
            Convolution filter = new Convolution(kernel);
            // apply the filter
            filter.ApplyInPlace(sourceImage);
            menuItem10.Checked = true; 

        }


        private void menuItemErode_Click(object sender, EventArgs e)
        {
              struction struForm = new struction();
              struForm.Text = "Erosion operation of structural elements";
                if (struForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
                    System.Drawing.Imaging.BitmapData bmpData = sourceImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, sourceImage.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = sourceImage.Width * sourceImage.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                    byte flagStru = struForm.GetStruction;

                    byte[] tempArray = new byte[bytes];
                    for (int i = 0; i < bytes; i++)
                    {
                        tempArray[i] = 255;
                    }

                    switch (flagStru)
                    {
                        case 0x11:
                            for (int i = 0; i < sourceImage.Height; i++)
                            {
                                for (int j = 1; j < sourceImage.Width - 1; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 1] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x21:
                            for (int i = 0; i < sourceImage.Height; i++)
                            {
                                for (int j = 2; j < sourceImage.Width - 2; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 2] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 2] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x12:
                            for (int i = 1; i < sourceImage.Height - 1; i++)
                            {
                                for (int j = 0; j < sourceImage.Width; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x22:
                            for (int i = 2; i < sourceImage.Height - 2; i++)
                            {
                                for (int j = 0; j < sourceImage.Width; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 2) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 2) * sourceImage.Width + j] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x14:
                            for (int i = 1; i < sourceImage.Height - 1; i++)
                            {
                                for (int j = 1; j < sourceImage.Width - 1; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 1] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x24:
                            for (int i = 2; i < sourceImage.Height - 2; i++)
                            {
                                for (int j = 2; j < sourceImage.Width - 2; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 2) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 2) * sourceImage.Width + j] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 2] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 2] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x18:
                            for (int i = 1; i < sourceImage.Height - 1; i++)
                            {
                                for (int j = 1; j < sourceImage.Width - 1; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j + 1] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x28:
                            for (int i = 2; i < sourceImage.Height - 2; i++)
                            {
                                for (int j = 2; j < sourceImage.Width - 2; j++)
                                {
                                    if (grayValues[(i - 2) * sourceImage.Width + j - 2] == 0 &&
                                        grayValues[(i - 2) * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[(i - 2) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 2) * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[(i - 2) * sourceImage.Width + j + 2] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j - 2] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[(i - 1) * sourceImage.Width + j + 2] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 2] == 0 &&
                                        grayValues[i * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[i * sourceImage.Width + j + 2] == 0 &&
                                        grayValues[(i + 2) * sourceImage.Width + j - 2] == 0 &&
                                        grayValues[(i + 2) * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[(i + 2) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 2) * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[(i + 2) * sourceImage.Width + j + 2] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j - 2] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j - 1] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j + 1] == 0 &&
                                        grayValues[(i + 1) * sourceImage.Width + j + 2] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        default:
                            MessageBox.Show("Erro Erodition Element£¡");
                            break;
                    }
                    grayValues = (byte[])tempArray.Clone();

                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                    sourceImage.UnlockBits(bmpData);
                    pictureBox.Image = sourceImage;
                }
               
                sourceImage.Dispose();
                menuItemErode.Checked = true;
        }

        private void menuItemDilate_Click(object sender, EventArgs e)
        {
              struction struForm = new struction();
                struForm.Text = "Dilation operation structual element";
                if (struForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
                    System.Drawing.Imaging.BitmapData bmpData = sourceImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, sourceImage.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = sourceImage.Width * sourceImage.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                    byte flagStru = struForm.GetStruction;

                    byte[] tempArray = new byte[bytes];
                    for (int i = 0; i < bytes; i++)
                    {
                        tempArray[i] = 255;
                    }

                    switch (flagStru)
                    {
                        case 0x11:
                            for (int i = 0; i < sourceImage.Height; i++)
                            {
                                for (int j = 1; j < sourceImage.Width - 1; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 1] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x21:
                            for (int i = 0; i < sourceImage.Height; i++)
                            {
                                for (int j = 2; j < sourceImage.Width - 2; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 2] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 2] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x12:
                            for (int i = 1; i < sourceImage.Height - 1; i++)
                            {
                                for (int j = 0; j < sourceImage.Width; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x22:
                            for (int i = 2; i < sourceImage.Height - 2; i++)
                            {
                                for (int j = 0; j < sourceImage.Width; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 2) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 2) * sourceImage.Width + j] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x14:
                            for (int i = 1; i < sourceImage.Height - 1; i++)
                            {
                                for (int j = 1; j < sourceImage.Width - 1; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 1] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x24:
                            for (int i = 2; i < sourceImage.Height - 2; i++)
                            {
                                for (int j = 2; j < sourceImage.Width - 2; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 2) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 2) * sourceImage.Width + j] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 2] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 2] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x18:
                            for (int i = 1; i < sourceImage.Height - 1; i++)
                            {
                                for (int j = 1; j < sourceImage.Width - 1; j++)
                                {
                                    if (grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j + 1] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        case 0x28:
                            for (int i = 2; i < sourceImage.Height - 2; i++)
                            {
                                for (int j = 2; j < sourceImage.Width - 2; j++)
                                {
                                    if (grayValues[(i - 2) * sourceImage.Width + j - 2] == 0 ||
                                        grayValues[(i - 2) * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[(i - 2) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 2) * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[(i - 2) * sourceImage.Width + j + 2] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j - 2] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[(i - 1) * sourceImage.Width + j + 2] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 2] == 0 ||
                                        grayValues[i * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[i * sourceImage.Width + j + 2] == 0 ||
                                        grayValues[(i + 2) * sourceImage.Width + j - 2] == 0 ||
                                        grayValues[(i + 2) * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[(i + 2) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 2) * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[(i + 2) * sourceImage.Width + j + 2] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j - 2] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j - 1] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j + 1] == 0 ||
                                        grayValues[(i + 1) * sourceImage.Width + j + 2] == 0)
                                    {
                                        tempArray[i * sourceImage.Width + j] = 0;
                                    }

                                }
                            }
                            break;
                        default:
                            MessageBox.Show("Erro struct element£¡");
                            break;
                    }


                    grayValues = (byte[])tempArray.Clone();

                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                    sourceImage.UnlockBits(bmpData);
                }
                sourceImage.Dispose();
                menuItemDilate.Checked = true;
        }

    }
}
