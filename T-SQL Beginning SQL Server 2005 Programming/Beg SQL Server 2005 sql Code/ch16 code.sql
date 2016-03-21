<?xml version='1.0' encoding='UTF-8'?>

<SomeElement MyFirstAttribute=“Hi There” MySecondAttribute=“25”>
     Optionally, some other XML
</SomeElement>

<?xml version="1.0" encoding="UTF-8"?>

<ThisCouldBeCalledAnything>
  <AnElement>
    <AnotherElement AnAttribute="Some Value">
      <AselfClosingElement AnAttributeThatNeedsASpecialCharacter="Fred&quot;s flicks"/>
    </AnotherElement>
  </AnElement>
</ThisCouldBeCalledAnything>


<root>
</root>

<?xml version="1.0" encoding="UTF-8"?>
<root>
</root>

<?xml version="1.0" encoding="UTF-8"?>
<root>
   <Order/>
</root>

<?xml version="1.0" encoding="UTF-8"?>
<root>
  <Order CustomerID="ALFKI" OrderID="10643" OrderDate="1997-08-25T00:00:00" /> 
</root>

<?xml version="1.0" encoding="UTF-8"?>
<root>
  <Order CustomerID="ALFKI" OrderID="10643" OrderDate="1997-08-25T00:00:00" /> 
  <Order CustomerID="ALFKI" OrderID="10692" OrderDate="1997-10-03T00:00:00" /> 
  <Order CustomerID="ALFKI" OrderID="10702" OrderDate="1997-10-13T00:00:00" /> 
  <Order CustomerID="ALFKI" OrderID="10835" OrderDate="1998-01-15T00:00:00" /> 
</root>

<?xml version="1.0" encoding="UTF-8"?>
<root>
  <Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
    <Order OrderID="10643" OrderDate="1997-08-25T00:00:00" /> 
    <Order OrderID="10692" OrderDate="1997-10-03T00:00:00" /> 
    <Order OrderID="10702" OrderDate="1997-10-13T00:00:00" /> 
    <Order OrderID="10835" OrderDate="1998-01-15T00:00:00" /> 
  </Customer>
</root>

<?xml version="1.0" encoding="UTF-8"?>
<root>
  <Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
    <Order OrderID="10643" OrderDate="1997-08-25T00:00:00" /> 
    <Order OrderID="10692" OrderDate="1997-10-03T00:00:00" /> 
    <Order OrderID="10702" OrderDate="1997-10-13T00:00:00" /> 
    <Order OrderID="10835" OrderDate="1998-01-15T00:00:00" /> 
  </Customer>
  <Customer CustomerID="ANTON" CompanyName="Antonio Moreno Taquería">
    <Order OrderID="10365" OrderDate="1996-11-27T00:00:00" /> 
    <Order OrderID="10507" OrderDate="1997-04-15T00:00:00" /> 
    <Order OrderID="10535" OrderDate="1997-05-13T00:00:00" /> 
    <Order OrderID="10573" OrderDate="1997-06-19T00:00:00" /> 
  </Customer>
</root>

<?xml version="1.0" encoding="UTF-8"?>
<Schema xmlns="urn:schemas-microsoft-com:xml-data" 
                xmlns:dt="urn:schemas-microsoft-com:datatypes" 
                xmlns:sql="urn:schemas-microsoft-com:xml-sql"
                sql:xsl='../Customers.xsl'>
 <ElementType name="Root" content="empty"  />
 <ElementType name="Customers" sql:relation="Customers">
        <AttributeType name="CustomerID"/>
        <AttributeType name="CompanyName"/>
        <AttributeType name="Address"/>
        <AttributeType name="City"/>
        <AttributeType name="Region"/>
        <AttributeType name="PostalCode"/>
        <attribute type="CustomerID" sql:field="CustomerID"/>
        <attribute type="CompanyName" sql:field="CompanyName"/>
        <attribute type="Address" sql:field="Address"/>
        <attribute type="City" sql:field="City"/>
        <attribute type="Region" sql:field="Region"/>
        <attribute type="PostalCode" sql:field="PostalCode"/>
 </ElementType>
