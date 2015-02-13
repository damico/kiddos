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


import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;


public class Utils {

	private static Utils INSTANCE = null;

	private Utils(){}

	public static Utils getInstance(){
		if(null == INSTANCE) INSTANCE = new Utils();
		return INSTANCE;
	}
	
	static final byte[] HEX_CHAR_TABLE = {
		(byte)'0', (byte)'1', (byte)'2', (byte)'3',
		(byte)'4', (byte)'5', (byte)'6', (byte)'7',
		(byte)'8', (byte)'9', (byte)'a', (byte)'b',
		(byte)'c', (byte)'d', (byte)'e', (byte)'f'
	};
	
	public String byteArrayToHexString(byte[] raw) throws TopLevelException 
	{
		byte[] hex = new byte[2 * raw.length];
		int index = 0;

		for (byte b : raw) {
			int v = b & 0xFF;
			hex[index++] = HEX_CHAR_TABLE[v >>> 4];
			hex[index++] = HEX_CHAR_TABLE[v & 0xF];
		}
		String ret = null;
		try {
			ret = new String(hex, "ASCII");
		} catch (UnsupportedEncodingException e) {
			throw new TopLevelException(e);
		}
		return ret;
	}
			
	public byte[] genMd5(byte[] source) throws TopLevelException{

		MessageDigest md = null;
		try {
			md = MessageDigest.getInstance("MD5");
		} catch (NoSuchAlgorithmException e) {
			throw new TopLevelException(e);
		}
		return md.digest(source);
	}
	
	public String url2String(String urlStr, String method) throws TopLevelException{

		
		
		URL url = null;
		StringBuffer strFromUrl = new StringBuffer();
		BufferedReader br = null;
		InputStreamReader isr = null;
		HttpURLConnection conn = null;
		int code = -1;
		try {

			url = new URL(urlStr);
			conn = (HttpURLConnection) url.openConnection();
			conn.setRequestMethod(method);
			conn.connect();
			code = conn.getResponseCode();
			isr = new InputStreamReader(conn.getInputStream());
			br = new BufferedReader(isr);

			String inputLine = null;

			while ((inputLine = br.readLine()) != null) {
				strFromUrl.append(inputLine);
			}
			
			
		} catch (FileNotFoundException e) {
			throw new TopLevelException(e);
		} catch (MalformedURLException e) {
			throw new TopLevelException(e);
		} catch (IOException e) {
			throw new TopLevelException(e);
		} finally {
			if(br != null)
				try {
					br.close();
				} catch (IOException e) {
					throw new TopLevelException(e);
				}
			
			if(isr != null)
				try {
					isr.close();
				} catch (IOException e) {
					throw new TopLevelException(e);
				}
		}

		return strFromUrl.toString();
	}
	
	public String url2String(String urlStr) throws TopLevelException{

		URL url = null;
		StringBuffer strFromUrl = new StringBuffer();
		BufferedReader br = null;
		InputStreamReader isr = null;

		try {

			url = new URL(urlStr);
			URLConnection conn = url.openConnection();
			isr = new InputStreamReader(conn.getInputStream());
			br = new BufferedReader(isr);

			String inputLine = null;

			while ((inputLine = br.readLine()) != null) {
				strFromUrl.append(inputLine);
			}

			
		} catch (FileNotFoundException e) {
			throw new TopLevelException(e);
		} catch (MalformedURLException e) {
			throw new TopLevelException(e);
		} catch (IOException e) {
			throw new TopLevelException(e);
		} finally {
			if(br != null)
				try {
					br.close();
				} catch (IOException e) {
					throw new TopLevelException(e);
				}
			
			if(isr != null)
				try {
					isr.close();
				} catch (IOException e) {
					throw new TopLevelException(e);
				}
		}

		return strFromUrl.toString();
	}
	
	public String getCurrentDateTimeFormated(String format){
		Date date = new Date();
		Format formatter = new SimpleDateFormat(format);
		String stime = formatter.format(date);
		return stime;
	}
	
	
}
