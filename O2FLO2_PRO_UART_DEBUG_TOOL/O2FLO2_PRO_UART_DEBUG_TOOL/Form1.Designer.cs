namespace O2FLO2_PRO_UART_DEBUG_TOOL
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_openSerialPort = new System.Windows.Forms.Button();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.comboBox_stopBit = new System.Windows.Forms.ComboBox();
            this.comboBox_dataBits = new System.Windows.Forms.ComboBox();
            this.label_parity = new System.Windows.Forms.Label();
            this.comboBox_baud = new System.Windows.Forms.ComboBox();
            this.label_dataBits = new System.Windows.Forms.Label();
            this.label_stopBits = new System.Windows.Forms.Label();
            this.label_Baud = new System.Windows.Forms.Label();
            this.comboBox_portName = new System.Windows.Forms.ComboBox();
            this.label_portName = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.checkBox_lock_device = new System.Windows.Forms.CheckBox();
            this.button_start_test_valve_curve = new System.Windows.Forms.Button();
            this.textBox_start_PWM_DC = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button_manual_set_pwm_DC = new System.Windows.Forms.Button();
            this.checkBox_manual_set_pwm_DC = new System.Windows.Forms.CheckBox();
            this.textBox_pwm_dc_value = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_Y_interval = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button_SET_Y_AXI = new System.Windows.Forms.Button();
            this.checkBox_auto_set_Y_axi = new System.Windows.Forms.CheckBox();
            this.textBox_Y_Max = new System.Windows.Forms.TextBox();
            this.textBox_Y_Min = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label_PID_set_result = new System.Windows.Forms.Label();
            this.textBox_I_Min = new System.Windows.Forms.TextBox();
            this.textBox_I_Max = new System.Windows.Forms.TextBox();
            this.textBox_P_Max = new System.Windows.Forms.TextBox();
            this.textBox_Kd = new System.Windows.Forms.TextBox();
            this.textBox_Ki = new System.Windows.Forms.TextBox();
            this.textBox_Kp = new System.Windows.Forms.TextBox();
            this.checkBox_disable_debug = new System.Windows.Forms.CheckBox();
            this.button_PID_SEND = new System.Windows.Forms.Button();
            this.label_D_Max = new System.Windows.Forms.Label();
            this.label_I_Max = new System.Windows.Forms.Label();
            this.label_P_Max = new System.Windows.Forms.Label();
            this.label_Kd = new System.Windows.Forms.Label();
            this.label_Ki = new System.Windows.Forms.Label();
            this.label_Kp = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label_pid_get_result = new System.Windows.Forms.Label();
            this.textBox_I_Min_get = new System.Windows.Forms.TextBox();
            this.textBox_I_Max_get = new System.Windows.Forms.TextBox();
            this.textBox_P_Max_get = new System.Windows.Forms.TextBox();
            this.textBox_Kd_get = new System.Windows.Forms.TextBox();
            this.textBox_Ki_get = new System.Windows.Forms.TextBox();
            this.textBox_Kp_get = new System.Windows.Forms.TextBox();
            this.button_PID_GET = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label_is_12V_ok = new System.Windows.Forms.Label();
            this.label_is_5V_ok = new System.Windows.Forms.Label();
            this.label_is_valve_exist = new System.Windows.Forms.Label();
            this.label_cur_adc = new System.Windows.Forms.Label();
            this.label_sensor_err = new System.Windows.Forms.Label();
            this.label_flow = new System.Windows.Forms.Label();
            this.label_sensor_type = new System.Windows.Forms.Label();
            this.label_avg_flow = new System.Windows.Forms.Label();
            this.label_pro_pwm = new System.Windows.Forms.Label();
            this.label_flow_lpm_set = new System.Windows.Forms.Label();
            this.label_flow_slpm = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_FLOW_SEND = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_set_flow = new System.Windows.Forms.TextBox();
            this.label_duration = new System.Windows.Forms.Label();
            this.label_set_flow = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_start_flow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_end_flow = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_step = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_duration = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.button_openSerialPort);
            this.groupBox1.Controls.Add(this.comboBox_parity);
            this.groupBox1.Controls.Add(this.comboBox_stopBit);
            this.groupBox1.Controls.Add(this.comboBox_dataBits);
            this.groupBox1.Controls.Add(this.label_parity);
            this.groupBox1.Controls.Add(this.comboBox_baud);
            this.groupBox1.Controls.Add(this.label_dataBits);
            this.groupBox1.Controls.Add(this.label_stopBits);
            this.groupBox1.Controls.Add(this.label_Baud);
            this.groupBox1.Controls.Add(this.comboBox_portName);
            this.groupBox1.Controls.Add(this.label_portName);
            this.groupBox1.Location = new System.Drawing.Point(13, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(235, 708);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 291);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // button_openSerialPort
            // 
            this.button_openSerialPort.Location = new System.Drawing.Point(75, 290);
            this.button_openSerialPort.Margin = new System.Windows.Forms.Padding(4);
            this.button_openSerialPort.Name = "button_openSerialPort";
            this.button_openSerialPort.Size = new System.Drawing.Size(136, 29);
            this.button_openSerialPort.TabIndex = 10;
            this.button_openSerialPort.Text = "Connect";
            this.button_openSerialPort.UseVisualStyleBackColor = true;
            this.button_openSerialPort.Click += new System.EventHandler(this.button_openSerialPort_Click);
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.FormattingEnabled = true;
            this.comboBox_parity.Location = new System.Drawing.Point(89, 228);
            this.comboBox_parity.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_parity.Name = "comboBox_parity";
            this.comboBox_parity.Size = new System.Drawing.Size(120, 23);
            this.comboBox_parity.TabIndex = 9;
            // 
            // comboBox_stopBit
            // 
            this.comboBox_stopBit.FormattingEnabled = true;
            this.comboBox_stopBit.Location = new System.Drawing.Point(89, 178);
            this.comboBox_stopBit.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_stopBit.Name = "comboBox_stopBit";
            this.comboBox_stopBit.Size = new System.Drawing.Size(120, 23);
            this.comboBox_stopBit.TabIndex = 8;
            // 
            // comboBox_dataBits
            // 
            this.comboBox_dataBits.FormattingEnabled = true;
            this.comboBox_dataBits.Location = new System.Drawing.Point(89, 132);
            this.comboBox_dataBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_dataBits.Name = "comboBox_dataBits";
            this.comboBox_dataBits.Size = new System.Drawing.Size(120, 23);
            this.comboBox_dataBits.TabIndex = 7;
            // 
            // label_parity
            // 
            this.label_parity.AutoSize = true;
            this.label_parity.Location = new System.Drawing.Point(7, 231);
            this.label_parity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_parity.Name = "label_parity";
            this.label_parity.Size = new System.Drawing.Size(63, 15);
            this.label_parity.TabIndex = 6;
            this.label_parity.Text = "Parity:";
            // 
            // comboBox_baud
            // 
            this.comboBox_baud.FormattingEnabled = true;
            this.comboBox_baud.Location = new System.Drawing.Point(89, 86);
            this.comboBox_baud.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_baud.Name = "comboBox_baud";
            this.comboBox_baud.Size = new System.Drawing.Size(120, 23);
            this.comboBox_baud.TabIndex = 5;
            // 
            // label_dataBits
            // 
            this.label_dataBits.AutoSize = true;
            this.label_dataBits.Location = new System.Drawing.Point(5, 136);
            this.label_dataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dataBits.Name = "label_dataBits";
            this.label_dataBits.Size = new System.Drawing.Size(87, 15);
            this.label_dataBits.TabIndex = 4;
            this.label_dataBits.Text = "Data bits:";
            // 
            // label_stopBits
            // 
            this.label_stopBits.AutoSize = true;
            this.label_stopBits.Location = new System.Drawing.Point(7, 181);
            this.label_stopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_stopBits.Name = "label_stopBits";
            this.label_stopBits.Size = new System.Drawing.Size(79, 15);
            this.label_stopBits.TabIndex = 3;
            this.label_stopBits.Text = "Stop bit:";
            // 
            // label_Baud
            // 
            this.label_Baud.AutoSize = true;
            this.label_Baud.Location = new System.Drawing.Point(7, 90);
            this.label_Baud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Baud.Name = "label_Baud";
            this.label_Baud.Size = new System.Drawing.Size(47, 15);
            this.label_Baud.TabIndex = 2;
            this.label_Baud.Text = "Baud:";
            // 
            // comboBox_portName
            // 
            this.comboBox_portName.FormattingEnabled = true;
            this.comboBox_portName.Location = new System.Drawing.Point(89, 39);
            this.comboBox_portName.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_portName.Name = "comboBox_portName";
            this.comboBox_portName.Size = new System.Drawing.Size(120, 23);
            this.comboBox_portName.TabIndex = 1;
            this.comboBox_portName.SelectedValueChanged += new System.EventHandler(this.comboBox_portName_SelectedValueChanged);
            // 
            // label_portName
            // 
            this.label_portName.AutoSize = true;
            this.label_portName.Location = new System.Drawing.Point(4, 42);
            this.label_portName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_portName.Name = "label_portName";
            this.label_portName.Size = new System.Drawing.Size(87, 15);
            this.label_portName.TabIndex = 0;
            this.label_portName.Text = "Port Name:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.groupBox10);
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.chart1);
            this.groupBox5.Location = new System.Drawing.Point(255, 383);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1926, 375);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Flow Curve";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.checkBox_lock_device);
            this.groupBox10.Controls.Add(this.button_start_test_valve_curve);
            this.groupBox10.Controls.Add(this.textBox_start_PWM_DC);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Location = new System.Drawing.Point(925, 25);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(361, 109);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Test valve curve";
            // 
            // checkBox_lock_device
            // 
            this.checkBox_lock_device.AutoSize = true;
            this.checkBox_lock_device.Checked = true;
            this.checkBox_lock_device.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_lock_device.Location = new System.Drawing.Point(11, 38);
            this.checkBox_lock_device.Name = "checkBox_lock_device";
            this.checkBox_lock_device.Size = new System.Drawing.Size(117, 19);
            this.checkBox_lock_device.TabIndex = 50;
            this.checkBox_lock_device.Text = "lock device";
            this.checkBox_lock_device.UseVisualStyleBackColor = true;
            this.checkBox_lock_device.CheckedChanged += new System.EventHandler(this.checkBox_lock_device_CheckedChanged);
            // 
            // button_start_test_valve_curve
            // 
            this.button_start_test_valve_curve.Location = new System.Drawing.Point(255, 45);
            this.button_start_test_valve_curve.Name = "button_start_test_valve_curve";
            this.button_start_test_valve_curve.Size = new System.Drawing.Size(100, 30);
            this.button_start_test_valve_curve.TabIndex = 48;
            this.button_start_test_valve_curve.Text = "START";
            this.button_start_test_valve_curve.UseVisualStyleBackColor = true;
            this.button_start_test_valve_curve.Click += new System.EventHandler(this.button_test_valve_curve_Click);
            // 
            // textBox_start_PWM_DC
            // 
            this.textBox_start_PWM_DC.Location = new System.Drawing.Point(131, 69);
            this.textBox_start_PWM_DC.MaxLength = 4;
            this.textBox_start_PWM_DC.Name = "textBox_start_PWM_DC";
            this.textBox_start_PWM_DC.Size = new System.Drawing.Size(100, 25);
            this.textBox_start_PWM_DC.TabIndex = 49;
            this.textBox_start_PWM_DC.Text = "0";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(8, 75);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(119, 15);
            this.label42.TabIndex = 48;
            this.label42.Text = "Start PWM D.C:";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.button_manual_set_pwm_DC);
            this.groupBox9.Controls.Add(this.checkBox_manual_set_pwm_DC);
            this.groupBox9.Controls.Add(this.textBox_pwm_dc_value);
            this.groupBox9.Controls.Add(this.label29);
            this.groupBox9.Location = new System.Drawing.Point(561, 25);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(944, 109);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Manual Set PWM";
            // 
            // button_manual_set_pwm_DC
            // 
            this.button_manual_set_pwm_DC.Location = new System.Drawing.Point(237, 45);
            this.button_manual_set_pwm_DC.Name = "button_manual_set_pwm_DC";
            this.button_manual_set_pwm_DC.Size = new System.Drawing.Size(100, 30);
            this.button_manual_set_pwm_DC.TabIndex = 47;
            this.button_manual_set_pwm_DC.Text = "SET";
            this.button_manual_set_pwm_DC.UseVisualStyleBackColor = true;
            this.button_manual_set_pwm_DC.Click += new System.EventHandler(this.button_manual_set_pwm_DC_Click);
            // 
            // checkBox_manual_set_pwm_DC
            // 
            this.checkBox_manual_set_pwm_DC.AutoSize = true;
            this.checkBox_manual_set_pwm_DC.Checked = true;
            this.checkBox_manual_set_pwm_DC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_manual_set_pwm_DC.Location = new System.Drawing.Point(19, 38);
            this.checkBox_manual_set_pwm_DC.Name = "checkBox_manual_set_pwm_DC";
            this.checkBox_manual_set_pwm_DC.Size = new System.Drawing.Size(173, 19);
            this.checkBox_manual_set_pwm_DC.TabIndex = 46;
            this.checkBox_manual_set_pwm_DC.Text = "manual set pwm D.C";
            this.checkBox_manual_set_pwm_DC.UseVisualStyleBackColor = true;
            // 
            // textBox_pwm_dc_value
            // 
            this.textBox_pwm_dc_value.Location = new System.Drawing.Point(107, 73);
            this.textBox_pwm_dc_value.MaxLength = 4;
            this.textBox_pwm_dc_value.Name = "textBox_pwm_dc_value";
            this.textBox_pwm_dc_value.Size = new System.Drawing.Size(100, 25);
            this.textBox_pwm_dc_value.TabIndex = 45;
            this.textBox_pwm_dc_value.Text = "0";
            this.textBox_pwm_dc_value.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox_pwm_dc_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 79);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(71, 15);
            this.label29.TabIndex = 14;
            this.label29.Text = "PWM D.C:";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.textBox_Y_interval);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.button_SET_Y_AXI);
            this.groupBox7.Controls.Add(this.checkBox_auto_set_Y_axi);
            this.groupBox7.Controls.Add(this.textBox_Y_Max);
            this.groupBox7.Controls.Add(this.textBox_Y_Min);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Location = new System.Drawing.Point(12, 25);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1129, 109);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Set Y axi";
            // 
            // textBox_Y_interval
            // 
            this.textBox_Y_interval.Location = new System.Drawing.Point(312, 79);
            this.textBox_Y_interval.MaxLength = 4;
            this.textBox_Y_interval.Name = "textBox_Y_interval";
            this.textBox_Y_interval.Size = new System.Drawing.Size(100, 25);
            this.textBox_Y_interval.TabIndex = 23;
            this.textBox_Y_interval.Text = "100";
            this.textBox_Y_interval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_interval_KeyPress);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(222, 83);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(79, 15);
            this.label28.TabIndex = 22;
            this.label28.Text = "Interval:";
            // 
            // button_SET_Y_AXI
            // 
            this.button_SET_Y_AXI.Location = new System.Drawing.Point(441, 22);
            this.button_SET_Y_AXI.Name = "button_SET_Y_AXI";
            this.button_SET_Y_AXI.Size = new System.Drawing.Size(79, 25);
            this.button_SET_Y_AXI.TabIndex = 21;
            this.button_SET_Y_AXI.Text = "SET";
            this.button_SET_Y_AXI.UseVisualStyleBackColor = true;
            this.button_SET_Y_AXI.Click += new System.EventHandler(this.button_SET_Y_AXI_Click);
            // 
            // checkBox_auto_set_Y_axi
            // 
            this.checkBox_auto_set_Y_axi.AutoSize = true;
            this.checkBox_auto_set_Y_axi.Checked = true;
            this.checkBox_auto_set_Y_axi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_auto_set_Y_axi.Location = new System.Drawing.Point(6, 24);
            this.checkBox_auto_set_Y_axi.Name = "checkBox_auto_set_Y_axi";
            this.checkBox_auto_set_Y_axi.Size = new System.Drawing.Size(141, 19);
            this.checkBox_auto_set_Y_axi.TabIndex = 20;
            this.checkBox_auto_set_Y_axi.Text = "auto set Y axi";
            this.checkBox_auto_set_Y_axi.UseVisualStyleBackColor = true;
            this.checkBox_auto_set_Y_axi.CheckedChanged += new System.EventHandler(this.checkBox_auto_set_Y_axi_CheckedChanged);
            // 
            // textBox_Y_Max
            // 
            this.textBox_Y_Max.Location = new System.Drawing.Point(312, 50);
            this.textBox_Y_Max.MaxLength = 4;
            this.textBox_Y_Max.Name = "textBox_Y_Max";
            this.textBox_Y_Max.Size = new System.Drawing.Size(100, 25);
            this.textBox_Y_Max.TabIndex = 19;
            this.textBox_Y_Max.Text = "9000";
            this.textBox_Y_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Y_Max_KeyPress);
            // 
            // textBox_Y_Min
            // 
            this.textBox_Y_Min.Location = new System.Drawing.Point(312, 19);
            this.textBox_Y_Min.MaxLength = 4;
            this.textBox_Y_Min.Name = "textBox_Y_Min";
            this.textBox_Y_Min.Size = new System.Drawing.Size(100, 25);
            this.textBox_Y_Min.TabIndex = 17;
            this.textBox_Y_Min.Text = "0";
            this.textBox_Y_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Y_Min_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(222, 54);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 15);
            this.label27.TabIndex = 18;
            this.label27.Text = "Y Max:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(222, 22);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(55, 15);
            this.label26.TabIndex = 17;
            this.label26.Text = "Y Min:";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 140);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            this.chart1.Size = new System.Drawing.Size(1900, 211);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(255, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1900, 334);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label_PID_set_result);
            this.groupBox6.Controls.Add(this.textBox_I_Min);
            this.groupBox6.Controls.Add(this.textBox_I_Max);
            this.groupBox6.Controls.Add(this.textBox_P_Max);
            this.groupBox6.Controls.Add(this.textBox_Kd);
            this.groupBox6.Controls.Add(this.textBox_Ki);
            this.groupBox6.Controls.Add(this.textBox_Kp);
            this.groupBox6.Controls.Add(this.checkBox_disable_debug);
            this.groupBox6.Controls.Add(this.button_PID_SEND);
            this.groupBox6.Controls.Add(this.label_D_Max);
            this.groupBox6.Controls.Add(this.label_I_Max);
            this.groupBox6.Controls.Add(this.label_P_Max);
            this.groupBox6.Controls.Add(this.label_Kd);
            this.groupBox6.Controls.Add(this.label_Ki);
            this.groupBox6.Controls.Add(this.label_Kp);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(820, 44);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 275);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "PID Set";
            // 
            // label_PID_set_result
            // 
            this.label_PID_set_result.AutoSize = true;
            this.label_PID_set_result.Location = new System.Drawing.Point(15, 248);
            this.label_PID_set_result.Name = "label_PID_set_result";
            this.label_PID_set_result.Size = new System.Drawing.Size(55, 15);
            this.label_PID_set_result.TabIndex = 44;
            this.label_PID_set_result.Text = "      ";
            // 
            // textBox_I_Min
            // 
            this.textBox_I_Min.Location = new System.Drawing.Point(67, 216);
            this.textBox_I_Min.MaxLength = 5;
            this.textBox_I_Min.Name = "textBox_I_Min";
            this.textBox_I_Min.Size = new System.Drawing.Size(100, 25);
            this.textBox_I_Min.TabIndex = 43;
            this.textBox_I_Min.TextChanged += new System.EventHandler(this.textBox_I_Min_TextChanged);
            this.textBox_I_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_I_Min_KeyPress);
            // 
            // textBox_I_Max
            // 
            this.textBox_I_Max.Location = new System.Drawing.Point(67, 188);
            this.textBox_I_Max.MaxLength = 6;
            this.textBox_I_Max.Name = "textBox_I_Max";
            this.textBox_I_Max.Size = new System.Drawing.Size(100, 25);
            this.textBox_I_Max.TabIndex = 42;
            this.textBox_I_Max.TextChanged += new System.EventHandler(this.textBox_I_Max_TextChanged);
            this.textBox_I_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_I_Max_KeyPress);
            // 
            // textBox_P_Max
            // 
            this.textBox_P_Max.Location = new System.Drawing.Point(67, 160);
            this.textBox_P_Max.MaxLength = 5;
            this.textBox_P_Max.Name = "textBox_P_Max";
            this.textBox_P_Max.Size = new System.Drawing.Size(100, 25);
            this.textBox_P_Max.TabIndex = 41;
            this.textBox_P_Max.TextChanged += new System.EventHandler(this.textBox_P_Max_TextChanged);
            this.textBox_P_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_P_Max_KeyPress);
            // 
            // textBox_Kd
            // 
            this.textBox_Kd.Location = new System.Drawing.Point(67, 132);
            this.textBox_Kd.MaxLength = 3;
            this.textBox_Kd.Name = "textBox_Kd";
            this.textBox_Kd.Size = new System.Drawing.Size(100, 25);
            this.textBox_Kd.TabIndex = 40;
            this.textBox_Kd.TextChanged += new System.EventHandler(this.textBox_Kd_TextChanged);
            this.textBox_Kd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Kd_KeyPress);
            // 
            // textBox_Ki
            // 
            this.textBox_Ki.Location = new System.Drawing.Point(67, 104);
            this.textBox_Ki.MaxLength = 3;
            this.textBox_Ki.Name = "textBox_Ki";
            this.textBox_Ki.Size = new System.Drawing.Size(100, 25);
            this.textBox_Ki.TabIndex = 38;
            this.textBox_Ki.TextChanged += new System.EventHandler(this.textBox_Ki_TextChanged);
            this.textBox_Ki.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Ki_KeyPress);
            // 
            // textBox_Kp
            // 
            this.textBox_Kp.Location = new System.Drawing.Point(67, 77);
            this.textBox_Kp.MaxLength = 3;
            this.textBox_Kp.Name = "textBox_Kp";
            this.textBox_Kp.Size = new System.Drawing.Size(100, 25);
            this.textBox_Kp.TabIndex = 37;
            this.textBox_Kp.TextChanged += new System.EventHandler(this.textBox_Kp_TextChanged);
            this.textBox_Kp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Kp_KeyPress);
            // 
            // checkBox_disable_debug
            // 
            this.checkBox_disable_debug.AutoSize = true;
            this.checkBox_disable_debug.Location = new System.Drawing.Point(11, 57);
            this.checkBox_disable_debug.Name = "checkBox_disable_debug";
            this.checkBox_disable_debug.Size = new System.Drawing.Size(133, 19);
            this.checkBox_disable_debug.TabIndex = 36;
            this.checkBox_disable_debug.Text = "Disable debug";
            this.checkBox_disable_debug.UseVisualStyleBackColor = true;
            this.checkBox_disable_debug.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button_PID_SEND
            // 
            this.button_PID_SEND.Location = new System.Drawing.Point(11, 20);
            this.button_PID_SEND.Name = "button_PID_SEND";
            this.button_PID_SEND.Size = new System.Drawing.Size(100, 30);
            this.button_PID_SEND.TabIndex = 35;
            this.button_PID_SEND.Text = "SEND";
            this.button_PID_SEND.UseVisualStyleBackColor = true;
            this.button_PID_SEND.Click += new System.EventHandler(this.button_PID_SEND_Click);
            // 
            // label_D_Max
            // 
            this.label_D_Max.AutoSize = true;
            this.label_D_Max.Location = new System.Drawing.Point(75, 227);
            this.label_D_Max.Name = "label_D_Max";
            this.label_D_Max.Size = new System.Drawing.Size(0, 15);
            this.label_D_Max.TabIndex = 34;
            // 
            // label_I_Max
            // 
            this.label_I_Max.AutoSize = true;
            this.label_I_Max.Location = new System.Drawing.Point(75, 199);
            this.label_I_Max.Name = "label_I_Max";
            this.label_I_Max.Size = new System.Drawing.Size(0, 15);
            this.label_I_Max.TabIndex = 33;
            // 
            // label_P_Max
            // 
            this.label_P_Max.AutoSize = true;
            this.label_P_Max.Location = new System.Drawing.Point(75, 170);
            this.label_P_Max.Name = "label_P_Max";
            this.label_P_Max.Size = new System.Drawing.Size(0, 15);
            this.label_P_Max.TabIndex = 32;
            // 
            // label_Kd
            // 
            this.label_Kd.AutoSize = true;
            this.label_Kd.Location = new System.Drawing.Point(75, 143);
            this.label_Kd.Name = "label_Kd";
            this.label_Kd.Size = new System.Drawing.Size(0, 15);
            this.label_Kd.TabIndex = 31;
            // 
            // label_Ki
            // 
            this.label_Ki.AutoSize = true;
            this.label_Ki.Location = new System.Drawing.Point(75, 117);
            this.label_Ki.Name = "label_Ki";
            this.label_Ki.Size = new System.Drawing.Size(0, 15);
            this.label_Ki.TabIndex = 30;
            // 
            // label_Kp
            // 
            this.label_Kp.AutoSize = true;
            this.label_Kp.Location = new System.Drawing.Point(75, 89);
            this.label_Kp.Name = "label_Kp";
            this.label_Kp.Size = new System.Drawing.Size(0, 15);
            this.label_Kp.TabIndex = 29;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 221);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 15);
            this.label25.TabIndex = 13;
            this.label25.Text = "I Min:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 195);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 15);
            this.label24.TabIndex = 12;
            this.label24.Text = "I Max:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 167);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 15);
            this.label23.TabIndex = 11;
            this.label23.Text = "P Max:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 137);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 15);
            this.label22.TabIndex = 10;
            this.label22.Text = "Kd:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Ki:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kp:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_is_12V_ok);
            this.groupBox4.Controls.Add(this.label_is_5V_ok);
            this.groupBox4.Controls.Add(this.label_is_valve_exist);
            this.groupBox4.Controls.Add(this.label_cur_adc);
            this.groupBox4.Controls.Add(this.label_sensor_err);
            this.groupBox4.Controls.Add(this.label_flow);
            this.groupBox4.Controls.Add(this.label_sensor_type);
            this.groupBox4.Controls.Add(this.label_avg_flow);
            this.groupBox4.Controls.Add(this.label_pro_pwm);
            this.groupBox4.Controls.Add(this.label_flow_lpm_set);
            this.groupBox4.Controls.Add(this.label_flow_slpm);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label);
            this.groupBox4.Location = new System.Drawing.Point(357, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(441, 275);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Real Data";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label_pid_get_result);
            this.groupBox8.Controls.Add(this.textBox_I_Min_get);
            this.groupBox8.Controls.Add(this.textBox_I_Max_get);
            this.groupBox8.Controls.Add(this.textBox_P_Max_get);
            this.groupBox8.Controls.Add(this.textBox_Kd_get);
            this.groupBox8.Controls.Add(this.textBox_Ki_get);
            this.groupBox8.Controls.Add(this.textBox_Kp_get);
            this.groupBox8.Controls.Add(this.button_PID_GET);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.label31);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.label36);
            this.groupBox8.Controls.Add(this.label37);
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.Controls.Add(this.label39);
            this.groupBox8.Controls.Add(this.label40);
            this.groupBox8.Controls.Add(this.label41);
            this.groupBox8.Location = new System.Drawing.Point(1048, 44);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(230, 275);
            this.groupBox8.TabIndex = 45;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "PID Get";
            // 
            // label_pid_get_result
            // 
            this.label_pid_get_result.AutoSize = true;
            this.label_pid_get_result.Location = new System.Drawing.Point(127, 30);
            this.label_pid_get_result.Name = "label_pid_get_result";
            this.label_pid_get_result.Size = new System.Drawing.Size(55, 15);
            this.label_pid_get_result.TabIndex = 44;
            this.label_pid_get_result.Text = "      ";
            // 
            // textBox_I_Min_get
            // 
            this.textBox_I_Min_get.Location = new System.Drawing.Point(67, 216);
            this.textBox_I_Min_get.Name = "textBox_I_Min_get";
            this.textBox_I_Min_get.Size = new System.Drawing.Size(100, 25);
            this.textBox_I_Min_get.TabIndex = 43;
            // 
            // textBox_I_Max_get
            // 
            this.textBox_I_Max_get.Location = new System.Drawing.Point(67, 188);
            this.textBox_I_Max_get.Name = "textBox_I_Max_get";
            this.textBox_I_Max_get.Size = new System.Drawing.Size(100, 25);
            this.textBox_I_Max_get.TabIndex = 42;
            // 
            // textBox_P_Max_get
            // 
            this.textBox_P_Max_get.Location = new System.Drawing.Point(67, 160);
            this.textBox_P_Max_get.Name = "textBox_P_Max_get";
            this.textBox_P_Max_get.Size = new System.Drawing.Size(100, 25);
            this.textBox_P_Max_get.TabIndex = 41;
            // 
            // textBox_Kd_get
            // 
            this.textBox_Kd_get.Location = new System.Drawing.Point(67, 132);
            this.textBox_Kd_get.Name = "textBox_Kd_get";
            this.textBox_Kd_get.Size = new System.Drawing.Size(100, 25);
            this.textBox_Kd_get.TabIndex = 40;
            // 
            // textBox_Ki_get
            // 
            this.textBox_Ki_get.Location = new System.Drawing.Point(67, 104);
            this.textBox_Ki_get.Name = "textBox_Ki_get";
            this.textBox_Ki_get.Size = new System.Drawing.Size(100, 25);
            this.textBox_Ki_get.TabIndex = 38;
            // 
            // textBox_Kp_get
            // 
            this.textBox_Kp_get.Location = new System.Drawing.Point(67, 77);
            this.textBox_Kp_get.Name = "textBox_Kp_get";
            this.textBox_Kp_get.Size = new System.Drawing.Size(100, 25);
            this.textBox_Kp_get.TabIndex = 37;
            // 
            // button_PID_GET
            // 
            this.button_PID_GET.Location = new System.Drawing.Point(11, 20);
            this.button_PID_GET.Name = "button_PID_GET";
            this.button_PID_GET.Size = new System.Drawing.Size(100, 30);
            this.button_PID_GET.TabIndex = 35;
            this.button_PID_GET.Text = "GET";
            this.button_PID_GET.UseVisualStyleBackColor = true;
            this.button_PID_GET.Click += new System.EventHandler(this.button_PID_GET_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(75, 227);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(0, 15);
            this.label30.TabIndex = 34;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(75, 199);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(0, 15);
            this.label31.TabIndex = 33;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(75, 170);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(0, 15);
            this.label32.TabIndex = 32;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(75, 143);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(0, 15);
            this.label33.TabIndex = 31;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(75, 117);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(0, 15);
            this.label34.TabIndex = 30;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(75, 89);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(0, 15);
            this.label35.TabIndex = 29;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 221);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(55, 15);
            this.label36.TabIndex = 13;
            this.label36.Text = "I Min:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(10, 195);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(55, 15);
            this.label37.TabIndex = 12;
            this.label37.Text = "I Max:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(10, 167);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(55, 15);
            this.label38.TabIndex = 11;
            this.label38.Text = "P Max:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(10, 137);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(31, 15);
            this.label39.TabIndex = 10;
            this.label39.Text = "Kd:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(10, 111);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(31, 15);
            this.label40.TabIndex = 9;
            this.label40.Text = "Ki:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(10, 83);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(31, 15);
            this.label41.TabIndex = 8;
            this.label41.Text = "Kp:";
            // 
            // label_is_12V_ok
            // 
            this.label_is_12V_ok.AutoSize = true;
            this.label_is_12V_ok.Location = new System.Drawing.Point(326, 219);
            this.label_is_12V_ok.Name = "label_is_12V_ok";
            this.label_is_12V_ok.Size = new System.Drawing.Size(15, 15);
            this.label_is_12V_ok.TabIndex = 28;
            this.label_is_12V_ok.Text = "0";
            // 
            // label_is_5V_ok
            // 
            this.label_is_5V_ok.AutoSize = true;
            this.label_is_5V_ok.Location = new System.Drawing.Point(326, 196);
            this.label_is_5V_ok.Name = "label_is_5V_ok";
            this.label_is_5V_ok.Size = new System.Drawing.Size(15, 15);
            this.label_is_5V_ok.TabIndex = 27;
            this.label_is_5V_ok.Text = "0";
            // 
            // label_is_valve_exist
            // 
            this.label_is_valve_exist.AutoSize = true;
            this.label_is_valve_exist.Location = new System.Drawing.Point(326, 168);
            this.label_is_valve_exist.Name = "label_is_valve_exist";
            this.label_is_valve_exist.Size = new System.Drawing.Size(15, 15);
            this.label_is_valve_exist.TabIndex = 26;
            this.label_is_valve_exist.Text = "0";
            // 
            // label_cur_adc
            // 
            this.label_cur_adc.AutoSize = true;
            this.label_cur_adc.Location = new System.Drawing.Point(326, 139);
            this.label_cur_adc.Name = "label_cur_adc";
            this.label_cur_adc.Size = new System.Drawing.Size(15, 15);
            this.label_cur_adc.TabIndex = 25;
            this.label_cur_adc.Text = "0";
            // 
            // label_sensor_err
            // 
            this.label_sensor_err.AutoSize = true;
            this.label_sensor_err.Location = new System.Drawing.Point(326, 109);
            this.label_sensor_err.Name = "label_sensor_err";
            this.label_sensor_err.Size = new System.Drawing.Size(15, 15);
            this.label_sensor_err.TabIndex = 24;
            this.label_sensor_err.Text = "0";
            // 
            // label_flow
            // 
            this.label_flow.AutoSize = true;
            this.label_flow.Location = new System.Drawing.Point(326, 53);
            this.label_flow.Name = "label_flow";
            this.label_flow.Size = new System.Drawing.Size(15, 15);
            this.label_flow.TabIndex = 23;
            this.label_flow.Text = "0";
            // 
            // label_sensor_type
            // 
            this.label_sensor_type.AutoSize = true;
            this.label_sensor_type.Location = new System.Drawing.Point(326, 81);
            this.label_sensor_type.Name = "label_sensor_type";
            this.label_sensor_type.Size = new System.Drawing.Size(15, 15);
            this.label_sensor_type.TabIndex = 22;
            this.label_sensor_type.Text = "0";
            // 
            // label_avg_flow
            // 
            this.label_avg_flow.AutoSize = true;
            this.label_avg_flow.Location = new System.Drawing.Point(326, 26);
            this.label_avg_flow.Name = "label_avg_flow";
            this.label_avg_flow.Size = new System.Drawing.Size(15, 15);
            this.label_avg_flow.TabIndex = 21;
            this.label_avg_flow.Text = "0";
            // 
            // label_pro_pwm
            // 
            this.label_pro_pwm.AutoSize = true;
            this.label_pro_pwm.Location = new System.Drawing.Point(119, 85);
            this.label_pro_pwm.Name = "label_pro_pwm";
            this.label_pro_pwm.Size = new System.Drawing.Size(15, 15);
            this.label_pro_pwm.TabIndex = 20;
            this.label_pro_pwm.Text = "0";
            // 
            // label_flow_lpm_set
            // 
            this.label_flow_lpm_set.AutoSize = true;
            this.label_flow_lpm_set.Location = new System.Drawing.Point(119, 54);
            this.label_flow_lpm_set.Name = "label_flow_lpm_set";
            this.label_flow_lpm_set.Size = new System.Drawing.Size(15, 15);
            this.label_flow_lpm_set.TabIndex = 19;
            this.label_flow_lpm_set.Text = "0";
            // 
            // label_flow_slpm
            // 
            this.label_flow_slpm.AutoSize = true;
            this.label_flow_slpm.Location = new System.Drawing.Point(119, 24);
            this.label_flow_slpm.Name = "label_flow_slpm";
            this.label_flow_slpm.Size = new System.Drawing.Size(15, 15);
            this.label_flow_slpm.TabIndex = 18;
            this.label_flow_slpm.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(194, 219);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 15);
            this.label21.TabIndex = 17;
            this.label21.Text = "is_12V_ok:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(194, 194);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 15);
            this.label20.TabIndex = 16;
            this.label20.Text = "is_5V_ok:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(194, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 15);
            this.label19.TabIndex = 15;
            this.label19.Text = "is_valve_exist:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(194, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 15);
            this.label18.TabIndex = 14;
            this.label18.Text = "cur_adc:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(194, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 15);
            this.label17.TabIndex = 13;
            this.label17.Text = "sensor_err:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(194, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 15);
            this.label16.TabIndex = 12;
            this.label16.Text = "sensor_type:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(194, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 15);
            this.label15.TabIndex = 11;
            this.label15.Text = "flow:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(194, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 15);
            this.label14.TabIndex = 10;
            this.label14.Text = "avg_flow:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 15);
            this.label13.TabIndex = 9;
            this.label13.Text = "pro_pwm:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "flow_lpm_set:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(6, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(87, 15);
            this.label.TabIndex = 7;
            this.label.Text = "flow_slpm:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.button_FLOW_SEND);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBox_set_flow);
            this.groupBox3.Controls.Add(this.label_duration);
            this.groupBox3.Controls.Add(this.label_set_flow);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBox_start_flow);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_end_flow);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_step);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox_duration);
            this.groupBox3.Location = new System.Drawing.Point(6, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 274);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Flow Set";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(125, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 19);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "only set flow";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_FLOW_SEND
            // 
            this.button_FLOW_SEND.Location = new System.Drawing.Point(6, 24);
            this.button_FLOW_SEND.Name = "button_FLOW_SEND";
            this.button_FLOW_SEND.Size = new System.Drawing.Size(100, 30);
            this.button_FLOW_SEND.TabIndex = 0;
            this.button_FLOW_SEND.Text = "SEND";
            this.button_FLOW_SEND.UseVisualStyleBackColor = true;
            this.button_FLOW_SEND.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "End Flow:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(230, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "0.01L/min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Flow:";
            // 
            // textBox_set_flow
            // 
            this.textBox_set_flow.Location = new System.Drawing.Point(121, 190);
            this.textBox_set_flow.MaxLength = 4;
            this.textBox_set_flow.Name = "textBox_set_flow";
            this.textBox_set_flow.Size = new System.Drawing.Size(100, 25);
            this.textBox_set_flow.TabIndex = 14;
            this.textBox_set_flow.Text = "0";
            this.textBox_set_flow.TextChanged += new System.EventHandler(this.textBox_set_flow_TextChanged);
            this.textBox_set_flow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_set_flow_KeyPress);
            // 
            // label_duration
            // 
            this.label_duration.AutoSize = true;
            this.label_duration.Location = new System.Drawing.Point(19, 164);
            this.label_duration.Name = "label_duration";
            this.label_duration.Size = new System.Drawing.Size(79, 15);
            this.label_duration.TabIndex = 3;
            this.label_duration.Text = "Duration:";
            // 
            // label_set_flow
            // 
            this.label_set_flow.AutoSize = true;
            this.label_set_flow.Location = new System.Drawing.Point(19, 196);
            this.label_set_flow.Name = "label_set_flow";
            this.label_set_flow.Size = new System.Drawing.Size(79, 15);
            this.label_set_flow.TabIndex = 13;
            this.label_set_flow.Text = "Set Flow:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Step:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "s";
            // 
            // textBox_start_flow
            // 
            this.textBox_start_flow.Location = new System.Drawing.Point(121, 54);
            this.textBox_start_flow.MaxLength = 4;
            this.textBox_start_flow.Name = "textBox_start_flow";
            this.textBox_start_flow.Size = new System.Drawing.Size(100, 25);
            this.textBox_start_flow.TabIndex = 5;
            this.textBox_start_flow.Text = "0";
            this.textBox_start_flow.TextChanged += new System.EventHandler(this.textBox_start_flow_TextChanged);
            this.textBox_start_flow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_start_flow_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "0.01L/min";
            // 
            // textBox_end_flow
            // 
            this.textBox_end_flow.Location = new System.Drawing.Point(121, 87);
            this.textBox_end_flow.MaxLength = 4;
            this.textBox_end_flow.Name = "textBox_end_flow";
            this.textBox_end_flow.Size = new System.Drawing.Size(100, 25);
            this.textBox_end_flow.TabIndex = 6;
            this.textBox_end_flow.Text = "0";
            this.textBox_end_flow.TextChanged += new System.EventHandler(this.textBox_end_flow_TextChanged);
            this.textBox_end_flow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_end_flow_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "0.01L/min";
            // 
            // textBox_step
            // 
            this.textBox_step.Location = new System.Drawing.Point(121, 122);
            this.textBox_step.MaxLength = 4;
            this.textBox_step.Name = "textBox_step";
            this.textBox_step.Size = new System.Drawing.Size(100, 25);
            this.textBox_step.TabIndex = 7;
            this.textBox_step.Text = "0";
            this.textBox_step.TextChanged += new System.EventHandler(this.textBox_step_TextChanged);
            this.textBox_step.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_step_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "0.01L/min";
            // 
            // textBox_duration
            // 
            this.textBox_duration.Location = new System.Drawing.Point(121, 156);
            this.textBox_duration.MaxLength = 3;
            this.textBox_duration.Name = "textBox_duration";
            this.textBox_duration.Size = new System.Drawing.Size(100, 25);
            this.textBox_duration.TabIndex = 8;
            this.textBox_duration.Text = "0";
            this.textBox_duration.TextChanged += new System.EventHandler(this.textBox_duration_TextChanged);
            this.textBox_duration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_duration_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(986, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "开始流量是Start flow,每隔duration的时间,流量增加Step,Set Flow会显示当前的设置流量;当流量到达End Flow后会回到Start " +
    "Flow,周而复始";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2155, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveDataToolStripMenuItem
            // 
            this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
            this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.saveDataToolStripMenuItem.Text = "Save Data";
            this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1590, 761);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "O2FLOW Pro Debug Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_openSerialPort;
        private System.Windows.Forms.ComboBox comboBox_parity;
        private System.Windows.Forms.ComboBox comboBox_stopBit;
        private System.Windows.Forms.ComboBox comboBox_dataBits;
        private System.Windows.Forms.Label label_parity;
        private System.Windows.Forms.ComboBox comboBox_baud;
        private System.Windows.Forms.Label label_dataBits;
        private System.Windows.Forms.Label label_stopBits;
        private System.Windows.Forms.Label label_Baud;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private System.Windows.Forms.Label label_portName;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_duration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_FLOW_SEND;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_duration;
        private System.Windows.Forms.TextBox textBox_step;
        private System.Windows.Forms.TextBox textBox_end_flow;
        private System.Windows.Forms.TextBox textBox_start_flow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_set_flow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_set_flow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_is_12V_ok;
        private System.Windows.Forms.Label label_is_5V_ok;
        private System.Windows.Forms.Label label_is_valve_exist;
        private System.Windows.Forms.Label label_cur_adc;
        private System.Windows.Forms.Label label_sensor_err;
        private System.Windows.Forms.Label label_flow;
        private System.Windows.Forms.Label label_sensor_type;
        private System.Windows.Forms.Label label_avg_flow;
        private System.Windows.Forms.Label label_pro_pwm;
        private System.Windows.Forms.Label label_flow_lpm_set;
        private System.Windows.Forms.Label label_flow_slpm;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_PID_SEND;
        private System.Windows.Forms.Label label_D_Max;
        private System.Windows.Forms.Label label_I_Max;
        private System.Windows.Forms.Label label_P_Max;
        private System.Windows.Forms.Label label_Kd;
        private System.Windows.Forms.Label label_Ki;
        private System.Windows.Forms.Label label_Kp;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_disable_debug;
        private System.Windows.Forms.TextBox textBox_I_Min;
        private System.Windows.Forms.TextBox textBox_I_Max;
        private System.Windows.Forms.TextBox textBox_P_Max;
        private System.Windows.Forms.TextBox textBox_Kd;
        private System.Windows.Forms.TextBox textBox_Ki;
        private System.Windows.Forms.TextBox textBox_Kp;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox_Y_Max;
        private System.Windows.Forms.TextBox textBox_Y_Min;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox checkBox_auto_set_Y_axi;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button_SET_Y_AXI;
        private System.Windows.Forms.TextBox textBox_Y_interval;
        private System.Windows.Forms.Label label_PID_set_result;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label_pid_get_result;
        private System.Windows.Forms.TextBox textBox_I_Min_get;
        private System.Windows.Forms.TextBox textBox_I_Max_get;
        private System.Windows.Forms.TextBox textBox_P_Max_get;
        private System.Windows.Forms.TextBox textBox_Kd_get;
        private System.Windows.Forms.TextBox textBox_Ki_get;
        private System.Windows.Forms.TextBox textBox_Kp_get;
        private System.Windows.Forms.Button button_PID_GET;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button button_manual_set_pwm_DC;
        private System.Windows.Forms.CheckBox checkBox_manual_set_pwm_DC;
        private System.Windows.Forms.TextBox textBox_pwm_dc_value;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button_start_test_valve_curve;
        private System.Windows.Forms.TextBox textBox_start_PWM_DC;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.CheckBox checkBox_lock_device;
    }
}