</Schema>


<?xml version="1.0" encoding="UTF-8"?>
<root>
  <Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
   <Note Date="1997-08-25T00:00:00">
   The customer called in today and placed another order. Says they really like our work and would like it if we would consider establishing a location closer to their base of operations.
   </Note>
   <Note Date="1997-08-26T00:00:00">
   Followed up with the customer on new location. Customer agrees to guarantee us $5,000 per month in business to help support a new office.
   </Note>
  </Customer>
</root>

SELECT <column list>
[FROM <source table(s)>]
[WHERE <restrictive condition>]
[GROUP BY <column name or expression using a column in the SELECT list>
[HAVING <restrictive condition based on the GROUP BY results>]
[ORDER BY <column list>]
[FOR XML {RAW|AUTO|EXPLICIT[, XMLDATA][, ELEMENTS][, BINARY base64]|PATH] 
[OPTION (<query hint>, [, …n])]

USE Northwind

SELECT Customers.CustomerID,
  Customers.CompanyName, 
  Orders.OrderID, 
  Orders.OrderDate
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'


ANTON Antonio Moreno Taquería          10365   1996-11-27 00:00:00.000
ANTON Antonio Moreno Taquería          10507   1997-04-15 00:00:00.000
…
…
ALFKI Alfreds Futterkiste              11081   2000-07-22 00:00:00.000
ALFKI Alfreds Futterkiste              11087   2000-08-05 17:37:52.520


USE Northwind

SELECT Customers.CustomerID,
  Customers.CompanyName, 
  Orders.OrderID, 
  Orders.OrderDate
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
FOR XML RAW

<row CustomerID="ANTON" CompanyName="Antonio Moreno Taquería" OrderID="10365" OrderDate="1996-11-27T00:00:00" /> 
<row CustomerID="ANTON" CompanyName="Antonio Moreno Taquería" OrderID="10507" OrderDate="1997-04-15T00:00:00" /> 
<row CustomerID="ANTON" CompanyName="Antonio Moreno Taquería" OrderID="10535" OrderDate="1997-05-13T00:00:00" /> 
<row CustomerID="ANTON" CompanyName="Antonio Moreno Taquería" OrderID="10573" OrderDate="1997-06-19T00:00:00" /> 
<row CustomerID="ALFKI" CompanyName="Alfreds Futterkiste" OrderID="10643" OrderDate="1997-08-25T00:00:00" /> 
<row CustomerID="ANTON" CompanyName="Antonio Moreno Taquería" OrderID="10677" OrderDate="1997-09-22T00:00:00" /> 
<row CustomerID="ANTON" CompanyName="Antonio Moreno Taquería" OrderID="10682" OrderDate="1997-09-25T00:00:00" /> 
<row CustomerID="ALFKI" CompanyName="Alfreds Futterkiste" OrderID="10692" OrderDate="1997-10-03T00:00:00" /> 
<row CustomerID="ALFKI" CompanyName="Alfreds Futterkiste" OrderID="10702" OrderDate="1997-10-13T00:00:00" /> 
<row CustomerID="ALFKI" CompanyName="Alfreds Futterkiste" OrderID="10835" OrderDate="1998-01-15T00:00:00" /> 
<row CustomerID="ANTON" CompanyName="Antonio Moreno Taquería" OrderID="10856" OrderDate="1998-01-28T00:00:00" /> 
<row CustomerID="ALFKI" CompanyName="Alfreds Futterkiste" OrderID="10952" OrderDate="1998-03-16T00:00:00" /> 
<row CustomerID="ALFKI" CompanyName="Alfreds Futterkiste" OrderID="11011" OrderDate="1998-04-09T00:00:00" /> 

USE Northwind

SELECT Customers.CustomerID, 
Customers.CompanyName, 
  Orders.OrderID, 
  Orders.OrderDate
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
FOR XML AUTO

<Customers CustomerID="ANTON" CompanyName="Antonio Moreno Taquería">
  <Orders OrderID="10365" OrderDate="1996-11-27T00:00:00" /> 
  <Orders OrderID="10507" OrderDate="1997-04-15T00:00:00" /> 
  <Orders OrderID="10535" OrderDate="1997-05-13T00:00:00" /> 
  <Orders OrderID="10573" OrderDate="1997-06-19T00:00:00" /> 
</Customers>
<Customers CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
  <Orders OrderID="10643" OrderDate="1997-08-25T00:00:00" /> 
</Customers>
<Customers CustomerID="ANTON" CompanyName="Antonio Moreno Taquería">
  <Orders OrderID="10677" OrderDate="1997-09-22T00:00:00" /> 
  <Orders OrderID="10682" OrderDate="1997-09-25T00:00:00" /> 
</Customers>
<Customers CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
  <Orders OrderID="10692" OrderDate="1997-10-03T00:00:00" /> 
  <Orders OrderID="10702" OrderDate="1997-10-13T00:00:00" /> 
  <Orders OrderID="10835" OrderDate="1998-01-15T00:00:00" /> 
</Customers>
<Customers CustomerID="ANTON" CompanyName="Antonio Moreno Taquería">
  <Orders OrderID="10856" OrderDate="1998-01-28T00:00:00" /> 
</Customers>
<Customers CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
  <Orders OrderID="10952" OrderDate="1998-03-16T00:00:00" /> 
  <Orders OrderID="11011" OrderDate="1998-04-09T00:00:00" /> 
</Customers>


<element name>!<tag>![<attribute name>][!{element|hide|ID|IDREF|IDREFS|xml|xmltext|cdata}]


USE Northwind

SELECT 1                               as Tag, 
   NULL                                as Parent,
   Customers.CustomerID         as [Customer!1!CustomerID],
   Customers.CompanyName               as [Customer!1!CompanyName],
       NULL                            as [Order!2!OrderID],
       NULL                            as [Order!2!OrderDate]
FROM Customers
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'

UNION ALL

SELECT 2, 
      1,
      Customers.CustomerID,
      Customers.CompanyName,
      Orders.OrderID,
      Orders.OrderDate
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
ORDER BY [Customer!1!CustomerID], [Order!2!OrderID]
FOR XML EXPLICIT

USE Northwind

SELECT 1                               as Tag, 
   NULL                                as Parent,
   Customers.CustomerID         as [Customer!1!CustomerID],
   Customers.CompanyName               as [Customer!1!CompanyName],
       NULL                            as [Order!2!OrderID],
       NULL                            as [Order!2!OrderDate],
   NULL                         as [Order!2!CompanyName]
FROM Customers
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'

UNION ALL

SELECT 2, 
      1,
      Customers.CustomerID,
      Customers.CompanyName,
      Orders.OrderID,
      Orders.OrderDate,
  Customers.CompanyName
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
ORDER BY [Customer!1!CustomerID], [Order!2!OrderID]
FOR XML EXPLICIT

<Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
  <Order OrderID="10643" OrderDate="1997-08-25T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="10692" OrderDate="1997-10-03T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="10702" OrderDate="1997-10-13T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="10835" OrderDate="1998-01-15T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="10952" OrderDate="1998-03-16T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="11011" OrderDate="1998-04-09T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="11078" OrderDate="1999-05-01T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="11079" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="11080" OrderDate="2000-07-22T16:48:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="11081" OrderDate="2000-07-22T00:00:00" CompanyName="Alfreds Futterkiste" /> 
  <Order OrderID="11087" OrderDate="2000-08-05T17:37:52.520" CompanyName="Alfreds Futterkiste" /> 
  </Customer>
<Customer CustomerID="ANTON" CompanyName="Antonio Moreno Taquería">
  <Order OrderID="10365" OrderDate="1996-11-27T00:00:00" CompanyName="Antonio Moreno Taquería" /> 
  <Order OrderID="10507" OrderDate="1997-04-15T00:00:00" CompanyName="Antonio Moreno Taquería" /> 
  <Order OrderID="10535" OrderDate="1997-05-13T00:00:00" CompanyName="Antonio Moreno Taquería" /> 
  <Order OrderID="10573" OrderDate="1997-06-19T00:00:00" CompanyName="Antonio Moreno Taquería" /> 
  <Order OrderID="10677" OrderDate="1997-09-22T00:00:00" CompanyName="Antonio Moreno Taquería" /> 
  <Order OrderID="10682" OrderDate="1997-09-25T00:00:00" CompanyName="Antonio Moreno Taquería" /> 
  <Order OrderID="10856" OrderDate="1998-01-28T00:00:00" CompanyName="Antonio Moreno Taquería" /> 
  </Customer>

SELECT 1                               as Tag, 
   NULL                                as Parent,
   Customers.CustomerID         as [Customer!1!CustomerID],
   Customers.CompanyName               as [Customer!1!CompanyName],
       NULL                            as [Order!2!OrderID],
       NULL                            as [Order!2!OrderDate!element]
FROM Customers
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'

UNION ALL

SELECT 2, 
      1,
      Customers.CustomerID,
      Customers.CompanyName,
      Orders.OrderID,
      Orders.OrderDate
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
ORDER BY [Customer!1!CustomerID], [Order!2!OrderID]
FOR XML EXPLICIT

<Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
  <Order OrderID="10643">
    <OrderDate>1997-08-25T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10692">
    <OrderDate>1997-10-03T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10702">
    <OrderDate>1997-10-13T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10835">
    <OrderDate>1998-01-15T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10952">
    <OrderDate>1998-03-16T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="11011">
    <OrderDate>1998-04-09T00:00:00</OrderDate> 
  </Order>
</Customer>
<Customer CustomerID="ANTON" CompanyName="Antonio Moreno Taquería">
  <Order OrderID="10365">
    <OrderDate>1996-11-27T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10507">
      <OrderDate>1997-04-15T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10535">
    <OrderDate>1997-05-13T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10573">
    <OrderDate>1997-06-19T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10677">
    <OrderDate>1997-09-22T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10682">
    <OrderDate>1997-09-25T00:00:00</OrderDate> 
  </Order>
  <Order OrderID="10856">
    <OrderDate>1998-01-28T00:00:00</OrderDate> 
  </Order>
</Customer>

SELECT 1                               as Tag, 
   NULL                                as Parent,
   ProductID                           as [Product!1!ProductID],
      CategoryID               as [Product!1!CategoryID],
   NULL                                       as [Order!2!OrderID],
   NULL                                       as [Order!2!OrderDate]
FROM Products

UNION ALL

SELECT 2, 
   1,
   p.ProductID,
       p.CategoryID,
   od.OrderID,
   o.OrderDate
FROM Products AS p
JOIN  [Order Details] AS od
 ON p.ProductID = od.ProductID
JOIN Orders AS o
 ON od.OrderID = o.OrderID
WHERE o.OrderDate BETWEEN '1998-01-01' AND '1998-01-07'
ORDER BY [Product!1!CategoryID],[Product!1!ProductID], [Order!2!OrderID]
FOR XML EXPLICIT

<Product ProductID="1" CategoryID="1" /> 
<Product ProductID="2" CategoryID="1">
<Order OrderID="10813" OrderDate="1998-01-05T00:00:00" /> 
</Product>
<Product ProductID="24" CategoryID="1" /> 
<Product ProductID="34" CategoryID="1" /> 
<Product ProductID="35" CategoryID="1" /> 
<Product ProductID="38" CategoryID="1">
<Order OrderID="10816" OrderDate="1998-01-06T00:00:00" /> 
<Order OrderID="10817" OrderDate="1998-01-06T00:00:00" /> 
</Product>
<Product ProductID="39" CategoryID="1" /> 
<Product ProductID="43" CategoryID="1">
<Order OrderID="10814" OrderDate="1998-01-05T00:00:00" /> 
<Order OrderID="10819" OrderDate="1998-01-07T00:00:00" /> 
</Product>
<Product ProductID="67" CategoryID="1" /> 
<Product ProductID="70" CategoryID="1">
<Order OrderID="10810" OrderDate="1998-01-01T00:00:00" /> 
</Product>
<Product ProductID="75" CategoryID="1">
<Order OrderID="10819" OrderDate="1998-01-07T00:00:00" /> 
</Product>
<Product ProductID="76" CategoryID="1">
<Order OrderID="10808" OrderDate="1998-01-01T00:00:00" /> 
</Product>
<Product ProductID="3" CategoryID="2" /> 
<Product ProductID="4" CategoryID="2" /> 
…

SELECT 1                               as Tag, 
   NULL                                as Parent,
   ProductID                           as [Product!1!ProductID],
       CategoryID                      as [Product!1!CategoryID!hide],
   NULL                        as [Order!2!OrderID],
   NULL                        as [Order!2!OrderDate]
FROM Products

UNION ALL

SELECT 2, 
   1,
   p.ProductID,
       p.CategoryID,
   od.OrderID,
   o.OrderDate
FROM Products AS p
JOIN  [Order Details] AS od
 ON p.ProductID = od.ProductID
JOIN Orders AS o
 ON od.OrderID = o.OrderID
WHERE o.OrderDate BETWEEN '1998-01-01' AND '1998-01-07'
ORDER BY [Product!1!CategoryID!hide],[Product!1!ProductID], [Order!2!OrderID]
FOR XML EXPLICIT

<Product ProductID="1" /> 
<Product ProductID="2">
<Order OrderID="10813" OrderDate="1998-01-05T00:00:00" /> 
</Product>
<Product ProductID="24" /> 
<Product ProductID="34" /> 
<Product ProductID="35" /> 
<Product ProductID="38">
<Order OrderID="10816" OrderDate="1998-01-06T00:00:00" /> 
<Order OrderID="10817" OrderDate="1998-01-06T00:00:00" /> 
</Product>
<Product ProductID="39" /> 
<Product ProductID="43">
<Order OrderID="10814" OrderDate="1998-01-05T00:00:00" /> 
<Order OrderID="10819" OrderDate="1998-01-07T00:00:00" /> 
</Product>
<Product ProductID="67" /> 
<Product ProductID="70">
<Order OrderID="10810" OrderDate="1998-01-01T00:00:00" /> 
</Product>
<Product ProductID="75">
<Order OrderID="10819" OrderDate="1998-01-07T00:00:00" /> 
</Product>
<Product ProductID="76">
<Order OrderID="10808" OrderDate="1998-01-01T00:00:00" /> 
</Product>
<Product ProductID="3" /> 
<Product ProductID="4" /> 
…

SELECT 1                               as Tag, 
   NULL                                       as Parent,
   ProductID                                  as [Product!1!ProductID!ID],
      CategoryID                              as [Product!1!CategoryID!hide],
   NULL                                as [Order!2!OrderID],
   NULL                                as [Order!2!ProductID!idref],
   NULL                                as [Order!2!OrderDate]
FROM Products

UNION ALL

SELECT 2, 
   1,
   p.ProductID,
       p.CategoryID,
   od.OrderID,
   od.ProductID,
   o.OrderDate
FROM Products AS p
JOIN  [Order Details] AS od
 ON p.ProductID = od.ProductID
JOIN Orders AS o
 ON od.OrderID = o.OrderID
WHERE o.OrderDate BETWEEN '1998-01-01' AND '1998-01-07'
ORDER BY [Product!1!CategoryID!hide],[Product!1!ProductID!ID], [Order!2!OrderID]
FOR XML EXPLICIT, XMLDATA

<Schema name="Schema2" xmlns="urn:schemas-microsoft-com:xml-data" xmlns:dt="urn:schemas-microsoft-com:datatypes">
<ElementType name="Product" content="mixed" model="open">
<AttributeType name="ProductID" dt:type="id" /> 
<attribute type="ProductID" /> 
</ElementType>
<ElementType name="Order" content="mixed" model="open">
<AttributeType name="OrderID" dt:type="i4" /> 
<AttributeType name="ProductID" dt:type="idref" /> 
<AttributeType name="OrderDate" dt:type="dateTime" /> 
<attribute type="OrderID" /> 
<attribute type="ProductID" /> 
<attribute type="OrderDate" /> 
</ElementType>
</Schema>

<Product xmlns="x-schema:#Schema2" ProductID="2">
<Order OrderID="10813" ProductID="2" OrderDate="1998-01-05T00:00:00"/>
</Product>

SELECT 1                              as Tag, 
  NULL                           as Parent,
  ProductID                            as [Product!1!ProductID],
      CategoryID                       as [Product!1!CategoryID!hide],
  NULL                                 as [Product!1!OrderList!idrefs],
  NULL                                 as [Order!2!OrderID!id],
  NULL                                 as [Order!2!OrderDate]
FROM Products

UNION ALL

SELECT 1, 
   NULL,
   p.ProductID,
      p.CategoryID,
   'id' + CAST(od.OrderID AS varchar),
   NULL,
   NULL
FROM Products AS p
JOIN  [Order Details] AS od
 ON p.ProductID = od.ProductID
JOIN Orders AS o
 ON od.OrderID = o.OrderID
WHERE o.OrderDate BETWEEN '1998-01-01' AND '1998-01-07'

UNION ALL

SELECT 2, 
   1,
   p.ProductID,
       p.CategoryID,
   NULL,
   'id' + CAST(od.OrderID AS varchar),
   o.OrderDate
FROM Products AS p
JOIN  [Order Details] AS od
 ON p.ProductID = od.ProductID
JOIN Orders AS o
 ON od.OrderID = o.OrderID
WHERE o.OrderDate BETWEEN '1998-01-01' AND '1998-01-07'
ORDER BY [Product!1!CategoryID!hide],[Order!2!OrderID!id], [Product!1!OrderList!idrefs]
FOR XML EXPLICIT, XMLDATA

<Schema name="Schema9" xmlns="urn:schemas-microsoft-com:xml-data" xmlns:dt="urn:schemas-microsoft-com:datatypes">
<ElementType name="Product" content="mixed" model="open">
<AttributeType name="ProductID" dt:type="i4" /> 
<AttributeType name="OrderList" dt:type="idrefs" /> 
<attribute type="ProductID" /> 
<attribute type="OrderList" /> 
</ElementType>
<ElementType name="Order" content="mixed" model="open">
<AttributeType name="OrderID" dt:type="id" /> 
<AttributeType name="OrderDate" dt:type="dateTime" /> 
<attribute type="OrderID" /> 
<attribute type="OrderDate" /> 
</ElementType>
</Schema>

<Product xmlns="x-schema:#Schema9" ProductID="76" OrderList="id10808 id10810 id10813 id10814 id10816 id10817 id10819 id10819">
  <Order OrderID="id10808" OrderDate="1998-01-01T00:00:00"/>
  <Order OrderID="id10810" OrderDate="1998-01-01T00:00:00"/>
  <Order OrderID="id10813" OrderDate="1998-01-05T00:00:00"/>
  <Order OrderID="id10814" OrderDate="1998-01-05T00:00:00"/>
  <Order OrderID="id10816" OrderDate="1998-01-06T00:00:00"/>
  <Order OrderID="id10817" OrderDate="1998-01-06T00:00:00"/>
  <Order OrderID="id10819" OrderDate="1998-01-07T00:00:00"/>
  <Order OrderID="id10819" OrderDate="1998-01-07T00:00:00"/>
</Product>

SELECT 1                     as Tag, 
       NULL                  as Parent,
       Employees.EmployeeID  as [Employee!1!EmployeeID],
       Employees.Notes         as [Employee!1!!cdata]
FROM Employees
ORDER BY [Employee!1!EmployeeID]
FOR XML EXPLICIT


<Employee EmployeeID="1">
<![CDATA[ 
Education includes a BA in psychology from Colorado State University in 1970.  She also completed "The Art of the Cold Call."  Nancy is a member of Toastmasters International.
]]>
</Employee>
<Employee EmployeeID="2">
<![CDATA[ 
Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  He is fluent in French and Italian and reads German.  He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.
]]>
</Employee>
<Employee EmployeeID="3">
<![CDATA[ 
Janet has a BS degree in chemistry from Boston College (1984).  She has also completed a certificate program in food retailing management.  Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.
]]>
</Employee>


USE Northwind

SELECT Customers.CustomerID,
  COUNT(Orders.OrderID)
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
GROUP BY Customers.CustomerID
FOR XML PATH

<row><CustomerID>ALFKI</CustomerID>7</row>
<row><CustomerID>ANTON</CustomerID>7</row>

<row><CustomerID>ALFKI</CustomerID>7</row>

SELECT Customers.CustomerID AS '@CustomerID',
  COUNT(Orders.OrderID)
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
GROUP BY Customers.CustomerID
FOR XML PATH

<row CustomerID="ALFKI">7</row>
<row CustomerID="ANTON">7</row>

SELECT Customers.CustomerID AS '@CustomerID',
  COUNT(Orders.OrderID) AS '@OrderCount'
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
GROUP BY Customers.CustomerID
FOR XML PATH

<row CustomerID="ALFKI" OrderCount="7"/>
<row CustomerID="ANTON" OrderCount="7"/>

SELECT Customers.CustomerID,
  COUNT(Orders.OrderID) AS '@OrderCount'
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
GROUP BY Customers.CustomerID
FOR XML PATH

Msg 6852, Level 16, State 1, Line 3
Attribute-centric column '@OrderCount' must not come after a non-attribute-centric sibling in XML hierarchy in FOR XML PATH.

SELECT Customers.CustomerID,
  COUNT(Orders.OrderID) AS 'CustomerID/OrderCount'
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
GROUP BY Customers.CustomerID
FOR XML PATH

<row><CustomerID>ALFKI<OrderCount>7</OrderCount></CustomerID>
</row><row><CustomerID>ANTON<OrderCount>7</OrderCount></CustomerID></row>

SELECT Customers.CustomerID,
  COUNT(Orders.OrderID) AS 'CustomerID/@OrderCount'
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
GROUP BY Customers.CustomerID
FOR XML PATH

Msg 6852, Level 16, State 1, Line 1
Attribute-centric column 'CustomerID/@OrderCount' must not come after a non-attribute-centric sibling in XML hierarchy in FOR XML PATH.

SELECT COUNT(Orders.OrderID) AS 'CustomerID/@OrderCount',
  Customers.CustomerID AS 'CustomerID'
FROM Customers
JOIN Orders
  ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID = 'ALFKI' OR Customers.CustomerID = 'ANTON'
GROUP BY Customers.CustomerID
FOR XML PATH

<row><CustomerID OrderCount="7">ALFKI</CustomerID></row>
<row><CustomerID OrderCount="7">ANTON</CustomerID></row>

sp_xml_preparedocument @hdoc = <integer variable> OUTPUT,
[, @xmltext = <character data>]
[, @xpath_namespaces = <url to a namespace>]

OPENXML(<handle>,<XPath to base node>[, <mapping flags>])
[WITH (<Schema Declaration>|<Table Name>)]

WITH (
<Column Name> <data type> [{<Column XPath>|<MetaProperty>}]
[,<Column Name> <data type> [{<Column XPath>|<MetaProperty>}]
 …

sp_xml_removedocument [hdoc = ]<handle of XML doc>

USE Northwind

DECLARE @idoc      int 
DECLARE @xmldoc    nvarchar(4000) 

-- define the XML document 
SET @xmldoc = ' 
<ROOT> 
<Shipper ShipperID="100" CompanyName="Billy Bob&apos;s Pretty Good Shipping"/> 
<Shipper ShipperID="101" CompanyName="Fred&apos;s Freight"/> 
</ROOT> 
' 

--Load and parse the XML document in memory 
EXEC sp_xml_preparedocument @idoc OUTPUT, @xmldoc 

--List out what our shippers table looks like before the insert
SELECT * FROM Shippers

-- ShipperID is an IDENTITY column, so we need to allow direct updates
SET IDENTITY_INSERT Shippers ON

--See our XML data in a tabular format
SELECT * FROM OPENXML (@idoc, '/ROOT/Shipper', 0) WITH ( 
    ShipperID        int, 
 CompanyName            nvarchar(40)) 

--Perform and insert based on that data
INSERT INTO Shippers
(ShipperID, CompanyName)
SELECT * FROM OPENXML (@idoc, '/ROOT/Shipper', 0) WITH ( 
    ShipperID        int, 
 CompanyName            nvarchar(40)) 

--Set things back to normal
SET IDENTITY_INSERT Shippers OFF

--Now look at the Shippers table after our insert
SELECT * FROM Shippers

--Now clear the XML document from memory
EXEC sp_xml_removedocument @idoc


DECLARE @idoc int
DECLARE @doc varchar(4000)
-- XML that came from our FOR XML EXPLICIT
SET @doc ='
<root>
<Product ProductID="1" CategoryID="1" /> 
<Product ProductID="2" CategoryID="1">
 <Order OrderID="10813" OrderDate="1998-01-05T00:00:00" /> 
</Product>
<Product ProductID="24" CategoryID="1" /> 
<Product ProductID="34" CategoryID="1" /> 
<Product ProductID="35" CategoryID="1" /> 
<Product ProductID="38" CategoryID="1">
 <Order OrderID="10816" OrderDate="1998-01-06T00:00:00" /> 
 <Order OrderID="10817" OrderDate="1998-01-06T00:00:00" /> 
</Product>
<Product ProductID="39" CategoryID="1" /> 
<Product ProductID="43" CategoryID="1">
 <Order OrderID="10814" OrderDate="1998-01-05T00:00:00" /> 
 <Order OrderID="10819" OrderDate="1998-01-07T00:00:00" /> 
</Product>
<Product ProductID="67" CategoryID="1" /> 
<Product ProductID="70" CategoryID="1">
 <Order OrderID="10810" OrderDate="1998-01-01T00:00:00" /> 
</Product>
</root>
'
-- Create an internal representation of the XML document.
EXEC sp_xml_preparedocument @idoc OUTPUT, @doc

-- Execute a SELECT statement using OPENXML rowset provider.
SELECT *
FROM OPENXML (@idoc, '/root/Product/Order', 1)
      WITH (ProductID int '../@ProductID', 
            Category int '../@CategoryID', 
            OrderID int '@OrderID',
            OrderDate varchar(19) '@OrderDate',
            Previous varchar(10) '@mp:prev')
EXEC sp_xml_removedocument @idoc

<?xml version="1.0" encoding="UTF-8"?>
<root>
 <Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste">
         <Products ProductID="28" ProductName="Rössle Sauerkraut"/>
         <Products ProductID="39" ProductName="Chartreuse verte"/>
         <Products ProductID="46" ProductName="Spegesild"/>
 </Customer>
 <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils">
         <Products ProductID="28" ProductName="Rössle Sauerkraut"/>
         <Products ProductID="29" ProductName="Thüringer Rostbratwurst"/>
         <Products ProductID="31" ProductName="Gorgonzola Telino"/>
         <Products ProductID="38" ProductName="Côte de Blaye"/>
         <Products ProductID="39" ProductName="Chartreuse verte"/>
         <Products ProductID="41" ProductName="Jack&apos;s New England Clam Chowder"/>
         <Products ProductID="46" ProductName="Spegesild"/>
         <Products ProductID="49" ProductName="Maxilaku"/>
 </Customer>
</root>

<?xml version="1.0" encoding="UTF-8"?>
<root>
 <Products ProductID="28" ProductName="Rössle Sauerkraut">
         <Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste"/>
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
 <Products ProductID="29" ProductName="Thüringer Rostbratwurst">
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
 <Products ProductID="31" ProductName="Gorgonzola Telino">
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
 <Products ProductID="38" ProductName="Côte de Blaye">
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
 <Products ProductID="39" ProductName="Chartreuse verte">
         <Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste"/>
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
 <Products ProductID="41" ProductName="Jack&apos;s New England Clam Chowder">
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
 <Products ProductID="46" ProductName="Spegesild">
         <Customer CustomerID="ALFKI" CompanyName="Alfreds Futterkiste"/>
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
 <Products ProductID="49" ProductName="Maxilaku">
         <Customer CustomerID="BLONP" CompanyName="Blondesddsl père et fils"/>
 </Products>
</root>


