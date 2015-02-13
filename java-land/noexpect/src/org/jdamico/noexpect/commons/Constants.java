package org.jdamico.noexpect.commons;


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

public interface Constants {
	
	public static final String APP_VERSION = "0.0.1";
	public static final String APP_NAME = "noexpect";
	public static final String LOG_NAME = APP_NAME.trim()+".log";
	public static final String LOG_FOLDER = "/var/log/"+APP_NAME.toLowerCase()+"/";
	public static final String LOG_DATE_FORMAT = "yyyyMMMdd_HH:mm:ss";
	public static final String SEVERE_LOGLEVEL = " S ";
	public static final String NORMAL_LOGLEVEL = " N ";
	public static final int FIXED_LOGLIMIT = 50000;

}
