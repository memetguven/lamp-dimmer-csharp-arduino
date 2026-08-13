using System.IO.Ports;

namespace LampBrightness
{
    public partial class Form1 : Form
    {
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] ports = SerialPort.GetPortNames();

            foreach (string p in ports)
            {
                comboBox1.Items.Add(p);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
                btnConnect.Text = "Connect";
                label1.Text = "Not Connected";
                label1.ForeColor = Color.Red;
                trackBar1.Enabled = false;
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a COM port.");
                return;
            }

            try
            {
                port = new SerialPort(comboBox1.SelectedItem.ToString(), 9600);
                port.Open();

                btnConnect.Text = "Disconnect";
                label1.Text = "Connected: " + comboBox1.SelectedItem.ToString();
                label1.ForeColor = Color.Green;
                trackBar1.Enabled = true;

                port.WriteLine(trackBar1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Brightness %" + trackBar1.Value;

            if (port != null && port.IsOpen)
            {
                port.WriteLine(trackBar1.Value.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
 
            if (port != null && port.IsOpen)
            {
                port.Close();
            }
        }
    }
}