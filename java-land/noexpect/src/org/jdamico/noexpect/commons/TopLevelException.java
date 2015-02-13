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


import java.sql.SQLException;

public class TopLevelException extends Exception {
private static final long serialVersionUID = -5433172278956353912L;
	
	private StackTraceElement[] stackTraceElements;
	
	private String message;
	
	public TopLevelException(String message){
		super(message);
		this.message = message;
		LoggerManager.getInstance().logAtExceptionTime(this.getClass().getName(), message);
	}
	
	public TopLevelException(String message, String className){
		super(message);
		this.message = message;
		LoggerManager.getInstance().logAtExceptionTime(className, message);

	}
	
	public TopLevelException(Exception e){
		super(e);
		if(e instanceof SQLException){
			SQLException sqle = (SQLException) e;
			if(sqle.getNextException() !=null) LoggerManager.getInstance().logAtExceptionTime(this.getClass().getName(), sqle.getNextException().getMessage());
		}
		LoggerManager.getInstance().logAtExceptionTime(this.getClass().getName(), e.getMessage());
		//LoggerManager.getInstance().logAtExceptionTime(this.getClass().getName(), getStackTraceElements(e));
	}
	
	
	private String getStackTraceElements(Exception e) {
		this.stackTraceElements = e.getStackTrace();
		StringBuffer sb = new StringBuffer();
		
		if(stackTraceElements == null){
			sb.append(message+" ");
		}else{
			sb.append(message+" ");
			for(int i = 0; i < stackTraceElements.length; i++){
				sb.append(stackTraceElements[i].getFileName()+" ("+stackTraceElements[i].getLineNumber()+")\n");
			}
		}
		
		
		return sb.toString();
	}

	public TopLevelException(){
		super();
	}
	
	public TopLevelException(StackTraceElement[] stackTraceElements) {
		this.stackTraceElements = stackTraceElements;
		LoggerManager.getInstance().logAtExceptionTime(this.getClass().getName(), getStackTraceElements());
	}
	
	public TopLevelException(StackTraceElement[] stackTraceElements, String rootMessage) {
		super(rootMessage);
		message = rootMessage;
		this.stackTraceElements = stackTraceElements;
		LoggerManager.getInstance().logAtExceptionTime(this.getClass().getName(), rootMessage + " " +getStackTraceElements());
	}

	public String getStackTraceElements(){
		StringBuffer sb = new StringBuffer();
		
		if(stackTraceElements == null){
			sb.append(message);
		}else{
			sb.append(message);
			for(int i = 0; i < stackTraceElements.length; i++){
				sb.append(stackTraceElements[i].getFileName()+"("+stackTraceElements[i].getLineNumber()+")\n");
			}
		}
		
		
		return sb.toString();
	}
}
