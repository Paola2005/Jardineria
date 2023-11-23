Consultas de Cliente

Devuelve un listado con el código de cliente de aquellos clientes que realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar aquellos códigos de cliente que aparezcan repetidos. Resuelva la consulta
http://localhost:5162/api/Client/GetUniqueClientCodesWithPaymentsIn2008



Devuelve un listado que muestre solamente los clientes que no han
realizado ningún pago.

http://localhost:5162/api/Client/GetClientsWithoutPayments

Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre
de sus representantes junto con la ciudad de la oficina a la que pertenece el
representante.

http://localhost:5162/api/Client/GetClientsWithoutPaymentsAndRepresentativesWithCity

Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus
representantes junto con la ciudad de la oficina a la que pertenece el
representante.

http://localhost:5162/api/Client/GetClientsWithPaymentsAndRepresentativesWithCity

Devuelve el nombre de los clientes y el nombre de sus representantes junto
con la ciudad de la oficina a la que pertenece el representante.

http://localhost:5162/api/Client/GetClientsWithRepresentativesAndOfficeCity

Consultas de empleado

Devuelve un listado que muestre el nombre de cada empleados, el nombre
de su jefe y el nombre del jefe de sus jefe.
http://localhost:5162/api/Employee/GetEmployeeHierarchy


Consultas de pedido
¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.

http://localhost:5162/api/Order/PedidosEstado


Consultas de pago
 Devuelve un listado con todos los pagos que se realizaron en el año 2008 mediante Paypal. Ordene el resultado de mayor a menor
http://localhost:5162/api/Paymen/GetPaymentsIn2008ByPaypal

  Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetida
http://localhost:5162/api/Paymen/GetDistinctPaymentMethods

Consultas de Producto
 Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
http://localhost:5162/api/Product/GetProductsNoOrderWithInfo

 Devuelve un listado de las diferentes gamas de producto que ha comprado
        cada cliente.

http://localhost:5162/api/Product/GetProductRangesPerClient