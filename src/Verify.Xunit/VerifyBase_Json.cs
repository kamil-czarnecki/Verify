﻿using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace VerifyXunit
{
    public partial class VerifyBase :
        XunitContextBase
    {
        public Task Verify(object target)
        {
            Guard.AgainstNull(target, nameof(target));
            return Verify(target, serialization.currentSettings);
        }

        public Task Verify(object target, JsonSerializerSettings jsonSerializerSettings)
        {
            Guard.AgainstNull(target, nameof(target));
            Guard.AgainstNull(jsonSerializerSettings, nameof(jsonSerializerSettings));
            var formatJson = JsonFormatter.AsJson(target, jsonSerializerSettings);
            return Verify(formatJson);
        }

        public JsonSerializerSettings BuildJsonSerializerSettings()
        {
            return serialization.BuildSettings();
        }
    }
}