using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace O2FLO2_PRO_UART_DEBUG_TOOL
{
    public partial class Form1 : Form
    {
        private enum CURVE_STATE
        {
            CURVE_NONE,
            CURVE_INCREASE,
            CURVE_HOLD,
            CURVE_DECREASE
        }
        private const int PWM_MAX_DC = 2400;         //占空比最大的值
        private const int INCREASE_CNT = 0;
        private const int DECREASE_CNT = 0;
        private const int HOLD_CNT = 50;
        private const int PWM_STEP = 12;  //12=2400*0.5%,厂商回复分辨率为0.5%

        private int m_increase_cnt = INCREASE_CNT;              //计数,PWM D.C 增加一次
        private int m_decrease_cnt = DECREASE_CNT;              //计数,PWM D.C 减法一次
        private int m_hold_cnt = HOLD_CNT;                  //占空比到达最高的时候，hold住的次数
        private CURVE_STATE m_curve_state = CURVE_STATE.CURVE_NONE;

        private bool m_b_start_test_valve_curve = false;  //测试比例阀的特性曲线

        private string m_flow_pid_FilePath = Environment.CurrentDirectory + @"\" + "flow_pid.ini";

        private string[] m_old_serialPortNames;
        private bool m_SerialPortOpened = false;

        private List<byte> m_buffer = new List<byte>();

        private const int HEAD = 0;
        private const int LEN = 1;
        private const int CMDTYPE = 2;
        private const int FRAME_ID = 3;

        public struct SENSOR_DATA
        {
            public int FLOW_LPM_SET;
            public int PWM_DC;
            public byte DATA_0;
            public byte DATA_1;

            public byte AVG_FLOW_DATA_0;
            public byte AVG_FLOW_DATA_1;
        }

        private List<SENSOR_DATA> m_HWData_list = new List<SENSOR_DATA>();
        private List<SENSOR_DATA> m_HW_buffer = new List<SENSOR_DATA>();
        private int m_recv_cnt = 0;

        private struct DATA_SEND
        {
            public byte IS_ONLY_SET_FLOW_CHECKED;     //根据check来判断是否循环跑
            public UInt16 START_FLOW;
            public UInt16 END_FLOW;
            public UInt16 STEP;
            public UInt16 DURATION;
            public UInt16 SET_FLOW;
        }

        private struct FLOW_PID_PARAMETER
        {
            public bool FLOW_ONLY_SET_FLOW;
            public int START_FLOW;
            public int END_FLOW;
            public int STEP;
            public int DURATION;
            public int SET_FLOW;

            public int PID_Kp;
            public int PID_Ki;
            public int PID_Kd;
            public int PID_P_MAX;
            public int PID_I_MAX;
            public int PID_I_MIN;
        }

        private FLOW_PID_PARAMETER flow_pid_parameter = new FLOW_PID_PARAMETER();
        private int label_PID_set_result_cnt = 0;
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


        public struct Y_AXI_SET
        {
            public bool IS_SETTED;
            public float Y_MAX;
            public float Y_MIN;
            public float Y_INTERVAL;
        }

        private Y_AXI_SET Y_AXI_set = new Y_AXI_SET() { IS_SETTED = false, Y_MAX = 90000, Y_MIN = 0, Y_INTERVAL = 100 };
        //private bool b_initial_Y_AXI = true;

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
                            //解析数据
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
                    //ParseData();
                    lock (m_HW_buffer)
                    {
                        if (m_recv_cnt == 1)
                        {
                            m_recv_cnt = 0;
                            m_HW_buffer.Clear();
                            for (int i = 0; i < m_HWData_list.Count; i++)
                            {
                                SENSOR_DATA data = new SENSOR_DATA();
                                data.DATA_0 = m_HWData_list[i].DATA_0;
                                data.DATA_1 = m_HWData_list[i].DATA_1;

                                data.AVG_FLOW_DATA_0 = m_HWData_list[i].AVG_FLOW_DATA_0;
                                data.AVG_FLOW_DATA_1 = m_HWData_list[i].AVG_FLOW_DATA_1;
                                m_HW_buffer.Add(data);
                            }
                        }
                        else
                        {
                            m_recv_cnt++;
                            //get_HW_data_2_list();
                            ParseData();
                        }
                    }
                    break;
                case 0xAB:
                    if (m_buffer[4] == 0x00)
                    {
                        label_PID_set_result.Text = "Modify PID successful!";
                    }
                    else if (m_buffer[4] == 0x01)
                    {
                        label_PID_set_result.Text = "Disable debug successful!";
                    }
                    break;
                case 0xAD:
                    get_pid_parameter();
                    break;
                default:
                    break;
            }
        }

        private void get_pid_parameter()
        {
            int kp = m_buffer[4] * 256 * 256 * 256 + m_buffer[5] * 256 * 256 + m_buffer[6] * 256 + m_buffer[7];
            int ki = m_buffer[8] * 256 * 256 * 256 + m_buffer[9] * 256 * 256 + m_buffer[10] * 256 + m_buffer[11];
            int kd = m_buffer[12] * 256 * 256 * 256 + m_buffer[13] * 256 * 256 + m_buffer[14] * 256 + m_buffer[15];
            int P_Max = m_buffer[16] * 256 * 256 * 256 + m_buffer[17] * 256 * 256 + m_buffer[18] * 256 + m_buffer[19];
            int I_Max = m_buffer[20] * 256 * 256 * 256 + m_buffer[21] * 256 * 256 + m_buffer[22] * 256 + m_buffer[23];
            int I_Min = m_buffer[24] * 256 * 256 * 256 + m_buffer[25] * 256 * 256 + m_buffer[26] * 256 + m_buffer[27];

            this.textBox_Kp_get.Text = Convert.ToString(kp);
            this.textBox_Ki_get.Text = Convert.ToString(ki);
            this.textBox_Kd_get.Text = Convert.ToString(kd);
            this.textBox_P_Max_get.Text = Convert.ToString(P_Max);
            this.textBox_I_Max_get.Text = Convert.ToString(I_Max);
            this.textBox_I_Min_get.Text = Convert.ToString(I_Min);

            this.label_pid_get_result.Text = "Successful!";
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

            //将数据显示在app上
            label_flow_slpm.Text = Convert.ToString(data_recv.FLOW_SLPM);
            label_flow_lpm_set.Text = Convert.ToString(data_recv.FLOW_LPM_SET);
            label_pro_pwm.Text = Convert.ToString(data_recv.PRO_PWM);

            label_avg_flow.Text = Convert.ToString(data_recv.AVG_FLOW);
            label_flow.Text = Convert.ToString(data_recv.FLOW);
            label_sensor_type.Text = Convert.ToString(data_recv.SENSOR_TYPE);
            label_sensor_err.Text = Convert.ToString(data_recv.SENSOR_ERR);
            label_cur_adc.Text = Convert.ToString(data_recv.CUR_ADC);
            label_is_valve_exist.Text = Convert.ToString(data_recv.IS_VALVE_EXIST);
            label_is_5V_ok.Text = Convert.ToString(data_recv.IS_5V_OK);
            label_is_12V_ok.Text = Convert.ToString(data_recv.IS_12V_OK);

            //将数据添加到链表中
            SENSOR_DATA data = new SENSOR_DATA();

            if (m_b_start_test_valve_curve && this.checkBox_lock_device.Checked)
            {
                data.PWM_DC = Convert.ToInt32(this.textBox_start_PWM_DC.Text);
            }
            else
            {
                data.PWM_DC = Convert.ToInt32(this.label_pro_pwm.Text);
            }
            
            data.FLOW_LPM_SET = Convert.ToInt32(this.label_flow_lpm_set.Text);
            data.DATA_0 = Convert.ToByte(data_recv.FLOW / 256);
            data.DATA_1 = Convert.ToByte(data_recv.FLOW % 256);

            data.AVG_FLOW_DATA_0 = Convert.ToByte(data_recv.AVG_FLOW / 256);
            data.AVG_FLOW_DATA_1 = Convert.ToByte(data_recv.AVG_FLOW % 256);
            m_HWData_list.Add(data);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
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

            //加载配置文件，初始化text box
            InitTextBox();
        }

        private void InitTextBox()
        {
            //文件存在就加载配置的值，不存在就使用默认值
            if ((File.Exists(m_flow_pid_FilePath)))
            {
                FileStream fs = new FileStream(m_flow_pid_FilePath, FileMode.Open);
                BinaryReader br = new BinaryReader(fs,Encoding.ASCII);

                int len = Marshal.SizeOf(flow_pid_parameter);
                byte[] buffer = new byte[len];

                br.Read(buffer, 0, len);

                br.Close();
                fs.Close();

                //将buffer转换成flow_pid_parameter
                flow_pid_parameter=GetObject<FLOW_PID_PARAMETER>(buffer, len);

                //赋值给textbox
                this.checkBox1.Checked = flow_pid_parameter.FLOW_ONLY_SET_FLOW;
                this.textBox_start_flow.Text = Convert.ToString(flow_pid_parameter.START_FLOW);
                this.textBox_end_flow.Text = Convert.ToString(flow_pid_parameter.END_FLOW);
                this.textBox_step.Text = Convert.ToString(flow_pid_parameter.STEP);
                this.textBox_duration.Text = Convert.ToString(flow_pid_parameter.DURATION);
                this.textBox_set_flow.Text = Convert.ToString(flow_pid_parameter.SET_FLOW);

                this.textBox_Kp.Text = Convert.ToString(flow_pid_parameter.PID_Kp);
                this.textBox_Ki.Text = Convert.ToString(flow_pid_parameter.PID_Ki);
                this.textBox_Kd.Text = Convert.ToString(flow_pid_parameter.PID_Kd);
                this.textBox_P_Max.Text = Convert.ToString(flow_pid_parameter.PID_P_MAX);
                this.textBox_I_Max.Text = Convert.ToString(flow_pid_parameter.PID_I_MAX);
                this.textBox_I_Min.Text = Convert.ToString(flow_pid_parameter.PID_I_MIN);
            }
            else
            {
                //默认值
                this.textBox_start_flow.Text = "0";
                this.textBox_end_flow.Text = "0";
                this.textBox_step.Text = "0";
                this.textBox_duration.Text = "0";
                this.textBox_set_flow.Text = "0";

                this.textBox_Kp.Text = "3";
                this.textBox_Ki.Text = "5";
                this.textBox_Kd.Text = "1";
                this.textBox_P_Max.Text = "1000";
                this.textBox_I_Max.Text = "48000";
                this.textBox_I_Min.Text = "2000";

                //默认值
                flow_pid_parameter.PID_Kp = Convert.ToInt32(this.textBox_Kp.Text);
                flow_pid_parameter.PID_Ki = Convert.ToInt32(this.textBox_Ki.Text);
                flow_pid_parameter.PID_Kd = Convert.ToInt32(this.textBox_Kd.Text);
                flow_pid_parameter.PID_P_MAX = Convert.ToInt32(this.textBox_P_Max.Text);
                flow_pid_parameter.PID_I_MAX = Convert.ToInt32(this.textBox_I_Max.Text);
                flow_pid_parameter.PID_I_MIN = Convert.ToInt32(this.textBox_I_Min.Text);
                flow_pid_parameter.FLOW_ONLY_SET_FLOW = true;
                flow_pid_parameter.START_FLOW = 0;
                flow_pid_parameter.END_FLOW = 0;
                flow_pid_parameter.STEP = 0;
                flow_pid_parameter.DURATION = 0;
                flow_pid_parameter.SET_FLOW = 0;
            }


            if (this.checkBox1.Checked)
            {
                this.textBox_start_flow.Enabled = false;
                this.textBox_end_flow.Enabled = false;
                this.textBox_step.Enabled = false;
                this.textBox_duration.Enabled = false;
            }

            this.checkBox_auto_set_Y_axi.Checked = true;
            this.textBox_Y_Min.Enabled = false;
            this.textBox_Y_Max.Enabled = false;
            this.textBox_Y_interval.Enabled = false;
            this.button_SET_Y_AXI.Enabled = false;
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
                m_HWData_list.Clear();
                m_HW_buffer.Clear();
                m_buffer.Clear();

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
                ||textBox_duration.Text=="")&&!this.checkBox1.Checked)
            {
                if (textBox_set_flow.Text == "")
                {
                    textBox_set_flow.Text = "0";
                }
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

            for (int i = 1; i < send_buffer[LEN]; i++)
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
                flow_pid_parameter.FLOW_ONLY_SET_FLOW = true;

                this.textBox_start_flow.Enabled = false;
                this.textBox_end_flow.Enabled = false;
                this.textBox_step.Enabled = false;
                this.textBox_duration.Enabled = false;
                this.textBox_set_flow.Enabled = true;

                this.textBox_set_flow.Visible = true;
                label_set_flow.Visible = true;
                label10.Visible = true;
            }
            else
            {
                flow_pid_parameter.FLOW_ONLY_SET_FLOW = false;

                this.textBox_start_flow.Enabled = true;
                this.textBox_end_flow.Enabled = true;
                this.textBox_step.Enabled = true;
                this.textBox_duration.Enabled = true;
                this.textBox_set_flow.Enabled = false;

                this.textBox_set_flow.Visible = false;
                label_set_flow.Visible = false;
                label10.Visible = false;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button_PID_SEND_Click(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please open serial port!");
                return;
            }
            UInt32 sum = 0;
            byte[] send_buffer = new byte[31];
            send_buffer[0] = 0xFF;
            send_buffer[LEN] = 31 - 2;    //发送的包长度,不包含checksum
            send_buffer[2] = 0x01;
            send_buffer[3] = 0xAA;

            //disable debug
            send_buffer[4] = Convert.ToByte( this.checkBox_disable_debug.Checked ? 1 : 0);

            //存储PID参数
            flow_pid_parameter.PID_Kp = Convert.ToInt32(this.textBox_Kp.Text);
            flow_pid_parameter.PID_Ki = Convert.ToInt32(this.textBox_Ki.Text);
            flow_pid_parameter.PID_Kd = Convert.ToInt32(this.textBox_Kd.Text);
            flow_pid_parameter.PID_P_MAX = Convert.ToInt32(this.textBox_P_Max.Text);
            flow_pid_parameter.PID_I_MAX = Convert.ToInt32(this.textBox_I_Max.Text);
            flow_pid_parameter.PID_I_MIN = Convert.ToInt32(this.textBox_I_Min.Text);

            //Kp
            send_buffer[5] = Convert.ToByte(Convert.ToInt32(this.textBox_Kp.Text) / 65536/256);
            send_buffer[6] = Convert.ToByte(Convert.ToInt32(this.textBox_Kp.Text) / 65536 % 256);
            send_buffer[7] = Convert.ToByte(Convert.ToInt32(this.textBox_Kp.Text) % 65536 / 256);
            send_buffer[8] = Convert.ToByte(Convert.ToInt32(this.textBox_Kp.Text) % 65536 % 256);

            //Ki
            send_buffer[9] = Convert.ToByte(Convert.ToInt32(this.textBox_Ki.Text) / 65536 / 256);
            send_buffer[10] = Convert.ToByte(Convert.ToInt32(this.textBox_Ki.Text) / 65536 % 256);
            send_buffer[11] = Convert.ToByte(Convert.ToInt32(this.textBox_Ki.Text) % 65536 / 256);
            send_buffer[12] = Convert.ToByte(Convert.ToInt32(this.textBox_Ki.Text) % 65536 % 256);

            //Kd
            send_buffer[13] = Convert.ToByte(Convert.ToInt32(this.textBox_Kd.Text) / 65536 / 256);
            send_buffer[14] = Convert.ToByte(Convert.ToInt32(this.textBox_Kd.Text) / 65536 % 256);
            send_buffer[15] = Convert.ToByte(Convert.ToInt32(this.textBox_Kd.Text) % 65536 / 256);
            send_buffer[16] = Convert.ToByte(Convert.ToInt32(this.textBox_Kd.Text) % 65536 % 256);

            //P Max
            send_buffer[17] = Convert.ToByte(Convert.ToInt32(this.textBox_P_Max.Text) / 65536 / 256);
            send_buffer[18] = Convert.ToByte(Convert.ToInt32(this.textBox_P_Max.Text) / 65536 % 256);
            send_buffer[19] = Convert.ToByte(Convert.ToInt32(this.textBox_P_Max.Text) % 65536 / 256);
            send_buffer[20] = Convert.ToByte(Convert.ToInt32(this.textBox_P_Max.Text) % 65536 % 256);

            //I Max
            send_buffer[21] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Max.Text) / 65536 / 256);
            send_buffer[22] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Max.Text) / 65536 % 256);
            send_buffer[23] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Max.Text) % 65536 / 256);
            send_buffer[24] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Max.Text) % 65536 % 256);

            //D Max
            send_buffer[25] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Min.Text) / 65536 / 256);
            send_buffer[26] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Min.Text) / 65536 % 256);
            send_buffer[27] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Min.Text) % 65536 / 256);
            send_buffer[28] = Convert.ToByte(Convert.ToInt32(this.textBox_I_Min.Text) % 65536 % 256);


            for (int i = 1; i < send_buffer[LEN]; i++)
            {
                sum += send_buffer[i];
            }


            //填充checksum
            send_buffer[Convert.ToInt32(send_buffer[LEN])] = Convert.ToByte(sum / 256);   //checksum1
            send_buffer[Convert.ToInt32(send_buffer[LEN]) + 1] = Convert.ToByte(sum % 256); //checksum2

            this.serialPort1.Write(send_buffer, 0, Convert.ToInt32(send_buffer[LEN]) + 2);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBox_disable_debug.Checked)
            {
                //this.checkBox_enable_debug.Text = "Disable debug";

                this.textBox_Kp.Enabled = true;
                this.textBox_Ki.Enabled = true;
                this.textBox_Kd.Enabled = true;
                this.textBox_P_Max.Enabled = true;
                this.textBox_I_Max.Enabled = true;
                this.textBox_I_Min.Enabled = true;
            }
            else
            {
                //this.checkBox_enable_debug.Text = "Enable debug";

                this.textBox_Kp.Enabled = false;
                this.textBox_Ki.Enabled = false;
                this.textBox_Kd.Enabled = false;
                this.textBox_P_Max.Enabled = false;
                this.textBox_I_Max.Enabled = false;
                this.textBox_I_Min.Enabled = false;
            }
        }

        private void textBox_Kp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void textBox_Ki_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void textBox_Kd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           
        }

        private void textBox_P_Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void textBox_I_Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void textBox_I_Min_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           
        }

        private void textBox_start_flow_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void textBox_end_flow_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void textBox_step_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           
        }

        private void textBox_duration_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           
        }

        private void textBox_set_flow_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //发送
            if (m_b_start_test_valve_curve&&this.serialPort1.IsOpen&& checkBox_lock_device.Checked)
            {
                //设置PWM值，循环
                auto_set_PWM_DC(ref m_increase_cnt, ref m_decrease_cnt, ref m_hold_cnt,ref m_curve_state);

                send_test_valve_curve();

            }

            //取消勾选的时候不要设置坐标
            if (this.checkBox_auto_set_Y_axi.Checked)
            {
                set_Y_AXI();
            }

            if (label_PID_set_result_cnt == 50)
            {
                label_PID_set_result_cnt = 0;
                this.label_PID_set_result.Text = "";
                label_pid_get_result.Text = "";
            }
            else
            {
                label_PID_set_result_cnt++;
            }

            show_chart(m_HW_buffer);
        }

        private void auto_set_PWM_DC(ref int m_increase_cnt,ref int m_decrease_cnt,ref int m_hold_cnt,ref CURVE_STATE m_curve_state)
        {
            int val = Convert.ToInt32(this.textBox_start_PWM_DC.Text);
            if (m_curve_state == CURVE_STATE.CURVE_INCREASE)
            {
                if (val < PWM_MAX_DC)
                {
                    if (m_increase_cnt-- == 0)   //每隔m_increase_cnt*100ms就增加10
                    {
                        m_increase_cnt = INCREASE_CNT;
                        val += PWM_STEP;
                        this.textBox_start_PWM_DC.Text = Convert.ToString(val);
                    }
                }
                else    //  >=PWM_MAX_DC就切换到hold
                {
                    m_curve_state = CURVE_STATE.CURVE_HOLD;
                }
            }

            if (m_curve_state == CURVE_STATE.CURVE_HOLD)
            {
                if (m_hold_cnt-- == 0)
                {
                    m_hold_cnt = HOLD_CNT;
                    m_curve_state = CURVE_STATE.CURVE_DECREASE;
                }
            }

            if (m_curve_state == CURVE_STATE.CURVE_DECREASE)
            {
                if (val > 0)
                {
                    if (m_decrease_cnt-- == 0)
                    {

                        m_decrease_cnt = DECREASE_CNT;
                        val -= PWM_STEP;
                        this.textBox_start_PWM_DC.Text = Convert.ToString(val);
                    }
                }
                else
                {
                    this.textBox_start_PWM_DC.Text ="0";
                    m_curve_state = CURVE_STATE.CURVE_INCREASE;
                }
                
            }
            

        }

        private void send_test_valve_curve()
        {
            UInt32 sum = 0;
            byte[] send_buffer = new byte[9];
            send_buffer[0] = 0xFF;
            send_buffer[LEN] = 9 - 2;    //发送的包长度,不包含checksum
            send_buffer[2] = 0x01;
            send_buffer[3] = 0xAF;
            
            send_buffer[4] = this.checkBox_lock_device.Checked ? Convert.ToByte(1) : Convert.ToByte(0);

            if (Convert.ToInt32(this.textBox_start_PWM_DC.Text) < 0)
            {
                this.textBox_start_PWM_DC.Text = "0";
            }
            send_buffer[5] = Convert.ToByte(Convert.ToInt32(this.textBox_start_PWM_DC.Text) / 256);
            send_buffer[6] = Convert.ToByte(Convert.ToInt32(this.textBox_start_PWM_DC.Text) % 256);

            for (int i = 1; i < send_buffer[LEN]; i++)
            {
                sum += send_buffer[i];
            }

            //填充checksum
            send_buffer[Convert.ToInt32(send_buffer[LEN])] = Convert.ToByte(sum / 256);   //checksum1
            send_buffer[Convert.ToInt32(send_buffer[LEN]) + 1] = Convert.ToByte(sum % 256); //checksum2

            this.serialPort1.Write(send_buffer, 0, Convert.ToInt32(send_buffer[LEN]) + 2);
        }

        private void show_chart(object list_data)
        {
            lock (m_HW_buffer)
            {
                //  while (true)
                {
                    // Thread.Sleep(500);
                    List<SENSOR_DATA> list = (List<SENSOR_DATA>)list_data;

                    if (list == null || list.Count == 0)
                    {
                        //continue;
                        return;
                    }

                    DataTable table1 = new DataTable();
                    table1 = new DataTable();
                    table1.Columns.Add("编号", typeof(int));
                    table1.Columns.Add("数据", typeof(float));

                    int LEN = 300;  //显示300个数据
                    float Y_MAX = 0;
                    Y_MAX = Y_AXI_set.Y_MAX;
                    
                    
                    List<SENSOR_DATA> show_list = new List<SENSOR_DATA>();

                    int index = 0;
                    index = (list.Count < LEN) ? 0 : list.Count - LEN;

                    int i = 0;

                    for (; index < list.Count; index++)
                    {
                        if (m_HW_buffer == null || m_HW_buffer.Count == 0)
                        {
                            return;
                        }
                        double data = (float)(m_HW_buffer[index].DATA_0 * 256 + m_HW_buffer[index].DATA_1);
                        data = data > Y_MAX ? Y_MAX : data;
                        table1.Rows.Add(i++, data);
                    }

                    Series series = new Series("S1");
                    ChartArea chartArea = new ChartArea("C1");
                    series.ChartArea = "C1";

                    this.chart1.Series.Clear();
                    this.chart1.ChartAreas.Clear();
                    this.chart1.Titles.Clear();

                    this.chart1.Titles.Add("流量(0.01L/min)");

                    this.chart1.BorderlineColor = Color.Gray;
                    this.chart1.BorderlineWidth = 1;
                    this.chart1.BorderlineDashStyle = ChartDashStyle.Solid;
                    series.BorderWidth = 2;

                    //chartarea中设置是否显示虚线
                    chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
                    chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                    //series中设置x,y轴坐标类型
                    series.XValueType = ChartValueType.Int32;  //设置X,Y轴的坐标类型
                    series.YValueType = ChartValueType.Int32;

                    //设置图标类型，折线图
                    series.ChartType = SeriesChartType.Spline;
                    series.MarkerSize = 1;

                    ////chartArea_honeywellData.AxisX.LabelStyle.Format = "HH:mm\nMM-dd";
                    //chartArea.AxisX.LabelStyle.Format = "%d";
                    chartArea.AxisX.Minimum = 0;
                    chartArea.AxisX.Maximum = LEN;
                    chartArea.AxisX.Interval = 50;
                    ////chartArea_honeywellData.AxisX.Interval = 0.125 / 3 * duration; //调整x轴坐标，特别注意这个！

                    //chartarea中设置y轴显示范围，以及步长
                    //chartArea.AxisY.Maximum = Y_MAX;
                    //chartArea.AxisY.Minimum = Convert.ToInt32(label_flow_lpm_set.Text) - 500;
                    //chartArea.AxisY.Interval = 100;
                    chartArea.AxisY.Maximum = Y_MAX;
                    chartArea.AxisY.Minimum = Y_AXI_set.Y_MIN;
                    chartArea.AxisY.Interval = Y_AXI_set.Y_INTERVAL;
                   

                    this.chart1.Legends.Clear(); //清除chart_workData的legend
                    this.chart1.ChartAreas.Add(chartArea);
                    this.chart1.Series.Add(series);
                    this.chart1.Series[0].Points.DataBind(table1.AsEnumerable(), "编号", "数据", "");

                    table1 = null;

                    Y_AXI_set.IS_SETTED = false;   //不允许设置Y轴，除非点了set按键
                    //this.chart1.Invalidate();
                }
            }
        }

        private void textBox_Y_Min_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox_Y_Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void set_Y_AXI()
        {
            //设置Y轴的上下限，设置当前值flow_lpm_set的正负500(也就是正负5L/min)
            //如果接收到的flow_lpm_set有数据
            int flow_lpm_set = Convert.ToInt32(this.label_flow_lpm_set.Text);
            if (flow_lpm_set > 0)
            {
                //设置下限
                if (flow_lpm_set - 500 > 0)
                {
                    //设置整数值
                    if ((flow_lpm_set - 500) % 100 > 0)  //有余数
                    {
                        this.textBox_Y_Min.Text = Convert.ToString(Convert.ToInt32((flow_lpm_set - 500) / 100) * 100);
                    }
                    else                                //没有余数
                    {
                        this.textBox_Y_Min.Text = Convert.ToString(flow_lpm_set - 500);
                    }
                }
                else
                {
                    this.textBox_Y_Min.Text = "0";
                }

                //设置上限
                if (flow_lpm_set + 500 < 9000)
                {
                    //设置整数值
                    if ((flow_lpm_set + 500) % 100 > 0)  //有余数
                    {
                        this.textBox_Y_Max.Text = Convert.ToString(Convert.ToInt32((flow_lpm_set + 500) / 100) * 100);
                    }
                    else                                //没有余数
                    {
                        this.textBox_Y_Max.Text = Convert.ToString(flow_lpm_set + 500);
                    }
                }
                else     //超出上限
                {
                    this.textBox_Y_Max.Text = "9000";
                }
                
            }
            else
            {
                this.textBox_Y_Min.Text = "0";   //如果没有数据,就直接赋值为0
            }
            this.textBox_Y_interval.Text = "100";
            
            Y_AXI_set.Y_MIN = Convert.ToInt32(this.textBox_Y_Min.Text);
            Y_AXI_set.Y_MAX = Convert.ToInt32(this.textBox_Y_Max.Text);
            Y_AXI_set.Y_INTERVAL = 100;
           
        }

        private void checkBox_auto_set_Y_axi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_auto_set_Y_axi.Checked)
            {
                this.textBox_Y_Min.Enabled = false;
                this.textBox_Y_Max.Enabled = false;
                this.textBox_Y_interval.Enabled = false;
                button_SET_Y_AXI.Enabled = false;
            }
            else
            {
                this.textBox_Y_Min.Enabled = true;
                this.textBox_Y_Max.Enabled = true;
                this.textBox_Y_interval.Enabled = true;
                button_SET_Y_AXI.Enabled = true;
            }

            set_Y_AXI();
        }

        private void textBox1_interval_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button_SET_Y_AXI_Click(object sender, EventArgs e)
        {
            //将值放入Y_AXI_set结构体中
            Y_AXI_set.IS_SETTED = true;
            Y_AXI_set.Y_MAX = Convert.ToInt32(this.textBox_Y_Max.Text);
            Y_AXI_set.Y_MIN = Convert.ToInt32(this.textBox_Y_Min.Text);
            Y_AXI_set.Y_INTERVAL = Convert.ToInt32(this.textBox_Y_interval.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream(m_flow_pid_FilePath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            //获取结构体的长度
            int len = Marshal.SizeOf(flow_pid_parameter);
            //将结构体转换成byte[]
            byte[] buffer = GetData(flow_pid_parameter);

            bw.Write(buffer, 0, len);

            bw.Close();
            fs.Close();
        }

        public static T GetObject<T>(byte[] data, int size)
        {
            Contract.Assume(size == Marshal.SizeOf(typeof(T)));
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.Copy(data, 0, ptr, size);
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

        }

        public static byte[] GetData(object obj)
        {
            int size = Marshal.SizeOf(obj.GetType());
            byte[] data = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(obj, ptr, true);
                Marshal.Copy(ptr, data, 0, size);
                return data;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        private void textBox_start_flow_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_start_flow.Text == "")
            {
                flow_pid_parameter.START_FLOW = 0;
            }
            else
            {
                flow_pid_parameter.START_FLOW = Convert.ToInt32(this.textBox_start_flow.Text);
            }
        }

        private void textBox_end_flow_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_end_flow.Text == "")
            {
                flow_pid_parameter.END_FLOW = 0;
            }
            else
            {
                flow_pid_parameter.END_FLOW = Convert.ToInt32(this.textBox_end_flow.Text);
            }
        }

        private void textBox_step_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_step.Text == "")
            {
                flow_pid_parameter.STEP = 0;
            }
            else
            {
                flow_pid_parameter.STEP = Convert.ToInt32(this.textBox_step.Text);
            }
            
        }

        private void textBox_duration_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_duration.Text == "")
            {
                flow_pid_parameter.DURATION = 0;
            }
            else
            {
                flow_pid_parameter.DURATION = Convert.ToInt32(this.textBox_duration.Text);
            }
            
        }

        private void textBox_set_flow_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_set_flow.Text == "")
            {
                flow_pid_parameter.SET_FLOW = 0;
            }
            else
            {
                flow_pid_parameter.SET_FLOW = Convert.ToInt32(this.textBox_set_flow.Text);
            }
            
        }

        private void textBox_Kp_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_Kp.Text == "")
            {
                flow_pid_parameter.PID_Kp = 0;
            }
            else
            {
                flow_pid_parameter.PID_Kp = Convert.ToInt32(this.textBox_Kp.Text);
            }
            
        }

        private void textBox_Ki_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_Ki.Text == "")
            {
                flow_pid_parameter.PID_Ki = 0;
            }
            else
            {
                flow_pid_parameter.PID_Ki = Convert.ToInt32(this.textBox_Ki.Text);
            }
           
        }

        private void textBox_Kd_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_Kd.Text == "")
            {
                flow_pid_parameter.PID_Kd = 0;
            }
            else
            {
                flow_pid_parameter.PID_Kd = Convert.ToInt32(this.textBox_Kd.Text);
            }
            
        }

        private void textBox_P_Max_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_P_Max.Text == "")
            {
                flow_pid_parameter.PID_P_MAX = 0;
            }
            else
            {
                flow_pid_parameter.PID_P_MAX = Convert.ToInt32(this.textBox_P_Max.Text);
            }
        }

        private void textBox_I_Max_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_I_Max.Text == "")
            {
                flow_pid_parameter.PID_I_MAX = 0;
            }
            else
            {
                flow_pid_parameter.PID_I_MAX = Convert.ToInt32(this.textBox_I_Max.Text);
            }

        }

        private void textBox_I_Min_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_I_Min.Text == "")
            {
                flow_pid_parameter.PID_I_MIN = 0;
            }
            else
            {
                flow_pid_parameter.PID_I_MIN = Convert.ToInt32(this.textBox_I_Min.Text);
            }
            
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please close serial port first!");
                return;
            }


            if (m_HWData_list.Count > 0)
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    var path = this.folderBrowserDialog1.SelectedPath;
                    string fileName = "Flow_Data_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

                    FileStream fs = null;
                    try
                    {
                        fs = new FileStream(path + @"\" + fileName, FileMode.Create);
                    }
                    catch (Exception ex)
                    {
                        fs.Close();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    sw.WriteLine("No.," + "flow_lpm_set,"+"pwm_DC,"+"Data");
                    for (int i = 0; i < m_HWData_list.Count; i++)
                    {
                        //sw.WriteLine(Convert.ToString(i)+","+Convert.ToString(this.m_HWData_list[i].FLOW_LPM_SET)+","+
                        //    Convert.ToString(m_HWData_list[i].PWM_DC )+","+
                        //    Convert.ToString(m_HWData_list[i].DATA_0 * 256 + m_HWData_list[i].DATA_1));
                        sw.WriteLine(Convert.ToString(i) + "," + Convert.ToString(this.m_HWData_list[i].FLOW_LPM_SET) + "," +
                           Convert.ToString(m_HWData_list[i].PWM_DC) + "," +
                           Convert.ToString(m_HWData_list[i].AVG_FLOW_DATA_0 * 256 + m_HWData_list[i].AVG_FLOW_DATA_1));
                    }

                    sw.Close();
                    fs.Close();
                    MessageBox.Show("Create successful for\n\n"+fileName);
                }

            }
            else
            {
                MessageBox.Show("No data!");
            }
        }

        private void button_PID_GET_Click(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please open serial port!");
                return;
            }
            UInt32 sum = 0;
            byte[] send_buffer = new byte[6];
            send_buffer[0] = 0xFF;
            send_buffer[LEN] = 6 - 2;    //发送的包长度,不包含checksum
            send_buffer[2] = 0x01;
            send_buffer[3] = 0xAC;       //发送获取PID参数命令

            for (int i = 1; i < send_buffer[LEN]; i++)
            {
                sum += send_buffer[i];
            }

            //填充checksum
            send_buffer[Convert.ToInt32(send_buffer[LEN])] = Convert.ToByte(sum / 256);   //checksum1
            send_buffer[Convert.ToInt32(send_buffer[LEN]) + 1] = Convert.ToByte(sum % 256); //checksum2

            this.serialPort1.Write(send_buffer, 0, Convert.ToInt32(send_buffer[LEN]) + 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text == "")
            {
                return;
            }

            if (Convert.ToInt32(((TextBox)(sender)).Text) > 4800)
            {
                MessageBox.Show("Max value is 4800");
                ((TextBox)(sender)).Text = "0";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-退格键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button_manual_set_pwm_DC_Click(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please open serial port!");
                return;
            }
            UInt32 sum = 0;
            byte[] send_buffer = new byte[9];
            send_buffer[0] = 0xFF;
            send_buffer[LEN] = 9 - 2;    //发送的包长度,不包含checksum
            send_buffer[2] = 0x01;
            send_buffer[3] = 0xAE;

            send_buffer[4] = this.checkBox_manual_set_pwm_DC.Checked ? Convert.ToByte(1) : Convert.ToByte(0);
            send_buffer[5] = Convert.ToByte(Convert.ToInt32(this.textBox_pwm_dc_value.Text) / 256);
            send_buffer[6] = Convert.ToByte(Convert.ToInt32(this.textBox_pwm_dc_value.Text) % 256);

            for (int i = 1; i < send_buffer[LEN]; i++)
            {
                sum += send_buffer[i];
            }

            //填充checksum
            send_buffer[Convert.ToInt32(send_buffer[LEN])] = Convert.ToByte(sum / 256);   //checksum1
            send_buffer[Convert.ToInt32(send_buffer[LEN]) + 1] = Convert.ToByte(sum % 256); //checksum2

            this.serialPort1.Write(send_buffer, 0, Convert.ToInt32(send_buffer[LEN]) + 2);
        }

        private void button_test_valve_curve_Click(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please open serial port!");
                return;
            }

            m_b_start_test_valve_curve = !m_b_start_test_valve_curve;
            if (m_b_start_test_valve_curve)
            {
                this.button_start_test_valve_curve.Text = "STOP";
                this.textBox_start_PWM_DC.Enabled = false;
                m_curve_state = CURVE_STATE.CURVE_INCREASE;

                button_manual_set_pwm_DC.Enabled = false;
                button_FLOW_SEND.Enabled = false;
            }
            else
            {
                this.button_start_test_valve_curve.Text = "START";
                this.textBox_start_PWM_DC.Enabled = true;
                m_curve_state = CURVE_STATE.CURVE_NONE;

                button_manual_set_pwm_DC.Enabled = true;
                button_FLOW_SEND.Enabled = true;

                send_test_valve_curve();
            }
        }

        private void checkBox_lock_device_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
