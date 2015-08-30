﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.288
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=1.0.3705.288.
// 
using System.Diagnostics;
using System.Xml.Serialization;
using System;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Services;


/// <remarks/>
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="CalendarSoap", Namespace="http://www.thetasoft.com/calendar")]
public class Calendar : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    /// <remarks/>
    public Calendar() {
        this.Url = "http://www.thetasoft.com/calendar/cal.asmx";
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.thetasoft.com/calendar/QueryCalendar", RequestNamespace="http://www.thetasoft.com/calendar", ResponseNamespace="http://www.thetasoft.com/calendar", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public System.Xml.XmlNode QueryCalendar(string sEventID, string sName, string sStart, string sEnd, string sDescription, string sOwner) {
        object[] results = this.Invoke("QueryCalendar", new object[] {
                    sEventID,
                    sName,
                    sStart,
                    sEnd,
                    sDescription,
                    sOwner});
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginQueryCalendar(string sEventID, string sName, string sStart, string sEnd, string sDescription, string sOwner, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("QueryCalendar", new object[] {
                    sEventID,
                    sName,
                    sStart,
                    sEnd,
                    sDescription,
                    sOwner}, callback, asyncState);
    }
    
    /// <remarks/>
    public System.Xml.XmlNode EndQueryCalendar(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.thetasoft.com/calendar/CreateCalenderEvent", RequestNamespace="http://www.thetasoft.com/calendar", ResponseNamespace="http://www.thetasoft.com/calendar", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public System.Xml.XmlNode CreateCalenderEvent(string sName, string sStart, string sEnd, string sDescription, string sOwner, int nPrivateLevel) {
        object[] results = this.Invoke("CreateCalenderEvent", new object[] {
                    sName,
                    sStart,
                    sEnd,
                    sDescription,
                    sOwner,
                    nPrivateLevel});
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginCreateCalenderEvent(string sName, string sStart, string sEnd, string sDescription, string sOwner, int nPrivateLevel, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("CreateCalenderEvent", new object[] {
                    sName,
                    sStart,
                    sEnd,
                    sDescription,
                    sOwner,
                    nPrivateLevel}, callback, asyncState);
    }
    
    /// <remarks/>
    public System.Xml.XmlNode EndCreateCalenderEvent(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.thetasoft.com/calendar/ModifyCalenderEvent", RequestNamespace="http://www.thetasoft.com/calendar", ResponseNamespace="http://www.thetasoft.com/calendar", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public System.Xml.XmlNode ModifyCalenderEvent(string sID, string sName, string sStart, string sEnd, string sDescription, string sOwner, int nPrivateLevel) {
        object[] results = this.Invoke("ModifyCalenderEvent", new object[] {
                    sID,
                    sName,
                    sStart,
                    sEnd,
                    sDescription,
                    sOwner,
                    nPrivateLevel});
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginModifyCalenderEvent(string sID, string sName, string sStart, string sEnd, string sDescription, string sOwner, int nPrivateLevel, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("ModifyCalenderEvent", new object[] {
                    sID,
                    sName,
                    sStart,
                    sEnd,
                    sDescription,
                    sOwner,
                    nPrivateLevel}, callback, asyncState);
    }
    
    /// <remarks/>
    public System.Xml.XmlNode EndModifyCalenderEvent(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.thetasoft.com/calendar/DeleteCalenderEvent", RequestNamespace="http://www.thetasoft.com/calendar", ResponseNamespace="http://www.thetasoft.com/calendar", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public System.Xml.XmlNode DeleteCalenderEvent(string sID) {
        object[] results = this.Invoke("DeleteCalenderEvent", new object[] {
                    sID});
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginDeleteCalenderEvent(string sID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("DeleteCalenderEvent", new object[] {
                    sID}, callback, asyncState);
    }
    
    /// <remarks/>
    public System.Xml.XmlNode EndDeleteCalenderEvent(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((System.Xml.XmlNode)(results[0]));
    }
}
