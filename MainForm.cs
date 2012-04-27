using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using WeifenLuo.WinFormsUI;
using rpaulo.toolbar;
using AForge.Imaging;

namespace BaicImageProcessModule
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form, IDocumentsHost
	{
		private static string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app.config");
		private static string dockManagerConfigFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockManager.config");

		private int unnamedNumber = 0;
		private Configuration config = new Configuration();

        #region System Windows Forms
        private WeifenLuo.WinFormsUI.DockManager dockManager;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem fileItem;
		private System.Windows.Forms.MenuItem exitFileItem;
        private System.Windows.Forms.MenuItem OpenItem;
		private System.Windows.Forms.MenuItem closeFileItem;
        private System.Windows.Forms.MenuItem closeAllFileItem;
        private System.Windows.Forms.MenuItem windowItem;
		private System.Windows.Forms.StatusBarPanel zoomPanel;
		private System.Windows.Forms.StatusBarPanel sizePanel;
		private System.Windows.Forms.StatusBarPanel infoPanel;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem reloadFileItem;
		private System.Windows.Forms.StatusBarPanel selectionPanel;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.StatusBarPanel colorPanel;
        private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolBar imageToolBar;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ToolBarButton cloneButton;
		private System.Windows.Forms.ToolBarButton cropButton;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton zoomInButton;
		private System.Windows.Forms.ToolBarButton zoomOutButton;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton fitToScreenButton;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton levelsButton;
		private System.Windows.Forms.ToolBarButton grayscaleButton;
		private System.Windows.Forms.ToolBarButton thresholdButton;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton morphologyButton;
        private System.Windows.Forms.ToolBarButton convolutionButton;
		private System.Windows.Forms.ToolBarButton resizeButton;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton rotateButton;
		private System.Windows.Forms.StatusBarPanel hslPanel;
		private System.Windows.Forms.ToolBarButton toolBarButton8;
		private System.Windows.Forms.ToolBarButton saturationButton;
		private System.Windows.Forms.ToolBarButton fourierButton;
		private System.Windows.Forms.MenuItem copyFileItem;
		private System.Windows.Forms.MenuItem pasteFileItem;
		private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem saveFileItem;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.StatusBarPanel ycbcrPanel;
		private System.ComponentModel.IContainer components;
        #endregion
        public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileItem = new System.Windows.Forms.MenuItem();
            this.OpenItem = new System.Windows.Forms.MenuItem();
            this.reloadFileItem = new System.Windows.Forms.MenuItem();
            this.saveFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.copyFileItem = new System.Windows.Forms.MenuItem();
            this.pasteFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.closeFileItem = new System.Windows.Forms.MenuItem();
            this.closeAllFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.exitFileItem = new System.Windows.Forms.MenuItem();
            this.windowItem = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.zoomPanel = new System.Windows.Forms.StatusBarPanel();
            this.sizePanel = new System.Windows.Forms.StatusBarPanel();
            this.selectionPanel = new System.Windows.Forms.StatusBarPanel();
            this.colorPanel = new System.Windows.Forms.StatusBarPanel();
            this.hslPanel = new System.Windows.Forms.StatusBarPanel();
            this.ycbcrPanel = new System.Windows.Forms.StatusBarPanel();
            this.infoPanel = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dockManager = new WeifenLuo.WinFormsUI.DockManager();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageToolBar = new System.Windows.Forms.ToolBar();
            this.cloneButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.cropButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.zoomInButton = new System.Windows.Forms.ToolBarButton();
            this.zoomOutButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.fitToScreenButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.resizeButton = new System.Windows.Forms.ToolBarButton();
            this.rotateButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.levelsButton = new System.Windows.Forms.ToolBarButton();
            this.grayscaleButton = new System.Windows.Forms.ToolBarButton();
            this.thresholdButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.morphologyButton = new System.Windows.Forms.ToolBarButton();
            this.convolutionButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.saturationButton = new System.Windows.Forms.ToolBarButton();
            this.fourierButton = new System.Windows.Forms.ToolBarButton();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hslPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileItem,
            this.windowItem});
            // 
            // fileItem
            // 
            this.fileItem.Index = 0;
            this.fileItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.OpenItem,
            this.reloadFileItem,
            this.saveFileItem,
            this.menuItem1,
            this.copyFileItem,
            this.pasteFileItem,
            this.menuItem5,
            this.closeFileItem,
            this.closeAllFileItem,
            this.menuItem8,
            this.exitFileItem});
            this.fileItem.Text = "&File";
            this.fileItem.Popup += new System.EventHandler(this.fileItem_Popup);
            // 
            // OpenItem
            // 
            this.OpenItem.Index = 0;
            this.OpenItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.OpenItem.Text = "&Open";
            this.OpenItem.Click += new System.EventHandler(this.OpenItem_Click);
            // 
            // reloadFileItem
            // 
            this.reloadFileItem.Index = 1;
            this.reloadFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.reloadFileItem.Text = "&Reload";
            this.reloadFileItem.Click += new System.EventHandler(this.reloadFileItem_Click);
            // 
            // saveFileItem
            // 
            this.saveFileItem.Index = 2;
            this.saveFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.saveFileItem.Text = "&Save";
            this.saveFileItem.Click += new System.EventHandler(this.saveFileItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // copyFileItem
            // 
            this.copyFileItem.Index = 4;
            this.copyFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.copyFileItem.Text = "&Copy";
            this.copyFileItem.Click += new System.EventHandler(this.copyFileItem_Click);
            // 
            // pasteFileItem
            // 
            this.pasteFileItem.Index = 5;
            this.pasteFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.pasteFileItem.Text = "&Paste";
            this.pasteFileItem.Click += new System.EventHandler(this.pasteFileItem_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.Text = "-";
            // 
            // closeFileItem
            // 
            this.closeFileItem.Index = 7;
            this.closeFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            this.closeFileItem.Text = "C&lose";
            this.closeFileItem.Click += new System.EventHandler(this.closeFileItem_Click);
            // 
            // closeAllFileItem
            // 
            this.closeAllFileItem.Index = 8;
            this.closeAllFileItem.Text = "Close All";
            this.closeAllFileItem.Click += new System.EventHandler(this.closeAllFileItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 9;
            this.menuItem8.Text = "-";
            // 
            // exitFileItem
            // 
            this.exitFileItem.Index = 10;
            this.exitFileItem.Text = "E&xit";
            this.exitFileItem.Click += new System.EventHandler(this.exitFileItem_Click);
            // 
            // windowItem
            // 
            //this.windowItem.Index = 2;
            this.windowItem.MdiList = true;
            this.windowItem.MergeOrder = 3;
            this.windowItem.Text = "&Window";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 509);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.zoomPanel,
            this.sizePanel,
            this.selectionPanel,
            this.colorPanel,
            this.hslPanel,
            this.ycbcrPanel,
            this.infoPanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(792, 24);
            this.statusBar.TabIndex = 1;
            // 
            // zoomPanel
            // 
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.ToolTipText = "Zoom coefficient";
            this.zoomPanel.Width = 50;
            // 
            // sizePanel
            // 
            this.sizePanel.Name = "sizePanel";
            this.sizePanel.ToolTipText = "Image size";
            // 
            // selectionPanel
            // 
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.ToolTipText = "Current point and selection size";
            this.selectionPanel.Width = 120;
            // 
            // colorPanel
            // 
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.ToolTipText = "Current color";
            this.colorPanel.Width = 110;
            // 
            // hslPanel
            // 
            this.hslPanel.Name = "hslPanel";
            this.hslPanel.Width = 130;
            // 
            // ycbcrPanel
            // 
            this.ycbcrPanel.Name = "ycbcrPanel";
            this.ycbcrPanel.Width = 145;
            // 
            // infoPanel
            // 
            this.infoPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dockManager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 509);
            this.panel1.TabIndex = 2;
            // 
            // dockManager
            // 
            this.dockManager.ActiveAutoHideContent = null;
            this.dockManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockManager.Location = new System.Drawing.Point(0, 0);
            this.dockManager.Name = "dockManager";
            this.dockManager.Size = new System.Drawing.Size(792, 509);
            this.dockManager.TabIndex = 2;
            this.dockManager.ActiveDocumentChanged += new System.EventHandler(this.dockManager_ActiveDocumentChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            // 
            // imageToolBar
            // 
            this.imageToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.imageToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cloneButton,
            this.toolBarButton1,
            this.cropButton,
            this.toolBarButton2,
            this.zoomInButton,
            this.zoomOutButton,
            this.toolBarButton3,
            this.fitToScreenButton,
            this.toolBarButton5,
            this.resizeButton,
            this.rotateButton,
            this.toolBarButton7,
            this.levelsButton,
            this.grayscaleButton,
            this.thresholdButton,
            this.toolBarButton6,
            this.morphologyButton,
            this.convolutionButton,
            this.toolBarButton8,
            this.saturationButton,
            this.fourierButton});
            this.imageToolBar.Divider = false;
            this.imageToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.imageToolBar.DropDownArrows = true;
            this.imageToolBar.ImageList = this.imageList2;
            this.imageToolBar.Location = new System.Drawing.Point(0, 507);
            this.imageToolBar.Name = "imageToolBar";
            this.imageToolBar.ShowToolTips = true;
            this.imageToolBar.Size = new System.Drawing.Size(566, 26);
            this.imageToolBar.TabIndex = 3;
            this.imageToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.imageToolBar_ButtonClick);
            // 
            // cloneButton
            // 
            this.cloneButton.ImageIndex = 0;
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.ToolTipText = "Clone the image";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // cropButton
            // 
            this.cropButton.ImageIndex = 1;
            this.cropButton.Name = "cropButton";
            this.cropButton.ToolTipText = "Crop image";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // zoomInButton
            // 
            this.zoomInButton.ImageIndex = 2;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.ToolTipText = "Zoom In";
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.ImageIndex = 3;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.ToolTipText = "Zoom out";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 4;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.ToolTipText = "Original size";
            // 
            // fitToScreenButton
            // 
            this.fitToScreenButton.ImageIndex = 5;
            this.fitToScreenButton.Name = "fitToScreenButton";
            this.fitToScreenButton.ToolTipText = "Fit to window size";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // resizeButton
            // 
            this.resizeButton.ImageIndex = 11;
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.ToolTipText = "Resize the image";
            // 
            // rotateButton
            // 
            this.rotateButton.ImageIndex = 12;
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.ToolTipText = "Rotate the image";
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // levelsButton
            // 
            this.levelsButton.ImageIndex = 6;
            this.levelsButton.Name = "levelsButton";
            this.levelsButton.ToolTipText = "Levels correction";
            // 
            // grayscaleButton
            // 
            this.grayscaleButton.ImageIndex = 7;
            this.grayscaleButton.Name = "grayscaleButton";
            this.grayscaleButton.ToolTipText = "Grayscale";
            // 
            // thresholdButton
            // 
            this.thresholdButton.ImageIndex = 8;
            this.thresholdButton.Name = "thresholdButton";
            this.thresholdButton.ToolTipText = "Threshold";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // morphologyButton
            // 
            this.morphologyButton.ImageIndex = 9;
            this.morphologyButton.Name = "morphologyButton";
            this.morphologyButton.ToolTipText = "Custom morphology operator";
            // 
            // convolutionButton
            // 
            this.convolutionButton.ImageIndex = 10;
            this.convolutionButton.Name = "convolutionButton";
            this.convolutionButton.ToolTipText = "Custom convolution operator";
            // 
            // toolBarButton8
            // 
            this.toolBarButton8.Name = "toolBarButton8";
            this.toolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // saturationButton
            // 
            this.saturationButton.ImageIndex = 13;
            this.saturationButton.Name = "saturationButton";
            this.saturationButton.ToolTipText = "Saturation (HSL)";
            // 
            // fourierButton
            // 
            this.fourierButton.ImageIndex = 14;
            this.fourierButton.Name = "fourierButton";
            this.fourierButton.ToolTipText = "Fourier Transformation";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            // 
            // ofd
            // 
            this.ofd.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
    "es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
    "p)|*.bmp|GIF files (*.gif)|*.gif";
            this.ofd.Title = "Open image";
            // 
            // sfd
            // 
            this.sfd.Filter = "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp";
            this.sfd.Title = "Save image";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(792, 533);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.imageToolBar);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Processing Lab";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hslPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		#region IDocumentsHost implementation

		// Create new document on change on existent or modify it
		public bool CreateNewDocumentOnChange
		{
			get { return config.openInNewDoc; }
		}

		// Remember or not an image, so we can back one step
		public bool RememberOnChange
		{
			get { return config.rememberOnChange; }
		}

		// Create new document
		public bool NewDocument(Bitmap image)
		{
			unnamedNumber++;

			ImageDoc imgDoc = new ImageDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unnamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			// set events
			SetupDocumentEvents(imgDoc);

			return true;
		}


		#endregion

		// On form closing
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// close all files
			foreach (Content c in dockManager.Documents)
				c.Close();

			// save configuration
			config.mainWindowLocation = this.Location;
			config.mainWindowSize = this.Size;
			config.Save(configFile);
			// save dock manager configuration
			dockManager.SaveAsXml(dockManagerConfigFile);
		}

		

		// Main tool bar clicked
		private void mainToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.ImageIndex)
			{
				case 0:		// open an image
					OpenFile();
					break;
				case 1:		// save file
					SaveFile();
					break;
				case 2:		// copy
					CopyToClipboard();
					break;
				case 3:		// paste
					PasteFromClipboard();
					break;
				
			}
		}

		// active document changed
		private void dockManager_ActiveDocumentChanged(object sender, System.EventArgs e)
		{
			Content		doc = dockManager.ActiveDocument;
			ImageDoc	imgDoc = (doc is ImageDoc) ? (ImageDoc) doc : null;

			UpdateZoomStatus(imgDoc);

			UpdateSizeStatus(doc);
		}

		
		// on File item popum - set state ot child menu items
		private void fileItem_Popup(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;
			bool	docOpened = (doc != null);

			closeFileItem.Enabled = docOpened;
			closeAllFileItem.Enabled = (dockManager.Documents.Length > 0);
			reloadFileItem.Enabled = ((docOpened) && (doc is ImageDoc) && (((ImageDoc) doc).FileName != null));

			saveFileItem.Enabled = docOpened;
			copyFileItem.Enabled = docOpened;
			pasteFileItem.Enabled = (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap));

			
		}

		// Exit application
		private void exitFileItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		// Setup events
		private void SetupDocumentEvents(ImageDoc doc)
		{
			
			doc.ZoomChanged += new System.EventHandler(this.document_ZoomChanged);
			doc.MouseImagePosition += new ImageDoc.SelectionEventHandler(this.document_MouseImagePosition);
			doc.SelectionChanged += new ImageDoc.SelectionEventHandler(this.document_SelectionChanged);
		}

		// Open file
		private void OpenFile()
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				ImageDoc imgDoc = null;
				
				try
				{
					// create image document
					imgDoc = new ImageDoc(ofd.FileName, (IDocumentsHost) this);
					imgDoc.Text = Path.GetFileName(ofd.FileName);

				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				if (imgDoc != null)
				{
					imgDoc.Show(dockManager);
					imgDoc.Focus();

					// set events
					SetupDocumentEvents(imgDoc);
				}
			}		
		}


		// On "File->Open" item clicked
		private void OpenItem_Click(object sender, System.EventArgs e)
		{
			OpenFile();
		}

		// Reload file
		private void reloadFileItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
			{
				try
				{
					((ImageDoc) doc).Reload();
				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Save file
		private void SaveFile()
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				// set initial file name
				if ((doc is ImageDoc) && (((ImageDoc) doc).FileName != null))
				{
					sfd.FileName = Path.GetFileName(((ImageDoc) doc).FileName);
				}
				else
				{
					sfd.FileName = doc.Text + ".jpg";
				}

				sfd.FilterIndex = 0;

				// show dialog
				if (sfd.ShowDialog(this) == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Jpeg;

					// resolve file format
					switch (Path.GetExtension(sfd.FileName).ToLower())
					{
						case ".jpg":
							format = ImageFormat.Jpeg;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
						default:
							MessageBox.Show(this, "Unsupported image format was specified", "Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
					}

					// save the image
					try
					{
						if (doc is ImageDoc)
						{
							((ImageDoc) doc).Image.Save(sfd.FileName, format);
						}
				
					}
					catch (Exception)
					{
						MessageBox.Show(this, "Failed writing image file", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		// On "File->Save" - save the file
		private void saveFileItem_Click(object sender, System.EventArgs e)
		{
			SaveFile();
		}

		// Copy image to clipboard
		private void CopyToClipboard()
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					Clipboard.SetDataObject(((ImageDoc) doc).Image, true);
				}
			
			}
		}

		// On "File->Copy" - copy image to clipboard
		private void copyFileItem_Click(object sender, System.EventArgs e)
		{
			CopyToClipboard();
		}

		// Paste image from clipboard
		private void PasteFromClipboard()
		{
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
			{
				ImageDoc imgDoc = new ImageDoc((Bitmap) Clipboard.GetDataObject().GetData(DataFormats.Bitmap), (IDocumentsHost) this);

				imgDoc.Text = "Image " + unnamedNumber.ToString();
				imgDoc.Show(dockManager);
				imgDoc.Focus();

				// set events
				SetupDocumentEvents(imgDoc);
			}
		}

		// On "File->Paste" - paste image from clipboard
		private void pasteFileItem_Click(object sender, System.EventArgs e)
		{
			PasteFromClipboard();
		}

		// Close file
		private void closeFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
				dockManager.ActiveDocument.Close();
		}

		// Close all files
		private void closeAllFileItem_Click(object sender, System.EventArgs e)
		{
			foreach (Content c in dockManager.Documents)
				c.Close();
		}


		// On "Options->Open in new Document" click
		private void openInNewOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.openInNewDoc = !config.openInNewDoc;
		}

		// On "Options->Remember on change" click
		private void rememberOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.rememberOnChange = !config.rememberOnChange;
		}

	
		// On "View->Center" - center image
		private void centerViewItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
				((ImageDoc) doc).Center();
		}


		// On zoom factor changed
		private void document_ZoomChanged(object sender, System.EventArgs e)
		{
			UpdateZoomStatus((ImageDoc) sender);
		}

		// On mouse position over image changed
		private void document_MouseImagePosition(object sender, SelectionEventArgs e)
		{
			if (e.Location.X >= 0)
			{
				this.selectionPanel.Text = string.Format( "({0}, {1})", e.Location.X, e.Location.Y );

				// get current color
				Bitmap image = ((ImageDoc) sender).Image;
				if (image.PixelFormat == PixelFormat.Format24bppRgb)
				{
					Color	color = image.GetPixel(e.Location.X, e.Location.Y);
					RGB		rgb = new RGB( color );
					YCbCr	ycbcr = new YCbCr( );

					AForge.Imaging.ColorConverter.RGB2YCbCr( rgb, ycbcr );

					// RGB
					this.colorPanel.Text = string.Format( "RGB: {0}; {1}; {2}", color.R, color.G, color.B );
					// HSL
					this.hslPanel.Text = string.Format( "HSL: {0}; {1:F3}; {2:F3}", (int) color.GetHue(), color.GetSaturation(), color.GetBrightness() );
					// YCbCr
					this.ycbcrPanel.Text = string.Format( "YCbCr: {0:F3}; {1:F3}; {2:F3}", ycbcr.Y, ycbcr.Cb, ycbcr.Cr );
				}
				else if (image.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					Color color = image.GetPixel(e.Location.X, e.Location.Y);
					this.colorPanel.Text	= "Gray: " + color.R.ToString();
					this.hslPanel.Text		= "";
					this.ycbcrPanel.Text	= "";
				}
			}
			else
			{
				this.selectionPanel.Text	= "";
				this.colorPanel.Text		= "";
				this.hslPanel.Text			= "";
				this.ycbcrPanel.Text		= "";
			}
		}

		// On selection changed
		private void document_SelectionChanged(object sender, SelectionEventArgs e)
		{
			this.selectionPanel.Text = string.Format( "({0}, {1}) - {2} x {3}", e.Location.X, e.Location.Y, e.Size.Width, e.Size.Height );
		}

		// Update size status
		private void UpdateSizeStatus(Content doc)
		{
			if (doc != null)
			{
				int w = 0, h = 0;

				if (doc is ImageDoc)
				{
					w = ((ImageDoc) doc).ImageWidth;
					h = ((ImageDoc) doc).ImageHeight;
				}
				
				sizePanel.Text = w.ToString() + " x " + h.ToString();
			}
			else
			{
				sizePanel.Text = String.Empty;
			}
		}

		// Update zoom status
		private void UpdateZoomStatus(ImageDoc imgDoc)
		{
			if (imgDoc != null)
			{
				int zoom = (int)(imgDoc.Zoom * 100);
				zoomPanel.Text = zoom.ToString() + "%";
			}
			else
			{
				zoomPanel.Text = String.Empty;
			}
		}

		// On image toolbar clicked
		private void imageToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					ImageDocCommands[] cmd = new ImageDocCommands[]
					{
						ImageDocCommands.Clone, ImageDocCommands.Crop,
						ImageDocCommands.ZoomIn, ImageDocCommands.ZoomOut,
						ImageDocCommands.ZoomOriginal, ImageDocCommands.FitToSize,
						ImageDocCommands.Levels, ImageDocCommands.Grayscale,
						ImageDocCommands.Threshold, ImageDocCommands.Morphology,
						ImageDocCommands.Convolution, ImageDocCommands.Resize,
						ImageDocCommands.Rotate, ImageDocCommands.Saturation,
						ImageDocCommands.Fourier
					};

					((ImageDoc) doc).ExecuteCommand(cmd[e.Button.ImageIndex]);
				}
			}
		}

		

		// Print document page
		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				Bitmap image = null;

				// get an image to print
				if (doc is ImageDoc)
				{
					image = ((ImageDoc) doc).Image;
				}
		
				System.Diagnostics.Debug.WriteLine("X: " + e.MarginBounds.Left + ", Y = " + e.MarginBounds.Top + ", width = " + e.MarginBounds.Width + ", height = " + e.MarginBounds.Height);
				System.Diagnostics.Debug.WriteLine("X: " + e.PageBounds.Left + ", Y = " + e.PageBounds.Top + ", width = " + e.PageBounds.Width + ", height = " + e.PageBounds.Height);

				int		width = image.Width;
				int		height = image.Height;

				if ((width > e.MarginBounds.Width) || (height > e.MarginBounds.Height))
				{
					float f = Math.Min((float) e.MarginBounds.Width / width, (float) e.MarginBounds.Height / height);

					width = (int)(f * width);
					height = (int)(f * height);
				}

				e.Graphics.DrawImage(image, e.MarginBounds.Left, e.MarginBounds.Top, width, height);
			}
		}


        public bool NewDocument(ComplexImage image)
        {
            throw new NotImplementedException();
        }


        public Bitmap GetImage(object sender, string text, Size size, PixelFormat format)
        {
            throw new NotImplementedException();
        }
    }
}
