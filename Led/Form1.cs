using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Globalization;

namespace Led
{
    public partial class Form1 : Form
    {
        SerialPort port;
        Thread tempSensThread;
        Thread logTempThread;
        Thread statusReadThread;
        int setPoint = 18;
        byte[] command = new byte[1];
        public Form1()
        {
            InitializeComponent();
            SetLabel(setPoint.ToString());
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            if (port == null)
            {
                //MessageBox.Show("Port-ul este utilizat");
                port = new SerialPort("COM3", 9600);//Set your board COM
                port.Open();
                
                tempSensThread = new Thread(readTemp); // creez un nou Thread pentru metoda care citeste temperatura odata la 0.5 secunde de pe port 
                tempSensThread.Start(); // starting thread
                
                logTempThread = new Thread(logTemp); // creez un nou Thread pentru a insera in baza de date log uri legate de temperatura
                logTempThread.Start(); // starting thread

                statusReadThread = new Thread(readStatus);// creez un nou Thread pentru metoda care afiseaza statusul sursei de caldura
                statusReadThread.Start();
            }
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
                
            }
        } 
        void SetLabel(string text)
        {
            labelSetPoint.Text = text; 

        }
        void logTemp()
        {
            while (true)
            {
                port.DiscardInBuffer();
                command[0] = 0x2e;
                PortWrite(command);
                string a = port.ReadLine();
                MessageBox.Show(a);
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\DB\AppDB.mdf;Integrated Security=True;Connect Timeout=30"); //schimba location cu path-ul bazei tale de date create. LoginTable e tabel cu id, username, password
                string now = DateTime.Now.ToString("F", CultureInfo.CreateSpecificCulture("en-US"));
                SqlCommand comm = new SqlCommand("insert into LogTemp1 values (' " + a + "', '" + now + "')",conn) ;
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                //DataTable dtbl = new DataTable();
               // sda.Fill(dtbl);
                Thread.Sleep(1000 * 60 * 5);
            }
        }

        void readTemp()
        {
            while (true)
            {
                
                port.DiscardInBuffer();
                command[0] = 1;
                PortWrite(command);
                string a = port.ReadLine();
                this.Invoke(new MethodInvoker(delegate ()
                {
                    labelTemp.Text = a;
                })); // nu pot modifica formul din al thread decat cel care l-a creat. pentru asta se foloseste begin invoke
                Thread.Sleep(500);
            }
        }

        void readStatus()
        {
            while (true)
            {

                port.DiscardInBuffer();
                command[0] = 5;
                PortWrite(command);
                string a = port.ReadLine();
                this.Invoke(new MethodInvoker(delegate ()
                {
                    labelStatus.Text = a;
                })); // nu pot modifica formul din al thread decat cel care l-a creat. pentru asta se foloseste begin invoke
                Thread.Sleep(500);
                //testt
            }
        }

 
        
        private void button3_Click(object sender, EventArgs e)//SetPlus
        {
            port.DiscardInBuffer();
            command[0] = 3;
            PortWrite(command);
            setPoint++;
            SetLabel(setPoint.ToString());
            //string a = port.ReadLine();
            //MessageBox.Show(a);
        }
        private void button1_Click(object sender, EventArgs e)//SetMinus
        {
            port.DiscardInBuffer();
            command[0] = 4;
            PortWrite(command);
            setPoint--;
            SetLabel(setPoint.ToString());
            //string a = port.ReadLine();
            //MessageBox.Show(a);
        }


        private void PortWrite(byte[] message)
        {

            port.Write(message,0,1);
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

  
       
    }
}
