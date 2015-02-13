using System;
using System.Collections.Generic;
using System.Text;

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
    public class Manager
    {
        private static Manager INSTANCE = null;
        private Manager() { }

        public static Manager Instance
        {
            get
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new Manager();
                }
                return INSTANCE;
            }
        }

        public KiddosPocketEntity getKiddosPocketEntityFromKiddosTrollerUrlStr(String urlStr)
        {
            String strUrl = Utils.Instance.getTextFromUrl(urlStr + Constants.POCKET_PATH);
            return Utils.Instance.parseKiddosPocketStrXml(strUrl);
        }
    }
}
