package org.jdamico.noexpect.entities;

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


import java.io.Serializable;
import java.util.List;

public class LogDataEntity implements Serializable {

	private static final long serialVersionUID = 7806857335799433816L;
	
	private String logName = null;
	private String logPrefix = null;
	private int logLines = 0;
	private long logSize = 0L;
	private List<String> lineLst = null; 
	
	
	
	public List<String> getLineLst() {
		return lineLst;
	}
	public void setLineLst(List<String> lineLst) {
		this.lineLst = lineLst;
	}
	public String getLogName() {
		return logName;
	}
	public void setLogName(String logName) {
		this.logName = logName;
	}
	public String getLogPrefix() {
		return logPrefix;
	}
	public void setLogPrefix(String logPrefix) {
		this.logPrefix = logPrefix;
	}
	public int getLogLines() {
		return logLines;
	}
	public void setLogLines(int logLines) {
		this.logLines = logLines;
	}
	public long getLogSize() {
		return logSize;
	}
	public void setLogSize(long logSize) {
		this.logSize = logSize;
	}
	
	

}
