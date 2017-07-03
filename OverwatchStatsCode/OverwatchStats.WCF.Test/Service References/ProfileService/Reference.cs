﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OverwatchStats.WCF.Test.ProfileService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProfileService.IProfileService")]
    public interface IProfileService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/GetOrCreateProfile", ReplyAction="http://tempuri.org/IProfileService/GetOrCreateProfileResponse")]
        OverwatchStats.Common.Data.General.Profile GetOrCreateProfile(string userName, int regionId, int platformId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/GetOrCreateProfile", ReplyAction="http://tempuri.org/IProfileService/GetOrCreateProfileResponse")]
        System.Threading.Tasks.Task<OverwatchStats.Common.Data.General.Profile> GetOrCreateProfileAsync(string userName, int regionId, int platformId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/RetrieveProfile", ReplyAction="http://tempuri.org/IProfileService/RetrieveProfileResponse")]
        OverwatchStats.Common.Data.General.Profile RetrieveProfile(string userName, int regionId, int platformId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/RetrieveProfile", ReplyAction="http://tempuri.org/IProfileService/RetrieveProfileResponse")]
        System.Threading.Tasks.Task<OverwatchStats.Common.Data.General.Profile> RetrieveProfileAsync(string userName, int regionId, int platformId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/RetieveAllProfiles", ReplyAction="http://tempuri.org/IProfileService/RetieveAllProfilesResponse")]
        OverwatchStats.Common.Data.General.Profile[] RetieveAllProfiles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProfileService/RetieveAllProfiles", ReplyAction="http://tempuri.org/IProfileService/RetieveAllProfilesResponse")]
        System.Threading.Tasks.Task<OverwatchStats.Common.Data.General.Profile[]> RetieveAllProfilesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProfileServiceChannel : OverwatchStats.WCF.Test.ProfileService.IProfileService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProfileServiceClient : System.ServiceModel.ClientBase<OverwatchStats.WCF.Test.ProfileService.IProfileService>, OverwatchStats.WCF.Test.ProfileService.IProfileService {
        
        public ProfileServiceClient() {
        }
        
        public ProfileServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProfileServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProfileServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProfileServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public OverwatchStats.Common.Data.General.Profile GetOrCreateProfile(string userName, int regionId, int platformId) {
            return base.Channel.GetOrCreateProfile(userName, regionId, platformId);
        }
        
        public System.Threading.Tasks.Task<OverwatchStats.Common.Data.General.Profile> GetOrCreateProfileAsync(string userName, int regionId, int platformId) {
            return base.Channel.GetOrCreateProfileAsync(userName, regionId, platformId);
        }
        
        public OverwatchStats.Common.Data.General.Profile RetrieveProfile(string userName, int regionId, int platformId) {
            return base.Channel.RetrieveProfile(userName, regionId, platformId);
        }
        
        public System.Threading.Tasks.Task<OverwatchStats.Common.Data.General.Profile> RetrieveProfileAsync(string userName, int regionId, int platformId) {
            return base.Channel.RetrieveProfileAsync(userName, regionId, platformId);
        }
        
        public OverwatchStats.Common.Data.General.Profile[] RetieveAllProfiles() {
            return base.Channel.RetieveAllProfiles();
        }
        
        public System.Threading.Tasks.Task<OverwatchStats.Common.Data.General.Profile[]> RetieveAllProfilesAsync() {
            return base.Channel.RetieveAllProfilesAsync();
        }
    }
}
