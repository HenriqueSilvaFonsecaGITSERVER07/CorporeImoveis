﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Corpore_Imoveis.DataServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.totvs.com/", ConfigurationName="DataServer.IRMSServer")]
    public interface IRMSServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/Implements", ReplyAction="http://www.totvs.com/IRMSServer/ImplementsResponse")]
        bool Implements(System.Type type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/Implements", ReplyAction="http://www.totvs.com/IRMSServer/ImplementsResponse")]
        System.Threading.Tasks.Task<bool> ImplementsAsync(System.Type type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/CheckServiceActivity", ReplyAction="http://www.totvs.com/IRMSServer/CheckServiceActivityResponse")]
        bool CheckServiceActivity();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/CheckServiceActivity", ReplyAction="http://www.totvs.com/IRMSServer/CheckServiceActivityResponse")]
        System.Threading.Tasks.Task<bool> CheckServiceActivityAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRMSServerChannel : Corpore_Imoveis.DataServer.IRMSServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RMSServerClient : System.ServiceModel.ClientBase<Corpore_Imoveis.DataServer.IRMSServer>, Corpore_Imoveis.DataServer.IRMSServer {
        
        public RMSServerClient() {
        }
        
        public RMSServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RMSServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RMSServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RMSServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Implements(System.Type type) {
            return base.Channel.Implements(type);
        }
        
        public System.Threading.Tasks.Task<bool> ImplementsAsync(System.Type type) {
            return base.Channel.ImplementsAsync(type);
        }
        
        public bool CheckServiceActivity() {
            return base.Channel.CheckServiceActivity();
        }
        
        public System.Threading.Tasks.Task<bool> CheckServiceActivityAsync() {
            return base.Channel.CheckServiceActivityAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.totvs.com/", ConfigurationName="DataServer.IwsBase")]
    public interface IwsBase {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/Implements", ReplyAction="http://www.totvs.com/IRMSServer/ImplementsResponse")]
        bool Implements(System.Type type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/Implements", ReplyAction="http://www.totvs.com/IRMSServer/ImplementsResponse")]
        System.Threading.Tasks.Task<bool> ImplementsAsync(System.Type type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/CheckServiceActivity", ReplyAction="http://www.totvs.com/IRMSServer/CheckServiceActivityResponse")]
        bool CheckServiceActivity();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/CheckServiceActivity", ReplyAction="http://www.totvs.com/IRMSServer/CheckServiceActivityResponse")]
        System.Threading.Tasks.Task<bool> CheckServiceActivityAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsBase/AutenticaAcesso", ReplyAction="http://www.totvs.com/IwsBase/AutenticaAcessoResponse")]
        string AutenticaAcesso();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsBase/AutenticaAcesso", ReplyAction="http://www.totvs.com/IwsBase/AutenticaAcessoResponse")]
        System.Threading.Tasks.Task<string> AutenticaAcessoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IwsBaseChannel : Corpore_Imoveis.DataServer.IwsBase, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IwsBaseClient : System.ServiceModel.ClientBase<Corpore_Imoveis.DataServer.IwsBase>, Corpore_Imoveis.DataServer.IwsBase {
        
        public IwsBaseClient() {
        }
        
        public IwsBaseClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IwsBaseClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsBaseClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsBaseClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Implements(System.Type type) {
            return base.Channel.Implements(type);
        }
        
        public System.Threading.Tasks.Task<bool> ImplementsAsync(System.Type type) {
            return base.Channel.ImplementsAsync(type);
        }
        
        public bool CheckServiceActivity() {
            return base.Channel.CheckServiceActivity();
        }
        
        public System.Threading.Tasks.Task<bool> CheckServiceActivityAsync() {
            return base.Channel.CheckServiceActivityAsync();
        }
        
        public string AutenticaAcesso() {
            return base.Channel.AutenticaAcesso();
        }
        
        public System.Threading.Tasks.Task<string> AutenticaAcessoAsync() {
            return base.Channel.AutenticaAcessoAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.totvs.com/", ConfigurationName="DataServer.IwsDataServer")]
    public interface IwsDataServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/Implements", ReplyAction="http://www.totvs.com/IRMSServer/ImplementsResponse")]
        bool Implements(System.Type type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/Implements", ReplyAction="http://www.totvs.com/IRMSServer/ImplementsResponse")]
        System.Threading.Tasks.Task<bool> ImplementsAsync(System.Type type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/CheckServiceActivity", ReplyAction="http://www.totvs.com/IRMSServer/CheckServiceActivityResponse")]
        bool CheckServiceActivity();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IRMSServer/CheckServiceActivity", ReplyAction="http://www.totvs.com/IRMSServer/CheckServiceActivityResponse")]
        System.Threading.Tasks.Task<bool> CheckServiceActivityAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/GetSchema", ReplyAction="http://www.totvs.com/IwsDataServer/GetSchemaResponse")]
        string GetSchema(string DataServerName, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/GetSchema", ReplyAction="http://www.totvs.com/IwsDataServer/GetSchemaResponse")]
        System.Threading.Tasks.Task<string> GetSchemaAsync(string DataServerName, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/IsValidDataServer", ReplyAction="http://www.totvs.com/IwsDataServer/IsValidDataServerResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Reflection.MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Type))]
        object IsValidDataServer(string DataServerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/IsValidDataServer", ReplyAction="http://www.totvs.com/IwsDataServer/IsValidDataServerResponse")]
        System.Threading.Tasks.Task<object> IsValidDataServerAsync(string DataServerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/GetSchemaEmail", ReplyAction="http://www.totvs.com/IwsDataServer/GetSchemaEmailResponse")]
        string GetSchemaEmail(string DataServerName, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/GetSchemaEmail", ReplyAction="http://www.totvs.com/IwsDataServer/GetSchemaEmailResponse")]
        System.Threading.Tasks.Task<string> GetSchemaEmailAsync(string DataServerName, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadView", ReplyAction="http://www.totvs.com/IwsDataServer/ReadViewResponse")]
        string ReadView(string DataServerName, string Filtro, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadView", ReplyAction="http://www.totvs.com/IwsDataServer/ReadViewResponse")]
        System.Threading.Tasks.Task<string> ReadViewAsync(string DataServerName, string Filtro, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadViewEmail", ReplyAction="http://www.totvs.com/IwsDataServer/ReadViewEmailResponse")]
        string ReadViewEmail(string DataServerName, string Filtro, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadViewEmail", ReplyAction="http://www.totvs.com/IwsDataServer/ReadViewEmailResponse")]
        System.Threading.Tasks.Task<string> ReadViewEmailAsync(string DataServerName, string Filtro, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadRecord", ReplyAction="http://www.totvs.com/IwsDataServer/ReadRecordResponse")]
        string ReadRecord(string DataServerName, string PrimaryKey, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadRecord", ReplyAction="http://www.totvs.com/IwsDataServer/ReadRecordResponse")]
        System.Threading.Tasks.Task<string> ReadRecordAsync(string DataServerName, string PrimaryKey, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadRecordEmail", ReplyAction="http://www.totvs.com/IwsDataServer/ReadRecordEmailResponse")]
        string ReadRecordEmail(string DataServerName, string PrimaryKey, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadRecordEmail", ReplyAction="http://www.totvs.com/IwsDataServer/ReadRecordEmailResponse")]
        System.Threading.Tasks.Task<string> ReadRecordEmailAsync(string DataServerName, string PrimaryKey, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/SaveRecord", ReplyAction="http://www.totvs.com/IwsDataServer/SaveRecordResponse")]
        string SaveRecord(string DataServerName, string XML, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/SaveRecord", ReplyAction="http://www.totvs.com/IwsDataServer/SaveRecordResponse")]
        System.Threading.Tasks.Task<string> SaveRecordAsync(string DataServerName, string XML, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/SaveRecordEmail", ReplyAction="http://www.totvs.com/IwsDataServer/SaveRecordEmailResponse")]
        string SaveRecordEmail(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/SaveRecordEmail", ReplyAction="http://www.totvs.com/IwsDataServer/SaveRecordEmailResponse")]
        System.Threading.Tasks.Task<string> SaveRecordEmailAsync(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/DeleteRecord", ReplyAction="http://www.totvs.com/IwsDataServer/DeleteRecordResponse")]
        string DeleteRecord(string DataServerName, string XML, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/DeleteRecord", ReplyAction="http://www.totvs.com/IwsDataServer/DeleteRecordResponse")]
        System.Threading.Tasks.Task<string> DeleteRecordAsync(string DataServerName, string XML, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/DeleteRecordEmail", ReplyAction="http://www.totvs.com/IwsDataServer/DeleteRecordEmailResponse")]
        string DeleteRecordEmail(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/DeleteRecordEmail", ReplyAction="http://www.totvs.com/IwsDataServer/DeleteRecordEmailResponse")]
        System.Threading.Tasks.Task<string> DeleteRecordEmailAsync(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/DeleteRecordByKey", ReplyAction="http://www.totvs.com/IwsDataServer/DeleteRecordByKeyResponse")]
        string DeleteRecordByKey(string DataServerName, string PrimaryKey, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/DeleteRecordByKey", ReplyAction="http://www.totvs.com/IwsDataServer/DeleteRecordByKeyResponse")]
        System.Threading.Tasks.Task<string> DeleteRecordByKeyAsync(string DataServerName, string PrimaryKey, string Contexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadLookupView", ReplyAction="http://www.totvs.com/IwsDataServer/ReadLookupViewResponse")]
        string ReadLookupView(string DataServerName, string Filtro, string Contexto, string OwnerData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadLookupView", ReplyAction="http://www.totvs.com/IwsDataServer/ReadLookupViewResponse")]
        System.Threading.Tasks.Task<string> ReadLookupViewAsync(string DataServerName, string Filtro, string Contexto, string OwnerData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadLookupViewEmail", ReplyAction="http://www.totvs.com/IwsDataServer/ReadLookupViewEmailResponse")]
        string ReadLookupViewEmail(string DataServerName, string Filtro, string Contexto, string OwnerData, string EmailUsuarioContexto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.totvs.com/IwsDataServer/ReadLookupViewEmail", ReplyAction="http://www.totvs.com/IwsDataServer/ReadLookupViewEmailResponse")]
        System.Threading.Tasks.Task<string> ReadLookupViewEmailAsync(string DataServerName, string Filtro, string Contexto, string OwnerData, string EmailUsuarioContexto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IwsDataServerChannel : Corpore_Imoveis.DataServer.IwsDataServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IwsDataServerClient : System.ServiceModel.ClientBase<Corpore_Imoveis.DataServer.IwsDataServer>, Corpore_Imoveis.DataServer.IwsDataServer {
        
        public IwsDataServerClient() {
        }
        
        public IwsDataServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IwsDataServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsDataServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsDataServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Implements(System.Type type) {
            return base.Channel.Implements(type);
        }
        
        public System.Threading.Tasks.Task<bool> ImplementsAsync(System.Type type) {
            return base.Channel.ImplementsAsync(type);
        }
        
        public bool CheckServiceActivity() {
            return base.Channel.CheckServiceActivity();
        }
        
        public System.Threading.Tasks.Task<bool> CheckServiceActivityAsync() {
            return base.Channel.CheckServiceActivityAsync();
        }
        
        public string GetSchema(string DataServerName, string Contexto) {
            return base.Channel.GetSchema(DataServerName, Contexto);
        }
        
        public System.Threading.Tasks.Task<string> GetSchemaAsync(string DataServerName, string Contexto) {
            return base.Channel.GetSchemaAsync(DataServerName, Contexto);
        }
        
        public object IsValidDataServer(string DataServerName) {
            return base.Channel.IsValidDataServer(DataServerName);
        }
        
        public System.Threading.Tasks.Task<object> IsValidDataServerAsync(string DataServerName) {
            return base.Channel.IsValidDataServerAsync(DataServerName);
        }
        
        public string GetSchemaEmail(string DataServerName, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.GetSchemaEmail(DataServerName, Contexto, EmailUsuarioContexto);
        }
        
        public System.Threading.Tasks.Task<string> GetSchemaEmailAsync(string DataServerName, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.GetSchemaEmailAsync(DataServerName, Contexto, EmailUsuarioContexto);
        }
        
        public string ReadView(string DataServerName, string Filtro, string Contexto) {
            return base.Channel.ReadView(DataServerName, Filtro, Contexto);
        }
        
        public System.Threading.Tasks.Task<string> ReadViewAsync(string DataServerName, string Filtro, string Contexto) {
            return base.Channel.ReadViewAsync(DataServerName, Filtro, Contexto);
        }
        
        public string ReadViewEmail(string DataServerName, string Filtro, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.ReadViewEmail(DataServerName, Filtro, Contexto, EmailUsuarioContexto);
        }
        
        public System.Threading.Tasks.Task<string> ReadViewEmailAsync(string DataServerName, string Filtro, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.ReadViewEmailAsync(DataServerName, Filtro, Contexto, EmailUsuarioContexto);
        }
        
        public string ReadRecord(string DataServerName, string PrimaryKey, string Contexto) {
            return base.Channel.ReadRecord(DataServerName, PrimaryKey, Contexto);
        }
        
        public System.Threading.Tasks.Task<string> ReadRecordAsync(string DataServerName, string PrimaryKey, string Contexto) {
            return base.Channel.ReadRecordAsync(DataServerName, PrimaryKey, Contexto);
        }
        
        public string ReadRecordEmail(string DataServerName, string PrimaryKey, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.ReadRecordEmail(DataServerName, PrimaryKey, Contexto, EmailUsuarioContexto);
        }
        
        public System.Threading.Tasks.Task<string> ReadRecordEmailAsync(string DataServerName, string PrimaryKey, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.ReadRecordEmailAsync(DataServerName, PrimaryKey, Contexto, EmailUsuarioContexto);
        }
        
        public string SaveRecord(string DataServerName, string XML, string Contexto) {
            return base.Channel.SaveRecord(DataServerName, XML, Contexto);
        }
        
        public System.Threading.Tasks.Task<string> SaveRecordAsync(string DataServerName, string XML, string Contexto) {
            return base.Channel.SaveRecordAsync(DataServerName, XML, Contexto);
        }
        
        public string SaveRecordEmail(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.SaveRecordEmail(DataServerName, XML, Contexto, EmailUsuarioContexto);
        }
        
        public System.Threading.Tasks.Task<string> SaveRecordEmailAsync(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.SaveRecordEmailAsync(DataServerName, XML, Contexto, EmailUsuarioContexto);
        }
        
        public string DeleteRecord(string DataServerName, string XML, string Contexto) {
            return base.Channel.DeleteRecord(DataServerName, XML, Contexto);
        }
        
        public System.Threading.Tasks.Task<string> DeleteRecordAsync(string DataServerName, string XML, string Contexto) {
            return base.Channel.DeleteRecordAsync(DataServerName, XML, Contexto);
        }
        
        public string DeleteRecordEmail(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.DeleteRecordEmail(DataServerName, XML, Contexto, EmailUsuarioContexto);
        }
        
        public System.Threading.Tasks.Task<string> DeleteRecordEmailAsync(string DataServerName, string XML, string Contexto, string EmailUsuarioContexto) {
            return base.Channel.DeleteRecordEmailAsync(DataServerName, XML, Contexto, EmailUsuarioContexto);
        }
        
        public string DeleteRecordByKey(string DataServerName, string PrimaryKey, string Contexto) {
            return base.Channel.DeleteRecordByKey(DataServerName, PrimaryKey, Contexto);
        }
        
        public System.Threading.Tasks.Task<string> DeleteRecordByKeyAsync(string DataServerName, string PrimaryKey, string Contexto) {
            return base.Channel.DeleteRecordByKeyAsync(DataServerName, PrimaryKey, Contexto);
        }
        
        public string ReadLookupView(string DataServerName, string Filtro, string Contexto, string OwnerData) {
            return base.Channel.ReadLookupView(DataServerName, Filtro, Contexto, OwnerData);
        }
        
        public System.Threading.Tasks.Task<string> ReadLookupViewAsync(string DataServerName, string Filtro, string Contexto, string OwnerData) {
            return base.Channel.ReadLookupViewAsync(DataServerName, Filtro, Contexto, OwnerData);
        }
        
        public string ReadLookupViewEmail(string DataServerName, string Filtro, string Contexto, string OwnerData, string EmailUsuarioContexto) {
            return base.Channel.ReadLookupViewEmail(DataServerName, Filtro, Contexto, OwnerData, EmailUsuarioContexto);
        }
        
        public System.Threading.Tasks.Task<string> ReadLookupViewEmailAsync(string DataServerName, string Filtro, string Contexto, string OwnerData, string EmailUsuarioContexto) {
            return base.Channel.ReadLookupViewEmailAsync(DataServerName, Filtro, Contexto, OwnerData, EmailUsuarioContexto);
        }
    }
}
