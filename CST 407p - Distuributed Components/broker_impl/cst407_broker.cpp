/***** Class :- cst407
*	Winter 2003.
*	Implementation of the cst407 Broker interface.
*	This interface allows for a peaceful negotiation
*	between clients and devices. 
*
*	This is a DCOM compliant interface.
*
*	See http://capital.ous.edu/~rksaripa/cst407dcom.
*	for more information.
*
*/

#include "cst407brokerimpl.h"
#include	<windows.h>
#include	<vector>
using	namespace std;

#include <iostream>


CCST407Broker::CCST407Broker()
{
	cout << 
		"<==CCST407Broker::CCST407Broker" 
		<< endl;

	m_cRef = 1;
}

CCST407Broker::~CCST407Broker()
{
	cout << "CCST407Broker::~CCST407Broker. ref count="
		<< m_cRef << " " << endl;
}

ULONG
CCST407Broker::AddRef()
{
	InterlockedIncrement(&m_cRef);

	return	m_cRef;
}

ULONG
CCST407Broker::Release()
{
	ULONG	temp	=	m_cRef;

	InterlockedDecrement(&m_cRef);

	if ( 0 == m_cRef )
	{
	}

	return	temp;
}

HRESULT
CCST407Broker::QueryInterface(
							  REFIID	riid,
							  void	**ppv
							  )
{
	if ( IID_IUnknown == riid )
	{
		cout << "CCST407Broker::QueryInterface" 
			<< "query for IUnknown interface"
			<< endl;
		
		*ppv = static_cast<IUnknown *>(this);
	}
	else if ( IID_ICST407BrokerIntf == riid )
	{
		cout << "CCST407Broker::QueryInterface" 
			<< "query for Broker interface"
			<< endl;

		*ppv = static_cast<ICST407BrokerIntf *>(this);
	}
	else
	{
		*ppv = NULL;
		return	E_NOINTERFACE;
	}

	AddRef();
	return	S_OK;
}

HRESULT
STDMETHODCALLTYPE
CCST407Broker::RegisterDeviceComponent(
								int	guid_array[]
								)
{
	HRESULT	s_retvalue = S_OK;

	cout << "CCST407Broker::RegisterDeviceComponent"
		<< "guid to be registered = " 
		<< hex << 
		guid_array[0] << 
		guid_array[1] <<
		guid_array[2] << 
		guid_array[3]
		<< dec << endl;

	GUID	*p_new_guid = new GUID;

	if  (p_new_guid )
	{
		memcpy(
					p_new_guid,
					guid_array,
					sizeof(GUID)
					);

		m_device_guid_list.push_back(p_new_guid);
	}
	else
	{
		cout << "CCST407Broker::RegisterDeviceComponent"
			<< "cannot allocate memory for guid" << endl;
	}

	return s_retvalue;
}

HRESULT
STDMETHODCALLTYPE
CCST407Broker::UnregisterDeviceComponent(
									int	guid_array[]
									)
{
	GUID	guid;
	GUID	*temp;

	bool	bGuidFound = false;

	cout << "CCST407Broker::UnregisterDeviceComponent"
		<< "guid to be unregistered = " 
		<< hex << 
		guid_array[0] << 
		guid_array[1] <<
		guid_array[2] << 
		guid_array[3]
		<< dec << endl;

	memcpy(&guid,
		guid_array,
		sizeof(GUID)
		);

	vector<GUID*>::iterator		guid_iter;

	guid_iter = m_device_guid_list.begin();

	while (guid_iter != m_device_guid_list.end() )
	{
		if ( 0 == memcmp(*guid_iter, &guid, sizeof(GUID)) )
		{
			temp	=	*guid_iter;

			m_device_guid_list.erase(guid_iter);

			delete	temp;
			bGuidFound = true;
			break;
		}

		guid_iter++;
	}

	if ( true == bGuidFound )
	{
		return	S_OK;
	}
	else
	{
		return	S_OK;
	}
}

HRESULT
STDMETHODCALLTYPE
CCST407Broker::GetDeviceComponentList(
								int	maxGuids,
								int	*pActualGuids,
								int	guid_array[]
								)
{
	HRESULT	hRet = S_OK;
	int	arIdx = 0;
	GUID	guid;

	*pActualGuids	=	this->m_device_guid_list.size();

	if ( *pActualGuids > maxGuids )
	{
		*pActualGuids = maxGuids;
	}

	for ( arIdx = 0; arIdx < *pActualGuids; arIdx+=4)
	{
		guid	=	*(m_device_guid_list[arIdx]);

		memcpy(
			guid_array + arIdx,
			&guid,
			sizeof(guid)
			);
	}

	return	hRet;
}