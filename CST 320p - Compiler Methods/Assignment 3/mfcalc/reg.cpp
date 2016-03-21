#include "reg.h"

CPU320Reg::CPU320Reg(
					 int	regNum
					 )
{
	m_reg_num	=	regNum;
	m_inuse = false;
}

CPU320Reg::~CPU320Reg()
{
}