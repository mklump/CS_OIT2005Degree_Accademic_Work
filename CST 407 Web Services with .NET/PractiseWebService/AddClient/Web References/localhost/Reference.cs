﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
// 
namespace AddClient.localhost {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    public class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service1() {
            this.Url = "http://localhost/PractiseWebService/Service1.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/")]
        public AddResponse Add([System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/")] Add add) {
            object[] results = this.Invoke("Add", new object[] {
                        add});
            return ((AddResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAdd(Add add, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Add", new object[] {
                        add}, callback, asyncState);
        }
        
        /// <remarks/>
        public AddResponse EndAdd(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((AddResponse)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public class Add {
        
        /// <remarks/>
        public int one;
        
        /// <remarks/>
        public int two;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public class AddResponse {
        
        /// <remarks/>
        public int result;
    }
}
