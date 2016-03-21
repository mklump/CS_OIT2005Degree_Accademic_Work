/* 
 * Create a trigger on the customers table, to display a 
 * message each time a customer row is inserted or updated
 */

CREATE TRIGGER notify_customer_change
ON customers
FOR INSERT, UPDATE
AS
  print('customer inserted or updated')
GO
