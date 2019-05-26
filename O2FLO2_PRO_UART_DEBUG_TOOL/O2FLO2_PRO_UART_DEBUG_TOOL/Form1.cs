using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2FLO2_PRO_UART_DEBUG_TOOL
{
    public partial class Form1 : Form
    {
        private string[] m_old_serialPortNames;
        private bool m_SerialPortOpened = false;

        private List<byte> m_buffer = new List<byte>();

        private const int HEAD = 0;
        private const int LEN = 1;
        private const int CMDTYPE = 2;
        private const int FRAME_ID = 3;

        private struct DATA_SEND
        {
            public byte IS_ONLY_SET_FLOW_CHECKED;     //根据check来判断是否循环跑
            public UInt16 START_FLOW;
            public UInt16 END_FLOW;
            public UInt16 STEP;
            public UInt16 DURATION;
            public UInt16 SET_FLOW;
        }

        private struct DATA_RECEIVE
        {
            public UInt16 FLOW_SLPM;
            public UInt16 FLOW_LPM_SET;
            public UInt16 PRO_PWM;   //占空比
            public UInt16 AVG_FLOW;
            public UInt16 FLOW;       //实时流量
            public byte SENSOR_TYPE;
            public byte SENSOR_ERR;
            public UInt16 CUR_ADC;      //比例阀的电流
            public byte IS_VALVE_EXIST; //比例阀是否存在
            public byte IS_5V_OK;   //5V电压是否ok
            public byte IS_12V_OK;  //12V电压是否ok

            public byte RESERVE_0;   //保留字
            public byte RESERVE_1;
            public byte RESERVE_2;
            public byte RESERVE_3;
            public byte RESERVE_4;
            public byte RESERVE_5;
            public byte RESERVE_6;
            public byte RESERVE_7;
            public byte RESERVE_8;
            public byte RESERVE_9;
            public byte RESERVE_10;
            public byte RESERVE_11;
            public byte RESERVE_12;
            public byte RESERVE_13;
            public byte RESERVE_14;
            public byte RESERVE_15;
            public byte RESERVE_16;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            var nPendingRead = this.serialPort1.BytesToRead;
            byte[] tmp = new byte[nPendingRead];
            this.serialPort1.Read(tmp, 0, nPendingRead);

            //m_bRcvParamtersCompleted = false;
            lock (m_buffer)
            {
                m_buffer.AddRange(tmp);
                #region
                while (m_buffer.Count >= 4)
                {
                    if (m_buffer[HEAD] == 0xFF) //帧头
                    {
                        int len = Convert.ToInt32(m_buffer[LEN]); // 获取帧长度(不包含checksum1和checksum2)
                        if (m_buffer.Count < len + 2)  //数据没有接收完全，继续接收
                        {
                            break;
                        }
                        int checksum = 256 * Convert.ToInt32(m_buffer[len]) + Convert.ToInt32(m_buffer[len + 1]);
                        int sum = 0;
                        for (int i = 1; i < len; i++) //校验和不包含包头
                        {
                            sum += Convert.ToInt32(m_buffer[i]);
                        }
                        //MessageBox.Show(sum.ToString());
                        if (checksum == sum)
                        {
                            //解析数据，加入到3个链表中
                            ParseData2Lists();
                        }
                        else
                        {
                            //校验之后发现数据不对,清除该帧数据
                            m_buffer.RemoveRange(0, len + 2);
                            continue;
                        }
                        m_buffer.RemoveRange(0, len + 2);
                    }
                    else
                    {
                        m_buffer.RemoveAt(0); //清除帧头
                    }
                }
                #endregion
            }
        }

        private void ParseData2Lists()
        {
            //将数据解析挂入到3个链表中
            if (m_buffer[CMDTYPE] != 0x00)
            {
                return;
            }
            //根据帧类型来判断
            switch (m_buffer[FRAME_ID])
            {
                case 0x92:        //下位机发送回来的数据
                    ParseData();
                    break;

                default:
                    break;
            }
        }

        private void ParseData()
        {
            DATA_RECEIVE data_recv = new DATA_RECEIVE();

            data_recv.FLOW_SLPM = Convert.ToUInt16( (m_buffer[4] * 256) + m_buffer[5]);   //flow_slpm
            data_recv.FLOW_LPM_SET = Convert.ToUInt16((m_buffer[6] * 256) + m_buffer[7]); //flow_lpm_set
            data_recv.PRO_PWM= Convert.ToUInt16((m_buffer[8] * 256) + m_buffer[9]);       //pro_pwm

            data_recv.AVG_FLOW = Convert.ToUInt16((m_buffer[10] * 256) + m_buffer[11]);   //avg_flow
            data_recv.FLOW = Convert.ToUInt16((m_buffer[12] * 256) + m_buffer[13]);       //flow
            data_recv.SENSOR_TYPE = m_buffer[14];                                         //sensor_type
            data_recv.SENSOR_ERR = m_buffer[15];                                          //sensor_err
            data_recv.CUR_ADC = Convert.ToUInt16((m_buffer[16] * 256) + m_buffer[17]);    //cur_adc
            data_recv.IS_VALVE_EXIST = m_buffer[18];                                      //is_valve_exist     
            data_recv.IS_5V_OK = m_buffer[19];                                            //is_5V_ok
            data_recv.IS_12V_OK = m_buffer[20];                                           //is_12V_ok

            //TODO,准备一个buffer装数据,解决线程冲突问题

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();

            if (names.Length == 0)
            {
                return;
            }
            if (m_old_serialPortNames == null)
            {
                return;
            }
            //Array.Sort(names);
            Array.Sort(names, (a, b) => Convert.ToInt32(((string)a).Substring(3)).CompareTo(Convert.ToInt32(((string)b).Substring(3))));
            int nCount = 0;
            if (names.Length == m_old_serialPortNames.Length)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == m_old_serialPortNames[i])
                    {
                        nCount++;
                    }
                }
                if (nCount == names.Length)  //如果每个都相同
                {
                    return;
                }
                else
                {
                    m_old_serialPortNames = names;  //如果不匹配，将新的值赋给旧的值
                }
            }
            else
            {
                m_old_serialPortNames = names;
            }

            this.comboBox_portName.Items.Clear();

            Array.Sort(names, (a, b) => Convert.ToInt32(((string)a).Substring(3)).CompareTo(Convert.ToInt32(((string)b).Substring(3))));

            this.comboBox_portName.Items.AddRange(names);
            this.comboBox_portName.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //屏蔽线程检查
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            //双缓冲，解决大量数据刷新界面的问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

            InitApp();
        }

        private void InitApp()
        {
       
            //初始化串口设置
            InitSerialPort();

            //加载图片
            LoadPicture();

            //初始化text box
            InitTextBox();
        }

        private void InitTextBox()
        {
            if (this.checkBox1.Checked)
            {
                this.textBox_start_flow.Enabled = false;
                this.textBox_end_flow.Enabled = false;
                this.textBox_step.Enabled = false;
                this.textBox_duration.Enabled = false;
            }
        }

        private void LoadPicture()
        {
            if (!m_SerialPortOpened)
            {
                this.pictureBox1.Load(Environment.CurrentDirectory + @"\" + "red.png");
            }
            else
            {
                this.pictureBox1.Load(Environment.CurrentDirectory + @"\" + "green.png");
            }
        }

        private void InitSerialPort()
        {
            #region
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length != 0)
            {
                //Array.Sort(ports);
                Array.Sort(ports, (a, b) => Convert.ToInt32(((string)a).Substring(3)).CompareTo(Convert.ToInt32(((string)b).Substring(3))));
                m_old_serialPortNames = ports;
                this.comboBox_portName.Items.AddRange(ports);
                this.comboBox_portName.SelectedIndex = 0;
            }

            this.comboBox_baud.Text = "115200";
            this.comboBox_dataBits.Text = "8";
            this.comboBox_stopBit.Text = "one";
            this.comboBox_parity.Text = "none";
            #endregion
        }

        private void comboBox_portName_SelectedValueChanged(object sender, EventArgs e)
        {
            this.serialPort1.PortName = this.comboBox_portName.Text;
        }

        private void button_openSerialPort_Click(object sender, EventArgs e)
        {
            m_SerialPortOpened = !m_SerialPortOpened;

            if (m_SerialPortOpened)
            {
                try
                {
                    this.serialPort1.Open();
                }
                catch (Exception ex)
                {
                    m_SerialPortOpened = false;
                    MessageBox.Show(ex.Message);
                    return;
                }
                this.button_openSerialPort.Text = "Close";

                m_SerialPortOpened = true;
                this.comboBox_portName.Enabled = false;
                LoadPicture();

                ////2019.3.26
                //send_stop_getting_HW_data();
                //m_HWData_list.Clear();
                //m_buffer.Clear();
                //label_HW.Text = "0";


            }
            else
            {
                this.button_openSerialPort.Text = "Connect";
                this.serialPort1.Close();
                m_SerialPortOpened = false;
                LoadPicture();
                this.comboBox_portName.Enabled = true;

            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please open serial port!");
                return;
            }

            if((this.textBox_start_flow.Text==""||textBox_end_flow.Text==""||textBox_step.Text==""
                ||textBox_duration.Text==""||textBox_set_flow.Text=="")&&!this.checkBox1.Checked)
            {
                MessageBox.Show("No allow for empty data!");
                return;
            }

            byte[] send_buffer = new byte[17];
            send_buffer[0] = 0xFF;
            send_buffer[LEN] = 17-2;    //发送的包长度,不包含checksum
            send_buffer[2] = 0x01;
            send_buffer[3] = 0x91;   


            DATA_SEND data = new DATA_SEND();
            UInt32 sum = 0;
            //根据checkbox1是否被勾选,来填充发送的结构体
            if(this.checkBox1.Checked)
            {
                data.IS_ONLY_SET_FLOW_CHECKED = 1;
                data.START_FLOW = 0;
                data.END_FLOW = 0;
                data.STEP = 0;
                data.DURATION = 0;
                data.SET_FLOW = Convert.ToUInt16(textBox_set_flow.Text);
            }
            else
            {
                data.IS_ONLY_SET_FLOW_CHECKED = 0;
                data.START_FLOW = Convert.ToUInt16(textBox_start_flow.Text);
                data.END_FLOW = Convert.ToUInt16(textBox_end_flow.Text);
                data.STEP = Convert.ToUInt16(textBox_step.Text);
                data.DURATION = Convert.ToUInt16(textBox_duration.Text);
                //data.SET_FLOW = Convert.ToUInt16(textBox_set_flow.Text);
                textBox_set_flow.Enabled = false;
                textBox_set_flow.Text = textBox_start_flow.Text;
            }

            //is only set flow
            send_buffer[4] = Convert.ToByte( (checkBox1.Checked == true) ? 1 : 0);

            //start_flow
            send_buffer[5] = Convert.ToByte(data.START_FLOW / 256);
            send_buffer[6] = Convert.ToByte(data.START_FLOW % 256);

            //end_flow
            send_buffer[7] = Convert.ToByte(data.END_FLOW / 256);
            send_buffer[8] = Convert.ToByte(data.END_FLOW % 256);

            //step
            send_buffer[9] = Convert.ToByte(data.STEP / 256);
            send_buffer[10] = Convert.ToByte(data.STEP % 256);

            //duration
            send_buffer[11] = Convert.ToByte(data.DURATION / 256);
            send_buffer[12] = Convert.ToByte(data.DURATION % 256);

            //set_flow
            send_buffer[13] = Convert.ToByte(data.SET_FLOW / 256);
            send_buffer[14] = Convert.ToByte(data.SET_FLOW % 256);

            for (int i = 1; i < 15; i++)
            {
                sum += send_buffer[i];
            }

            //填充checksum
            send_buffer[Convert.ToInt32(send_buffer[LEN])] = Convert.ToByte(sum / 256);   //checksum1
            send_buffer[Convert.ToInt32(send_buffer[LEN]) + 1] = Convert.ToByte(sum % 256); //checksum2

            this.serialPort1.Write(send_buffer, 0, Convert.ToInt32(send_buffer[LEN]) + 2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox_start_flow.Enabled = false;
                this.textBox_end_flow.Enabled = false;
                this.textBox_step.Enabled = false;
                this.textBox_duration.Enabled = false;
                this.textBox_set_flow.Enabled = true;
            }
            else
            {
                this.textBox_start_flow.Enabled = true;
                this.textBox_end_flow.Enabled = true;
                this.textBox_step.Enabled = true;
                this.textBox_duration.Enabled = true;
                this.textBox_set_flow.Enabled = false;
            }
        }
    }
}
