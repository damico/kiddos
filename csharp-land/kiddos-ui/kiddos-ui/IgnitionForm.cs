using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Http;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

/*

Copyleft 2015 - Jose Ricardo de Oliveira Damico <jd.comment@gmail.com>

This file is part of Kiddos.

Kiddos is free software: you can redistribute it and/or modify it under the terms 
of the GNU General Public License as published by the Free Software Foundation, 
either version 3 of the License, or any later version.

Kiddos is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with Kiddos. 
If not, see http://www.gnu.org/licenses/.

*/

namespace kiddos_ui
{
    public partial class IgnitionForm : Form
    {
        public static Int64 rd = 0;
        public static Int64 ud = 0;
        public static bool KiddieZooStatus = false;
        public static String clientId = null;

        public IgnitionForm()
        {
            InitializeComponent();
        }

        public delegate void UpdateTextCallback(String dataStr);
        public delegate void UpdateTextCallbackT(Label label);
        public delegate void IncreaseLabelBytes(Label label, Int64 len);
        public delegate void ReleaseUi();


        private bool checkUiInput(String urlStr, int iFaceIndex, int nThreads, int nTimes, bool spoof)
        {
            bool ret = false;

            if (nThreads > 0 && nTimes > 0 && spoof == false && urlStr.Length > 10) ret = true;
            else if (nThreads > 0 && nTimes > 0 && spoof == true && iFaceIndex >= 0 && urlStr.Length > 10) ret = true;

            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nThreads = 0;
            int nTimes = 0;

            try
            {
                nThreads = Int32.Parse(nThreadsTextBox.Text);
            }
            catch (Exception)
            { }

            try
            {
                nTimes = Int32.Parse(timesTextBox.Text);
            }
            catch (Exception)
            { }

            if (checkUiInput(urlsTextBox.Text, interfacesComboBox.SelectedIndex, nThreads, nTimes, ipSpoofCheckBox.Checked))
            {


                plantBt.Enabled = false;
                KiddieZooStatus = true;

                ClockThreadImpl clockImpl = new ClockThreadImpl(clockLabel, urlsTextBox.Text);
                Thread clock = new Thread(new ThreadStart(clockImpl.run));
                clock.Start();

                KiddosPocketEntity kde = Manager.Instance.getKiddosPocketEntityFromKiddosTrollerUrlStr(urlsTextBox.Text);

                List<SeedEntity> seedLst = kde.seedLst;

                for (int i = 0; i < seedLst.Count; i++)
                {
                    logTextBox.Text = seedLst[i].address;

                    for (int j = 0; j < nThreads; j++)
                    {
                        if (ipSpoofCheckBox.Checked) runThreadSpoof(seedLst[i], j, nTimes, logTextBox, activeThreadsLabel, srLabel, urLabel, rdL, udL, interfacesComboBox.SelectedIndex, plantBt);
                        else runThreadNoSpoof(seedLst[i], j, nTimes, logTextBox, activeThreadsLabel, srLabel, urLabel, rdL, udL, plantBt);
                    }
                }

            }
            else MessageBox.Show("Error: Missing data. Check the input fields!");
            
        }

        private void runThreadSpoof(SeedEntity seed, int id, int times, TextBox logBox, Label activeTlabel, Label srL, Label urL, Label rdL, Label udL, int deviceIndex, Button plantBt)
        {

            HttpPcapThreadImpl httpPcapThreadImpl = new HttpPcapThreadImpl(seed, id, times, logBox, activeTlabel, srL, urL, rdL, udL, deviceIndex, plantBt);
            Thread serviceThread = new Thread(new ThreadStart(httpPcapThreadImpl.run));
            serviceThread.Start();
        }

        private void runThreadNoSpoof(SeedEntity seed, int id, int times, TextBox logBox, Label activeTlabel, Label srL, Label urL, Label rdL, Label udL, Button plantBt)
        {

            HttpThreadImpl httpThreadImpl = new HttpThreadImpl(seed, id, times, logBox, activeTlabel, srL, urL, rdL, udL, plantBt);
            Thread serviceThread = new Thread(new ThreadStart(httpThreadImpl.run));
            serviceThread.Start();
        }

        private void IgnitionForm_Load(object sender, EventArgs e)
        {
            List<String> iFaces = Utils.Instance.getPcapInterfaces();
            foreach (var iface in iFaces)
            {
                interfacesComboBox.Items.Add(iface);
            }

            String cpName = System.Environment.MachineName;
            DateTime d = new DateTime();
            clientId = Utils.Instance.CalculateMD5Hash(cpName + d.ToString());
            idTextBox.Text = clientId;
            this.Text = this.Text + " - " + Constants.VERSION;


        }

        private void ipSpoofCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ipSpoofCheckBox.Checked)
            {
                interfacesComboBox.Enabled = true;
                label10.Enabled = true;
            }
            else
            {
                interfacesComboBox.Enabled = false;
                label10.Enabled = false;
            }
        }
    }



}
