/* 
 * Insert employee information into the customers table
 */

USE northwind
INSERT customers
  SELECT substring (firstname, 1, 3)
         + substring (lastname, 1, 2)
         , lastname, firstname, title, address, city
         , region, postalcode, country, homephone, NULL
    FROM employees
GO
