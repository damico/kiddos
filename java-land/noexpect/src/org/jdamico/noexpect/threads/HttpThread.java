package org.jdamico.noexpect.threads;

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


import org.jdamico.noexpect.commons.TopLevelException;
import org.jdamico.noexpect.commons.Utils;

public class HttpThread extends Thread {
	private String urlStr = null;
	private String method = null;
	private int id = -1;
	private int times = -1;
	
	public HttpThread(String urlStr, String method, int id, int times){
		this.urlStr = urlStr;
		this.method = method;
		this.id = id;
		this.times = times;
	}
	
	public void run(){
		
		for (int i = 0; i < times; i++) {
			try {
				
				String r = Utils.getInstance().url2String(urlStr, method);
				System.out.println(urlStr+" Thread "+id+" started. ["+i+"]: "+r.length());
			} catch (TopLevelException e) {
				System.out.println("opss");
				e.printStackTrace();
			}
		}
		
		
	}
}
