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
namespace ConsoleClientAssignment4.net.cauldwell {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MainSoap", Namespace="http://www.northwind.com/Catalog")]
    public class Main : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Main() {
            this.Url = "http://www.cauldwell.net/patrick/work/Northwind/main.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/Catalog/GetCategories", RequestNamespace="http://www.northwind.com/Catalog", ResponseNamespace="http://www.northwind.com/Catalog", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetCategories() {
            object[] results = this.Invoke("GetCategories", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCategories(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCategories", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGetCategories(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/Catalog/GetProductsForCategory", RequestNamespace="http://www.northwind.com/Catalog", ResponseNamespace="http://www.northwind.com/Catalog", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Product[] GetProductsForCategory(string category) {
            object[] results = this.Invoke("GetProductsForCategory", new object[] {
                        category});
            return ((Product[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetProductsForCategory(string category, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetProductsForCategory", new object[] {
                        category}, callback, asyncState);
        }
        
        /// <remarks/>
        public Product[] EndGetProductsForCategory(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Product[])(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.northwind.com/Catalog")]
    public class Product {
        
        /// <remarks/>
        public int id;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public System.Decimal price;
    }
}
