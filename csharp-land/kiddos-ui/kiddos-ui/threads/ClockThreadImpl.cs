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
    class ClockThreadImpl
    {
        private Int32 h = 0;
        private Int32 m = 0;
        private Int32 s = 0;
        private Label clockLabel = null;
        private String kiddosTrollerUrl = null;

        public ClockThreadImpl(Label clockLabel, String kiddosTrollerUrl)
        {
            this.clockLabel = clockLabel;
            this.kiddosTrollerUrl = kiddosTrollerUrl;
        }

        private void UpdateFormItemText(String str)
        {
            clockLabel.Text = str;
        }

        public void run()
        {
            while (IgnitionForm.KiddieZooStatus)
            {
                Thread.Sleep(1000);
                s++;
                if (s == 60)
                {
                    s = 0;
                    m++;
                }
                if (m == 60)
                {
                    UpdateKiddosTrollerThreadImpl updateImpl = new UpdateKiddosTrollerThreadImpl(kiddosTrollerUrl);
                    Thread updateT = new Thread(new ThreadStart(updateImpl.run));
                    updateT.Start();

                    m = 0;
                    h++;
                }
                String time = (h < 10 ? "0" : "") + h.ToString() + ":" + (m < 10 ? "0" : "") + m.ToString() + ":" + (s < 10 ? "0" : "") + s.ToString();
                clockLabel.Invoke(new IgnitionForm.UpdateTextCallback(this.UpdateFormItemText), new object[] { time });       

            }
        }
    }
}
