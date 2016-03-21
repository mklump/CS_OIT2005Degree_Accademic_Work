#ifndef _reg_h
#define _reg_h

class	CPU320Reg
{
private:
	int	m_reg_num;

	bool	m_inuse;

public:

	CPU320Reg(
				int	m_reg_num
				);

	bool	inUse() { return m_inuse; }

	~CPU320Reg();

	void	markInUse() {
		m_inuse	=	true;
	}

	void	markFree() {
		m_inuse = false;
	}

	int	getRegNum() { return	m_reg_num; }
};

#endif