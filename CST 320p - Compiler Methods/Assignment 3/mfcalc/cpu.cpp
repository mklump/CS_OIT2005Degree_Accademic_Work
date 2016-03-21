#include "mfcalc.h"
#include "reg.h"

CPU320Reg	*g_reglist[max_reg];

extern "C"
void
init_cpu()
{
	int	i;

	for ( i = 0; i < max_reg; i++ )
	{
		g_reglist[i] = new CPU320Reg(i);
	}
}

extern "C"
int
getFreeReg()
{
	int	i;

	for ( i = 0; i < max_reg; i++ )
	{
		if ( g_reglist[i]->inUse() == false )
		{
			g_reglist[i]->markInUse();
			return	g_reglist[i]->getRegNum();
		}
	}

	return	max_reg;
}

extern "C"
void
markRegFree(int regNum)
{
	g_reglist[regNum]->markFree();
}

extern "C"
void
markRegBusy(int regNum)
{
	g_reglist[regNum]->markInUse();
}