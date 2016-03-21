/* 
 * Create a trigger on the orders table. 
 * This trigger will be invoked whenever an attempt is made
 * to delete an order. 
 * The trigger deletes all the associated "order details" first,
 * and then deletes the order itself.
 */

CREATE TRIGGER delete_order_details
ON orders
INSTEAD OF DELETE
AS
  DELETE FROM "order details"
    WHERE orderid IN 
      (SELECT orderid FROM deleted)

  DELETE FROM orders
    WHERE orderid IN 
      (SELECT orderid FROM deleted)
GO
