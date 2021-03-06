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
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Logger;

import org.jdamico.noexpect.entities.LogDataEntity;



public class LoggerManager{

	private static final Logger logger = Logger.getLogger("LoggerManager");

	private static LoggerManager INSTANCE;
	public static LoggerManager getInstance() {
		if (INSTANCE == null) {
			INSTANCE = new LoggerManager();
		}
		return INSTANCE;
	}
	private LoggerManager(){}

	public void logAtDebugTime(String className, String logLine){
		log(className, logLine, false);
	}

	public void logAtExceptionTime(String className, String logLine) {
		log(className, logLine, true);
	}

	/** 
	 * Check if log direction is SystemOut or a separate file
	 * Check if a log file exist
	 * If there is no file create, on the contrary, use the file
	 * @throws IOException 
	 *
	 */
	private void log(String className, String logLine, boolean logLevel) {
		String formatedLog = " ("+className+") "+logLine;


		String fileName = Constants.LOG_NAME;

		fileName = Constants.LOG_FOLDER + fileName;

		

		String stime = Utils.getInstance().getCurrentDateTimeFormated(Constants.LOG_DATE_FORMAT);
		if(logLevel){
			formatedLog = stime+Constants.SEVERE_LOGLEVEL+formatedLog+"\n";
			//logger.log(Level.SEVERE, formatedLog);
		}else{
			formatedLog = stime+Constants.NORMAL_LOGLEVEL+formatedLog+"\n";
			
		}

		int limit = Constants.FIXED_LOGLIMIT;

		
		
		File listenerLog = null;
		FileWriter fw = null;
		BufferedWriter bwr = null;
		try{

			listenerLog = new File(fileName);
			if(!listenerLog.exists()){
				listenerLog.createNewFile();
			} else if(listenerLog.length() > limit){
				/* 
				 * check if file is too big
				 */
				 listenerLog.delete();
				listenerLog.createNewFile();

			}

			fw = new FileWriter(fileName, true);
			bwr = new BufferedWriter(fw);
			bwr.write(formatedLog);
			bwr.close();
			fw.close();
		}catch(IOException ioe){
			System.err.println("write log error @ "+fileName);
		}finally{
			try {
				if(bwr!=null) bwr.close();
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			try {
				if(fw!=null) fw.close();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			listenerLog = null;
			fw = null;
			bwr = null;
		}




	}

	public List<LogDataEntity> getLogsData() throws TopLevelException{
		/* 
		 * Scan logs folder
		 */
		List<LogDataEntity> logsArray = new ArrayList<LogDataEntity>();
		LogDataEntity logData = null;

		File foldersLog = new File(Constants.LOG_FOLDER);

		String[] logsList = foldersLog.list();

		if (logsList == null) {
			String msg = "No log files found! Check system configuration.";
			logAtExceptionTime(this.getClass().getName(), msg);
			throw new TopLevelException(msg);
		} else {
			for (int i=0; i< logsList.length; i++) {
				logData = new LogDataEntity();
				String logName = logsList[i];
				logData.setLogName(logName);
				logData.setLogPrefix(logName.replaceAll("_"+Constants.LOG_NAME, ""));
				logData.setLogSize(getLogSize(logName));
				List<String> lineLst = getLogLines(logName);
				logData.setLineLst(lineLst);
				logData.setLogLines(lineLst.size());
				logsArray.add(logData); 
			}
		}
		return logsArray;
	}

	private List<String> getLogLines(String fileName) throws TopLevelException {
		List<String> lineLst = new  ArrayList<String>();
		
		try {
			FileReader fr =  new FileReader(Constants.LOG_FOLDER+fileName);
			BufferedReader fileInput = new BufferedReader(fr);
			String line;
			while ((line = fileInput.readLine()) != null) {
				lineLst.add(line);
			}
			fileInput.close();
			fr.close();
		} catch (IOException e) {
			logAtExceptionTime(this.getClass().getName(), "getLogLines(String fileName) "+e.getMessage());
			throw new TopLevelException(e);
		}
		return lineLst;
	}

	private long getLogSize(String fileName) {
		File listenerLog = new File(Constants.LOG_FOLDER+fileName);
		return listenerLog.length();
	}


}
