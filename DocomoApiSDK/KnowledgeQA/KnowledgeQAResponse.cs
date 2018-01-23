using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace DocomoApiSDK.KnowledgeQA
{
    [DataContract]
    public class KnowledgeQAResponse
    {
        [IgnoreDataMember]
        public HttpStatusCode StatusCode { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "message")]
        public KnowledgeQAMessage Message { get; set; }

        [DataMember(Name = "answers")]
        public List<KnowledgeQAAnswer> Answers { get; set; }
    }
}
