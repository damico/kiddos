package org.jdamico.noexpect.runtime;

/*
 * This file is part of "NOEXPECT (KIDDOS)", written by Jose Damico - <jd.comment@gmail.com>.
 * 
 *    "NOEXPECT (KIDDOS)" is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License (version 3) 
 *    as published by the Free Software Foundation.
 *
 *    "NOEXPECT (KIDDOS)" is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *    GNU General Public License for more details.
 *
 *    You should have received a copy of the GNU General Public License
 *    along with "NOEXPECT (KIDDOS)".  If not, see <http://www.gnu.org/licenses/>.
 */


import java.util.Date;

import org.jdamico.noexpect.commons.TopLevelException;
import org.jdamico.noexpect.commons.Utils;
import org.jdamico.noexpect.threads.HttpThread;

public class Ignition {

	public static void main(String[] args) {
		int nThreads = 80;
		
		for (int i = 0; i < nThreads; i++) {
			System.out.println(i);
			
			Date d = new Date();
			String baseUrlStr = "http://localhost/?query=";
			Long epoch= d.getTime();
			int parmSize = 5;
			
			String strEpoch = String.valueOf(epoch);
			String strHexMd5 = null;
			try {
				byte[] md5 = Utils.getInstance().genMd5((baseUrlStr+strEpoch).getBytes());
				strHexMd5 = Utils.getInstance().byteArrayToHexString(md5);
			} catch (TopLevelException e) {
				e.printStackTrace();
			}
			
			baseUrlStr = baseUrlStr + strHexMd5.substring(0, parmSize) + " " + strHexMd5.substring(0, parmSize);
			HttpThread t = new HttpThread(baseUrlStr, "GET", i, 10000000);
			t.start();

		}
	}

}
