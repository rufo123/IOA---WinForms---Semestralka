
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxNodeInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(265, 12);
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
            this.buttonDraw.Location = new System.Drawing.Point(59, 88);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 1;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(45, 59);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(100, 23);
            this.textBoxSize.TabIndex = 2;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(82, 36);
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
            this.listBoxNodeInfo.Location = new System.Drawing.Point(34, 431);
            this.listBoxNodeInfo.Name = "listBoxNodeInfo";
            this.listBoxNodeInfo.Size = new System.Drawing.Size(178, 154);
            this.listBoxNodeInfo.TabIndex = 4;
            this.listBoxNodeInfo.Visible = false;
            this.listBoxNodeInfo.SelectedIndexChanged += new System.EventHandler(this.listBoxNodeInfo_SelectedIndexChanged);
            this.listBoxNodeInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxNodeInfo_MouseMove);
            // 
            // textBoxMouseCoordinates
            // 
            this.textBoxMouseCoordinates.Location = new System.Drawing.Point(32, 388);
            this.textBoxMouseCoordinates.Name = "textBoxMouseCoordinates";
            this.textBoxMouseCoordinates.Size = new System.Drawing.Size(178, 23);
            this.textBoxMouseCoordinates.TabIndex = 5;
            // 
            // labelMouseCoordinates
            // 
            this.labelMouseCoordinates.AutoSize = true;
            this.labelMouseCoordinates.Location = new System.Drawing.Point(69, 318);
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
            this.listBoxSelectedNode.Location = new System.Drawing.Point(32, 614);
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
            this.groupBoxNodeInfo.Location = new System.Drawing.Point(13, 132);
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
            this.buttonConnected.Location = new System.Drawing.Point(1169, 88);
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
            this.labelStartNode.Location = new System.Drawing.Point(1083, 23);
            this.labelStartNode.Name = "labelStartNode";
            this.labelStartNode.Size = new System.Drawing.Size(83, 15);
            this.labelStartNode.TabIndex = 10;
            this.labelStartNode.Text = "Starting Node:";
            // 
            // labelEndNode
            // 
            this.labelEndNode.AutoSize = true;
            this.labelEndNode.Location = new System.Drawing.Point(1083, 59);
            this.labelEndNode.Name = "labelEndNode";
            this.labelEndNode.Size = new System.Drawing.Size(79, 15);
            this.labelEndNode.TabIndex = 11;
            this.labelEndNode.Text = "Ending Node:";
            // 
            // buttonShortestPath
            // 
            this.buttonShortestPath.Location = new System.Drawing.Point(1155, 161);
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
            this.labelAllNodesConnected.Location = new System.Drawing.Point(1145, 204);
            this.labelAllNodesConnected.Name = "labelAllNodesConnected";
            this.labelAllNodesConnected.Size = new System.Drawing.Size(122, 15);
            this.labelAllNodesConnected.TabIndex = 13;
            this.labelAllNodesConnected.Text = "All Nodes Connected:";
            // 
            // labelAllNodesConnectedTrueFalse
            // 
            this.labelAllNodesConnectedTrueFalse.AutoSize = true;
            this.labelAllNodesConnectedTrueFalse.Location = new System.Drawing.Point(1181, 231);
            this.labelAllNodesConnectedTrueFalse.Name = "labelAllNodesConnectedTrueFalse";
            this.labelAllNodesConnectedTrueFalse.Size = new System.Drawing.Size(63, 15);
            this.labelAllNodesConnectedTrueFalse.TabIndex = 14;
            this.labelAllNodesConnectedTrueFalse.Text = "Not Tested";
            // 
            // SemestralkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1318, 825);
            this.Controls.Add(this.labelAllNodesConnectedTrueFalse);
            this.Controls.Add(this.labelAllNodesConnected);
            this.Controls.Add(this.buttonShortestPath);
            this.Controls.Add(this.labelEndNode);
            this.Controls.Add(this.labelStartNode);
            this.Controls.Add(this.buttonConnected);
            this.Controls.Add(this.groupBoxNodeInfo);
            this.Controls.Add(this.listBoxSelectedNode);
            this.Controls.Add(this.labelMouseCoordinates);
            this.Controls.Add(this.textBoxMouseCoordinates);
            this.Controls.Add(this.listBoxNodeInfo);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "SemestralkaForm";
            this.Text = "SemestralkaForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SemestralkaForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxNodeInfo.ResumeLayout(false);
            this.groupBoxNodeInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}