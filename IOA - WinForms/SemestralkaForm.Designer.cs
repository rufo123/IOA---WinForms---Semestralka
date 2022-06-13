
namespace IOA___WinForms
{
    partial class SemestralkaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.listBoxNodeInfo = new System.Windows.Forms.ListBox();
            this.textBoxMouseCoordinates = new System.Windows.Forms.TextBox();
            this.labelMouseCoordinates = new System.Windows.Forms.Label();
            this.listBoxSelectedNode = new System.Windows.Forms.ListBox();
            this.groupBoxNodeInfo = new System.Windows.Forms.GroupBox();
            this.buttonSaveNodeInfo = new System.Windows.Forms.Button();
            this.buttonNodeType = new System.Windows.Forms.Button();
            this.labelNodeType = new System.Windows.Forms.Label();
            this.labelNodeCapacity = new System.Windows.Forms.Label();
            this.labelNodeCords = new System.Windows.Forms.Label();
            this.labelNodeID = new System.Windows.Forms.Label();
            this.labelInfoNode = new System.Windows.Forms.Label();
            this.textBoxNodeCapac = new System.Windows.Forms.TextBox();
            this.textBoxNodeCoords = new System.Windows.Forms.TextBox();
            this.buttonConnected = new System.Windows.Forms.Button();
            this.labelStartNode = new System.Windows.Forms.Label();
            this.labelEndNode = new System.Windows.Forms.Label();
            this.buttonShortestPath = new System.Windows.Forms.Button();
            this.labelAllNodesConnected = new System.Windows.Forms.Label();
            this.labelAllNodesConnectedTrueFalse = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVisualizer = new System.Windows.Forms.TabPage();
            this.tabPageClark = new System.Windows.Forms.TabPage();
            this.numericUpDownK = new System.Windows.Forms.NumericUpDown();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.buttonStartKlarke = new System.Windows.Forms.Button();
            this.labelCustomersText = new System.Windows.Forms.Label();
            this.labelPrimarySourceText = new System.Windows.Forms.Label();
            this.labelConnNetworkClarkText = new System.Windows.Forms.Label();
            this.listBoxRoutes = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxNodeInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageVisualizer.SuspendLayout();
            this.tabPageClark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(280, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(59, 67);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 1;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(45, 38);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(100, 23);
            this.textBoxSize.TabIndex = 2;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(82, 15);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(27, 15);
            this.labelSize.TabIndex = 3;
            this.labelSize.Text = "Size";
            // 
            // listBoxNodeInfo
            // 
            this.listBoxNodeInfo.FormattingEnabled = true;
            this.listBoxNodeInfo.ItemHeight = 15;
            this.listBoxNodeInfo.Items.AddRange(new object[] {
            "dasdas"});
            this.listBoxNodeInfo.Location = new System.Drawing.Point(34, 410);
            this.listBoxNodeInfo.Name = "listBoxNodeInfo";
            this.listBoxNodeInfo.Size = new System.Drawing.Size(178, 154);
            this.listBoxNodeInfo.TabIndex = 4;
            this.listBoxNodeInfo.Visible = false;
            this.listBoxNodeInfo.SelectedIndexChanged += new System.EventHandler(this.listBoxNodeInfo_SelectedIndexChanged);
            this.listBoxNodeInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxNodeInfo_MouseMove);
            // 
            // textBoxMouseCoordinates
            // 
            this.textBoxMouseCoordinates.Location = new System.Drawing.Point(32, 367);
            this.textBoxMouseCoordinates.Name = "textBoxMouseCoordinates";
            this.textBoxMouseCoordinates.Size = new System.Drawing.Size(178, 23);
            this.textBoxMouseCoordinates.TabIndex = 5;
            // 
            // labelMouseCoordinates
            // 
            this.labelMouseCoordinates.AutoSize = true;
            this.labelMouseCoordinates.Location = new System.Drawing.Point(69, 297);
            this.labelMouseCoordinates.Name = "labelMouseCoordinates";
            this.labelMouseCoordinates.Size = new System.Drawing.Size(110, 15);
            this.labelMouseCoordinates.TabIndex = 6;
            this.labelMouseCoordinates.Text = "Mouse Coordinates";
            // 
            // listBoxSelectedNode
            // 
            this.listBoxSelectedNode.FormattingEnabled = true;
            this.listBoxSelectedNode.ItemHeight = 15;
            this.listBoxSelectedNode.Items.AddRange(new object[] {
            "dasdas"});
            this.listBoxSelectedNode.Location = new System.Drawing.Point(32, 593);
            this.listBoxSelectedNode.Name = "listBoxSelectedNode";
            this.listBoxSelectedNode.Size = new System.Drawing.Size(178, 154);
            this.listBoxSelectedNode.TabIndex = 7;
            this.listBoxSelectedNode.Visible = false;
            // 
            // groupBoxNodeInfo
            // 
            this.groupBoxNodeInfo.Controls.Add(this.buttonSaveNodeInfo);
            this.groupBoxNodeInfo.Controls.Add(this.buttonNodeType);
            this.groupBoxNodeInfo.Controls.Add(this.labelNodeType);
            this.groupBoxNodeInfo.Controls.Add(this.labelNodeCapacity);
            this.groupBoxNodeInfo.Controls.Add(this.labelNodeCords);
            this.groupBoxNodeInfo.Controls.Add(this.labelNodeID);
            this.groupBoxNodeInfo.Controls.Add(this.labelInfoNode);
            this.groupBoxNodeInfo.Controls.Add(this.textBoxNodeCapac);
            this.groupBoxNodeInfo.Controls.Add(this.textBoxNodeCoords);
            this.groupBoxNodeInfo.Location = new System.Drawing.Point(13, 111);
            this.groupBoxNodeInfo.Name = "groupBoxNodeInfo";
            this.groupBoxNodeInfo.Size = new System.Drawing.Size(246, 230);
            this.groupBoxNodeInfo.TabIndex = 8;
            this.groupBoxNodeInfo.TabStop = false;
            // 
            // buttonSaveNodeInfo
            // 
            this.buttonSaveNodeInfo.Location = new System.Drawing.Point(81, 186);
            this.buttonSaveNodeInfo.Name = "buttonSaveNodeInfo";
            this.buttonSaveNodeInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveNodeInfo.TabIndex = 9;
            this.buttonSaveNodeInfo.Text = "Save";
            this.buttonSaveNodeInfo.UseVisualStyleBackColor = true;
            this.buttonSaveNodeInfo.Click += new System.EventHandler(this.buttonSaveNodeInfo_Click);
            // 
            // buttonNodeType
            // 
            this.buttonNodeType.Location = new System.Drawing.Point(178, 152);
            this.buttonNodeType.Name = "buttonNodeType";
            this.buttonNodeType.Size = new System.Drawing.Size(30, 23);
            this.buttonNodeType.TabIndex = 8;
            this.buttonNodeType.Text = "->";
            this.buttonNodeType.UseVisualStyleBackColor = true;
            this.buttonNodeType.Click += new System.EventHandler(this.buttonNodeType_Click);
            // 
            // labelNodeType
            // 
            this.labelNodeType.AutoSize = true;
            this.labelNodeType.Location = new System.Drawing.Point(25, 156);
            this.labelNodeType.Name = "labelNodeType";
            this.labelNodeType.Size = new System.Drawing.Size(34, 15);
            this.labelNodeType.TabIndex = 7;
            this.labelNodeType.Text = "Type:";
            // 
            // labelNodeCapacity
            // 
            this.labelNodeCapacity.AutoSize = true;
            this.labelNodeCapacity.Location = new System.Drawing.Point(25, 120);
            this.labelNodeCapacity.Name = "labelNodeCapacity";
            this.labelNodeCapacity.Size = new System.Drawing.Size(56, 15);
            this.labelNodeCapacity.TabIndex = 6;
            this.labelNodeCapacity.Text = "Capacity:";
            // 
            // labelNodeCords
            // 
            this.labelNodeCords.AutoSize = true;
            this.labelNodeCords.Location = new System.Drawing.Point(25, 94);
            this.labelNodeCords.Name = "labelNodeCords";
            this.labelNodeCords.Size = new System.Drawing.Size(77, 15);
            this.labelNodeCords.TabIndex = 5;
            this.labelNodeCords.Text = "Coordinates: ";
            // 
            // labelNodeID
            // 
            this.labelNodeID.AutoSize = true;
            this.labelNodeID.Location = new System.Drawing.Point(25, 57);
            this.labelNodeID.Name = "labelNodeID";
            this.labelNodeID.Size = new System.Drawing.Size(23, 15);
            this.labelNodeID.TabIndex = 4;
            this.labelNodeID.Text = "Id: ";
            // 
            // labelInfoNode
            // 
            this.labelInfoNode.AutoSize = true;
            this.labelInfoNode.Location = new System.Drawing.Point(25, 29);
            this.labelInfoNode.Name = "labelInfoNode";
            this.labelInfoNode.Size = new System.Drawing.Size(141, 15);
            this.labelInfoNode.TabIndex = 3;
            this.labelInfoNode.Text = "Information About Node:";
            // 
            // textBoxNodeCapac
            // 
            this.textBoxNodeCapac.Location = new System.Drawing.Point(108, 120);
            this.textBoxNodeCapac.Name = "textBoxNodeCapac";
            this.textBoxNodeCapac.Size = new System.Drawing.Size(100, 23);
            this.textBoxNodeCapac.TabIndex = 1;
            // 
            // textBoxNodeCoords
            // 
            this.textBoxNodeCoords.Location = new System.Drawing.Point(108, 91);
            this.textBoxNodeCoords.Name = "textBoxNodeCoords";
            this.textBoxNodeCoords.Size = new System.Drawing.Size(100, 23);
            this.textBoxNodeCoords.TabIndex = 0;
            // 
            // buttonConnected
            // 
            this.buttonConnected.Location = new System.Drawing.Point(1189, 87);
            this.buttonConnected.Name = "buttonConnected";
            this.buttonConnected.Size = new System.Drawing.Size(75, 23);
            this.buttonConnected.TabIndex = 9;
            this.buttonConnected.Text = "Connect";
            this.buttonConnected.UseVisualStyleBackColor = true;
            this.buttonConnected.Click += new System.EventHandler(this.buttonConnected_Click);
            // 
            // labelStartNode
            // 
            this.labelStartNode.AutoSize = true;
            this.labelStartNode.Location = new System.Drawing.Point(1103, 22);
            this.labelStartNode.Name = "labelStartNode";
            this.labelStartNode.Size = new System.Drawing.Size(83, 15);
            this.labelStartNode.TabIndex = 10;
            this.labelStartNode.Text = "Starting Node:";
            // 
            // labelEndNode
            // 
            this.labelEndNode.AutoSize = true;
            this.labelEndNode.Location = new System.Drawing.Point(1103, 58);
            this.labelEndNode.Name = "labelEndNode";
            this.labelEndNode.Size = new System.Drawing.Size(79, 15);
            this.labelEndNode.TabIndex = 11;
            this.labelEndNode.Text = "Ending Node:";
            // 
            // buttonShortestPath
            // 
            this.buttonShortestPath.Location = new System.Drawing.Point(1175, 160);
            this.buttonShortestPath.Name = "buttonShortestPath";
            this.buttonShortestPath.Size = new System.Drawing.Size(108, 23);
            this.buttonShortestPath.TabIndex = 12;
            this.buttonShortestPath.Text = "Distance Matrix";
            this.buttonShortestPath.UseVisualStyleBackColor = true;
            this.buttonShortestPath.Click += new System.EventHandler(this.buttonShortestPath_Click);
            // 
            // labelAllNodesConnected
            // 
            this.labelAllNodesConnected.AutoSize = true;
            this.labelAllNodesConnected.Location = new System.Drawing.Point(1165, 203);
            this.labelAllNodesConnected.Name = "labelAllNodesConnected";
            this.labelAllNodesConnected.Size = new System.Drawing.Size(122, 15);
            this.labelAllNodesConnected.TabIndex = 13;
            this.labelAllNodesConnected.Text = "All Nodes Connected:";
            // 
            // labelAllNodesConnectedTrueFalse
            // 
            this.labelAllNodesConnectedTrueFalse.AutoSize = true;
            this.labelAllNodesConnectedTrueFalse.Location = new System.Drawing.Point(1201, 230);
            this.labelAllNodesConnectedTrueFalse.Name = "labelAllNodesConnectedTrueFalse";
            this.labelAllNodesConnectedTrueFalse.Size = new System.Drawing.Size(63, 15);
            this.labelAllNodesConnectedTrueFalse.TabIndex = 14;
            this.labelAllNodesConnectedTrueFalse.Text = "Not Tested";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVisualizer);
            this.tabControl1.Controls.Add(this.tabPageClark);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1397, 824);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPageVisualizer
            // 
            this.tabPageVisualizer.Controls.Add(this.buttonLoad);
            this.tabPageVisualizer.Controls.Add(this.buttonSave);
            this.tabPageVisualizer.Controls.Add(this.groupBoxNodeInfo);
            this.tabPageVisualizer.Controls.Add(this.labelAllNodesConnectedTrueFalse);
            this.tabPageVisualizer.Controls.Add(this.buttonDraw);
            this.tabPageVisualizer.Controls.Add(this.labelAllNodesConnected);
            this.tabPageVisualizer.Controls.Add(this.textBoxSize);
            this.tabPageVisualizer.Controls.Add(this.buttonShortestPath);
            this.tabPageVisualizer.Controls.Add(this.labelEndNode);
            this.tabPageVisualizer.Controls.Add(this.labelSize);
            this.tabPageVisualizer.Controls.Add(this.labelStartNode);
            this.tabPageVisualizer.Controls.Add(this.listBoxNodeInfo);
            this.tabPageVisualizer.Controls.Add(this.buttonConnected);
            this.tabPageVisualizer.Controls.Add(this.textBoxMouseCoordinates);
            this.tabPageVisualizer.Controls.Add(this.labelMouseCoordinates);
            this.tabPageVisualizer.Controls.Add(this.pictureBox1);
            this.tabPageVisualizer.Controls.Add(this.listBoxSelectedNode);
            this.tabPageVisualizer.Location = new System.Drawing.Point(4, 24);
            this.tabPageVisualizer.Name = "tabPageVisualizer";
            this.tabPageVisualizer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVisualizer.Size = new System.Drawing.Size(1389, 796);
            this.tabPageVisualizer.TabIndex = 0;
            this.tabPageVisualizer.Text = "Visualizer";
            this.tabPageVisualizer.UseVisualStyleBackColor = true;
            // 
            // tabPageClark
            // 
            this.tabPageClark.Controls.Add(this.numericUpDownK);
            this.tabPageClark.Controls.Add(this.labelCapacity);
            this.tabPageClark.Controls.Add(this.buttonStartKlarke);
            this.tabPageClark.Controls.Add(this.labelCustomersText);
            this.tabPageClark.Controls.Add(this.labelPrimarySourceText);
            this.tabPageClark.Controls.Add(this.labelConnNetworkClarkText);
            this.tabPageClark.Controls.Add(this.listBoxRoutes);
            this.tabPageClark.Location = new System.Drawing.Point(4, 24);
            this.tabPageClark.Name = "tabPageClark";
            this.tabPageClark.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClark.Size = new System.Drawing.Size(1389, 796);
            this.tabPageClark.TabIndex = 1;
            this.tabPageClark.Text = "Clarke-Wrigth";
            this.tabPageClark.UseVisualStyleBackColor = true;
            // 
            // numericUpDownK
            // 
            this.numericUpDownK.Location = new System.Drawing.Point(43, 122);
            this.numericUpDownK.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownK.Name = "numericUpDownK";
            this.numericUpDownK.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownK.TabIndex = 6;
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(17, 124);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(20, 15);
            this.labelCapacity.TabIndex = 5;
            this.labelCapacity.Text = "K: ";
            // 
            // buttonStartKlarke
            // 
            this.buttonStartKlarke.Location = new System.Drawing.Point(17, 158);
            this.buttonStartKlarke.Name = "buttonStartKlarke";
            this.buttonStartKlarke.Size = new System.Drawing.Size(75, 23);
            this.buttonStartKlarke.TabIndex = 4;
            this.buttonStartKlarke.Text = "Start";
            this.buttonStartKlarke.UseVisualStyleBackColor = true;
            this.buttonStartKlarke.Click += new System.EventHandler(this.buttonStartKlarke_Click);
            // 
            // labelCustomersText
            // 
            this.labelCustomersText.AutoSize = true;
            this.labelCustomersText.Location = new System.Drawing.Point(17, 85);
            this.labelCustomersText.Name = "labelCustomersText";
            this.labelCustomersText.Size = new System.Drawing.Size(70, 15);
            this.labelCustomersText.TabIndex = 3;
            this.labelCustomersText.Text = "Customers: ";
            // 
            // labelPrimarySourceText
            // 
            this.labelPrimarySourceText.AutoSize = true;
            this.labelPrimarySourceText.Location = new System.Drawing.Point(17, 51);
            this.labelPrimarySourceText.Name = "labelPrimarySourceText";
            this.labelPrimarySourceText.Size = new System.Drawing.Size(90, 15);
            this.labelPrimarySourceText.TabIndex = 2;
            this.labelPrimarySourceText.Text = "Primary Source:";
            // 
            // labelConnNetworkClarkText
            // 
            this.labelConnNetworkClarkText.AutoSize = true;
            this.labelConnNetworkClarkText.Location = new System.Drawing.Point(17, 17);
            this.labelConnNetworkClarkText.Name = "labelConnNetworkClarkText";
            this.labelConnNetworkClarkText.Size = new System.Drawing.Size(119, 15);
            this.labelConnNetworkClarkText.TabIndex = 1;
            this.labelConnNetworkClarkText.Text = "Network Connected: ";
            // 
            // listBoxRoutes
            // 
            this.listBoxRoutes.FormattingEnabled = true;
            this.listBoxRoutes.ItemHeight = 15;
            this.listBoxRoutes.Location = new System.Drawing.Point(3, 444);
            this.listBoxRoutes.Name = "listBoxRoutes";
            this.listBoxRoutes.Size = new System.Drawing.Size(1365, 349);
            this.listBoxRoutes.TabIndex = 0;
            this.listBoxRoutes.Click += new System.EventHandler(this.listBoxRoutes_Click);
            this.listBoxRoutes.DoubleClick += new System.EventHandler(this.listBoxRoutes_DoubleClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1189, 267);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(1189, 318);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 16;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // SemestralkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1399, 825);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "SemestralkaForm";
            this.Text = "SemestralkaForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SemestralkaForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxNodeInfo.ResumeLayout(false);
            this.groupBoxNodeInfo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageVisualizer.ResumeLayout(false);
            this.tabPageVisualizer.PerformLayout();
            this.tabPageClark.ResumeLayout(false);
            this.tabPageClark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.ListBox listBoxNodeInfo;
        private System.Windows.Forms.TextBox textBoxMouseCoordinates;
        private System.Windows.Forms.Label labelMouseCoordinates;
        private System.Windows.Forms.ListBox listBoxSelectedNode;
        private System.Windows.Forms.GroupBox groupBoxNodeInfo;
        private System.Windows.Forms.Label labelNodeID;
        private System.Windows.Forms.Label labelInfoNode;
        private System.Windows.Forms.TextBox textBoxNodeCapac;
        private System.Windows.Forms.TextBox textBoxNodeCoords;
        private System.Windows.Forms.Button buttonNodeType;
        private System.Windows.Forms.Label labelNodeType;
        private System.Windows.Forms.Label labelNodeCapacity;
        private System.Windows.Forms.Label labelNodeCords;
        private System.Windows.Forms.Button buttonSaveNodeInfo;
        private System.Windows.Forms.Button buttonConnected;
        private System.Windows.Forms.Label labelStartNode;
        private System.Windows.Forms.Label labelEndNode;
        private System.Windows.Forms.Button buttonShortestPath;
        private System.Windows.Forms.Label labelAllNodesConnected;
        private System.Windows.Forms.Label labelAllNodesConnectedTrueFalse;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVisualizer;
        private System.Windows.Forms.TabPage tabPageClark;
        private System.Windows.Forms.Label labelCustomersText;
        private System.Windows.Forms.Label labelPrimarySourceText;
        private System.Windows.Forms.Label labelConnNetworkClarkText;
        private System.Windows.Forms.ListBox listBoxRoutes;
        private System.Windows.Forms.Button buttonStartKlarke;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.NumericUpDown numericUpDownK;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
    }
}