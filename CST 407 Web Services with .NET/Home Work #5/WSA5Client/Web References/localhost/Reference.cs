﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2032.
// 
namespace WSA5NameSpace.localhost {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSA5Soap", Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class WSA5 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        public _Session _SessionValue;
        
        /// <remarks/>
        public WSA5() {
            this.Url = "http://localhost/mywebprojects/WSA5_Service/WSA5_Service.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("_SessionValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/Login", RequestNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", ResponseNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Login(int employee_ID, int customer_ID, string Name, int admin) {
            object[] results = this.Invoke("Login", new object[] {
                        employee_ID,
                        customer_ID,
                        Name,
                        admin});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLogin(int employee_ID, int customer_ID, string Name, int admin, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Login", new object[] {
                        employee_ID,
                        customer_ID,
                        Name,
                        admin}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndLogin(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("_SessionValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/GetAllGategories", RequestNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", ResponseNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Category[] GetAllGategories(Order custOrder) {
            object[] results = this.Invoke("GetAllGategories", new object[] {
                        custOrder});
            return ((Category[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAllGategories(Order custOrder, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAllGategories", new object[] {
                        custOrder}, callback, asyncState);
        }
        
        /// <remarks/>
        public Category[] EndGetAllGategories(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Category[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("_SessionValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/GetAllProductsByC" +
"ategory", RequestNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", ResponseNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Product[] GetAllProductsByCategory(Order orderSource, Category itemQuery) {
            object[] results = this.Invoke("GetAllProductsByCategory", new object[] {
                        orderSource,
                        itemQuery});
            return ((Product[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAllProductsByCategory(Order orderSource, Category itemQuery, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAllProductsByCategory", new object[] {
                        orderSource,
                        itemQuery}, callback, asyncState);
        }
        
        /// <remarks/>
        public Product[] EndGetAllProductsByCategory(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Product[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("_SessionValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/GetAllCustomers", RequestNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", ResponseNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Customer[] GetAllCustomers() {
            object[] results = this.Invoke("GetAllCustomers", new object[0]);
            return ((Customer[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAllCustomers(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAllCustomers", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public Customer[] EndGetAllCustomers(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Customer[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("_SessionValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/GetAllEmployees", RequestNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", ResponseNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Employee[] GetAllEmployees() {
            object[] results = this.Invoke("GetAllEmployees", new object[0]);
            return ((Employee[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAllEmployees(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAllEmployees", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public Employee[] EndGetAllEmployees(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Employee[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("_SessionValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/GetAllOrders", RequestNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", ResponseNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderDetail[] GetAllOrders() {
            object[] results = this.Invoke("GetAllOrders", new object[0]);
            return ((OrderDetail[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAllOrders(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAllOrders", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public OrderDetail[] EndGetAllOrders(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((OrderDetail[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("_SessionValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/PlaceOrder", RequestNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", ResponseNamespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool PlaceOrder(Customer orderingCustomer, Order neworders, System.Double ammountEnclosed) {
            object[] results = this.Invoke("PlaceOrder", new object[] {
                        orderingCustomer,
                        neworders,
                        ammountEnclosed});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPlaceOrder(Customer orderingCustomer, Order neworders, System.Double ammountEnclosed, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("PlaceOrder", new object[] {
                        orderingCustomer,
                        neworders,
                        ammountEnclosed}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndPlaceOrder(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/Session")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/Session", IsNullable=false)]
    public class _Session : System.Web.Services.Protocols.SoapHeader {
        
        /// <remarks/>
        public string id;
        
        /// <remarks/>
        public Initiate initiate;
        
        /// <remarks/>
        public Terminate terminate;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/Session")]
    public class Initiate {
        
        /// <remarks/>
        public System.DateTime expires;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class Customer {
        
        /// <remarks/>
        public int CustomerID;
        
        /// <remarks/>
        public System.Double AmountPaid;
        
        /// <remarks/>
        public string CompanyName;
        
        /// <remarks/>
        public Order custOrder;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class Order {
        
        /// <remarks/>
        public OrderDetail[] orders;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class OrderDetail {
        
        /// <remarks/>
        public int OrderID;
        
        /// <remarks/>
        public System.Double UnitPrice;
        
        /// <remarks/>
        public int Quantity;
        
        /// <remarks/>
        public System.Double Discount;
        
        /// <remarks/>
        public Product product;
        
        /// <remarks/>
        public Employee processingEmployee;
        
        /// <remarks/>
        public Customer orderingCustomer;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class Product {
        
        /// <remarks/>
        public int ProductID;
        
        /// <remarks/>
        public string ProductName;
        
        /// <remarks/>
        public bool Discontinued;
        
        /// <remarks/>
        public Category category;
        
        /// <remarks/>
        public Supply supply;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class Category {
        
        /// <remarks/>
        public int CategoryID;
        
        /// <remarks/>
        public string CategoryName;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class Supply {
        
        /// <remarks/>
        public Product[] product;
        
        /// <remarks/>
        public Supplier[] supplier;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class Supplier {
        
        /// <remarks/>
        public int SupplierID;
        
        /// <remarks/>
        public string CompanyName;
        
        /// <remarks/>
        public Supply supply;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
    public class Employee {
        
        /// <remarks/>
        public int EmployeeID;
        
        /// <remarks/>
        public string FirstName;
        
        /// <remarks/>
        public string LastName;
        
        /// <remarks/>
        public bool IsManager;
        
        /// <remarks/>
        public Order orderHandle;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/Session")]
    public class Terminate {
        
        /// <remarks/>
        public bool Terminated;
    }
}
