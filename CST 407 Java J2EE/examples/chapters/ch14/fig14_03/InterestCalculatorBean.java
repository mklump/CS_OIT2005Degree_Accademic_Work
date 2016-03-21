package com.deitel.advjhtp1.ejb.session.stateful.ejb;
/**
 * Bean implementation class for Enterprise Bean: InterestCalculator
 */
public class InterestCalculatorBean implements javax.ejb.SessionBean
{
	private javax.ejb.SessionContext mySessionCtx;
	
	//	state variables
 	private double principal;
 	private double interestRate;
 	private int term;
 	
	//	set principal amount
 	public void setPrincipal( double amount )
 	{
 		principal = amount;
 	}
 	
	//	set interest rate
 	public void setInterestRate( double rate )
 	{
 		interestRate = rate;
 	}
 	
	//	set loan length in years
 	public void setTerm( int years )
 	{
 		term = years;
 	}
 	
	//	get loan balance
 	public double getBalance()
 	{
		//	calculate simple interest
 		return principal * Math.pow( 1.0 + interestRate, term );
 	}
 	
	//	get amount of interest earned
 	public double getInterestEarned()
 	{
 		return getBalance() - principal;
 	}
	
	/**
	 * getSessionContext
	 */
	public javax.ejb.SessionContext getSessionContext()
	{
		return mySessionCtx;
	}
	
	/**
	 * setSessionContext
	 */
	public void setSessionContext(javax.ejb.SessionContext ctx)
	{
		mySessionCtx = ctx;
	}
	
	/**
	 * ejbCreate
	 */
	public void ejbCreate() throws javax.ejb.CreateException
	{
	}
	
	/**
	 * ejbActivate
	 */
	public void ejbActivate()
	{
	}
	/**
	 * ejbPassivate
	 */
	public void ejbPassivate()
	{
	}
	
	/**
	 * ejbRemove
	 */
	public void ejbRemove()
	{
	}
}
