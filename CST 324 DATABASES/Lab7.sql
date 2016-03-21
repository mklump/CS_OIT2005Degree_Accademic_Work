DECLARE
	vFlag CHAR(1) := 'N';
	vCname CHAR(25);
	vNextDetail NUMBER(2);
	vStockqty NUMBER(4);
	vCustid NUMBER(4) := '&Custid';
	vOrderid NUMBER(4) := '&Orderid';
	vPartid NUMBER(4) := '&Partid';
	vQty NUMBER(3) := '&Qty';
	BadCustomer EXCEPTION;
	BadOrder EXCEPTION;
	BadPartid EXCEPTION;
	PRAGMA EXCEPTION_INIT( BadPartid, -02291 );
	OutOfStock EXCEPTION;
	vErrorMessage VARCHAR( 512 );

BEGIN
	BEGIN
		SELECT	Cname
		INTO	vCname
		FROM	CUSTOMERS
		WHERE	Custid = vCustid;
	EXCEPTION
		WHEN NO_DATA_FOUND THEN
			RAISE BadCustomer;
	END;

	BEGIN
		SELECT	'Y'
		INTO	vFlag
		FROM	ORDERS
		WHERE	Custid = vCustid AND
			Orderid = vOrderid;
	EXCEPTION
		WHEN NO_DATA_FOUND THEN
			RAISE BadOrder;
	END;

	BEGIN
		SELECT	MAX( Detail ) + 1
		INTO	vNextDetail
		FROM	ORDERITEMS
		WHERE	Orderid = vOrderid;
		
		INSERT INTO ORDERITEMS
		VALUES (	vOrderid, vNextDetail,
			vPartid, vQty );

			DBMS_OUTPUT.PUT_LINE ( ' ' );
			DBMS_OUTPUT.PUT_LINE ( 'Inserting ' || vQty || ' of item: ' || vPartid );
			DBMS_OUTPUT.PUT_LINE ( 'into order number: ' || vOrderid );
			DBMS_OUTPUT.PUT_LINE ( 'for customer: ' || vCname || ' ID #: ' || vCustid );
			DBMS_OUTPUT.PUT_LINE ( ' ' );

		UPDATE	INVENTORY
		SET	Stockqty = Stockqty - vQty
		WHERE	Partid = vPartid;

		SELECT	Stockqty
		INTO	vStockqty
		FROM	INVENTORY
		WHERE	Partid = vPartid;

		IF	vStockqty < 0 THEN
			RAISE OutOfStock;
		END IF;

		COMMIT;
	END;

EXCEPTION
	WHEN BadPartid THEN
		ROLLBACK;
		DBMS_OUTPUT.PUT_LINE (
		'*****************************************************' );
		DBMS_OUTPUT.PUT_LINE (
		vPartid ||
		' is not a valid part ID.' );
	WHEN OutOfStock THEN
		ROLLBACK;
		DBMS_OUTPUT.PUT_LINE (
		'*****************************************************' );
		DBMS_OUTPUT.PUT_LINE (
		vPartid ||
		' does not have ' ||
		vQty || ' available.' );
	WHEN BadCustomer THEN
		DBMS_OUTPUT.PUT_LINE (
		'*****************************************************' );
		DBMS_OUTPUT.PUT_LINE (
		vCustid ||
		' is not a valid customer ID.' );
	WHEN BadOrder THEN
		DBMS_OUTPUT.PUT_LINE (
		'*****************************************************' );
		DBMS_OUTPUT.PUT_LINE (
		vOrderid ||
		' is not a valid order ID for ' ||
		vCname );
	WHEN OTHERS THEN
		ROLLBACK;
		vErrorMessage := SQLERRM;
		DBMS_OUTPUT.PUT_LINE (
		'*****************************************************' );
		DBMS_OUTPUT.PUT_LINE ('This program encountered the following error: ');
		DBMS_OUTPUT.PUT_LINE ( vErrorMessage );
END;
/