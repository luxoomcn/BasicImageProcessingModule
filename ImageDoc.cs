using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace BaicImageProcessModule
{
    /// <summary>
    /// Summary description for ImageDoc.
    /// </summary>
    public class ImageDoc : Content
    {
        private System.Drawing.Bitmap backup = null;
        private System.Drawing.Bitmap image = null;
        private string fileName = null;
        private int width;
        private int height;
        private float zoom = 1;
        private IDocumentsHost host = null;

        private bool cropping = false;
        private bool dragging = false;
        private Point start, end, startW, endW;

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem imageItem;
        private System.Windows.Forms.MenuItem filtersItem;
        private System.Windows.Forms.MenuItem cloneImageItem;
        private System.Windows.Forms.MenuItem invertColorFiltersItem;
        private System.Windows.Forms.MenuItem grayscaleColorFiltersItem;
        private System.Windows.Forms.MenuItem backImageItem;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem z10ImageItem;
        private System.Windows.Forms.MenuItem z25ImageItem;
        private System.Windows.Forms.MenuItem z50ImageItem;
        private System.Windows.Forms.MenuItem z75ImageItem;
        private System.Windows.Forms.MenuItem z100ImageItem;
        private System.Windows.Forms.MenuItem z150ImageItem;
        private System.Windows.Forms.MenuItem z200ImageItem;
        private System.Windows.Forms.MenuItem z400ImageItem;
        private System.Windows.Forms.MenuItem z500ImageItem;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem zoomInImageItem;
        private System.Windows.Forms.MenuItem zoomOutImageItem;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem zoomFitImageItem;
        private System.Windows.Forms.MenuItem colorFiltersItem;
        private System.Windows.Forms.MenuItem binaryFiltersItem;
        private System.Windows.Forms.MenuItem thresholdBinaryFiltersItem;
        private System.Windows.Forms.MenuItem thresholdCarryBinaryFiltersItem;
        private System.Windows.Forms.MenuItem morphologyFiltersItem;
        private System.Windows.Forms.MenuItem dilatationMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem convolutionFiltersItem;
        private System.Windows.Forms.MenuItem meanConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem blurConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem sharpenConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem edgesConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem flipImageItem;
        private System.Windows.Forms.MenuItem mirrorItem;
        private System.Windows.Forms.MenuItem rotateImageItem;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem cropImageItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem customConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem openingMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem closingMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem erosionMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem redColorFiltersItem;
        private System.Windows.Forms.MenuItem greenColorFiltersItem;
        private System.Windows.Forms.MenuItem blueColorFiltersItem;
        private System.Windows.Forms.MenuItem extractRedColorFiltersItem;
        private System.Windows.Forms.MenuItem extractGreenColorFiltersItem;
        private System.Windows.Forms.MenuItem extractRedBlueFiltersItem;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem orderedDitherBinaryFiltersItem;
        private System.Windows.Forms.MenuItem bayerDitherBinaryFiltersItem;
        private System.Windows.Forms.MenuItem menuItem23;
        private System.Windows.Forms.MenuItem resizeFiltersItem;
        private System.Windows.Forms.MenuItem gaussianConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem menuItem33;
        private System.Windows.Forms.MenuItem sharpenExConvolutionFiltersItem;
        private System.ComponentModel.IContainer components;

        // Image property
        public Bitmap Image
        {
            get { return image; }
        }
        // Width property
        public int ImageWidth
        {
            get { return width; }
        }
        // Height property
        public int ImageHeight
        {
            get { return height; }
        }
        // Zoom property
        public float Zoom
        {
            get { return zoom; }
        }
        // FileName property
        // return file name if the document was created from file or null
        public string FileName
        {
            get { return fileName; }
        }


        // Events
        public delegate void SelectionEventHandler( object sender, SelectionEventArgs e );

        public event EventHandler DocumentChanged;
        public event EventHandler ZoomChanged;
        public event SelectionEventHandler MouseImagePosition;
        public event SelectionEventHandler SelectionChanged;


        // Constructors
        private ImageDoc( IDocumentsHost host )
        {
            this.host = host;
        }
        // Construct from file
        public ImageDoc( string fileName, IDocumentsHost host )
            : this( host )
        {
            try
            {
                // load image
                image = (Bitmap) Bitmap.FromFile( fileName );

                // format image
                AForge.Imaging.Image.FormatImage( ref image );

                this.fileName = fileName;
            }
            catch ( Exception )
            {
                throw new ApplicationException( "Failed loading image" );
            }

            Init( );
        }
        // Construct from image
        public ImageDoc( Bitmap image, IDocumentsHost host )
            : this( host )
        {
            this.image = image;
            AForge.Imaging.Image.FormatImage( ref this.image );

            Init( );
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
                if ( image != null )
                {
                    image.Dispose( );
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
            this.imageItem = new System.Windows.Forms.MenuItem();
            this.backImageItem = new System.Windows.Forms.MenuItem();
            this.cloneImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.z10ImageItem = new System.Windows.Forms.MenuItem();
            this.z25ImageItem = new System.Windows.Forms.MenuItem();
            this.z50ImageItem = new System.Windows.Forms.MenuItem();
            this.z75ImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.z100ImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.z150ImageItem = new System.Windows.Forms.MenuItem();
            this.z200ImageItem = new System.Windows.Forms.MenuItem();
            this.z400ImageItem = new System.Windows.Forms.MenuItem();
            this.z500ImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.zoomInImageItem = new System.Windows.Forms.MenuItem();
            this.zoomOutImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.zoomFitImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.flipImageItem = new System.Windows.Forms.MenuItem();
            this.mirrorItem = new System.Windows.Forms.MenuItem();
            this.rotateImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.cropImageItem = new System.Windows.Forms.MenuItem();
            this.filtersItem = new System.Windows.Forms.MenuItem();
            this.colorFiltersItem = new System.Windows.Forms.MenuItem();
            this.grayscaleColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.invertColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.extractRedColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.extractGreenColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.extractRedBlueFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.redColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.greenColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.blueColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.binaryFiltersItem = new System.Windows.Forms.MenuItem();
            this.thresholdBinaryFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.thresholdCarryBinaryFiltersItem = new System.Windows.Forms.MenuItem();
            this.orderedDitherBinaryFiltersItem = new System.Windows.Forms.MenuItem();
            this.bayerDitherBinaryFiltersItem = new System.Windows.Forms.MenuItem();
            this.morphologyFiltersItem = new System.Windows.Forms.MenuItem();
            this.erosionMorphologyFiltersItem = new System.Windows.Forms.MenuItem();
            this.dilatationMorphologyFiltersItem = new System.Windows.Forms.MenuItem();
            this.openingMorphologyFiltersItem = new System.Windows.Forms.MenuItem();
            this.closingMorphologyFiltersItem = new System.Windows.Forms.MenuItem();
            this.convolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.meanConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.blurConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.sharpenConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.edgesConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.customConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.gaussianConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.sharpenExConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.resizeFiltersItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.imageItem,
            this.filtersItem});
            // 
            // imageItem
            // 
            this.imageItem.Index = 0;
            this.imageItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.backImageItem,
            this.cloneImageItem,
            this.menuItem4,
            this.menuItem5,
            this.menuItem10,
            this.flipImageItem,
            this.mirrorItem,
            this.rotateImageItem,
            this.menuItem3,
            this.cropImageItem});
            this.imageItem.MergeOrder = 1;
            this.imageItem.Text = "&Image";
            this.imageItem.Popup += new System.EventHandler(this.imageItem_Popup);
            // 
            // backImageItem
            // 
            this.backImageItem.Index = 0;
            this.backImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.backImageItem.Text = "&Back";
            this.backImageItem.Click += new System.EventHandler(this.backImageItem_Click);
            // 
            // cloneImageItem
            // 
            this.cloneImageItem.Index = 1;
            this.cloneImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.cloneImageItem.Text = "&Clone";
            this.cloneImageItem.Click += new System.EventHandler(this.cloneImageItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.z10ImageItem,
            this.z25ImageItem,
            this.z50ImageItem,
            this.z75ImageItem,
            this.menuItem7,
            this.z100ImageItem,
            this.menuItem6,
            this.z150ImageItem,
            this.z200ImageItem,
            this.z400ImageItem,
            this.z500ImageItem,
            this.menuItem8,
            this.zoomInImageItem,
            this.zoomOutImageItem,
            this.menuItem11,
            this.zoomFitImageItem});
            this.menuItem5.Text = "&Zoom";
            // 
            // z10ImageItem
            // 
            this.z10ImageItem.Index = 0;
            this.z10ImageItem.Text = "10%";
            this.z10ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z25ImageItem
            // 
            this.z25ImageItem.Index = 1;
            this.z25ImageItem.Text = "25%";
            this.z25ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z50ImageItem
            // 
            this.z50ImageItem.Index = 2;
            this.z50ImageItem.Text = "50%";
            this.z50ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z75ImageItem
            // 
            this.z75ImageItem.Index = 3;
            this.z75ImageItem.Text = "75%";
            this.z75ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // z100ImageItem
            // 
            this.z100ImageItem.Index = 5;
            this.z100ImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl0;
            this.z100ImageItem.Text = "100%";
            this.z100ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.Text = "-";
            // 
            // z150ImageItem
            // 
            this.z150ImageItem.Index = 7;
            this.z150ImageItem.Text = "150%";
            this.z150ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z200ImageItem
            // 
            this.z200ImageItem.Index = 8;
            this.z200ImageItem.Text = "200%";
            this.z200ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z400ImageItem
            // 
            this.z400ImageItem.Index = 9;
            this.z400ImageItem.Text = "400%";
            this.z400ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z500ImageItem
            // 
            this.z500ImageItem.Index = 10;
            this.z500ImageItem.Text = "500%";
            this.z500ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 11;
            this.menuItem8.Text = "-";
            // 
            // zoomInImageItem
            // 
            this.zoomInImageItem.Index = 12;
            this.zoomInImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl8;
            this.zoomInImageItem.Text = "Zoom &In";
            this.zoomInImageItem.Click += new System.EventHandler(this.zoomInImageItem_Click);
            // 
            // zoomOutImageItem
            // 
            this.zoomOutImageItem.Index = 13;
            this.zoomOutImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl7;
            this.zoomOutImageItem.Text = "Zoom &Out";
            this.zoomOutImageItem.Click += new System.EventHandler(this.zoomOutImageItem_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 14;
            this.menuItem11.Text = "-";
            // 
            // zoomFitImageItem
            // 
            this.zoomFitImageItem.Index = 15;
            this.zoomFitImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl9;
            this.zoomFitImageItem.Text = "Fit to screen";
            this.zoomFitImageItem.Click += new System.EventHandler(this.zoomFitImageItem_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.Text = "-";
            // 
            // flipImageItem
            // 
            this.flipImageItem.Index = 5;
            this.flipImageItem.Text = "&Flip";
            this.flipImageItem.Click += new System.EventHandler(this.flipImageItem_Click);
            // 
            // mirrorItem
            // 
            this.mirrorItem.Index = 6;
            this.mirrorItem.Text = "&Mirror";
            this.mirrorItem.Click += new System.EventHandler(this.mirrorItem_Click);
            // 
            // rotateImageItem
            // 
            this.rotateImageItem.Index = 7;
            this.rotateImageItem.Text = "&Rotate 90 degree";
            this.rotateImageItem.Click += new System.EventHandler(this.rotateImageItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 8;
            this.menuItem3.Text = "-";
            // 
            // cropImageItem
            // 
            this.cropImageItem.Index = 9;
            this.cropImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.cropImageItem.Text = "Cro&p";
            this.cropImageItem.Click += new System.EventHandler(this.cropImageItem_Click);
            // 
            // filtersItem
            // 
            this.filtersItem.Index = 1;
            this.filtersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.colorFiltersItem,
            this.binaryFiltersItem,
            this.morphologyFiltersItem,
            this.convolutionFiltersItem,
            this.menuItem23,
            this.resizeFiltersItem});
            this.filtersItem.MergeOrder = 1;
            this.filtersItem.Text = "Fi&lters";
            // 
            // colorFiltersItem
            // 
            this.colorFiltersItem.Index = 0;
            this.colorFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.grayscaleColorFiltersItem,
            this.invertColorFiltersItem,
            this.menuItem16,
            this.extractRedColorFiltersItem,
            this.extractGreenColorFiltersItem,
            this.extractRedBlueFiltersItem,
            this.menuItem18,
            this.redColorFiltersItem,
            this.greenColorFiltersItem,
            this.blueColorFiltersItem});
            this.colorFiltersItem.Text = "&Color";
            // 
            // grayscaleColorFiltersItem
            // 
            this.grayscaleColorFiltersItem.Index = 0;
            this.grayscaleColorFiltersItem.Text = "&Grayscale";
            this.grayscaleColorFiltersItem.Click += new System.EventHandler(this.grayscaleColorFiltersItem_Click);
            // 
            // invertColorFiltersItem
            // 
            this.invertColorFiltersItem.Index = 1;
            this.invertColorFiltersItem.Text = "&Invert";
            this.invertColorFiltersItem.Click += new System.EventHandler(this.invertColorFiltersItem_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 2;
            this.menuItem16.Text = "-";
            // 
            // extractRedColorFiltersItem
            // 
            this.extractRedColorFiltersItem.Index = 3;
            this.extractRedColorFiltersItem.Text = "Extract Red Channel";
            this.extractRedColorFiltersItem.Click += new System.EventHandler(this.extractRedColorFiltersItem_Click);
            // 
            // extractGreenColorFiltersItem
            // 
            this.extractGreenColorFiltersItem.Index = 4;
            this.extractGreenColorFiltersItem.Text = "Extract Green Channel";
            this.extractGreenColorFiltersItem.Click += new System.EventHandler(this.extractGreenColorFiltersItem_Click);
            // 
            // extractRedBlueFiltersItem
            // 
            this.extractRedBlueFiltersItem.Index = 5;
            this.extractRedBlueFiltersItem.Text = "Extract Blue Channel";
            this.extractRedBlueFiltersItem.Click += new System.EventHandler(this.extractRedBlueFiltersItem_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 6;
            this.menuItem18.Text = "-";
            // 
            // redColorFiltersItem
            // 
            this.redColorFiltersItem.Index = 7;
            this.redColorFiltersItem.Text = "Red";
            this.redColorFiltersItem.Click += new System.EventHandler(this.redColorFiltersItem_Click);
            // 
            // greenColorFiltersItem
            // 
            this.greenColorFiltersItem.Index = 8;
            this.greenColorFiltersItem.Text = "Green";
            this.greenColorFiltersItem.Click += new System.EventHandler(this.greenColorFiltersItem_Click);
            // 
            // blueColorFiltersItem
            // 
            this.blueColorFiltersItem.Index = 9;
            this.blueColorFiltersItem.Text = "Blue";
            this.blueColorFiltersItem.Click += new System.EventHandler(this.blueColorFiltersItem_Click);
            // 
            // binaryFiltersItem
            // 
            this.binaryFiltersItem.Index = 1;
            this.binaryFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.thresholdBinaryFiltersItem,
            this.menuItem15,
            this.thresholdCarryBinaryFiltersItem,
            this.orderedDitherBinaryFiltersItem,
            this.bayerDitherBinaryFiltersItem});
            this.binaryFiltersItem.Text = "&Binarization";
            // 
            // thresholdBinaryFiltersItem
            // 
            this.thresholdBinaryFiltersItem.Index = 0;
            this.thresholdBinaryFiltersItem.Text = "&Threshold";
            this.thresholdBinaryFiltersItem.Click += new System.EventHandler(this.thresholdBinaryFiltersItem_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "-";
            // 
            // thresholdCarryBinaryFiltersItem
            // 
            this.thresholdCarryBinaryFiltersItem.Index = 2;
            this.thresholdCarryBinaryFiltersItem.Text = "Threshold with Error &Carry";
            this.thresholdCarryBinaryFiltersItem.Click += new System.EventHandler(this.thresholdCarryBinaryFiltersItem_Click);
            // 
            // orderedDitherBinaryFiltersItem
            // 
            this.orderedDitherBinaryFiltersItem.Index = 3;
            this.orderedDitherBinaryFiltersItem.Text = "&Ordered Dither";
            this.orderedDitherBinaryFiltersItem.Click += new System.EventHandler(this.orderedDitherBinaryFiltersItem_Click);
            // 
            // bayerDitherBinaryFiltersItem
            // 
            this.bayerDitherBinaryFiltersItem.Index = 4;
            this.bayerDitherBinaryFiltersItem.Text = "Ba&yer Ordered Dither";
            this.bayerDitherBinaryFiltersItem.Click += new System.EventHandler(this.bayerDitherBinaryFiltersItem_Click);
            // 
            // morphologyFiltersItem
            // 
            this.morphologyFiltersItem.Index = 2;
            this.morphologyFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.erosionMorphologyFiltersItem,
            this.dilatationMorphologyFiltersItem,
            this.openingMorphologyFiltersItem,
            this.closingMorphologyFiltersItem});
            this.morphologyFiltersItem.Text = "&Morphology";
            // 
            // erosionMorphologyFiltersItem
            // 
            this.erosionMorphologyFiltersItem.Index = 0;
            this.erosionMorphologyFiltersItem.Text = "&Erosion";
            this.erosionMorphologyFiltersItem.Click += new System.EventHandler(this.erosionMorphologyFiltersItem_Click);
            // 
            // dilatationMorphologyFiltersItem
            // 
            this.dilatationMorphologyFiltersItem.Index = 1;
            this.dilatationMorphologyFiltersItem.Text = "&Dilatation";
            this.dilatationMorphologyFiltersItem.Click += new System.EventHandler(this.dilatationMorphologyFiltersItem_Click);
            // 
            // openingMorphologyFiltersItem
            // 
            this.openingMorphologyFiltersItem.Index = 2;
            this.openingMorphologyFiltersItem.Text = "&Opening";
            this.openingMorphologyFiltersItem.Click += new System.EventHandler(this.openingMorphologyFiltersItem_Click);
            // 
            // closingMorphologyFiltersItem
            // 
            this.closingMorphologyFiltersItem.Index = 3;
            this.closingMorphologyFiltersItem.Text = "&Closing";
            this.closingMorphologyFiltersItem.Click += new System.EventHandler(this.closingMorphologyFiltersItem_Click);
            // 
            // convolutionFiltersItem
            // 
            this.convolutionFiltersItem.Index = 3;
            this.convolutionFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.meanConvolutionFiltersItem,
            this.blurConvolutionFiltersItem,
            this.sharpenConvolutionFiltersItem,
            this.edgesConvolutionFiltersItem,
            this.menuItem12,
            this.customConvolutionFiltersItem,
            this.menuItem33,
            this.gaussianConvolutionFiltersItem,
            this.sharpenExConvolutionFiltersItem});
            this.convolutionFiltersItem.Text = "Co&nvolution && Correlation";
            // 
            // meanConvolutionFiltersItem
            // 
            this.meanConvolutionFiltersItem.Index = 0;
            this.meanConvolutionFiltersItem.Text = "&Mean";
            this.meanConvolutionFiltersItem.Click += new System.EventHandler(this.meanConvolutionFiltersItem_Click);
            // 
            // blurConvolutionFiltersItem
            // 
            this.blurConvolutionFiltersItem.Index = 1;
            this.blurConvolutionFiltersItem.Text = "&Blur";
            this.blurConvolutionFiltersItem.Click += new System.EventHandler(this.blurConvolutionFiltersItem_Click);
            // 
            // sharpenConvolutionFiltersItem
            // 
            this.sharpenConvolutionFiltersItem.Index = 2;
            this.sharpenConvolutionFiltersItem.Text = "&Sharpen";
            this.sharpenConvolutionFiltersItem.Click += new System.EventHandler(this.sharpenConvolutionFiltersItem_Click);
            // 
            // edgesConvolutionFiltersItem
            // 
            this.edgesConvolutionFiltersItem.Index = 3;
            this.edgesConvolutionFiltersItem.Text = "&Edges";
            this.edgesConvolutionFiltersItem.Click += new System.EventHandler(this.edgesConvolutionFiltersItem_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 4;
            this.menuItem12.Text = "-";
            // 
            // customConvolutionFiltersItem
            // 
            this.customConvolutionFiltersItem.Index = 5;
            this.customConvolutionFiltersItem.Text = "&Custom";
            this.customConvolutionFiltersItem.Click += new System.EventHandler(this.customConvolutionFiltersItem_Click);
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 6;
            this.menuItem33.Text = "-";
            // 
            // gaussianConvolutionFiltersItem
            // 
            this.gaussianConvolutionFiltersItem.Index = 7;
            this.gaussianConvolutionFiltersItem.Text = "&Gaussian";
            this.gaussianConvolutionFiltersItem.Click += new System.EventHandler(this.gaussianConvolutionFiltersItem_Click);
            // 
            // sharpenExConvolutionFiltersItem
            // 
            this.sharpenExConvolutionFiltersItem.Index = 8;
            this.sharpenExConvolutionFiltersItem.Text = "Sharpen Ex";
            this.sharpenExConvolutionFiltersItem.Click += new System.EventHandler(this.sharpenExConvolutionFiltersItem_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 4;
            this.menuItem23.Text = "-";
            // 
            // resizeFiltersItem
            // 
            this.resizeFiltersItem.Index = 5;
            this.resizeFiltersItem.Text = "&Resize";
            this.resizeFiltersItem.Click += new System.EventHandler(this.resizeFiltersItem_Click);
            // 
            // ImageDoc
            // 
            this.AllowedStates = WeifenLuo.WinFormsUI.ContentStates.Document;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(528, 417);
            this.Menu = this.mainMenu;
            this.Name = "ImageDoc";
            this.Text = "Image";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseDown);
            this.MouseLeave += new System.EventHandler(this.ImageDoc_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseUp);
            this.ResumeLayout(false);

        }
        #endregion

        // Init the document
        private void Init( )
        {
            // init components
            InitializeComponent( );

            // form style
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true );

            // init scroll bars
            this.AutoScroll = true;

            UpdateSize( );
        }

        // Execute command
        public void ExecuteCommand( ImageDocCommands cmd )
        {
            switch ( cmd )
            {
                case ImageDocCommands.Clone:		// clone the image
                    Clone( );
                    break;
                case ImageDocCommands.Crop:			// crop the image
                    Crop( );
                    break;
                case ImageDocCommands.ZoomIn:		// zoom in
                    ZoomIn( );
                    break;
                case ImageDocCommands.ZoomOut:		// zoom out
                    ZoomOut( );
                    break;
                case ImageDocCommands.ZoomOriginal:	// original size
                    zoom = 1;
                    UpdateZoom( );
                    break;
                case ImageDocCommands.FitToSize:	// fit to screen
                    FitToScreen( );
                    break;              
                case ImageDocCommands.Grayscale:	// grayscale
                    Grayscale( );
                    break;
                case ImageDocCommands.Threshold:	// threshold
                    Threshold( );
                    break;
                case ImageDocCommands.Morphology:	// morphology
                    Morphology( );
                    break;
                case ImageDocCommands.Convolution:	// convolution
                    Convolution( );
                    break;
                case ImageDocCommands.Resize:		// resize the image
                    ResizeImage( );
                    break;               
            }
        }

        // Update document and notify client about changes
        private void UpdateNewImage( )
        {
            // update size
            UpdateSize( );
            // repaint
            Invalidate( );

            // notify host
            if ( DocumentChanged != null )
                DocumentChanged( this, null );
        }

        // Reload image from file
        public void Reload( )
        {
            if ( fileName != null )
            {
                try
                {
                    // load image
                    Bitmap newImage = (Bitmap) Bitmap.FromFile( fileName );

                    // Release current image
                    image.Dispose( );
                    // set document image to just loaded
                    image = newImage;

                    // format image
                    AForge.Imaging.Image.FormatImage( ref image );
                }
                catch ( Exception )
                {
                    throw new ApplicationException( "Failed reloading image" );
                }

                // update
                UpdateNewImage( );
            }
        }

        // Center image in the document
        public void Center( )
        {
            Rectangle rc = ClientRectangle;
            Point p = this.AutoScrollPosition;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );

            if ( rc.Width < width )
                p.X = ( width - rc.Width ) >> 1;
            if ( rc.Height < height )
                p.Y = ( height - rc.Height ) >> 1;

            this.AutoScrollPosition = p;
        }

        // Update document size 
        private void UpdateSize( )
        {
            // image dimension
            width = image.Width;
            height = image.Height;

            // scroll bar size
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
        }

        // Paint image
        protected override void OnPaint( PaintEventArgs e )
        {
            if ( image != null )
            {
                Graphics g = e.Graphics;
                Rectangle rc = ClientRectangle;
                Pen pen = new Pen( Color.FromArgb( 0, 0, 0 ) );

                int width = (int) ( this.width * zoom );
                int height = (int) ( this.height * zoom );
                int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                // draw rectangle around the image
                g.DrawRectangle( pen, x - 1, y - 1, width + 1, height + 1 );

                // set nearest neighbor interpolation to avoid image smoothing
                g.InterpolationMode = InterpolationMode.NearestNeighbor;

                // draw image
                g.DrawImage( image, x, y, width, height );

                pen.Dispose( );
            }
        }

        // Mouse click
        protected override void OnClick( EventArgs e )
        {
            Focus( );
        }

        // Apply filter on the image
        private void ApplyFilter( IFilter filter )
        {
            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply( image );

                if ( host.CreateNewDocumentOnChange )
                {
                    // open new image in new document
                    host.NewDocument( newImage );
                }
                else
                {
                    if ( host.RememberOnChange )
                    {
                        // backup current image
                        if ( backup != null )
                            backup.Dispose( );

                        backup = image;
                    }
                    else
                    {
                        // release current image
                        image.Dispose( );
                    }

                    image = newImage;

                    // update
                    UpdateNewImage( );
                }
            }
            catch ( ArgumentException )
            {
                MessageBox.Show( "Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }

        // on "Image" item popup
        private void imageItem_Popup( object sender, System.EventArgs e )
        {
            this.backImageItem.Enabled = ( backup != null );
            this.cropImageItem.Checked = cropping;
        }

        // Restore image to previous
        private void backImageItem_Click( object sender, System.EventArgs e )
        {
            if ( backup != null )
            {
                // release current image
                image.Dispose( );
                // restore
                image = backup;
                backup = null;

                // update
                UpdateNewImage( );
            }
        }

        // Clone the image
        private void Clone( )
        {
            if ( host != null )
            {
                Bitmap clone = AForge.Imaging.Image.Clone( image );

                if ( !host.NewDocument( clone ) )
                {
                    clone.Dispose( );
                }
            }
        }

        // On "Image->Clone" item click
        private void cloneImageItem_Click( object sender, System.EventArgs e )
        {
            Clone( );
        }

        // Update zoom factor
        private void UpdateZoom( )
        {
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
            this.Invalidate( );

            // notify host
            if ( ZoomChanged != null )
                ZoomChanged( this, null );
        }

        // Zoom image
        private void zoomItem_Click( object sender, System.EventArgs e )
        {
            // get menu item text
            String t = ( (MenuItem) sender ).Text;
            // parse it`s value
            int i = int.Parse( t.Remove( t.Length - 1, 1 ) );
            // calc zoom factor
            zoom = (float) i / 100;

            UpdateZoom( );
        }

        // Zoom In image
        private void ZoomIn( )
        {
            float z = zoom * 1.5f;

            if ( z <= 10 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom In" item click
        private void zoomInImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomIn( );
        }

        // Zoom Out image
        private void ZoomOut( )
        {
            float z = zoom / 1.5f;

            if ( z >= 0.05 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom out" item click
        private void zoomOutImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomOut( );
        }

        // Fit to size
        private void FitToScreen( )
        {
            Rectangle rc = ClientRectangle;

            zoom = Math.Min( (float) rc.Width / ( width + 2 ), (float) rc.Height / ( height + 2 ) );

            UpdateZoom( );
        }

        // On "Image->Zoom->Fit To Screen" item click
        private void zoomFitImageItem_Click( object sender, System.EventArgs e )
        {
            FitToScreen( );
        }

        // Flip image
        private void flipImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipY );

            Invalidate( );
        }

        // Mirror image
        private void mirrorItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipX );

            Invalidate( );
        }

        // Rotate image 90 degree
        private void rotateImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.Rotate90FlipNone );

            // update
            UpdateNewImage( );
        }

        // Invert image
        private void invertColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Invert( ) );
        }

        // Rotatet colors
        private void rotateColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new RotateChannels( ) );
        }

        // Sepia image
        private void sepiaColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sepia( ) );
        }

        // Grayscale image
        private void Grayscale( )
        {
            if ( image.PixelFormat == PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "The image is already grayscale", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }
            ApplyFilter( new GrayscaleBT709( ) );
        }

        // On "Filter->Color->Grayscale"
        private void grayscaleColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            Grayscale( );
        }

        // Converts grayscale image to RGB
        private void toRgbColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat == PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "The image is already RGB", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }
            ApplyFilter( new GrayscaleToRGB( ) );
        }

        // Remove green and blue channels
        private void redColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 0 ), new IntRange( 0, 0 ) ) );
        }

        // Remove red and blue channels
        private void greenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 255 ), new IntRange( 0, 0 ) ) );
        }

        // Remove red and green channels
        private void blueColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 0 ), new IntRange( 0, 255 ) ) );
        }

        // Remove green channel
        private void cyanColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 255 ), new IntRange( 0, 255 ) ) );
        }

        // Remove green channel
        private void magentaColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 0 ), new IntRange( 0, 255 ) ) );
        }

        // Remove blue channel
        private void yellowColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 255 ), new IntRange( 0, 0 ) ) );
        }

       
              // Extract red channel of image
        private void extractRedColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.R ) );
        }

        // Extract green channel of image
        private void extractGreenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.G ) );
        }

        // Extract blue channel of image
        private void extractRedBlueFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.B ) );
        }

        // Replace red channel
        private void replaceRedColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the red channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.R, channelImage ) );
        }

        // Replace green channel
        private void replaceGreenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the green channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.G, channelImage ) );
        }

        // Replace blue channel
        private void replaceBlueColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the blue channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.B, channelImage ) );
        }

      
        // Extract Y channel of YCbCr color space
        private void extracYFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.YIndex ) );
        }

        // Extract Cb channel of YCbCr color space
        private void extracCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CbIndex ) );
        }

        // Extract Cr channel of YCbCr color space
        private void extracCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CrIndex ) );
        }

        // Replace Y channel of YCbCr color space
        private void replaceYFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Y channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.YIndex, channelImage ) );
        }

        // Replace Cb channel of YCbCr color space
        private void replaceCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cb channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CbIndex, channelImage ) );
        }

        // Replace Cr channel of YCbCr color space
        private void replaceCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cr channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CrIndex, channelImage ) );
        }

        // Threshold binarization
        private void Threshold( )
        {
            ThresholdForm form = new ThresholdForm( );

            // set image to preview
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Binarization->Threshold" menu item click
        private void thresholdBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            Threshold( );
        }

        // Threshold binarization with carry
        private void thresholdCarryBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ThresholdWithCarry( ) );
        }

        // Ordered dithering
        private void orderedDitherBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new OrderedDithering( ) );
        }

        // Bayer ordered dithering
        private void bayerDitherBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new BayerDithering( ) );
        }

        // Binarization using Floyd-Steinverg dithering algorithm
        private void floydBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new FloydSteinbergDithering( ) );
        }

        // Binarization using Burkes dithering algorithm
        private void burkesBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new BurkesDithering( ) );
        }

        // Binarization using Stucki dithering algorithm
        private void stuckiBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new StuckiDithering( ) );
        }

        // Binarization using Jarvis, Judice and Ninke dithering algorithm
        private void jarvisBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new JarvisJudiceNinkeDithering( ) );
        }

        // Binarization using Sierra dithering algorithm
        private void sierraBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SierraDithering( ) );
        }

        // Binarization using Stevenson and Arce dithering algorithm
        private void stevensonBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new StevensonArceDithering( ) );
        }

        // Threshold using Simple Image Statistics
        private void sisThresholdBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SISThreshold( ) );
        }

        // Errosion (Mathematical Morphology)
        private void erosionMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Erosion( ) );
        }

        // Dilatation (Mathematical Morphology)
        private void dilatationMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Dilatation( ) );
        }

        // Opening (Mathematical Morphology)
        private void openingMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Opening( ) );
        }

        // Closing (Mathematical Morphology)
        private void closingMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Closing( ) );
        }

        // Custom morphology operator
        private void Morphology( )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Mathematical morpholgy filters can by applied to grayscale image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.Simple );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Morphology->Custom" menu item click
        private void customMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            Morphology( );
        }

        // Hit & Miss mathematical morphology operator
        private void hitAndMissFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Hit & Miss morpholgy filters can by applied to binary image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.HitAndMiss );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Mean
        private void meanConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Mean( ) );
        }

        // Blur
        private void blurConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Blur( ) );
        }

        // Gaussian smoothing
        private void gaussianConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            GaussianForm form = new GaussianForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extended sharpening
        private void sharpenExConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            SharpenExForm form = new SharpenExForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Sharpen
        private void sharpenConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sharpen( ) );
        }

        // Edges
        private void edgesConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Edges( ) );
        }

        // Custom convolution filter
        private void Convolution( )
        {
            ConvolutionForm form = new ConvolutionForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Convolution & Correlation->Custom" menu item click
        private void customConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            Convolution( );
        }

        
        // Move towards
        private void moveTowardsTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to which the curren image will be moved", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new MoveTowards( overlayImage, 10 ) );
        }

      
        // Conservative smoothing
        private void conservativeSmoothingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ConservativeSmoothing( ) );
        }

       
        // Resize the image
        private void ResizeImage( )
        {
            ResizeForm form = new ResizeForm( );

            form.OriginalSize = new Size( width, height );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Resize" menu item click
        private void resizeFiltersItem_Click( object sender, System.EventArgs e )
        {
            ResizeImage( );
        }

        // Median filter
        private void medianFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Median( ) );
        }

        // Fourier transformation
        private void ForwardFourierTransformation( )
        {
            System.Diagnostics.Debug.WriteLine( (int) FourierTransform.Direction.Forward );
            System.Diagnostics.Debug.WriteLine( (int) FourierTransform.Direction.Backward );

            if ( ( !AForge.Math.Tools.IsPowerOf2( width ) ) ||
                ( !AForge.Math.Tools.IsPowerOf2( height ) ) )
            {
                MessageBox.Show( "Fourier trasformation can be applied to an image with width and height of power of 2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ComplexImage cImage = ComplexImage.FromBitmap( image );

            cImage.ForwardFourierTransform( );
            host.NewDocument( cImage );
        }

        // On "Filters->Fourier Transformation" click
        private void fourierFiltersItem_Click( object sender, System.EventArgs e )
        {
            ForwardFourierTransformation( );
        }

        // Calculate image and screen coordinates of the point
        private void GetImageAndScreenPoints( Point point, out Point imgPoint, out Point screenPoint )
        {
            Rectangle rc = this.ClientRectangle;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );
            int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
            int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

            int ix = Math.Min( Math.Max( x, point.X ), x + width - 1 );
            int iy = Math.Min( Math.Max( y, point.Y ), y + height - 1 );

            ix = (int) ( ( ix - x ) / zoom );
            iy = (int) ( ( iy - y ) / zoom );

            // image point
            imgPoint = new Point( ix, iy );
            // screen point
            screenPoint = this.PointToScreen( new Point( (int) ( ix * zoom + x ), (int) ( iy * zoom + y ) ) );
        }

        // Normalize points so, that pt1 becomes top-left point of rectangle
        // and pt2 becomes right-bottom
        private void NormalizePoints( ref Point pt1, ref Point pt2 )
        {
            Point t1 = pt1;
            Point t2 = pt2;

            pt1.X = Math.Min( t1.X, t2.X );
            pt1.Y = Math.Min( t1.Y, t2.Y );
            pt2.X = Math.Max( t1.X, t2.X );
            pt2.Y = Math.Max( t1.Y, t2.Y );
        }

        // Draw selection rectangle
        private void DrawSelectionFrame( Graphics g )
        {
            Point sp = startW;
            Point ep = endW;

            // Normalize points
            NormalizePoints( ref sp, ref ep );
            // Draw reversible frame
            ControlPaint.DrawReversibleFrame( new Rectangle( sp.X, sp.Y, ep.X - sp.X + 1, ep.Y - sp.Y + 1 ), Color.White, FrameStyle.Dashed );
        }

        // Crop the image
        private void Crop( )
        {
            if ( !cropping )
            {
                // turn on
                cropping = true;
                this.Cursor = Cursors.Cross;

            }
            else
            {
                // turn off
                cropping = false;
                this.Cursor = Cursors.Default;
            }
        }

        // On "Image->Crop" - turn on/off cropping mode
        private void cropImageItem_Click( object sender, System.EventArgs e )
        {
            Crop( );
        }

        // On mouse down
        private void ImageDoc_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
            {
                // turn off cropping mode
                if ( !dragging )
                {
                    cropping = false;
                    this.Cursor = Cursors.Default;
                }
            }
            else if ( e.Button == MouseButtons.Left )
            {
                if ( cropping )
                {
                    // start dragging
                    dragging = true;
                    // set mouse capture
                    this.Capture = true;

                    // get selection start point
                    GetImageAndScreenPoints( new Point( e.X, e.Y ), out start, out startW );

                    // end point is the same as start
                    end = start;
                    endW = startW;

                    // draw frame
                    Graphics g = this.CreateGraphics( );
                    DrawSelectionFrame( g );
                    g.Dispose( );
                }
            }
        }

        // On mouse up
        private void ImageDoc_MouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( dragging )
            {
                // stop dragging and cropping
                dragging = cropping = false;
                // release capture
                this.Capture = false;
                // set default mouse pointer
                this.Cursor = Cursors.Default;

                // erase frame
                Graphics g = this.CreateGraphics( );
                DrawSelectionFrame( g );
                g.Dispose( );

                // normalize start and end points
                NormalizePoints( ref start, ref end );

                // crop tge image
                ApplyFilter( new Crop( new Rectangle( start.X, start.Y, end.X - start.X + 1, end.Y - start.Y + 1 ) ) );
            }
        }

        // On mouse move
        private void ImageDoc_MouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( dragging )
            {

                Graphics g = this.CreateGraphics( );

                // erase frame
                DrawSelectionFrame( g );

                // get selection end point
                GetImageAndScreenPoints( new Point( e.X, e.Y ), out end, out endW );

                // draw frame
                DrawSelectionFrame( g );

                g.Dispose( );

                if ( SelectionChanged != null )
                {
                    Point sp = start;
                    Point ep = end;

                    // normalize start and end points
                    NormalizePoints( ref sp, ref ep );

                    SelectionChanged( this, new SelectionEventArgs(
                        sp, new Size( ep.X - sp.X + 1, ep.Y - sp.Y + 1 ) ) );
                }
            }
            else
            {
                if ( MouseImagePosition != null )
                {
                    Rectangle rc = this.ClientRectangle;
                    int width = (int) ( this.width * zoom );
                    int height = (int) ( this.height * zoom );
                    int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                    int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                    if ( ( e.X >= x ) && ( e.Y >= y ) &&
                        ( e.X < x + width ) && ( e.Y < y + height ) )
                    {
                        // mouse is over the image
                        MouseImagePosition( this, new SelectionEventArgs(
                            new Point( (int) ( ( e.X - x ) / zoom ), (int) ( ( e.Y - y ) / zoom ) ) ) );
                    }
                    else
                    {
                        // mouse is outside image region
                        MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
                    }
                }
            }
        }

        // On mouse leave
        private void ImageDoc_MouseLeave( object sender, System.EventArgs e )
        {
            if ( ( !dragging ) && ( MouseImagePosition != null ) )
            {
                MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
            }
        }

        private void rotateFiltersItem_Click(object sender, EventArgs e)
        {

        }
    }

    // Selection arguments
    public class SelectionEventArgs : EventArgs
    {
        private Point location;
        private Size size;

        // Constructors
        public SelectionEventArgs( Point location )
        {
            this.location = location;
        }
        public SelectionEventArgs( Point location, Size size )
        {
            this.location = location;
            this.size = size;
        }

        // Location property
        public Point Location
        {
            get { return location; }
        }
        // Size property
        public Size Size
        {
            get { return size; }
        }
    }

    // Commands
    public enum ImageDocCommands
    {
        Clone,
        Crop,
        ZoomIn,
        ZoomOut,
        ZoomOriginal,
        FitToSize,
        Grayscale,
        Threshold,
        Morphology,
        Convolution,
        Resize
    }
}
