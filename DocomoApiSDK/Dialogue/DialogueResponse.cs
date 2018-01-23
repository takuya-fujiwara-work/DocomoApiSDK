using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace DocomoApiSDK.Dialogue
{
    [DataContract]
    public class DialogueResponse
    {
        [IgnoreDataMember]
        public HttpStatusCode StatusCode { get; set; }

        [DataMember(Name = "utt")]
        public string Utt { get; set; }

        [DataMember(Name = "yomi")]
        public string Yomi { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        [DataMember(Name = "da")]
        public string Da { get; set; }

        [DataMember(Name = "context")]
        public string Context { get; set; }
    }
}
