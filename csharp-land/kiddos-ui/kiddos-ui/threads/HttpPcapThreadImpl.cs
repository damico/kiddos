using System;
using System.Collections.Generic;
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
    class HttpPcapThreadImpl
    {
        private SeedEntity seed = null;
        private int id = -1;
        private int times = -1;
        private TextBox logBox = null;
        private Label activeTlabel = null;
        private Label srL = null;
        private Label urL = null;
        private Label dLen = null;
        private Label uLen = null;
        private int deviceIndex = 0;
        private Button plantBt = null;

        public HttpPcapThreadImpl(SeedEntity seed, int id, int times, TextBox logBox, Label activeTlabel, Label srL, Label urL, Label dLen, Label uLen, int deviceIndex, Button plantBt)
        {
            this.id = id;
            this.seed = seed;
            this.times = times;
            this.logBox = logBox;
            this.activeTlabel = activeTlabel;
            this.srL = srL;
            this.urL = urL;
            this.dLen = dLen;
            this.uLen = uLen;
            this.deviceIndex = deviceIndex;
            this.plantBt = plantBt;
        }

        private void UpdateFormItemText(String str)
        {
           logBox.Text = str + "\n";
        }

        private void DecreaseFormItemText(Label label)
        {
            Int32 value = Int32.Parse(label.Text);
            value--;
            label.Text = value.ToString();
        }

        private void IncreaseFormItemText(Label label)
        {
            Int64 value = Int64.Parse(label.Text);
            value++;
            label.Text = value.ToString();
        }

        private void IncreaseLabelBytes(Label label, Int64 len)
        {
            String unit = "B";

            String sLen = len.ToString();
            Double rDouble = len;

            if (len > 1024 && len < (1024 * 1024))
            {
                unit = "KB";
                rDouble = len / 1024;
                sLen = rDouble.ToString();
            }
            else if (len > (1024 * 1024) && len < (1024 * 1024 * 1024))
            {
                unit = "MB";
            }
            else if (len > (1024 * 1024 * 1024))
            {
                unit = "GB";
            }
            label.Text = len + " " + unit;
        }

        private void ReleaseUi()
        {
            plantBt.Enabled = true;
            IgnitionForm.KiddieZooStatus = false;
        
        }

        public void run()
        {
            
                String message = "Thread (Spoof) " + id+". ("+seed.domain+")";
                logBox.Invoke(new IgnitionForm.UpdateTextCallback(this.UpdateFormItemText), new object[]{message});
                activeTlabel.Invoke(new IgnitionForm.UpdateTextCallbackT(this.IncreaseFormItemText), new object[]{activeTlabel});

                Utils.Instance.sendPacket(deviceIndex, times);
                activeTlabel.Invoke(new IgnitionForm.UpdateTextCallbackT(this.DecreaseFormItemText), new object[] { activeTlabel });
                if (activeTlabel.Text == "0") plantBt.Invoke(new IgnitionForm.ReleaseUi(this.ReleaseUi), null);

        }
    }
}