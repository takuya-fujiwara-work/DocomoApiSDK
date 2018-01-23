using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DocomoApiSDK.KnowledgeQA
{
    [DataContract]
    public class KnowledgeQAMessage
    {
        [DataMember(Name = "textForDisplay")]
        public string TextForDisplay { get; set; }

        [DataMember(Name = "textForSpeech")]
        public string TextForSpeech { get; set; }
    }
}
