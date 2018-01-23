using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DocomoApiSDK.Dialogue
{
    [DataContract]
    public class DialogueRequest
    {
        [DataMember(Name = "utt")]
        public string Utt { get; set; }

        [DataMember(Name = "context")]
        public string Context { get; set; }

        [DataMember(Name = "nickname", EmitDefaultValue = false, IsRequired = false)]
        public string NickName { get; set; }

        [DataMember(Name = "nickname_y", EmitDefaultValue = false, IsRequired = false)]
        public string NickNameYomi { get; set; }

        [DataMember(Name = "sex", EmitDefaultValue = false, IsRequired = false)]
        public string Sex { get; set; }

        [DataMember(Name = "bloodtype", EmitDefaultValue = false, IsRequired = false)]
        public string BloodType { get; set; }

        [DataMember(Name = "birthdateY", EmitDefaultValue = false, IsRequired = false)]
        public string BirthDateYear { get; set; }

        [DataMember(Name = "birthdateM", EmitDefaultValue = false, IsRequired = false)]
        public string BirthDateMonth { get; set; }

        [DataMember(Name = "birthdateD", EmitDefaultValue = false, IsRequired = false)]
        public string BirthDateDay { get; set; }

        [DataMember(Name = "age", EmitDefaultValue = false, IsRequired = false)]
        public string Age { get; set; }

        [DataMember(Name = "constellations", EmitDefaultValue = false, IsRequired = false)]
        public string Constellations { get; set; }

        [DataMember(Name = "place", EmitDefaultValue = false, IsRequired = false)]
        public string Place { get; set; }

        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        [DataMember(Name = "t", EmitDefaultValue = false, IsRequired = false)]
        public string T { get; set; }
    }
}
