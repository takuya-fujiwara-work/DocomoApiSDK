using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DocomoApiSDK.KnowledgeQA
{
    [DataContract]
    public class KnowledgeQAAnswer
    {
        [DataMember(Name = "rank")]
        public int Rank { get; set; }

        [DataMember(Name = "answerText")]
        public string AnswerText { get; set; }

        [DataMember(Name = "linkText")]
        public string LinkText { get; set; }

        [DataMember(Name = "linkUrl")]
        public string LinkUrl { get; set; }
    }
}
