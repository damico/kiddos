package org.jdamico.noexpect.tests;

import org.jdamico.noexpect.threads.HttpThread;
import org.junit.Test;

public class DefaultTester {

	@Test
	public void test() {
		
		int nThreads = 8;
		
		for (int i = 0; i < nThreads; i++) {
			System.out.println(i);
			HttpThread t = new HttpThread("http://localhost/?query=test", "GET", i, 10000);
			t.start();
		}
		
	}
	
	

}
