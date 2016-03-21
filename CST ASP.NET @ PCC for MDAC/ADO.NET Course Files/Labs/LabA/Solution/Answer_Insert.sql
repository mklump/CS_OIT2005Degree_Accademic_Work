/* 
 * Insert supplier information into the customers table
 */

USE northwind
INSERT customers
  SELECT substring (companyname, 1, 5)
         , suppliers.companyname
         , suppliers.contactname
         , suppliers.contacttitle
         , suppliers.address
         , suppliers.city
         , suppliers.region
         , suppliers.postalcode
         , suppliers.country
         , suppliers.phone
         , suppliers.fax
    FROM suppliers

SELECT * FROM customers

GO
