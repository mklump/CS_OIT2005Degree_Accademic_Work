﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.3705.209
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.0.3705.209.
'
Namespace shippingWebRef
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="Service1Soap", [Namespace]:="http://tempuri.org/")>  _
    Public Class Service1
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://localhost/ShippingVB/Service1.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ComputeShipping", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ComputeShipping(ByVal sngPrice As Single) As Single
            Dim results() As Object = Me.Invoke("ComputeShipping", New Object() {sngPrice})
            Return CType(results(0),Single)
        End Function
        
        '<remarks/>
        Public Function BeginComputeShipping(ByVal sngPrice As Single, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ComputeShipping", New Object() {sngPrice}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndComputeShipping(ByVal asyncResult As System.IAsyncResult) As Single
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Single)
        End Function
    End Class
End Namespace