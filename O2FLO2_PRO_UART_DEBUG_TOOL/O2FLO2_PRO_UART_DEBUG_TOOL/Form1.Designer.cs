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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_flow_adc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_send = new System.Windows.Forms.Button();
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.groupBox5);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1245, 746);
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
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(255, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1057, 324);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation";
            // 
            // groupBox4
            // 
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
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBox_flow_adc);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(476, 46);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(541, 254);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Real Data";
            // 
            // textBox_flow_adc
            // 
            this.textBox_flow_adc.Location = new System.Drawing.Point(121, 180);
            this.textBox_flow_adc.Name = "textBox_flow_adc";
            this.textBox_flow_adc.Size = new System.Drawing.Size(121, 25);
            this.textBox_flow_adc.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Flow adc:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.button_send);
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
            this.groupBox3.Location = new System.Drawing.Point(6, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 254);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setting";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(140, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 19);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "only set flow";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(6, 24);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(100, 30);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "SEND";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
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
            this.label10.Location = new System.Drawing.Point(311, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "L/min";
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
            this.textBox_set_flow.Location = new System.Drawing.Point(202, 190);
            this.textBox_set_flow.Name = "textBox_set_flow";
            this.textBox_set_flow.Size = new System.Drawing.Size(100, 25);
            this.textBox_set_flow.TabIndex = 14;
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
            this.label8.Location = new System.Drawing.Point(311, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "s";
            // 
            // textBox_start_flow
            // 
            this.textBox_start_flow.Location = new System.Drawing.Point(202, 54);
            this.textBox_start_flow.Name = "textBox_start_flow";
            this.textBox_start_flow.Size = new System.Drawing.Size(100, 25);
            this.textBox_start_flow.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "L/min";
            // 
            // textBox_end_flow
            // 
            this.textBox_end_flow.Location = new System.Drawing.Point(202, 87);
            this.textBox_end_flow.Name = "textBox_end_flow";
            this.textBox_end_flow.Size = new System.Drawing.Size(100, 25);
            this.textBox_end_flow.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "L/min";
            // 
            // textBox_step
            // 
            this.textBox_step.Location = new System.Drawing.Point(202, 122);
            this.textBox_step.Name = "textBox_step";
            this.textBox_step.Size = new System.Drawing.Size(100, 25);
            this.textBox_step.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "L/min";
            // 
            // textBox_duration
            // 
            this.textBox_duration.Location = new System.Drawing.Point(202, 156);
            this.textBox_duration.Name = "textBox_duration";
            this.textBox_duration.Size = new System.Drawing.Size(100, 25);
            this.textBox_duration.TabIndex = 8;
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
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.chart1);
            this.groupBox5.Location = new System.Drawing.Point(247, 339);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(991, 382);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Flow Curve";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 21);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(985, 358);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "flow_slpm:";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 15);
            this.label13.TabIndex = 9;
            this.label13.Text = "pro_pwm:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(307, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 15);
            this.label14.TabIndex = 10;
            this.label14.Text = "avg_flow:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(307, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 15);
            this.label15.TabIndex = 11;
            this.label15.Text = "flow:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(307, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 15);
            this.label16.TabIndex = 12;
            this.label16.Text = "sensor_type:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(307, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 15);
            this.label17.TabIndex = 13;
            this.label17.Text = "sensor_err:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(307, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 15);
            this.label18.TabIndex = 14;
            this.label18.Text = "cur_adc:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(307, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 15);
            this.label19.TabIndex = 15;
            this.label19.Text = "is_valve_exist:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(307, 194);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 15);
            this.label20.TabIndex = 16;
            this.label20.Text = "is_5V_ok:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(307, 219);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 15);
            this.label21.TabIndex = 17;
            this.label21.Text = "is_12V_ok:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 761);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "O2FLOW Pro Debug Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.Button button_send;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_flow_adc;
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
        private System.Windows.Forms.Label label3;
    }
}

